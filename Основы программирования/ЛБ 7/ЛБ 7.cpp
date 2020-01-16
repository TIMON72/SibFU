/*
������� 19
� ����� �������� �������� ����.������ ������ ��������� ��������. ��������
���������, ������� ������ ������ �� ����� � ������ �����, � ������� �� ����� �������� ����,
������������ �� : �) �� �������� �� �����, �) � ���������� �������, �) � �������, ��������
�����������.
*/

#include <iostream>
#include <fstream>
#include <string>
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
/// ����� � �������� �����
string* open_file(string* str, int& n, bool& error)
{

	/// ���� ������ �����
	CString path;

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
		cout << "�� �� ������� ����" << endl;
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
		cout << "----------------------------------\n";
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
				cout << str[i] << endl;
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
/// ���������� �� �������� ����� ����
void sort_down_length(string* str, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (str[i].length() < str[j].length())
			{
				swap(str[i], str[j]);
			}

		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ���������� �� � �� �
void sort_down(string* str, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			/*
			strcmp ���������� �� ������ ������� � ��� ������ ����� �������
			������ ������������ �������, ������� �������������� �������� ����
			���� ��������. ��� ��� �������� ������, �� ������ � ����� ���������
			�������, ���������� -1 (a<b), 0 (a == b), 1 (a>b)
			*/
			if (strcmp(str[i].c_str(), str[j].c_str()) > NULL)
			{
				swap(str[i], str[j]); // swap ������ ������� ����������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ���������� �� � �� �
void sort_up(string* str, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			/*
			strcmp ���������� �� ������ ������� � ��� ������ ����� �������
			������ ������������ �������, ������� �������������� �������� ����
			���� ��������. ��� ��� �������� ������, �� ������ � ����� ���������
			�������, ���������� -1 (a<b), 0 (a == b), 1 (a>b)
			*/
			if (strcmp(str[i].c_str(), str[j].c_str()) < NULL)
			{
				swap(str[i], str[j]); // swap ������ ������� ����������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ����� �� ����� ������� �����
void print(string* str, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << str[i] << endl;
	}
}

/// ������� �������
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");

	int menu = 0, n;
	bool error = 1;
	string* str = 0;

	do
	{
		/// ���� ������ ����
		cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<";
		cout << "\n>>>>>>>>>>>>>> ���� <<<<<<<<<<<<<<\n";
		cout << "1. ����� � �������� �����\n";
		cout << "2. ���������� ����������� �����\n";
		cout << "3. ����� ���������� �� �����\n";
		cout << "4. �����\n";
		cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
		cout << "������� ����� ����: ";
		menu = print_menu(menu);

		switch (menu)
		{

		case 1:
		{
			/// ����� � �������� �����
			str = open_file(str, n, error);
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
				cout << "1. ���������� �� ����� ����\n";
				cout << "2. ���������� �� � �� �\n";
				cout << "3. ���������� �� � �� �\n";
				cout << "4. ������\n";
				cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
				cout << "�������� ����������: ";
				menu = print_menu(menu);
				switch (menu)
				{

				case 1:
				{
					/// ���������� �� �������� ����� ����
					sort_down_length(str, n);
					break;
				}

				case 2:
				{
					/// ���������� �� � �� �
					sort_down(str, n);
					break;
				}

				case 3:
				{
					/// ���������� �� � �� �
					sort_up(str, n);
					break;
				}

				case 4:
				{
					menu = NULL;
					break;
				}

				default:
				{
					cout << "�� ����������� ������� ����������!\n";
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
				/// ����� �� ����� ������� �����
				print(str, n);
			}
			break;
		}

		case 4:
		{
			break;
		}

		default:
		{
			cout << "�� ������� ����� ����� ����!\n";
			break;
		}

		}
	} while (menu != 4);

	/// ������� �������
	clear_str(str);

	return 0;
}