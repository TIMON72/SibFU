#include "..\Header\Header.h"

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