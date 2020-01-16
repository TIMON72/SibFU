#include <iostream>
#include <time.h>

using namespace std;

int main()
{
	setlocale(0, "");
	int n = 0, menu, error = 1;
	double middleA = 0, max, imax, sum = 0;
	int *arr = NULL; // int *arr - выделяем ячейки памяти для нашего массива
	char ch;

	do
	{
		cout << "\n>>>>>>>>>><<<<<<<<<<";
		cout << "\n>>>>>>> МЕНЮ <<<<<<<\n";
		cout << "1. Ввод элементов массива\n";
		cout << "2. Обработка массива\n";
		cout << "3. Вывод массива на экран\n";
		cout << "4. Выход\n";
		cout << "Введите пункт меню: ";
		// Модуль, отвечающий за правильность ввода
			// !-- НАЧАЛО --!
		while (!(cin >> menu))
		{
			cout << "Вы ввели некорректные данные\n";
			cout << "Введите пункт меню: ";
			cin.clear();
			while (cin.get() != '\n');
		}
		// !-- КОНЕЦ --!
		cout << ">>>>>>>>>><<<<<<<<<<\n\n";

		switch (menu)
		{
		case 1:

			// Ввод размера массива

			cout << "Введите размер массива: ";
			// Модуль, отвечающий за правильность ввода
			// !-- НАЧАЛО --!
			while (!(cin >> n) || n < 0)
			{
				cout << "Вы ввели некорректные данные\n";
				cout << "Введите размер массива: ";
				cin.clear();
				while (cin.get() != '\n');
			}
			// !-- КОНЕЦ --!
			if (arr != NULL)
				delete[] arr;
			arr = new int[n];

			// Автоматическое заполнение массива

			cout << "Вы хотите воспользоваться автоматическим вводом? (y/n): "; cin >> ch;
			// Модуль, отвечающий за правильность ввода
			// !-- НАЧАЛО --!
			while (ch != 'y' && ch != 'n')
			{
				cout << "Вы ввели некорректные данные\n";
				cout << "Вы хотите воспользоваться автоматическим вводом? (y/n): "; cin >> ch;
				cin.clear();
				while (cin.get() != '\n');
			}
			// !-- КОНЕЦ --!
			if (ch == 'y')
			{
				srand((unsigned int)time(NULL)); // для слуйчаных чисел
				for (int i = 0; i < n; i++)
				{
					arr[i] = (int)-50 + rand() % 100;
				}
			}

			// Ручное заполнение массива

			if (ch == 'n')
			{
				for (int i = 0; i < n; i++)
				{
					printf_s("a[%d] = ", i);
					// Модуль, отвечающий за правильность ввода
					// !-- НАЧАЛО --!
					while (!(cin >> arr[i]))
					{
						cout << "Вы ввели некорректные данные\n";
						printf_s("a[%d] = ", i);
						// cout << "[" << i << "]" << ": ";
						cin.clear();
						while (cin.get() != '\n');
					}
					// !-- КОНЕЦ --!
				}
			}
			error = 0;
			break;

		case 2:

			if (error == 1)
			{
				cout << ("Сначала заполните массив (1 пункт меню)\n");
			}
			else
			{
				// Нахождение среднего арифметического положительных чисел в массиве

				for (int i = 0, S = 0, t = 0; i < n;)
				{
					// cout << "S = " << S << endl;
					if (arr[i] > 0)
					{
						S += arr[i], i++;
						t = t++;
					}
					else i++;
					middleA = (double)S / t;
				}

				// Нахождение суммы элементов массива до максимального значения массива

				max = arr[0];
				for (int i = 0; i < n; i++)
				{
					if (max < arr[i])
					{
						max = arr[i];
						imax = i;
					}
					else if (max == arr[0]) imax = 0;
				}
				for (int i = 0; i < imax; i++)
				{
					sum += arr[i];
				}

				// Вывод ответов

				printf_s("Среднее арифметическое чисел = %.3f\n", middleA);
				//cout << "Среднее арифметическое чисел = " << middleA << endl;
				//printf_s("Максимальный элемент массива = %.0f\n", max);
				//cout << "Максимальный элемент массива = " << max << endl;
				printf_s("Сумма элементов до максимального значения массива = %.0f\n", sum);
				//cout << "Сумма элементов до максимального значения массива = " << sum << endl;
				sum = 0;
				middleA = 0;
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
				printf_s("a[%d] = %d\n", i, arr[i]);
				//cout << "[" << i << "]" << " = " << arr[i] << endl;
			}
			break;

		case 4:
			break;

		default:
			cout << "Вы неверно ввели пункт меню!\n";
			break;
		}

	} while (menu != 4);
	if (arr != NULL)
		delete[] arr;
	system("pause");
	return 0;
}