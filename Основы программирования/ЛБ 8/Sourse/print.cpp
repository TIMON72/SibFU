#include "..\Header\Header.h"

/// ����� ���� ������ �� ����� (���� 3)
void print(client*& clients, int& n)
{
	for (int i = 0; i < n; i++)
	{
		// ����� ���� ������ �� �����
		cout << "\n==================================\n" << endl;
		cout << "������ �" << i << endl;
		cout << "���: " << clients[i].name << endl;
		cout << "����� ������� " << clients[i].credit.summ << " ���." << endl;
		cout << "��������� ������ � ��� " << clients[i].credit.percent << "%" << endl;
		cout << "���� ������� " << clients[i].credit.time << " �." << endl;
		cout << "�����, ������� ������ ��������� ������ �� ������ ���� ������� " << fixed << setprecision(0) << clients[i].credit.debt << " ���." << endl;
	}
}