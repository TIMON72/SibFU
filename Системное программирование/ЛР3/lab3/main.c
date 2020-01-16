/* Вариант 18.
Структура данных: фамилия; имя; рост. Создать два запроса,
позволяющих найти максимальный рост, начиная с элемента списка с заданным
номером.*/
#include <files.c>

/*! \brief Очистка экрана
 *  \details Функция очистки экрана терминала
 */
void* ClearScreen()
{
    printf("\033[2J");
    printf("\033[0;0f");
}
/// Вывод содержимого файла на экран
/*! \brief Вывод содержимого файла на экран
*  \details Функция отображения массива структур на экран терминала
*  \param  *humans - указатель на массив данных
*  \param  numOfLines - количество строк в файле
*/
void* PrintOnConsole(struct Human *humans, int numOfLines)
{
    printf("number surname  name  height\n");
    for (int i = 0; i < numOfLines; i++)
    {
        printf("#%d     %s  %s  %d\n",
               i, humans[i].surname, humans[i].name, humans[i].height);
    }
}
/*! \brief Добавление элемента структуры
 *  \details Добавление новой структуры в массив структур путем ввода в терминал полей
 *  и запись в файл
 *  \param  *humans - указатель на массив данных
 *  \param  *numOfLines - указатель на количество строк в файле
 */
void* AddOneStructure(struct Human *humans, int *numOfLines)
{
    //char* newStructure;
    //char newStructure[128];
    struct Human *buf_humans;
    //printf("Введите новую единицу структуры (surname,name,height;): ");
    //gets(newStructure);
    //scanf("%s", newStructure);
    //ClearScreen();
    //printf("%s\n", newStructure);
    // Увеличиваем список структур на одну единицу
    buf_humans = (struct Human*)malloc((*numOfLines)*sizeof(struct Human));
    for (int i = 0; i < (*numOfLines); i++)
    {
        buf_humans[i] = humans[i];
    }
    (*numOfLines)++;
    free(humans);
    humans = (struct Human*)malloc((*numOfLines)*sizeof(struct Human));
    for (int i = 0; i < (*numOfLines) - 1; i++)
    {
        humans[i] = buf_humans[i];
    }
    free(buf_humans);
    printf("Введите информацию:\n", humans[*numOfLines - 1].surname);
    printf("фамилия: ");
    scanf("%s", humans[*numOfLines - 1].surname);
    printf("имя: ");
    scanf("%s", humans[*numOfLines - 1].name);
    printf("рост: ");
    scanf("%d", &humans[*numOfLines - 1].height);
    ClearScreen();
    // Конвертируем строку и добавляем к списку структур
    //ConvertToStruct(newStructure, humans, (*numOfLines) - 1);
    // Записываем в файл
    RecordFile(humans, numOfLines);
}
/*! \brief Удаление элемента структуры
 *  \details Удаление элемента структуры из массива структур путем ввода в терминале
 * индекса элемента и запись в файл
 *  \param  *humans - указатель на массив данных
 *  \param  *numOfLines - указатель на количество строк в файле
 */
void* DeleteOneStructure(struct Human *humans, int *numOfLines)
{
    int index;
    struct Human *buf_humans;
    printf("Введите номер строки для удаления: ");
    scanf("%d", &index);
    ClearScreen();
    buf_humans = (struct Human*)malloc((*numOfLines)*sizeof(struct Human));
    for (int i = 0; i < (*numOfLines) - 1; i++)
    {
        if (i < index)
        {
            buf_humans[i] = humans[i];
        }
        else
        {
            buf_humans[i] = humans[i+1];
        }
    }
    (*numOfLines)--;
    free(humans);
    humans = (struct Human*)malloc((*numOfLines)*sizeof(struct Human));
    for (int i = 0; i < (*numOfLines); i++)
    {
        humans[i] = buf_humans[i];
    }
    free(buf_humans);
    // Записываем в файл
    RecordFile(humans, numOfLines);
}
/*! \brief Поиск максимального роста с i-ой позиции
 *  \details Обход массива структур с указанной в терминале позиции и нахождение
 структуры с наибольшим значением поля height
 *  \param  *humans - указатель на массив данных
 *  \param  numOfLines - количество строк в файле
 */
void* FindMaxHeight(struct Human *humans, int numOfLines)
{
    int index;
    int max_index;
    printf("Введите номер строки откуда следует искать: ");
    scanf("%d", &index);
    ClearScreen();
    // Алгоритм поиска максимального роста
    int max = humans[0].height;
    for (int i = index; i < numOfLines; i++)
    {
        if (humans[i].height > max)
        {
            max = humans[i].height;
            max_index = i;
        }
    }
    printf("Самый высокий рост: ");
    printf("#%d     %s  %s  %d\n",
           max_index, humans[max_index].surname, humans[max_index].name,
           humans[max_index].height);
}
/*! \brief Главная функция
 *  \param argc  количество аргументов
 *  \param argv  массив системных переменных
 *  \return 0 - успешное выполнение программы,
 *          EXIT_FAILURE - какая либо ошибка
 */
int main(int argc, char *argv[])
{
    struct Human *humans;
    int numOfLines = 0;
    int menu;
    humans = ReadFile(humans, &numOfLines);
    do
    {
        printf("\n1. Вывести записи на экран\n");
        printf("2. Добавить запись\n");
        printf("3. Удалить запись\n");
        printf("4. Найти запись с максимальным ростом\n");
        printf("5. Выход\n");
        printf("\n>> Введите пункт меню: ");
        scanf("%d", &menu);
        switch (menu)
        {
        case 1:
        {
            ClearScreen();
            PrintOnConsole(humans, numOfLines);
            break;
        }
        case 2:
        {
            ClearScreen();
            PrintOnConsole(humans, numOfLines);
            AddOneStructure(humans, &numOfLines);
            printf("#%d     %s  %s  %d\n",
                   numOfLines-1, humans[numOfLines-1].surname,
                    humans[numOfLines-1].name,
                    humans[numOfLines-1].height);
            break;
        }
        case 3:
        {
            ClearScreen();
            PrintOnConsole(humans, numOfLines);
            DeleteOneStructure(humans, &numOfLines);
            break;
        }
        case 4:
        {
            ClearScreen();
            PrintOnConsole(humans, numOfLines);
            FindMaxHeight(humans, numOfLines);
            break;
        }
        }
    } while (menu != 5);
    free(humans);
    return 0;
}
