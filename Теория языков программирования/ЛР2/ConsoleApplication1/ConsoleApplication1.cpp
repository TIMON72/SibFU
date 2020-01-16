// ConsoleApplication1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <regex>
#include <cstdlib>

using namespace std;



int main()
{
	string s1 = "sssss";
	string s2 = "111000010";
	string s3 = "s0sx1000";
	string s4 = "111000100011";
	string s5 = "10";
	regex pattern("(0|1)*(000|001|011|100|101|110|111)");//("010$");//("[0-1]*(?!010)");
	cmatch result;
	if (regex_match(s4.c_str(), result, pattern))
		cout << "True\n";
	else
		cout << "False\n";
	system("pause");
	return 0;
}