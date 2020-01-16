/*
Вариант 19
В файле хранится произвольный текст, сформировать файл из слов,
расположенных в алфавитном порядке (на оценку 5 баллов дубликаты слов удалить).
*/

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
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
void open_file(vector<string>& vecStr, bool& error, CString& path)
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
		return;
	}

	/// Открытие файла
	fstream file;
	string str0;

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

		// Вывод содержимого файла на экран
		while (!file.eof())
		{
			getline(file, str0);
			cout << str0 << endl;
		}
		file.seekg(0, file.beg); // Возвращаем курсор в начало файла

		// Заполняем массив повторным считыванием файла
		while (!file.eof())
		{
			getline(file, str0);
			char* current_str0; // Хранит в себе текст до знака
			char* next_str0; // Хранит в себе остаток предложения после работы ф-ции strtok_s
			current_str0 = strtok_s(const_cast<char*>(str0.c_str()), " .,?!", &next_str0);
			while (current_str0 != NULL)
			{
				vecStr.push_back(current_str0);
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
}
/// Сортировка от А до Я (меню 2)
void sort_down(vector<string>& vecStr)
{
	for (int i = 0; i < vecStr.size() - 1; i++)
	{
		for (int j = i + 1; j < vecStr.size(); j++)
		{
			// Сортирвка
			if (_stricmp(vecStr[i].c_str(), vecStr[j].c_str()) > NULL) // _stricmp может сортировать нижний и верхний регистр
			{
				swap(vecStr[i], vecStr[j]); // swap меняет местами переменные
			}
			// Удаление повторяющегося эл-та
			if (_stricmp(vecStr[i].c_str(), vecStr[j].c_str()) == NULL) // _stricmp может сортировать нижний и верхний регистр
			{
				vecStr.erase(vecStr.begin() + i); // erase - стирание эл-та массива
			}
		}
	}
	cout << "Сортировка выполнена успешно" << endl;
}
/// Вывод на экран массива строк (меню 3)
void print(vector<string>& vecStr)
{
	for (int i = 0; i < vecStr.size(); i++)
	{
		cout << vecStr[i] << endl;
	}
}
/// Запись в файл
void rewriting(vector<string>& vecStr, CString& path, bool& error)
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
		return;
	}
	fstream file;
	// Открываем файл в режиме записи
	file.open(path, ios::out);
	// Записываем строки в файл
	for (int i = 0; i < vecStr.size() - 1; i++)
	{
		file << vecStr[i] << endl;
	}
	file << vecStr[vecStr.size() - 1]; // чтоб \n не засунул после добавления последнего клиента

	file.close();

	cout << "Файл успешно перезаписан!" << endl;
}

/// ГЛАВНАЯ ФУНКЦИЯ
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");

	int menu = 0;
	bool error = 1;
	vector<string> vecStr;
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
			open_file(vecStr, error, path);
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
				sort_down(vecStr);
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
				print(vecStr);
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
				rewriting(vecStr, path, error);
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

	return 0;
}