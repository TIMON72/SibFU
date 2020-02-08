using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using ServiceAuthorization;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using Newtonsoft.Json;

public class CaptchaResponse
{
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("error-codes")]
    public List<string> ErrorCodes { get; set; }
}

public partial class HomePage : System.Web.UI.Page
{
    /// <summary>
    /// Загрузка страницы
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Зашифрование RSA
    /// </summary>
    /// <param name="DataToEncrypt"></param>
    /// <param name="RSAKeyInfo"></param>
    /// <param name="DoOAEPPadding"></param>
    /// <returns></returns>
    static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
    {
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        RSA.ImportParameters(RSAKeyInfo);
        return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
    }
    /// <summary>
    /// Нажатие
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        ServiceAuthorizationClient client = new ServiceAuthorizationClient();
        var response = Request["g-recaptcha-response"];
        string secret = "6LcmoCMUAAAAAK4SMWcFs5OwvXAzZZO3i9yKZA9t";
        var clientCaptcha = new WebClient();
        var reply = clientCaptcha.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
        var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
        if (!captchaResponse.Success)
        {
            var error = captchaResponse.ErrorCodes[0].ToLower();
            switch (error)
            {
                case ("missing-input-secret"):
                    Response.Write("The secret parameter is missing.");
                    break;
                case ("invalid-input-secret"):
                    Response.Write("The secret parameter is invalid or malformed.");
                    break;

                case ("missing-input-response"):
                    Response.Write("The response parameter is missing.");
                    break;
                case ("invalid-input-response"):
                    Response.Write("The response parameter is invalid or malformed.");
                    break;

                default:
                    Response.Write("Error occured. Please try again");
                    break;
            }
            return;
        }
        string login = TextBoxLogin.Text;
        string password = TextBoxPassword.Text;
        // Зашифровывание логина и пароля
        UnicodeEncoding byteConverter = new UnicodeEncoding();
        RSAParameters publicKey = client.MakeCryptoKey();
        byte[] input = byteConverter.GetBytes(login);
        byte[] output = RSAEncrypt(input, publicKey, false);
        login = Convert.ToBase64String(output);
        input = byteConverter.GetBytes(password);
        output = RSAEncrypt(input, publicKey, false);
        password = Convert.ToBase64String(output);
        // Получение токена
        string token = client.Authentication(login, password);
        if (token == "401")
        {
            Response.Write("Вы ввели неверные данные");
        }
        else if (token == "404")
        {
            Response.Write("Ошибка соединения с сервером");
        }
        else
        {
            string casheKey = Guid.NewGuid().ToString();
            string[] userInfo = { login, password, token };
            Cache.Insert(casheKey, userInfo);
            Response.Redirect("Home.aspx?cashe=" + casheKey);
        }
    }
}