#pragma once
#ifndef BUTTON3_H_ // <- ���� �� ����������, ��
#define BUTTON3_H_ // <- ����������

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <afxdlgs.h>

using namespace std;

/// �������� �����
bool open_file(vector<string>& vecStr, CString& nameFileIn);
/// ���������� �� � �� �
void sort_down(vector<string>& vecStr);
/// ������ � ����
bool rewriting(vector<string>& vecStr, CString& nameFileOut);

#endif