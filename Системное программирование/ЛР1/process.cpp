/*
@file process.cpp
@mainpage Лабораторная работа №1
@author Радионов Тимофей, группа КИ15-17Б
@brief ВАРИАНТ 18. Задание: Выполнить поиск элемента введенного пользователем массива целочисленных чисел любыми алгоритмами, кроме прямого поиска
*/
#include <iostream>
#include <string>
#include <vector>
#include <cstdlib>

using namespace std;

/*! \brief Binary search in ordered array.
*
*  \details Binary search in vector of integers.
*
*  \param   arr		Ordered list of integers.
*  \param   key		Number which we will search.
*
*  \return  index of the element if found.
*           -1, otherwise. Index of nearest element via posBefore parameter.
*/
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
/*! \brief Interpolation search in ordered array.
*
*  \details Interpolation search in vector of integers.
*
*  \param   arr		Ordered list of integers.
*  \param   key		Number which we will search.
*
*  \return  index of the element if found.
*           -1, otherwise. Index of nearest element via posBefore parameter.
*/
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
/*! \brief Main function
*  \return Integer 0 - success
*/
int main()
{
	vector<int> arr;
	string buffer = "";
	// Считывание массива и конвертация в тип int
	cout << "Заполните ваш массив (через пробел): ";
	getline(cin, buffer);
	int end = buffer.find(' ');
	int size = 0;
	while (end != -1)
	{
		arr.push_back(atoi(buffer.substr(0, end).c_str()));
		buffer = buffer.substr(end + 1, buffer.length() - 1);
		end = buffer.find(' ');
		size++;
	}
	arr.push_back(atoi(buffer.substr(0, buffer.length()).c_str()));
	size++;
	// Вывод массива на экран
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << endl;
	}

	cout << "======================================" << endl;
	cout << endl;

	// Осуществление бинарного поиска элемента
	int x = BinarySearch(arr);
	cout << "Индекс искомого числа: " << x << endl;
	// Осуществление интерполяционного поиска элемента
	int y = InterpolationSearch(arr);
	cout << "Индекс искомого числа: " << y << endl;

	return 0;
}


