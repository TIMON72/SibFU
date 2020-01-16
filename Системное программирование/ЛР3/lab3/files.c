/*! \file    file.c
 *  \brief   Файл обработки записи и чтения файлов
 *  \details Файл содержит функции, предназначенные для чтения,
 * записи, а также конвертирования в необходимые форматы для работы
 */
#include <fcntl.h>
#include <stdio.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <unistd.h>
#include <syscall.h>
#include <string.h>
#include <stdlib.h>
/*! \brief Структура Human
 *  \details Структура для хранения данных в необходимом формате
 *  \param  surname - фамилия
 *  \param  name - имя
 *  \param  height - рост
 */
typedef struct Human
{
    char surname[32];
    char name[32];
    int height;
} Human;
/*! \brief Конвертация в структурный тип Human
 *  \details Функция перевода массива типа char в массив данных типа Human.
 *  \param  line - строка данных
 *  \param  *humans - указатель на массив данных
 *  \param  index - порядковый индекс перевода в i-ую структуру
 */
void* ConvertToStruct(char* line, struct Human *humans, int index)
{
    strcpy(humans[index].surname, strtok(line, ","));
    strcpy(humans[index].name, strtok(NULL, ","));
    int height;
    height = atoi(strtok(NULL, ";"));
    humans[index].height = height;
}
/*! \brief Конвертация в строку
 *  \details Функция перевода массива структур в массив символов типа char
 *  \param  *humans - указатель на массив данных
 *  \param  numOfLines - количество строк в файле
 *  \return line - возвращает массив типа char
 */
char* ConvertToLine(struct Human *humans, int numOfLines)
{
    char* line;
    line = (char*)malloc(numOfLines*(sizeof(struct Human)));
    for (int i = 0; i < numOfLines; i++)
    {
        strcat(line, humans[i].surname);
        strcat(line, ",");
        strcat(line, humans[i].name);
        strcat(line, ",");
        char height[16];
        snprintf(height, 16, "%d", humans[i].height);
        strcat(line, height);
        strcat(line, ";\n");
        printf("%s %s %d\n", humans[i].surname, humans[i].name, humans[i].height);
    }
    return line;
}
/*! \brief Конвертация в структурный тип Human
 *  \details Функция перевода массива типа char в массив данных типа Human.
 *  \param  *humans - указатель на массив данных
 *  \param  *numOfLines - указатель на количество строк в файле
 *  \return humans - возвращает массив типа Human
 *          NULL - если возникли проблемы при чтении файла
 */
struct Human* ReadFile(struct Human *humans, int *numOfLines)
{
    int index = 0;
    int end;
    ssize_t read_bytes;
    size_t length;
    struct stat fileInfo;
    char* buffer;
    char* line;
    // Создание файла
    int fileDescriptor = open("out.txt", O_RDWR | O_APPEND | O_CREAT, 0666);
    // Если произошла ошибка при создании
    if (fileDescriptor < 0)
    {
        fprintf(stderr, "Cann't open file\n");
        return;
    }
    // Выясняем размер файла и выделяем память для считывания
    fstat(fileDescriptor, &fileInfo);
    length = fileInfo.st_size;
    buffer = (char*)malloc(length);
    // Считываем содержимое файла
    read_bytes = read(fileDescriptor, buffer, length);
    if (read_bytes < 0)
    {
        fprintf(stderr, "Cannot read file\n");
        return NULL;
    }
    // Подсчитываем количество строк и находим индекс конца файла
    for (int i = 0; i < strlen(buffer); i++)
    {
        if (buffer[i] == '\n')
        {
            (*numOfLines)++;
            end = i;
        }
    }
    // Выделяем память для массива структур
    humans = (struct Human*)malloc((*numOfLines)*sizeof(struct Human));
    // Разбиваем на строки
    line = strtok(buffer, "\n");
    char arr_lines[*numOfLines][128];
    while (line != NULL)
    {
        strcpy(arr_lines[index], line);
        line = strtok(NULL, "\n");
        index++;
    }
    // Выполняем структуризацию строк
    for (int i = 0; i < (*numOfLines); i++)
    {
        printf("%s\n", arr_lines[i]);
        ConvertToStruct(arr_lines[i], humans, i);
    }
    close(fileDescriptor);
    return humans;
}
/*! \brief Запись в файл
 *  \details Функция записи массива структур в файл
 *  \param  *humans - указатель на массив данных
 *  \param  *numOfLines - указатель на количество строк в файле
 */
void* RecordFile(struct Human *humans, int *numOfLines)
{
    char *text;
    // Создание файла
    int fileDescriptor = open("out.txt", O_WRONLY | O_TRUNC | O_APPEND | O_CREAT, 0666);
    // Если произошла ошибка при создании
    if (-1 == fileDescriptor)
    {
        fprintf(stderr, "Cann't open file\n"); // Вывод ошибки на экран
    }
    text = ConvertToLine(humans, *numOfLines);
    printf("text: %s\n", text);
    write(fileDescriptor, text, strlen(text));
    close(fileDescriptor);
    // Освобождение памяти
    free(humans);
}
