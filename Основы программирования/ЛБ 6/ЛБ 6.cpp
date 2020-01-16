//������� 19
//�������: ��� ��������, �����, ���������� ������ � ���, ���� �������.��������� �����
//����������� � ����� ���������, ������� ����������� ��������� �������� �� ����
//�������.

#include <iostream>
#include <fstream>
#include <string>
#include <iomanip> // ��� ������������� setprecision()
#include <afxdlgs.h> // ���������� ������ CDialog, ����� �������� ���������� windows.h

using namespace std;

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
void clear_str(string* str)
{
	if (str != NULL)
		delete[] str;
}
/// ����� � �������� ����� (���� 1)
string* open_file(string* str, int& n, bool& error, CString& path)
{

	/// ���� ������ �����
	CFileDialog dlg(TRUE); // ������ ���������� ������ ��� �������� ������
						   /*
						   int console = dlg.DoModal(); // ����� ���� ������� ������� �� �����
						   ���� ������� ��� �������� ��� ���������� �����. ��� �������� ����������
						   ������� ���������� IDOK ��� IDCANCEL � ����������� �� ����, ��� ������
						   ����� ������ ������������ ������ ���� �������.
						   */
	if (dlg.DoModal() == IDOK)
	{
		path = dlg.GetPathName();
	}
	else
	{
		cout << "\n�� �� ������� ����" << endl;
		error = true;
		return 0;
	}

	/// �������� �����
	fstream file;
	string str0;
	n = 0;

	file.open(path, ios::in);

	if (file.is_open())
	{
		error = false;
		cout << "\n----------------------------------\n";
		cerr << "�������� �������� � �������� �����" << endl;
		cout << "----------------------------------\n";
		cout << "----------------------------------\n";
		cout << "���� � �����: ";
		wcout << (LPCTSTR)path << endl;
		cout << "-------- ���������� ����� --------\n";
		// ������� ���-�� ����� ����� getline
		while (!file.eof())
		{
			getline(file, str0);
			n++;
		}
		file.seekg(0, file.beg); // ���������� ������ � ������ �����

		/// ������� �������
		clear_str(str);

		str = new string[n]; // ������� �����. ������ �����

		// �������� ������ ������ � ������� �������
		while (!file.eof())
		{
			for (int i = 0; i < n; i++)
			{
				getline(file, str[i]);
				cout << i << ". " << str[i] << endl;
			}
		}
		cout << "----------------------------------\n";

		/// �������� �����
		file.close();
	}
	else
	{
		error = true;
		cout << "---------------------\n";
		cerr << "������ �������� �����" << endl;
		cout << "---------------------\n";
	}
	return str;
}
/// �������� ���� ������ (���� 1)
struct credit
{
	string percent;
	string time;
	string summ;
	double debt;
};
struct client
{
	string name;
	credit credit;
};
void structuring(client*& clients, string* str, int& n)
{
	// ������� ������������ ������ ��� �������� ���� struct
	if (clients != NULL)
		delete[]clients;
	clients = new client[n];

	// ������� �������� ���� ������ ��� ��������������
	string* str_buf = NULL;
	if (str_buf != NULL)
		delete[]str_buf;
	str_buf = new string[n];
	for (int i = 0; i < n; i++)
	{
		str_buf[i] = str[i];
	}

	// �������� ��������������
	for (int i = 0; i < n; i++)
	{
		int pos, br;

		// ���
		br = 1;
		while (br != 0)
		{
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// �������� � name ���
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
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|'); // ���������� br == 0? �� -> ��������� ����
		}
		str_buf[i].replace(0, 1, ""); // ���������� "|"

									  // ����� �������
		br = 1;
		while (br != 0)
		{
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// �������� � summ ����� �������
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
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|');
		}
		str_buf[i].replace(0, 1, ""); // ���������� "|"

									  // ����� �������
		br = 1;
		while (br != 0)
		{
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// �������� � percent ���������� ������ �������
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
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|');
		}
		str_buf[i].replace(0, 1, ""); // ���������� "|"

									  // ���� �������
									  // ������� ��������
		pos = str_buf[i].find(' ');
		while (pos == 0)
		{
			str_buf[i].replace(0, pos + 1, "");
			pos = str_buf[i].find(' ');
		}
		// �������� � time ���� �������
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
		// ������� ��������
		pos = str_buf[i].find(' ');
		while (pos == 0)
		{
			str_buf[i].replace(0, pos + 1, "");
			pos = str_buf[i].find(' ');
		}

		// �����, ������� ������ ��������� ������ �� ���� �������
		int x = stoi(clients[i].credit.summ);
		int y = stoi(clients[i].credit.percent);
		float z = stof(clients[i].credit.time);
		clients[i].credit.debt = x + ((0.01 * y) * x) * z;
	}

	// ������� ��������� �������
	if (str_buf != NULL)
		delete[]str_buf;
}
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
/// ���������� �� ��� (���� 4.1)
void sorting_name(client*& clients, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (strcmp(clients[i].name.c_str(), clients[j].name.c_str()) > NULL)
			{
				swap(clients[i], clients[j]); // swap ������ ������� ����������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ���������� �� ����� ������� (���� 4.2)
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
				swap(clients[i], clients[j]); // swap ������ ������� ����������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ���������� �� ���������� ������ � ��� (���� 4.3)
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
				swap(clients[i], clients[j]); // swap ������ ������� ����������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ���������� �� ����� ������� (���� 4.4)
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
				swap(clients[i], clients[j]); // swap ������ ������� ����������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ���������� �� ����� ����� �� ���� ������� (���� 4.5)
void sorting_debt(client*& clients, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (clients[i].credit.debt < clients[j].credit.debt)
			{
				swap(clients[i], clients[j]); // swap ������ ������� ����������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ���������� ����� (���� 5)
void rewriting(string* str, int& n, CString& path)
{
	fstream file;
	// ��������� ���� � ������ ������
	file.open(path, ios::out);
	// ���������� ������ � ����
	for (int i = 0; i < n - 1; i++)
	{
		file << str[i] << endl;
	}
	file << str[n - 1]; // ���� \n �� ������� ����� ���������� ���������� �������

	file.close();

	cout << "���� ������� �����������!" << endl;
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

	/// ������� ������� �����
	clear_str(str);
	// ������� ������������ �������
	if (clients != NULL)
		delete[]clients;

	return 0;
}