#include <iostream> // окно
#include <math.h> // для функции cos
#include <iomanip> // для использования setprecision
#define Pi 3.14159265 // объявляем число Пи
using namespace std;

int main()
{
	setlocale(0, "");
	cout << "Вычесление квадрата косинуса заданного угла" << endl;
	double x, y;
	cout << "Введите угол: ";
	// Модуль, отвечающий за правильность ввода
	// !-- НАЧАЛО --!
	while (!(cin >> x) || x < 0)
	{
		cout << "Вы ввели некорректные данные\n"; // \n = endl
		cout << "Введите угол: ";
		cin.clear(); // очистка потока - чтоб не собирать предыдущие введенные данные в кучу (чтобы появилась возможность продолжить ввод)
		while (cin.get() != '\n'); // позволит cin считываnm все символы до '\n'(перевода строки)
	}
	// !-- КОНЕЦ --!
	x = x * Pi / 180;
	y = pow(cos(x), 2);
	cout << "Квадрат косинуса = " << fixed << setprecision(2) << y << endl;
	system("pause");
	return 0;
}
