#include "..\Header\Header.h"

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