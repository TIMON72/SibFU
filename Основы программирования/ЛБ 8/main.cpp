//������� 19
//�� ������ ����� ������� � ���������� � ������������ ������ �6.�������� ��������� ���, �����
//������ ������� ������������� � ��������� ������(cpp - �����).���������� �� �������������
//���������� ���������� �����������.
//�������: ��� ��������, �����, ���������� ������ � ���, ���� �������.��������� �����
//����������� � ����� ���������, ������� ����������� ��������� �������� �� ����
//�������.

#include "Header\Header.h"

/// ���� ������ ����
int print_menu(int menu)
{
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

/// ������� �������
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");

	int menu = 0, n;
	bool error = 1;
	string* str = NULL;
	client* clients = NULL;
	CString path;

	do
	{
		/// ���� ������ ����
		cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<";
		cout << "\n>>>>>>>>>>>>>> ���� <<<<<<<<<<<<<<\n";
		cout << "1. ����� � �������� �����\n";
		cout << "2. ���������� � �������� �������\n";
		cout << "3. ����� ���� ������ �� �����\n";
		cout << "4. ����������\n";
		cout << "5. ���������� �����\n";
		cout << "6. �����\n";
		cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
		cout << "������� ����� ����: ";
		menu = print_menu(menu);

		switch (menu)
		{
		case 1:
		{
			/// ����� � �������� �����
			str = open_file(str, n, error, path);
			/// �������� ���� ������
			structuring(clients, str, n);

			break;
		}
		case 2:
		{
			if (error == true)
			{
				cout << ("������� �������� ���� (1 ����� ����)\n");
			}
			else
			{
				/// ���� ������ ����
				cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n";
				cout << "1. ���������� �������\n";
				cout << "2. �������� �������\n";
				cout << "3. ������\n";
				cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
				cout << "�������� ����� ����: ";
				menu = print_menu(menu);
				switch (menu)
				{
				case 1:
				{
					/// ���������� ������� � ���� ������� � ����������
					str = widening(clients, str, n);
					break;
				}
				case 2:
				{
					/// ������ ������� � �������� �������
					str = constriction(clients, str, n);
					break;
				}
				case 3:
				{
					menu = NULL;
					break;
				}
				default:
				{
					cout << "�� ����������� ������� ����� ����!\n";
					break;
				}
				}
			}
			break;
		}
		case 3:
		{
			if (error == true)
			{
				cout << ("������� �������� ���� (1 ����� ����)\n");
			}
			else
			{
				print(clients, n);
			}
			break;
		}
		case 4:
		{
			if (error == true)
			{
				cout << ("������� �������� ���� (1 ����� ����)\n");
			}
			else
			{
				/// ���� ������ ����
				cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n";
				cout << "1. ���������� �� ���\n";
				cout << "2. ���������� �� ����� �������\n";
				cout << "3. ���������� �� ���������� ������ � ���\n";
				cout << "4. ���������� �� ����� �������\n";
				cout << "5. ���������� �� ����� ����� �� ���� �������\n";
				cout << "6. ������\n";
				cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
				cout << "�������� ����� ����: ";
				menu = print_menu(menu);
				switch (menu)
				{
				case 1:
				{
					/// ���������� �� ���
					sorting_name(clients, n);
					break;
				}

				case 2:
				{
					/// ���������� �� ����� �������
					sorting_credit_summ(clients, n);
					break;
				}

				case 3:
				{
					/// ���������� �� ���������� ������ � ���
					sorting_percent(clients, n);
					break;
				}
				case 4:
				{
					/// ���������� �� ����� �������
					sorting_time(clients, n);
					break;
				}
				case 5:
				{
					/// ���������� �� ����� ����� �� ���� �������
					sorting_debt(clients, n);
					break;
				}
				case 6:
				{
					menu = NULL;
					break;
				}

				default:
				{
					cout << "�� ����������� ������� ����� ����!\n";
					break;
				}
				}
			}

			break;
		}
		case 5:
		{
			if (error == true)
			{
				cout << ("������� �������� ���� (1 ����� ����)\n");
			}
			else
			{
				/// ���������� �����
				rewriting(str, n, path);
			}

			break;
		}
		case 6:
		{
			break;
		}

		default:
		{
			cout << "�� ������� ����� ����� ����!\n";
			break;
		}

		}
	} while (menu != 6);

	// ������� ������� �����
	if (str != NULL)
		delete[] str;
	// ������� ������������ �������
	if (clients != NULL)
		delete[]clients;

	return 0;
}