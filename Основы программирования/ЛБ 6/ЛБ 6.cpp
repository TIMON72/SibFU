//Вариант 19
//Кредиты: ФИО заемщика, сумма, процентная ставка в год, срок кредита.Дополнить вывод
//информацией о сумме процентов, которые понадобится выплатить заемщику за срок
//кредита.

#include <iostream>
#include <fstream>
#include <string>
#include <iomanip> // Для использования setprecision()
#include <afxdlgs.h> // Библиотека класса CDialog, также заменяет библиотеку windows.h

using namespace std;

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
/// Очистка массива
void clear_str(string* str)
{
	if (str != NULL)
		delete[] str;
}
/// Выбор и открытие файла (меню 1)
string* open_file(string* str, int& n, bool& error, CString& path)
{

	/// Окно выбора файла
	CFileDialog dlg(TRUE); // запрос диалоговой панели для открытия файлов
						   /*
						   int console = dlg.DoModal(); // вызов этой функции выводит на экран
						   блок диалога для открытия или сохранения файла. При успешном завершении
						   функция возвращает IDOK или IDCANCEL в зависимости от того, при помощи
						   какой кнопки пользователь закрыл блок диалога.
						   */
	if (dlg.DoModal() == IDOK)
	{
		path = dlg.GetPathName();
	}
	else
	{
		cout << "\nВы не выбрали файл" << endl;
		error = true;
		return 0;
	}

	/// Открытие файла
	fstream file;
	string str0;
	n = 0;

	file.open(path, ios::in);

	if (file.is_open())
	{
		error = false;
		cout << "\n----------------------------------\n";
		cerr << "Успешное открытие и закрытие файла" << endl;
		cout << "----------------------------------\n";
		cout << "----------------------------------\n";
		cout << "Путь к файлу: ";
		wcout << (LPCTSTR)path << endl;
		cout << "-------- СОДЕРЖИМОЕ ФАЙЛА --------\n";
		// Подсчет кол-ва строк через getline
		while (!file.eof())
		{
			getline(file, str0);
			n++;
		}
		file.seekg(0, file.beg); // Возвращаем курсор в начало файла

		/// Очистка массива
		clear_str(str);

		str = new string[n]; // Создаем динам. массив строк

		// Помещаем каждую строку в элемент массива
		while (!file.eof())
		{
			for (int i = 0; i < n; i++)
			{
				getline(file, str[i]);
				cout << i << ". " << str[i] << endl;
			}
		}
		cout << "----------------------------------\n";

		/// Закрытие файла
		file.close();
	}
	else
	{
		error = true;
		cout << "---------------------\n";
		cerr << "Ошибка открытия файла" << endl;
		cout << "---------------------\n";
	}
	return str;
}
/// Создание базы данных (меню 1)
struct credit
{
	string percent;
	string time;
	string summ;
	double debt;
};
struct client
{
	string name;
	credit credit;
};
void structuring(client*& clients, string* str, int& n)
{
	// Создаем динамический массив для клиентов типа struct
	if (clients != NULL)
		delete[]clients;
	clients = new client[n];

	// Создаем буферную базу данных для структуризации
	string* str_buf = NULL;
	if (str_buf != NULL)
		delete[]str_buf;
	str_buf = new string[n];
	for (int i = 0; i < n; i++)
	{
		str_buf[i] = str[i];
	}

	// Начинаем структуризацию
	for (int i = 0; i < n; i++)
	{
		int pos, br;

		// ФИО
		br = 1;
		while (br != 0)
		{
			// Очистка пробелов
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// Помещаем в name ФИО
			if (str_buf[i].find(' ') < str_buf[i].find('|'))
			{
				pos = str_buf[i].find(' ');
				if (clients[i].name == "")
				{
					clients[i].name = str_buf[i].substr(0, pos);
				}
				else
				{
					clients[i].name = clients[i].name + ' ' + str_buf[i].substr(0, pos);
				}
				str_buf[i].replace(0, pos, "");
			}
			else
			{
				pos = str_buf[i].find('|');
				clients[i].name = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			// Очистка пробелов
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|'); // определяем br == 0? да -> прерываем цикл
		}
		str_buf[i].replace(0, 1, ""); // Уничтожаем "|"

									  // Сумма кредита
		br = 1;
		while (br != 0)
		{
			// Очистка пробелов
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// Помещаем в summ сумму кредита
			if (str_buf[i].find(' ') < str_buf[i].find('|'))
			{
				pos = str_buf[i].find(' ');
				clients[i].credit.summ = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			else
			{
				pos = str_buf[i].find('|');
				clients[i].credit.summ = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			// Очистка пробелов
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|');
		}
		str_buf[i].replace(0, 1, ""); // Уничтожаем "|"

									  // Сумма кредита
		br = 1;
		while (br != 0)
		{
			// Очистка пробелов
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// Помещаем в percent процентную ставку кредита
			if (str_buf[i].find(' ') < str_buf[i].find('|'))
			{
				pos = str_buf[i].find(' ');
				clients[i].credit.percent = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			else
			{
				pos = str_buf[i].find('|');
				clients[i].credit.percent = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			// Очистка пробелов
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|');
		}
		str_buf[i].replace(0, 1, ""); // Уничтожаем "|"

									  // Срок кредита
									  // Очистка пробелов
		pos = str_buf[i].find(' ');
		while (pos == 0)
		{
			str_buf[i].replace(0, pos + 1, "");
			pos = str_buf[i].find(' ');
		}
		// Помещаем в time срок кредита
		if (str_buf[i].find(' ') < str_buf[i].find('|'))
		{
			pos = str_buf[i].find(' ');
			clients[i].credit.time = str_buf[i].substr(0, pos);
			str_buf[i].replace(0, pos, "");
		}
		else
		{
			pos = str_buf[i].find('|');
			clients[i].credit.time = str_buf[i].substr(0, pos);
			str_buf[i].replace(0, pos, "");
		}
		// Очистка пробелов
		pos = str_buf[i].find(' ');
		while (pos == 0)
		{
			str_buf[i].replace(0, pos + 1, "");
			pos = str_buf[i].find(' ');
		}

		// Сумма, которую должен выплатить клиент за срок кредита
		int x = stoi(clients[i].credit.summ);
		int y = stoi(clients[i].credit.percent);
		float z = stof(clients[i].credit.time);
		clients[i].credit.debt = x + ((0.01 * y) * x) * z;
	}

	// Очистка буферного массива
	if (str_buf != NULL)
		delete[]str_buf;
}
/// Расширение массива и ввод клиента с клавиатуры (меню 2.1)
string* widening(client*& clients, string* str, int& n)
{
	// Создаем буферную информационную базу для записи данных каждого клиента
	string* str_buf = NULL;
	if (str_buf != NULL)
		delete[]str_buf;
	int m = n + 1;
	str_buf = new string[m];
	// Перемещаем эл-ты из основного массива в буферный, очищаем основной массив и увеличиваем его размер и пересоздаем массив
	for (int i = 0; i < n; i++)
	{
		str_buf[i] = str[i];
	}
	delete[]str;
	n = n + 1;
	str = new string[n];
	// Перемещаем эл-ты из буферного массива в основной
	for (int i = 0; i < n - 1; i++)
	{
		str[i] = str_buf[i];
	}
	// Очистка буфферного массива
	if (str_buf != NULL)
	{
		delete[]str_buf;
	}

	// Подсчет пробелов до "|" для выравнивания при добавлении клиента в базу данных
	int a[3];
	string str_buff = str[0];
	for (int i = 0; i < 3; i++)
	{
		a[i] = str_buff.find('|');
		str_buff.replace(0, a[i] + 1, "");
	}

	// Ввод нового клиента с клавиатуры
	cout << "\nВведите нового клиента:" << endl;
	string w, x, y, z, w1, x1, y1;
	cout << "Введите ФИО (через пробел): ";
	getline(cin, w);
	for (int i = 0; i < (a[0] - (int)w.length() - 1); i++)
	{
		w1 = w1 + " ";
	}
	cout << "Введите сумму кредита (руб.): ";
	cin >> x;
	for (int i = 0; i < (a[1] - (int)x.length() - 1); i++)
	{
		x1 = x1 + " ";
	}
	cout << "Введите процентную ставку в год (кол-во процентов): ";
	cin >> y;
	for (int i = 0; i < (a[2] - (int)y.length() - 1); i++)
	{
		y1 = y1 + " ";
	}
	cout << "Введите срок кредита (года): ";
	cin >> z;
	// Объединяем все в одну строку
	str[n - 1] = w + w1 + " | " + x + x1 + "| " + y + y1 + "| " + z;
	// Снова создаем структуру (для добавления в нее нового клиента
	structuring(clients, str, n);

	return str;
}
/// Сжатие массива и удаление клиента (меню 2.2)
string* constriction(client*& clients, string* str, int& n)
{
	// Выбор номера удаляемого клиента и смещение эл-тов массива
	int index;
	cout << "\nВведите номер клиента, которого хотите убрать: ";
	cin >> index;
	for (int i = index; i < n - 1; i++)
	{
		str[i] = str[i + 1];
	}
	// Создаем буферную информационную базу для записи данных каждого клиента
	string* str_buf = NULL;
	if (str_buf != NULL)
		delete[]str_buf;
	int m = n - 1;
	str_buf = new string[m];
	// Перемещаем эл-ты из основного массива в буферный, очищаем основной массив и уменьшаем его размер и пересоздаем массив
	for (int i = 0; i < m; i++)
	{
		str_buf[i] = str[i];
	}
	delete[]str;
	n = n - 1;
	str = new string[n];
	// Перемещаем эл-ты из буферного массива в основной
	for (int i = 0; i < n; i++)
	{
		str[i] = str_buf[i];
	}
	// Очистка буфферного массива
	if (str_buf != NULL)
	{
		delete[]str_buf;
	}
	// Снова создаем структуру (для добавления в нее нового клиента
	structuring(clients, str, n);
	return str;
}
/// Вывод базы данных на экран (меню 3)
void print(client*& clients, int& n)
{
	for (int i = 0; i < n; i++)
	{
		// Вывод базы данных на экран
		cout << "\n==================================\n" << endl;
		cout << "Клиент №" << i << endl;
		cout << "ФИО: " << clients[i].name << endl;
		cout << "Сумма кредита " << clients[i].credit.summ << " руб." << endl;
		cout << "Кредитная ставка в год " << clients[i].credit.percent << "%" << endl;
		cout << "Срок кредита " << clients[i].credit.time << " г." << endl;
		cout << "Сумма, которую должен выплатить клиент за данный срок кредита " << fixed << setprecision(0) << clients[i].credit.debt << " руб." << endl;
	}
}
/// Сортировка по ФИО (меню 4.1)
void sorting_name(client*& clients, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (strcmp(clients[i].name.c_str(), clients[j].name.c_str()) > NULL)
			{
				swap(clients[i], clients[j]); // swap меняет местами переменные
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Сортировка по сумме кредита (меню 4.2)
void sorting_credit_summ(client*& clients, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		int x = stoi(clients[i].credit.summ);
		for (int j = i + 1; j < n; j++)
		{
			int y = stoi(clients[j].credit.summ);
			if (x < y)
			{
				swap(clients[i], clients[j]); // swap меняет местами переменные
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Сортировка по процентной ставке в год (меню 4.3)
void sorting_percent(client*& clients, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		int x = stoi(clients[i].credit.percent);
		for (int j = i + 1; j < n; j++)
		{
			int y = stoi(clients[j].credit.percent);
			if (x < y)
			{
				swap(clients[i], clients[j]); // swap меняет местами переменные
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Сортировка по сроку кредита (меню 4.4)
void sorting_time(client*& clients, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		int x = stoi(clients[i].credit.time);
		for (int j = i + 1; j < n; j++)
		{
			int y = stoi(clients[j].credit.time);
			if (x < y)
			{
				swap(clients[i], clients[j]); // swap меняет местами переменные
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Сортировка по сумме долга за срок кредита (меню 4.5)
void sorting_debt(client*& clients, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (clients[i].credit.debt < clients[j].credit.debt)
			{
				swap(clients[i], clients[j]); // swap меняет местами переменные
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Перезапись файла (меню 5)
void rewriting(string* str, int& n, CString& path)
{
	fstream file;
	// Открываем файл в режиме записи
	file.open(path, ios::out);
	// Записываем строки в файл
	for (int i = 0; i < n - 1; i++)
	{
		file << str[i] << endl;
	}
	file << str[n - 1]; // чтоб \n не засунул после добавления последнего клиента

	file.close();

	cout << "Файл успешно перезаписан!" << endl;
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

	/// Очистка массива строк
	clear_str(str);
	// Очистка структурного массива
	if (clients != NULL)
		delete[]clients;

	return 0;
}