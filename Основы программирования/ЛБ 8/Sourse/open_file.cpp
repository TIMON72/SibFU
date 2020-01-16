#include "..\Header\Header.h"

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

			if (str != NULL)
				delete[] str;

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