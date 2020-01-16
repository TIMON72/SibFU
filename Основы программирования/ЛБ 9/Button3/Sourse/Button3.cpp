#include "stdafx.h" // Почему он жалуется?
#include <C:\Users\TIMON_Dark\OneDrive\Google Drive\Study\Основы программирования\Программы\Лабораторные работы\ЛБ 9\Button3\Header\Button3.h>

/// Открытие файла
bool open_file(vector<string>& vecStr, CString& nameFileIn)
{
	// Открытие файла
	fstream file;
	string str0;
	file.open(nameFileIn, ios::in);
	if (file.is_open())
	{
		// Заполняем массив считыванием файла
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
		// Закрытие файла
		file.close();
		return TRUE;
	}
	else
	{
		return FALSE;
	}
}
/// Сортировка от А до Я
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
}
/// Запись в файл
bool rewriting(vector<string>& vecStr, CString& nameFileOut)
{
	fstream file;
	// Открываем файл в режиме записи
	file.open(nameFileOut, ios::out | ios::_Nocreate);
	if (file.is_open())
	{
		// Записываем строки в файл
		for (int i = 0; i < vecStr.size() - 1; i++)
		{
			file << vecStr[i] << endl;
		}
		file << vecStr[vecStr.size() - 1]; // чтоб \n не засунул после добавления последнего клиента
		// Закрытие файла
		file.close();
		return TRUE;
	}
	else
	{
		return FALSE;
	}
}