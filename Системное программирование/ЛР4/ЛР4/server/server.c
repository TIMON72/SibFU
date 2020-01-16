/*! \file    server.c
 *  \brief   Файл-сервер
 *  \details Имитация сервера, который принимает сообщения от клиента
 * и обрабатывает данные. Завершает работу при получении сообщения "exit"
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>
/*! \brief Обработка сообщения клиента
 *  \details Считывает сообщение из сокета, обрабатывает данные
 * и выводит на экран.
 *  \param  clientSocket      Сокет
 *  \return 0 - успешное выполнение программы,
 *          EXIT_FAILURE - какая либо ошибка
 */
int server(int clientSocket)
{
    for (int step = 0; step < 2; step++)
    {
        int length = 0;
        char* text = NULL;
        // Считываем длину сообщение: если возвращается 0, то клиент прервал сессию
        if (recv(clientSocket, &length, sizeof(length), 0) == 0)
            return 0;
        // Выделяем память для text и заполняем "0"
        text = (char*)malloc(length);
        bzero(text, length);
        // Считываем текст и выводим его
        recv(clientSocket, text, length, 0);
        // Если клиент отправил сообщение "exit", то завершаем работу сервера
        if (0 == strcmp(text, "exit"))
        {
            // Освобождаем память
            free(text);
            return 0;
        }
        switch (step)
        {
        int *array;
        int numOfElements = 0;
        case 0:
        {
            // Подсчет элементов в пришедшей строке массива чисел
            for (int i = 0; i < length; i++)
            {
                if (text[i] == ' ' || text[i] == '.')
                {
                    numOfElements++;
                }
            }
            // Выделение памяти под массив
            array = (int*)malloc(numOfElements*sizeof(int));
            // Разбиение text на элементы и помещение их в массив
            char* buffer = strtok(text, " ");
            int i = 0;
            printf("message 1:\n");
            while (buffer != NULL)
            {
                array[i] = atoi(buffer);
                printf("a[%d] = %d\n", i, array[i]);
                buffer = strtok(NULL, " .");
                i++;
            }
            free(buffer);
            break;
        }
        case 1:
        {
            int key;
            key = atoi(text);
            printf("message 2:\n");
            printf("key = %d\n", key);
            printf("searching element...\n");
            // Алгоритм бинарного поиска элемента по ключу
            int l = 0;
            int u = numOfElements;
            int m;
            while (l <= u)
            {
                m = (l + u) / 2;
                if (array[m] < key)
                {
                    l = m + 1;
                }
                if (array[m] > key)
                {
                    u = m - 1;
                }
                if (array[m] == key)
                {
                    break;
                }
                m = -1;
            }
            printf("Позиция искомого элемента: %d\n", m);
            numOfElements = 0;
        default:
            break;
        }
        }
        // Освобождаем память
        free(text);
    }
    printf("===============================\n");
    return 0;
}
/*! \brief Главная функция
 *  \param argc  количество аргументов
 *  \param argv  массив системных переменных
 *  \return 0 - успешное выполнение программы,
 *          EXIT_FAILURE - какая либо ошибка
 */
int main(int argc, char *argv[])
{
    printf("start Server...");
    int socketFileDescriptor = -1;
    int portNumber = 3000;
    struct sockaddr_in name;
    int clientSentQuitMessage;
    // Создаем сокет
    socketFileDescriptor = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    int i = 1;
    setsockopt(socketFileDescriptor, SOL_SOCKET, SO_REUSEADDR,
        (const char *)&i, sizeof(i));
    bzero((char *)&name, sizeof(name));
    // Индетификация сервера
    name.sin_family = AF_INET;
    name.sin_port = htons((u_short)portNumber);
    name.sin_addr.s_addr = INADDR_ANY;
    if (-1 == bind(socketFileDescriptor, (const struct sockaddr *)&name, sizeof(name)))
    {
        perror("bind "); // !!! заменить на fprintf(stderr, "bind error\n");
        close(socketFileDescriptor);
        exit(1);
    }
    //"Прослушивание" соединения
    if (-1 == listen(socketFileDescriptor, 5))
    {
        perror("listen "); // !!! заменить на fprintf(stderr, "listen error\n");
        close(socketFileDescriptor);
        exit(1);
    }
    /* Принимать соединения через функцию server(),
    обрабатываязапрос клиента.
    Повторно поулчать сообщения до тех пор, пока Клиент
    не отправит "exit". */
    struct sockaddr_in clientName;
    socklen_t clientNameLength = sizeof(clientName);
    int clientSocketFileDescriptor;
    // Разрешение соединения
    clientSocketFileDescriptor = accept(socketFileDescriptor,
                                        (struct sockaddr *)&clientName,
                                        &clientNameLength);
    printf(" Success!\n");
    // Удержание соединения, пока не получим сообщении о конце сессии
    do
    {
        clientSentQuitMessage = server(clientSocketFileDescriptor);
    } while (!clientSentQuitMessage);
    // Завершение соединения
    close(clientSocketFileDescriptor);
    // Разъединение и закрытие сокета
    shutdown(socketFileDescriptor, SHUT_RD);
    close(socketFileDescriptor);
    return 0;
}
