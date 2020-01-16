#include "..\Header\Header.h"

/// Создание базы данных (меню 1)
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