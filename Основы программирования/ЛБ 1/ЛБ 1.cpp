#include <iostream> // ����
#include <math.h> // ��� ������� cos
#include <iomanip> // ��� ������������� setprecision
#define Pi 3.14159265 // ��������� ����� ��
using namespace std;

int main()
{
	setlocale(0, "");
	cout << "���������� �������� �������� ��������� ����" << endl;
	double x, y;
	cout << "������� ����: ";
	// ������, ���������� �� ������������ �����
	// !-- ������ --!
	while (!(cin >> x) || x < 0)
	{
		cout << "�� ����� ������������ ������\n"; // \n = endl
		cout << "������� ����: ";
		cin.clear(); // ������� ������ - ���� �� �������� ���������� ��������� ������ � ���� (����� ��������� ����������� ���������� ����)
		while (cin.get() != '\n'); // �������� cin �������nm ��� ������� �� '\n'(�������� ������)
	}
	// !-- ����� --!
	x = x * Pi / 180;
	y = pow(cos(x), 2);
	cout << "������� �������� = " << fixed << setprecision(2) << y << endl;
	system("pause");
	return 0;
}
