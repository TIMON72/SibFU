#pragma once
#ifndef HEADER_H_ // <- ���� �� ����������, ��
#define HEADER_H_ // <- ����������

#include <iostream>
#include <fstream>
#include <string>
#include <afxdlgs.h>
#include <iomanip>

using namespace std;

/// ����� � �������� ����� (���� 1)
string* open_file(string* str, int& n, bool& error, CString& path);
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
void structuring(client*& clients, string* str, int& n);
/// ���������� ������� � ���� ������� � ���������� (���� 2.1)
string* widening(client*& clients, string* str, int& n);
/// ������ ������� � �������� ������� (���� 2.2)
string* constriction(client*& clients, string* str, int& n);
/// ����� ���� ������ �� ����� (���� 3)
void print(client*& clients, int& n);
/// ���������� �� ��� (���� 4.1)
void sorting_name(client*& clients, int& n);
/// ���������� �� ����� ������� (���� 4.2)
void sorting_credit_summ(client*& clients, int& n);
/// ���������� �� ���������� ������ � ��� (���� 4.3)
void sorting_percent(client*& clients, int& n);
/// ���������� �� ����� ������� (���� 4.4)
void sorting_time(client*& clients, int& n);
/// ���������� �� ����� ����� �� ���� ������� (���� 4.5)
void sorting_debt(client*& clients, int& n);
/// ���������� ����� (���� 5)
void rewriting(string* str, int& n, CString& path);

#endif