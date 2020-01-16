#pragma once
#ifndef HEADER_H_ // <- если не определено, то
#define HEADER_H_ // <- определяем

#include <iostream>
#include <fstream>
#include <string>
#include <afxdlgs.h>
#include <iomanip>

using namespace std;

/// Выбор и открытие файла (меню 1)
string* open_file(string* str, int& n, bool& error, CString& path);
/// Создание базы данных (меню 1)
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
/// Расширение массива и ввод клиента с клавиатуры (меню 2.1)
string* widening(client*& clients, string* str, int& n);
/// Сжатие массива и удаление клиента (меню 2.2)
string* constriction(client*& clients, string* str, int& n);
/// Вывод базы данных на экран (меню 3)
void print(client*& clients, int& n);
/// Сортировка по ФИО (меню 4.1)
void sorting_name(client*& clients, int& n);
/// Сортировка по сумме кредита (меню 4.2)
void sorting_credit_summ(client*& clients, int& n);
/// Сортировка по процентной ставке в год (меню 4.3)
void sorting_percent(client*& clients, int& n);
/// Сортировка по сроку кредита (меню 4.4)
void sorting_time(client*& clients, int& n);
/// Сортировка по сумме долга за срок кредита (меню 4.5)
void sorting_debt(client*& clients, int& n);
/// Перезапись файла (меню 5)
void rewriting(string* str, int& n, CString& path);

#endif