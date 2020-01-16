/*
Вариант 19
В файле хранится произвольный текст, сформировать файл из слов,
расположенных в алфавитном порядке (на оценку 5 баллов дубликаты слов удалить).
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
	system("cls");
	cout << endl;
	return menu;
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

		// Подсчет кол-ва слов через strtok_s
		char* current_str0; // Хранит в себе текст до знака
		char* next_str0; // Хранит в себе остаток предложения после работы ф-ции strtok_s
		while (!file.eof())
		{
			getline(file, str0);
			
			// Вывод строк на экран
			cout << str0 << endl;

			current_str0 = strtok_s(const_cast<char*>(str0.c_str()), " .,?!", &next_str0);
			while (current_str0 != NULL)
			{
				current_str0 = strtok_s(NULL, " .,?!", &next_str0);
				n++;
			}
		}
		file.seekg(0, file.beg); // Возвращаем курсор в начало файла

		// Очистка и создание массива
		if (str != NULL)
			delete[] str;
		str = new string[n];

		// Заполняем массив повторным считыванием файла
		int k = 0;
		while (!file.eof())
		{
			getline(file, str0);
			current_str0 = strtok_s(const_cast<char*>(str0.c_str()), " .,?!", &next_str0);
			while (current_str0 != NULL)
			{
				str[k] = current_str0;
				k++;
				current_str0 = strtok_s(NULL, " .,?!", &next_str0);
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
/// Сортировка от А до Я (меню 2)
string* sort_down(string* str, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (_stricmp(str[i].c_str(), str[j].c_str()) > NULL) // _stricmp может сортировать нижний и верхний регистр
			{
				swap(str[i], str[j]); // swap меняет местами переменные
			}
		}
	}
	// Поиск и удаление одинаковых эл-ов
	int index;
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (_stricmp(str[i].c_str(), str[j].c_str()) == NULL) // _stricmp может сортировать нижний и верхний регистр
			{
				cout << "Одинаковы: " << str[i] << " и " << str[j] << endl;
				index = i;
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
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
	return str;
}
/// Вывод на экран массива строк (меню 3)
void print(string* str, int& n)
{
	for (int i = 0; i < n; i++)
	{
		cout << str[i] << endl;
	}
}
/// Запись в файл (меню 4)
void rewriting(string* str, int& n, CString& path, bool& error)
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
		cout << "Вы не выбрали файл" << endl;
		error = true;
		//return 0;
	}
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
	string* str = 0;
	CString path;

	do
	{
		/// Ввод пункта меню
		cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<";
		cout << "\n>>>>>>>>>>>>>> МЕНЮ <<<<<<<<<<<<<<\n";
		cout << "1. Выбор и открытие файла\n";
		cout << "2. Сортировка от А до Я\n";
		cout << "3. Вывод результата на экран\n";
		cout << "4. Запись в файл\n";
		cout << "5. Выход\n";
		cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
		cout << "Введите пункт меню: ";
		menu = print_menu(menu);

		switch (menu)
		{

		case 1:
		{
			/// Выбор и открытие файла
			str = open_file(str, n, error, path);
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
				/// Сортировка от А до Я (меню 2)
				str = sort_down(str, n);
				break;
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
			if (error == true)
			{
				cout << ("Сначала откройте файл (1 пункт меню)\n");
			}
			else
			{
				/// Запись в файл (меню 4)
				rewriting(str, n, path, error);
			}
			break;
		}

		case 5:
		{
			break;
		}

		default:
		{
			cout << "Вы неверно ввели пункт меню!\n";
			break;
		}

		}
	} while (menu != 5);

	/// Очистка массива
	if (str != NULL)
		delete[] str;

	return 0;
}