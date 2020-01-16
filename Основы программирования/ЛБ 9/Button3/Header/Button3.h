#pragma once
#ifndef BUTTON3_H_ // <- если не определено, то
#define BUTTON3_H_ // <- определяем

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <afxdlgs.h>

using namespace std;

/// Открытие файла
bool open_file(vector<string>& vecStr, CString& nameFileIn);
/// Сортировка от А до Я
void sort_down(vector<string>& vecStr);
/// Запись в файл
bool rewriting(vector<string>& vecStr, CString& nameFileOut);

#endif