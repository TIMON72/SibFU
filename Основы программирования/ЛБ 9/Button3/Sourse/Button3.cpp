#include "stdafx.h" // ������ �� ��������?
#include <C:\Users\TIMON_Dark\OneDrive\Google Drive\Study\������ ����������������\���������\������������ ������\�� 9\Button3\Header\Button3.h>

/// �������� �����
bool open_file(vector<string>& vecStr, CString& nameFileIn)
{
	// �������� �����
	fstream file;
	string str0;
	file.open(nameFileIn, ios::in);
	if (file.is_open())
	{
		// ��������� ������ ����������� �����
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
		// �������� �����
		file.close();
		return TRUE;
	}
	else
	{
		return FALSE;
	}
}
/// ���������� �� � �� �
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
}
/// ������ � ����
bool rewriting(vector<string>& vecStr, CString& nameFileOut)
{
	fstream file;
	// ��������� ���� � ������ ������
	file.open(nameFileOut, ios::out | ios::_Nocreate);
	if (file.is_open())
	{
		// ���������� ������ � ����
		for (int i = 0; i < vecStr.size() - 1; i++)
		{
			file << vecStr[i] << endl;
		}
		file << vecStr[vecStr.size() - 1]; // ���� \n �� ������� ����� ���������� ���������� �������
		// �������� �����
		file.close();
		return TRUE;
	}
	else
	{
		return FALSE;
	}
}