/* 
Радионов Тимофей, группа КИ15-17Б
ВАРИАНТ 18
Задание: Выполнить поиск элемента введенного 
пользователем массива целочисленных чисел
любыми алгоритмами, кроме прямого поиска
*/
#include <iostream>
#include <string>
#include <vector>
#include <windows.h>

using namespace std;

int BinarySearch(vector<int>& arr)
{
	int key;
	int l = 0;
	int u = arr.size() - 1;

	cout << ">>> БИНАРНЫЙ ПОИСК <<<" << endl;
	cout << "Введите число, которое вы хотите найти: ";
	cin >> key;

	while (l <= u)
	{
		int m = (l + u) / 2;
		if (arr[m] < key)
		{
			l = m + 1;
		}
		if (arr[m] > key)
		{
			u = m - 1;
		}
		if (arr[m] == key)
		{
			return m;
		}
	}
	return -1;
}

int InterpolationSearch(vector<int>& arr)
{
	int key;
	int l = 0;
	int u = arr.size() - 1;

	cout << ">>> ИНТЕРПОЛЯЦИОННЫЙ ПОИСК <<<" << endl;
	cout << "Введите число, которое вы хотите найти: ";
	cin >> key;

	if (arr[l] == key)
	{
		return l;
	}
	while (arr[l] < key && arr[u] >= key)
	{
		int m = l + ((u - l) * (key - arr[l])) / (arr[u] - arr[l]);
		if (key < arr[m])
		{
			u = m - 1;
		}
		if (key > arr[m])
		{
			l = m + 1;
		}
		if (key == arr[m])
		{
			return m;
		}
	}
	return -1;
}

int main()
{
	// Поддержка кириллицы в консоли Windows
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");
	
	vector<int> arr;
	string buffer = "";
	// Считывание массива и конвертация в тип int
	cout << "Заполните ваш массив (через пробел): ";
	getline(cin, buffer);
	int size = buffer.length() / 2 + 1;
	for (int i = 0; i < size; i++)
	{
		arr.push_back(atoi(buffer.substr(0, 1).c_str()));
		if (i != size - 1)
		{
			buffer = buffer.substr(2, buffer.length() - 1);
		}
	}
	// Вывод массива на экран
	/*for (int i = 0; i < size; i++)
	{
		cout << arr[i];
	}*/
	
	cout << "======================================" << endl;
	cout << endl;

	// Осуществление бинарного поиска элемента
	int x = BinarySearch(arr);
	cout << "Индекс искомого числа: " << x << endl;
	// Осуществление интерполяционного поиска элемента
	int y = InterpolationSearch(arr);
	cout << "Индекс искомого числа: " << y << endl;

	system("pause");
	return 0;
}
