#include "..\Header\Header.h"

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