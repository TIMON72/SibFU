#include "..\Header\Header.h"

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