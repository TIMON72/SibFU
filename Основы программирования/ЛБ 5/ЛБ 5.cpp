// �� 5, ������� 19
// ����������� ���-�� "," � ������

#include <iostream>
#include <string>
#include <stdio.h>

using namespace std;

//���� ������ ����
int print_menu(int menu)
{
	cout << "\n>>>>>>>>>><<<<<<<<<<";
	cout << "\n>>>>>>> ���� <<<<<<<\n";
	cout << "1. ���� ������ � ����� ����������\n";
	cout << "2. -\n";
	cout << "3. -\n";
	cout << "4. �����\n";
	cout << ">>>>>>>>>><<<<<<<<<<\n\n";
	cout << "������� ����� ����: ";
	while (!(cin >> menu))
	{
		cout << "�� ����� ������������ ������\n";
		cout << "������� ����� ����: ";
		cin.clear();
		while (cin.get() != '\n');
	}
	cin.clear();
	while (cin.get() != '\n');
	return menu;
}

// ������� �������
int main()
{
	setlocale(0, "");
	int menu = 0, error = 1, pos = 0, t = 0;
	string str, str1;
	string symb = ",";

	do
	{
		// ���� ������ ����
		menu = print_menu(menu);

		switch (menu)
		{
		case 1:

			cout << "������� ������: ";
			getline(cin, str);
			str1 = str; // ������� ������ ������ ��� ������ � ��� (�������� ������� ��� ������ �� �����)
			pos = str1.find(symb);
			while (pos != -1)
			{
				str1.replace(pos, 1, ""); // �������� ������� ������ �� ������
				t++;
				pos = str1.find(symb);
			}
			cout << "\n���-�� ������� ��������: " << t << endl;
			t = 0;
			error = 0;
			break;

		case 2:

			if (error == 1)
			{
				cout << ("������� ��������� ������ (1 ����� ����)\n");
			}
			break;

		case 3:

			if (error == 1)
			{
				cout << ("������� ��������� ������ (1 ����� ����)\n");
			}
			break;

		case 4:
			break;

		default:
			cout << "�� ������� ����� ����� ����!\n";
			break;
		}
	} while (menu != 4);

	return 0;
}