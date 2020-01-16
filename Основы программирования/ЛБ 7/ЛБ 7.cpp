/*
Вариант 19
В файле хранятся названия блюд.Каждая строка отдельное название. Написать
программу, которая читает строки из файла в массив строк, и выводит на экран названия блюд,
отсортировав их : а) по убыванию их длины, б) в алфавитном порядке, в) в порядке, обратном
алфавитному.
*/

#include <iostream>
#include <fstream>
#include <string>
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
/// Выбор и открытие файла
string* open_file(string* str, int& n, bool& error)
{

	/// Окно выбора файла
	CString path;

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
		cout << "Вы не выбрали файл" << endl;
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
		cout << "----------------------------------\n";
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
				cout << str[i] << endl;
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
/// Сортировка по убыванию длины слов
void sort_down_length(string* str, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (str[i].length() < str[j].length())
			{
				swap(str[i], str[j]);
			}

		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Сортировка от А до Я
void sort_down(string* str, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			/*
			strcmp сравнивает по одному символу и как только будут найдены
			первые неодинаковые символы, функция проанализирует числовые коды
			этих символов. Чей код окажется больше, та строка и будет считаться
			большей, возвращает -1 (a<b), 0 (a == b), 1 (a>b)
			*/
			if (strcmp(str[i].c_str(), str[j].c_str()) > NULL)
			{
				swap(str[i], str[j]); // swap меняет местами переменные
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Сортировка от Я до А
void sort_up(string* str, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			/*
			strcmp сравнивает по одному символу и как только будут найдены
			первые неодинаковые символы, функция проанализирует числовые коды
			этих символов. Чей код окажется больше, та строка и будет считаться
			большей, возвращает -1 (a<b), 0 (a == b), 1 (a>b)
			*/
			if (strcmp(str[i].c_str(), str[j].c_str()) < NULL)
			{
				swap(str[i], str[j]); // swap меняет местами переменные
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Вывод на экран массива строк
void print(string* str, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << str[i] << endl;
	}
}

/// ГЛАВНАЯ ФУНКЦИЯ
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");

	int menu = 0, n;
	bool error = 1;
	string* str = 0;

	do
	{
		/// Ввод пункта меню
		cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<";
		cout << "\n>>>>>>>>>>>>>> МЕНЮ <<<<<<<<<<<<<<\n";
		cout << "1. Выбор и открытие файла\n";
		cout << "2. Сортировка содержимого файла\n";
		cout << "3. Вывод результата на экран\n";
		cout << "4. Выход\n";
		cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
		cout << "Введите пункт меню: ";
		menu = print_menu(menu);

		switch (menu)
		{

		case 1:
		{
			/// Выбор и открытие файла
			str = open_file(str, n, error);
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
				cout << "1. Сортировка по длине слов\n";
				cout << "2. Сортировка от А до Я\n";
				cout << "3. Сортировка от Я до А\n";
				cout << "4. Отмена\n";
				cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
				cout << "Выберите сортировку: ";
				menu = print_menu(menu);
				switch (menu)
				{

				case 1:
				{
					/// Сортировка по убыванию длины слов
					sort_down_length(str, n);
					break;
				}

				case 2:
				{
					/// Сортировка от А до Я
					sort_down(str, n);
					break;
				}

				case 3:
				{
					/// Сортировка от Я до А
					sort_up(str, n);
					break;
				}

				case 4:
				{
					menu = NULL;
					break;
				}

				default:
				{
					cout << "Вы некорректно выбрали сортировку!\n";
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
				/// Вывод на экран массива строк
				print(str, n);
			}
			break;
		}

		case 4:
		{
			break;
		}

		default:
		{
			cout << "Вы неверно ввели пункт меню!\n";
			break;
		}

		}
	} while (menu != 4);

	/// Очистка массива
	clear_str(str);

	return 0;
}