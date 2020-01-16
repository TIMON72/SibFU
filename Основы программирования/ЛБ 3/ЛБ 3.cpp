#include <iostream>
#include <time.h>
#include <iomanip>

using namespace std;

int main()
{
	setlocale(0, "");
	int n = 0, m = 0, menu, error = 1, min, max, jmin, jmax;
	int **arr = NULL; // адреса элементов "второго уровня"
	char ch;
	
	do
	{
		cout << "\n>>>>>>>>>><<<<<<<<<<";
		cout << "\n>>>>>>> МЕНЮ <<<<<<<\n";
		cout << "1. Ввод элементов массива\n";
		cout << "2. Обработка массива\n";
		cout << "3. Вывод массива на экран\n";
		cout << "4. Выход\n";
		cout << ">>>>>>>>>><<<<<<<<<<\n\n";
		cout << "Введите пункт меню: ";
		while (!(cin >> menu))
		{
			cout << "Вы ввели некорректные данные\n";
			cout << "Введите пункт меню: ";
			cin.clear();
			while (cin.get() != '\n');
		}
		
		switch (menu)
		{
		case 1:

			// Очистка памяти массива

			if (arr != NULL)
			{
				for (int i = 0; i < n; i++)
				{
					delete[]arr[i];
				}
				delete[]arr;
			}
			
			// Ввод размера массива

			cout << "Введите размер массива (количество строк и столбцов): ";
			while (!(cin >> n >> m) || n < 0 || m < 0)
			{
				cout << "Вы ввели некорректные данные\n";
				cout << "Введите размер массива: ";
				cin.clear();
				while (cin.get() != '\n');
			}
			
			
			// Выделение памяти под массив
			
			arr = new int*[n]; // выделяем строки с адресами элементов
			for (int i = 0; i<n; i++)
			{
				arr[i] = new int[m];
			}

			// Выбор автоматического или ручного ввода
			
			cout << "Вы хотите воспользоваться автоматическим вводом? (y/n): "; cin >> ch;
			while (ch != 'y' && ch != 'n')
			{
				cout << "Вы ввели некорректные данные\n";
				cout << "Вы хотите воспользоваться автоматическим вводом? (y/n): "; cin >> ch;
				cin.clear();
				while (cin.get() != '\n');
			}
			
			// Автоматическое заполнение массива

			if (ch == 'y')
			{
				srand((unsigned int)time(NULL)); // для слуйчаных чисел
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						arr[i][j] = (int)-50 + rand() % 100;
					}
				}
			}

			// Ручное заполнение массива

			if (ch == 'n')
			{
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						printf_s("a[%d, %d] = ", i, j);
						while (!(cin >> arr[i][j]))
						{
							cout << "Вы ввели некорректные данные\n";
							printf_s("a[%d, %d] = ", i, j);
							cin.clear();
							while (cin.get() != '\n');
						}
					}
				}
			}
			error = 0;
			break;

		case 2:

			if (error == 1)
			{
				cout << ("Сначала заполните массив (1 пункт меню)\n");
			}

			// Поиск максимального и минимального элемента строки, перестановка минимального и максимального элемента строки

			for (int i = 0; i < n; i++)
			{
				min = arr[i][0];
				max = arr[i][0];
				jmin = 0;
				jmax = 0;
				for (int j = 0; j < m; j++)
				{
					if (arr[i][j] < min)
					{
						min = arr[i][j];
						jmin = j;
					}
					if (arr[i][j] > max)
					{
						max = arr[i][j];
						jmax = j;
					}
				}

				// Перестановка местами минимального (jmin) и максимального (jmax) элемента строки

				int a = arr[i][jmin];
				int b = arr[i][jmax];
				arr[i][jmin] = b;
				arr[i][jmax] = a;
			}
			break;
			
		case 3:

			if (error == 1)
			{
				cout << ("Сначала заполните массив (1 пункт меню)\n");
			}
			
			// Вывод элементов массива

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					cout << setw(4) << arr[i][j];
				}
				cout << endl;
			}
			break;

		case 4: 
			break;
		
		default:
			cout << "Вы неверно ввели пункт меню!\n";
			break;
		}

	} while (menu != 4);
	
	// Очистка памяти массива

	if (arr != NULL)
	{
		for (int i = 0; i < n; i++) 
		{
			delete[]arr[i];
		}
		delete[]arr;
	}

	// Окно вывода на экран
	
	return 0;
}