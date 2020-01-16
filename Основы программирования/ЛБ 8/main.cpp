//Вариант 19
//За основу взять задания и требования к лабораторной работе №6.Изменить программу так, чтобы
//каждая функция располагалась в отдельном модуле(cpp - файле).Требования по использованию
//глобальных переменных сохраняются.
//Кредиты: ФИО заемщика, сумма, процентная ставка в год, срок кредита.Дополнить вывод
//информацией о сумме процентов, которые понадобится выплатить заемщику за срок
//кредита.

#include "Header\Header.h"

/// Ввод пункта меню
int print_menu(int menu)
{
	while (!(cin >> menu))
	{
		cout << "Вы ввели некорректные данные\n";
		cout << "Введите пункт меню: ";
		cin.clear();
		while (cin.get() != '\n');
	}
	cin.clear();
	while (cin.get() != '\n');
	return menu;
}

/// ГЛАВНАЯ ФУНКЦИЯ
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");

	int menu = 0, n;
	bool error = 1;
	string* str = NULL;
	client* clients = NULL;
	CString path;

	do
	{
		/// Ввод пункта меню
		cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<";
		cout << "\n>>>>>>>>>>>>>> МЕНЮ <<<<<<<<<<<<<<\n";
		cout << "1. Выбор и открытие файла\n";
		cout << "2. Добавление и удаление клиента\n";
		cout << "3. Вывод базы данных на экран\n";
		cout << "4. Сортировка\n";
		cout << "5. Перезапись файла\n";
		cout << "6. Выход\n";
		cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
		cout << "Введите пункт меню: ";
		menu = print_menu(menu);

		switch (menu)
		{
		case 1:
		{
			/// Выбор и открытие файла
			str = open_file(str, n, error, path);
			/// Создание базы данных
			structuring(clients, str, n);

			break;
		}
		case 2:
		{
			if (error == true)
			{
				cout << ("Сначала откройте файл (1 пункт меню)\n");
			}
			else
			{
				/// Ввод пункта меню
				cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n";
				cout << "1. Добавление клиента\n";
				cout << "2. Удаление клиента\n";
				cout << "3. Отмена\n";
				cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
				cout << "Выберите пункт меню: ";
				menu = print_menu(menu);
				switch (menu)
				{
				case 1:
				{
					/// Расширение массива и ввод клиента с клавиатуры
					str = widening(clients, str, n);
					break;
				}
				case 2:
				{
					/// Сжатие массива и удаление клиента
					str = constriction(clients, str, n);
					break;
				}
				case 3:
				{
					menu = NULL;
					break;
				}
				default:
				{
					cout << "Вы некорректно выбрали пункт меню!\n";
					break;
				}
				}
			}
			break;
		}
		case 3:
		{
			if (error == true)
			{
				cout << ("Сначала откройте файл (1 пункт меню)\n");
			}
			else
			{
				print(clients, n);
			}
			break;
		}
		case 4:
		{
			if (error == true)
			{
				cout << ("Сначала откройте файл (1 пункт меню)\n");
			}
			else
			{
				/// Ввод пункта меню
				cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n";
				cout << "1. Сортировка по ФИО\n";
				cout << "2. Сортировка по сумме кредита\n";
				cout << "3. Сортировка по процентной ставке в год\n";
				cout << "4. Сортировка по сроку кредита\n";
				cout << "5. Сортировка по сумме долга за срок кредита\n";
				cout << "6. Отмена\n";
				cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
				cout << "Выберите пункт меню: ";
				menu = print_menu(menu);
				switch (menu)
				{
				case 1:
				{
					/// Сортировка по ФИО
					sorting_name(clients, n);
					break;
				}

				case 2:
				{
					/// Сортировка по сумме кредита
					sorting_credit_summ(clients, n);
					break;
				}

				case 3:
				{
					/// Сортировка по процентной ставке в год
					sorting_percent(clients, n);
					break;
				}
				case 4:
				{
					/// Сортировка по сроку кредита
					sorting_time(clients, n);
					break;
				}
				case 5:
				{
					/// Сортировка по сумме долга за срок кредита
					sorting_debt(clients, n);
					break;
				}
				case 6:
				{
					menu = NULL;
					break;
				}

				default:
				{
					cout << "Вы некорректно выбрали пункт меню!\n";
					break;
				}
				}
			}

			break;
		}
		case 5:
		{
			if (error == true)
			{
				cout << ("Сначала откройте файл (1 пункт меню)\n");
			}
			else
			{
				/// Перезапись файла
				rewriting(str, n, path);
			}

			break;
		}
		case 6:
		{
			break;
		}

		default:
		{
			cout << "Вы неверно ввели пункт меню!\n";
			break;
		}

		}
	} while (menu != 6);

	// Очистка массива строк
	if (str != NULL)
		delete[] str;
	// Очистка структурного массива
	if (clients != NULL)
		delete[]clients;

	return 0;
}