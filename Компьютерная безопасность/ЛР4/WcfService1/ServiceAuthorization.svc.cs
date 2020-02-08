using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.ServiceModel.Channels;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceAuthorization" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ServiceAuthorization.svc или ServiceAuthorization.svc.cs в обозревателе решений и начните отладку.
    public class ServiceAuthorization : IServiceAuthorization
    {
        static string myConnectionString = "Database=database1;Data Source=localhost;User Id=root"; // строка соединения сервера с БД
        static MySqlConnection myConnection = new MySqlConnection(myConnectionString); // создание соединения с БД
        static int timeLifeToken = 30;
        static RSAParameters privateKey;
        /// <summary>
        /// Создание открытого и закрытого ключей RSA
        /// </summary>
        /// <returns></returns>
        public RSAParameters MakeCryptoKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            privateKey = RSA.ExportParameters(true);
            return RSA.ExportParameters(false);
        }
        /// <summary>
        /// Расшифрование RSA
        /// </summary>
        /// <param name="DataToDecrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        private byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(RSAKeyInfo);
            return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
        }
        /// <summary>
        /// Генерация токена
        /// </summary>
        /// <returns></returns>
        private string GenerateToken()
        {
            string token = "";
            string letters = "AaBbCcDd0123456789EeFfGgHh0123456789IiJjKkLl0123456789MmNnOoPp0123456789QqRrSsTt0123456789UuVvWwXx0123456789YyZz";
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int result = rnd.Next(letters.Length - 1);
                token += letters[result];
            }
            return token;
        }
        /// <summary>
        /// Проверка срока жизни токена в БД
        /// </summary>
        /// <param name="token"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private bool CheckToken(string token, string login)
        {
            // Формирование запроса к БД
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            // получение ip-адреса клиента и проверка на совпадение с ip-адресом существующей сесссии
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ipAddr = endpoint.Address;
            cmd.CommandText = string.Format("SELECT * FROM sessions WHERE sessions.IPAddress = '{0}' AND sessions.Token = '{1}'", ipAddr, token);
            cmd.Connection = myConnection;
            myConnection.Open();
            reader = cmd.ExecuteReader();
            string resultIPAddr = "";
            while (reader.Read())
            {
                resultIPAddr = reader.GetString(3);
            }
            myConnection.Close();
            // IP-адрес сессии есть?
            if (resultIPAddr == "")
                return false;
            // Проверка времени жизни запрашиваемого токена
            cmd.CommandText = string.Format("DELETE FROM sessions WHERE (sessions.Token = '{0}') AND " +
                "(ADDDATE(sessions.CreateTime, INTERVAL {1} SECOND) < NOW())", token, timeLifeToken);
            cmd.Connection = myConnection;
            myConnection.Open();
            int result = cmd.ExecuteNonQuery();
            myConnection.Close();
            // Проверка на выполнение удаления токена из БД
            if (result > 0)
                return false;
            cmd.CommandText = string.Format("SELECT * FROM sessions WHERE sessions.Token = '{0}'", token);
            cmd.Connection = myConnection;
            myConnection.Open();
            // Отправка запроса к БД и возврат ответа
            reader = cmd.ExecuteReader();
            // Преобразование ответа в строку и обработка результата
            string resultToken = "";
            while (reader.Read())
            {
                resultToken = reader.GetString(1);
            }
            myConnection.Close();
            // Сессия существует?
            if (resultToken == "")
                return false;
            else
                return true;
        }
        private bool CheckToken(string login)
        {
            // Формирование запроса к БД
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format("SELECT * FROM sessions WHERE sessions.Login = '{0}'", login);
            cmd.Connection = myConnection;
            myConnection.Open();
            // Отправка запроса к БД и возврат ответа
            MySqlDataReader reader = cmd.ExecuteReader();
            // Преобразование ответа в строку и обработка результата
            string resultLogin = "";
            while (reader.Read())
            {
                resultLogin = reader.GetString(0);
            }
            myConnection.Close();
            // Если сессия не существует
            if (resultLogin == "")
            {
                return false;
            }
            // Проверка истечения времени сессии
            cmd.CommandText = string.Format("DELETE FROM sessions WHERE (sessions.Login = '{0}') AND " +
                "(ADDDATE(sessions.CreateTime, INTERVAL {1} SECOND) < NOW())", login, timeLifeToken);
            cmd.Connection = myConnection;
            myConnection.Open();
            int result = cmd.ExecuteNonQuery();
            myConnection.Close();
            // Проверка на выполнение каких-либо удалений из БД
            if (result > 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Разрешение на действие для обладателя токена
        /// </summary>
        /// <param name="token"></param>
        /// <param name="rights"></param>
        /// <returns></returns>
        public bool AccessAction(string token, int rights)
        {
            MySqlCommand cmd = new MySqlCommand();
            // Если время жизни токена истекло
            if (!CheckToken(token, ""))
                return false;
            // Запрос к БД sessions с возвратом Login
            cmd.CommandText = string.Format("SELECT * FROM sessions WHERE sessions.Token = '{0}'", token);
            cmd.Connection = myConnection;
            myConnection.Open();
            string resultLogin = "";
            // Отправка запроса к БД и возврат ответа
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultLogin = reader.GetString(0);
            }
            myConnection.Close();
            // Если в БД не нашлось пользователей с таким токеном, то запрет доступа
            if (resultLogin == "")
            {
                return false;
            }
            cmd.CommandText = string.Format("SELECT * FROM users WHERE users.Login = '{0}'", resultLogin);
            cmd.Connection = myConnection;
            myConnection.Open();
            int resultRights = 0;
            // Отправка запроса к БД и возврат ответа
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultRights = Convert.ToInt32(reader.GetString(2));
            }
            myConnection.Close();
            // Если в БД не нашлось пользователей с таким правом, то запрет доступа
            if (resultRights == 0)
            {
                return false;
            }
            // Если права запроса совпадают с правами в БД
            if (resultRights == rights)
                return true;
            return false;
        }
        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Authentication(string login, string password)
        {
            // Попытка установить соединение
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                return "404";
            }
            // Расшифрование логина и пароля
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] input = Convert.FromBase64String(login);
            byte[] output = RSADecrypt(input, privateKey, false);
            login = byteConverter.GetString(output);
            input = Convert.FromBase64String(password);
            output = RSADecrypt(input, privateKey, false);
            password = byteConverter.GetString(output);
            // Формирование запроса к БД
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format("SELECT * FROM users WHERE users.Login = '{0}' AND users.Password = '{1}'", login, password);
            cmd.Connection = myConnection;
            // Отправка запроса к БД и возврат ответа
            MySqlDataReader reader = cmd.ExecuteReader();
            // Преобразование ответа в строку и обработка результата
            string resultLogin = "";
            string resultPassword = "";
            while (reader.Read())
            {
                resultLogin = reader.GetString(0);
                resultPassword = reader.GetString(1);
            }
            myConnection.Close(); // закрытие соединения
            // Если в БД не нашлось пользователей с таким логином и паролем, то прерываем авторизацию
            if (resultLogin == "" || resultPassword == "")
            {
                return "401";
            }
            string token = "";
            // Проверка сессии аутентифицированного пользователя
            if (!CheckToken(login))
            {
                // Генерация токена
                token = GenerateToken();
                // получение ip-адреса клиента
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                string ipAddr = endpoint.Address;
                // Добавление сессии в БД
                cmd.CommandText = string.Format("INSERT INTO sessions (Login, Token, CreateTime, IPAddress) VALUES ('{0}', '{1}', NOW(), '{2}')", login, token, ipAddr);
                myConnection.Open();
                int result = cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            else
            {
                cmd.CommandText = string.Format("SELECT * FROM sessions WHERE sessions.Login = '{0}'", login);
                myConnection.Open();
                // Отправка запроса к БД и возврат ответа
                reader = cmd.ExecuteReader();
                // Преобразование ответа в строку и обработка результата
                string resultToken = "";
                while (reader.Read())
                {
                    resultToken = reader.GetString(1);
                }
                myConnection.Close();
                token = resultToken;
            }
            // Возврат токена
            return token;
        }
    }
}
