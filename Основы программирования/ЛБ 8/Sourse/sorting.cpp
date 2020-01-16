#include "..\Header\Header.h"

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