#include "..\Header\Header.h"

/// ���������� ������� � ���� ������� � ���������� (���� 2.1)
string* widening(client*& clients, string* str, int& n)
{
	// ������� �������� �������������� ���� ��� ������ ������ ������� �������
	string* str_buf = NULL;
	if (str_buf != NULL)
		delete[]str_buf;
	int m = n + 1;
	str_buf = new string[m];
	// ���������� ��-�� �� ��������� ������� � ��������, ������� �������� ������ � ����������� ��� ������ � ����������� ������
	for (int i = 0; i < n; i++)
	{
		str_buf[i] = str[i];
	}
	delete[]str;
	n = n + 1;
	str = new string[n];
	// ���������� ��-�� �� ��������� ������� � ��������
	for (int i = 0; i < n - 1; i++)
	{
		str[i] = str_buf[i];
	}
	// ������� ���������� �������
	if (str_buf != NULL)
	{
		delete[]str_buf;
	}

	// ������� �������� �� "|" ��� ������������ ��� ���������� ������� � ���� ������
	int a[3];
	string str_buff = str[0];
	for (int i = 0; i < 3; i++)
	{
		a[i] = str_buff.find('|');
		str_buff.replace(0, a[i] + 1, "");
	}

	// ���� ������ ������� � ����������
	cout << "\n������� ������ �������:" << endl;
	string w, x, y, z, w1, x1, y1;
	cout << "������� ��� (����� ������): ";
	getline(cin, w);
	for (int i = 0; i < (a[0] - (int)w.length() - 1); i++)
	{
		w1 = w1 + " ";
	}
	cout << "������� ����� ������� (���.): ";
	cin >> x;
	for (int i = 0; i < (a[1] - (int)x.length() - 1); i++)
	{
		x1 = x1 + " ";
	}
	cout << "������� ���������� ������ � ��� (���-�� ���������): ";
	cin >> y;
	for (int i = 0; i < (a[2] - (int)y.length() - 1); i++)
	{
		y1 = y1 + " ";
	}
	cout << "������� ���� ������� (����): ";
	cin >> z;
	// ���������� ��� � ���� ������
	str[n - 1] = w + w1 + " | " + x + x1 + "| " + y + y1 + "| " + z;
	// ����� ������� ��������� (��� ���������� � ��� ������ �������
	structuring(clients, str, n);

	return str;
}
/// ������ ������� � �������� ������� (���� 2.2)
string* constriction(client*& clients, string* str, int& n)
{
	// ����� ������ ���������� ������� � �������� ��-��� �������
	int index;
	cout << "\n������� ����� �������, �������� ������ ������: ";
	cin >> index;
	for (int i = index; i < n - 1; i++)
	{
		str[i] = str[i + 1];
	}
	// ������� �������� �������������� ���� ��� ������ ������ ������� �������
	string* str_buf = NULL;
	if (str_buf != NULL)
		delete[]str_buf;
	int m = n - 1;
	str_buf = new string[m];
	// ���������� ��-�� �� ��������� ������� � ��������, ������� �������� ������ � ��������� ��� ������ � ����������� ������
	for (int i = 0; i < m; i++)
	{
		str_buf[i] = str[i];
	}
	delete[]str;
	n = n - 1;
	str = new string[n];
	// ���������� ��-�� �� ��������� ������� � ��������
	for (int i = 0; i < n; i++)
	{
		str[i] = str_buf[i];
	}
	// ������� ���������� �������
	if (str_buf != NULL)
	{
		delete[]str_buf;
	}
	// ����� ������� ��������� (��� ���������� � ��� ������ �������
	structuring(clients, str, n);
	return str;
}