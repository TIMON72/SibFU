#include "..\Header\Header.h"

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

			if (str != NULL)
				delete[] str;

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