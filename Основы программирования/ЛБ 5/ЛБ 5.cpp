// ЛБ 5, Вариант 19
// Определение кол-ва "," в строке

#include <iostream>
#include <string>
#include <stdio.h>

using namespace std;

//Ввод пункта меню
int print_menu(int menu)
{
	cout << "\n>>>>>>>>>><<<<<<<<<<";
	cout << "\n>>>>>>> МЕНЮ <<<<<<<\n";
	cout << "1. Ввод строки и вывод результата\n";
	cout << "2. -\n";
	cout << "3. -\n";
	cout << "4. Выход\n";
	cout << ">>>>>>>>>><<<<<<<<<<\n\n";
	cout << "Введите пункт меню: ";
	while (!(cin >> menu))
	{
		cout << "Вы ввели некорректные данные\n";
		cout << "Введите пункт меню: ";
		cin.clear();
		while (cin.get() != '\n');
	}
	cin.clear();
	while (cin.get() != '\n');
	return menu;
}

// ГЛАВНАЯ ФУНКЦИЯ
int main()
{
	setlocale(0, "");
	int menu = 0, error = 1, pos = 0, t = 0;
	string str, str1;
	string symb = ",";

	do
	{
		// Ввод пункта меню
		menu = print_menu(menu);

		switch (menu)
		{
		case 1:

			cout << "Введите строку: ";
			getline(cin, str);
			str1 = str; // Создаем вторую строку для работы с ней (оригинал оставим для вывода на экран)
			pos = str1.find(symb);
			while (pos != -1)
			{
				str1.replace(pos, 1, ""); // Заменяем искомый символ на пустой
				t++;
				pos = str1.find(symb);
			}
			cout << "\nКол-во искомых символов: " << t << endl;
			t = 0;
			error = 0;
			break;

		case 2:

			if (error == 1)
			{
				cout << ("Сначала заполните массив (1 пункт меню)\n");
			}
			break;

		case 3:

			if (error == 1)
			{
				cout << ("Сначала заполните массив (1 пункт меню)\n");
			}
			break;

		case 4:
			break;

		default:
			cout << "Вы неверно ввели пункт меню!\n";
			break;
		}
	} while (menu != 4);

	return 0;
}