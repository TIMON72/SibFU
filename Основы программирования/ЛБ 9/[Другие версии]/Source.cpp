/*
������� 19
� ����� �������� ������������ �����, ������������ ���� �� ����,
������������� � ���������� ������� (�� ������ 5 ������ ��������� ���� �������).
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
	system("cls");
	cout << endl;
	return menu;
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

		// ������� ���-�� ���� ����� strtok_s
		char* current_str0; // ������ � ���� ����� �� �����
		char* next_str0; // ������ � ���� ������� ����������� ����� ������ �-��� strtok_s
		while (!file.eof())
		{
			getline(file, str0);
			
			// ����� ����� �� �����
			cout << str0 << endl;

			current_str0 = strtok_s(const_cast<char*>(str0.c_str()), " .,?!", &next_str0);
			while (current_str0 != NULL)
			{
				current_str0 = strtok_s(NULL, " .,?!", &next_str0);
				n++;
			}
		}
		file.seekg(0, file.beg); // ���������� ������ � ������ �����

		// ������� � �������� �������
		if (str != NULL)
			delete[] str;
		str = new string[n];

		// ��������� ������ ��������� ����������� �����
		int k = 0;
		while (!file.eof())
		{
			getline(file, str0);
			current_str0 = strtok_s(const_cast<char*>(str0.c_str()), " .,?!", &next_str0);
			while (current_str0 != NULL)
			{
				str[k] = current_str0;
				k++;
				current_str0 = strtok_s(NULL, " .,?!", &next_str0);
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
/// ���������� �� � �� � (���� 2)
string* sort_down(string* str, int& n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (_stricmp(str[i].c_str(), str[j].c_str()) > NULL) // _stricmp ����� ����������� ������ � ������� �������
			{
				swap(str[i], str[j]); // swap ������ ������� ����������
			}
		}
	}
	// ����� � �������� ���������� ��-��
	int index;
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		{
			if (_stricmp(str[i].c_str(), str[j].c_str()) == NULL) // _stricmp ����� ����������� ������ � ������� �������
			{
				cout << "���������: " << str[i] << " � " << str[j] << endl;
				index = i;
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
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
	return str;
}
/// ����� �� ����� ������� ����� (���� 3)
void print(string* str, int& n)
{
	for (int i = 0; i < n; i++)
	{
		cout << str[i] << endl;
	}
}
/// ������ � ���� (���� 4)
void rewriting(string* str, int& n, CString& path, bool& error)
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
		cout << "�� �� ������� ����" << endl;
		error = true;
		//return 0;
	}
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
	string* str = 0;
	CString path;

	do
	{
		/// ���� ������ ����
		cout << "\n>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<";
		cout << "\n>>>>>>>>>>>>>> ���� <<<<<<<<<<<<<<\n";
		cout << "1. ����� � �������� �����\n";
		cout << "2. ���������� �� � �� �\n";
		cout << "3. ����� ���������� �� �����\n";
		cout << "4. ������ � ����\n";
		cout << "5. �����\n";
		cout << ">>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<\n\n";
		cout << "������� ����� ����: ";
		menu = print_menu(menu);

		switch (menu)
		{

		case 1:
		{
			/// ����� � �������� �����
			str = open_file(str, n, error, path);
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
				/// ���������� �� � �� � (���� 2)
				str = sort_down(str, n);
				break;
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
			if (error == true)
			{
				cout << ("������� �������� ���� (1 ����� ����)\n");
			}
			else
			{
				/// ������ � ���� (���� 4)
				rewriting(str, n, path, error);
			}
			break;
		}

		case 5:
		{
			break;
		}

		default:
		{
			cout << "�� ������� ����� ����� ����!\n";
			break;
		}

		}
	} while (menu != 5);

	/// ������� �������
	if (str != NULL)
		delete[] str;

	return 0;
}