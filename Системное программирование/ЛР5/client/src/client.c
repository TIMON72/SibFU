/*! \file    client.c
 *  \brief   Файл-клиент
 *  \details Имитация клиента, который шифрует сообщения, вводимые пользователем
 *  и посылает через сокет на сервер. Завершает работу при вводе в любое время "exit"
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
/*! \brief Запись текста в сокет
  *  \details Запись текста, получаемого от фалового дескриптора.
  *  \param socketFileDescriptor    Дескриптор
  *  \param text                    Сообщение
  */
void WriteText(int socketFileDescriptor, const char* text)
{
    // Записываем байты, включая "\0" (память для text)
    int length = strlen(text) + 1;
    send(socketFileDescriptor, &length, sizeof(length), 0);
    // Записываем сообщение
    send(socketFileDescriptor, text, length, 0);
}
/*! \brief Главная функция
 *  \param argc  количество аргументов
 *  \param argv  массив системных переменных
 *               argv[0] - имя программы
 *               argv[1] - IP-адрес сокета
 *               argv[2] - номер порта сокета
 *  \return 0 - успешное выполнение программы,
 *          EXIT_FAILURE - какая либо ошибка
 */
int main(int argc, const char* argv[])
{
    int socketFileDescriptor;
    int portNumber = 3000;
    struct sockaddr_in name;
    memset((char *)&name, 0, sizeof(name));
    // Назначаем имя сервера сокету
    name.sin_family = AF_INET;
    name.sin_addr.s_addr = inet_addr("127.0.0.1");

    if (INADDR_NONE == name.sin_addr.s_addr)
    {
        perror("inet_addr"); // !!! заменить на fprintf(stderr, "Address error\n");
        exit(1);
    }
    name.sin_port = htons((u_short)portNumber);
    // Создание сокета
    socketFileDescriptor = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (0 > socketFileDescriptor)
        perror("socket"); // !!! заменить на fprintf(stderr, "Socket error\n");
    int i = 1;
    setsockopt(socketFileDescriptor, SOL_SOCKET, SO_REUSEADDR,
               (const char *)&i, sizeof(i)
               );
    // Соединение сокета
    if (0 > connect(socketFileDescriptor,
                    (struct sockaddr *) &name,
                    (socklen_t) sizeof(name))
            )
    {
        perror("connect"); // !!! заменить на fprintf(stderr, "Connect error\n");
        exit(1);
    }
    char message[256];
    message[0] = '\0';
    int flag;
    char exit[256] = "exit";
    printf("Для выхода наберите \"exit\"\n");
    do
    {
        // Отсылаем 1 сообщение на сервер
        do
        {
            flag = 1;
            printf("Введите массив через пробел (по окончании поставьте \".\"): ");
            fgets(message, 256, stdin);
            message[strlen(message) - 1] = 0;
            if (0 == strcmp(message, exit))
            {
                WriteText(socketFileDescriptor, message);
                return 0;
            }
            // Проверка на упорядоченность введенного массива
            char* buf_message;
            strcpy(buf_message, message);
            char* buffer = strtok(buf_message, " ");
            int previous;
            int next;
            while (buffer != NULL)
            {
                previous = atoi(buffer);
                buffer = strtok(NULL, " ");
                if (buffer == NULL)
                    break;
                next = atoi(buffer);
                if (previous > next)
                {
                    printf("Вы ввели неупорядоченный массив\n");
                    flag = 0;
                }
            }
        } while (flag == 0);
        WriteText(socketFileDescriptor, message);
        // Отсылаем 2 сообшение на сервер
        printf("Введите ключ (элемент), который необходимо найти в массиве: ");
        fgets(message, 256, stdin);
        message[strlen(message) - 1] = 0;
        if (0 == strcmp(message, exit))
        {
            WriteText(socketFileDescriptor, message);
            return 0;
        }
        WriteText(socketFileDescriptor, message);
        printf("===============================\n");
    } while (1);
    // Разъединение и закрытие сокета
    shutdown(socketFileDescriptor, SHUT_WR);
    close(socketFileDescriptor);
    return 0;
}
