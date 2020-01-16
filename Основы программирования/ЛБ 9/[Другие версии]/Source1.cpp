/*
������� 19
� ����� �������� ������������ �����, ������������ ���� �� ����,
������������� � ���������� ������� (�� ������ 5 ������ ��������� ���� �������).
*/

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
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
void open_file(vector<string>& vecStr, bool& error, CString& path)
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
		return;
	}

	/// �������� �����
	fstream file;
	string str0;

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

		// ����� ����������� ����� �� �����
		while (!file.eof())
		{
			getline(file, str0);
			cout << str0 << endl;
		}
		file.seekg(0, file.beg); // ���������� ������ � ������ �����

		// ��������� ������ ��������� ����������� �����
		while (!file.eof())
		{
			getline(file, str0);
			char* current_str0; // ������ � ���� ����� �� �����
			char* next_str0; // ������ � ���� ������� ����������� ����� ������ �-��� strtok_s
			current_str0 = strtok_s(const_cast<char*>(str0.c_str()), " .,?!", &next_str0);
			while (current_str0 != NULL)
			{
				vecStr.push_back(current_str0);
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
}
/// ���������� �� � �� � (���� 2)
void sort_down(vector<string>& vecStr)
{
	for (int i = 0; i < vecStr.size() - 1; i++)
	{
		for (int j = i + 1; j < vecStr.size(); j++)
		{
			// ���������
			if (_stricmp(vecStr[i].c_str(), vecStr[j].c_str()) > NULL) // _stricmp ����� ����������� ������ � ������� �������
			{
				swap(vecStr[i], vecStr[j]); // swap ������ ������� ����������
			}
			// �������� �������������� ��-��
			if (_stricmp(vecStr[i].c_str(), vecStr[j].c_str()) == NULL) // _stricmp ����� ����������� ������ � ������� �������
			{
				vecStr.erase(vecStr.begin() + i); // erase - �������� ��-�� �������
			}
		}
	}
	cout << "���������� ��������� �������" << endl;
}
/// ����� �� ����� ������� ����� (���� 3)
void print(vector<string>& vecStr)
{
	for (int i = 0; i < vecStr.size(); i++)
	{
		cout << vecStr[i] << endl;
	}
}
/// ������ � ����
void rewriting(vector<string>& vecStr, CString& path, bool& error)
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
		return;
	}
	fstream file;
	// ��������� ���� � ������ ������
	file.open(path, ios::out);
	// ���������� ������ � ����
	for (int i = 0; i < vecStr.size() - 1; i++)
	{
		file << vecStr[i] << endl;
	}
	file << vecStr[vecStr.size() - 1]; // ���� \n �� ������� ����� ���������� ���������� �������

	file.close();

	cout << "���� ������� �����������!" << endl;
}

/// ������� �������
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");

	int menu = 0;
	bool error = 1;
	vector<string> vecStr;
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
			open_file(vecStr, error, path);
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
				sort_down(vecStr);
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
				print(vecStr);
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
				rewriting(vecStr, path, error);
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

	return 0;
}