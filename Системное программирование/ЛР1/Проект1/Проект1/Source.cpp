/* 
�������� �������, ������ ��15-17�
������� 18
�������: ��������� ����� �������� ���������� 
������������� ������� ������������� �����
������ �����������, ����� ������� ������
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

	cout << ">>> �������� ����� <<<" << endl;
	cout << "������� �����, ������� �� ������ �����: ";
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

	cout << ">>> ���������������� ����� <<<" << endl;
	cout << "������� �����, ������� �� ������ �����: ";
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
	// ��������� ��������� � ������� Windows
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(0, "");
	
	vector<int> arr;
	string buffer = "";
	// ���������� ������� � ����������� � ��� int
	cout << "��������� ��� ������ (����� ������): ";
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
	// ����� ������� �� �����
	/*for (int i = 0; i < size; i++)
	{
		cout << arr[i];
	}*/
	
	cout << "======================================" << endl;
	cout << endl;

	// ������������� ��������� ������ ��������
	int x = BinarySearch(arr);
	cout << "������ �������� �����: " << x << endl;
	// ������������� ����������������� ������ ��������
	int y = InterpolationSearch(arr);
	cout << "������ �������� �����: " << y << endl;

	system("pause");
	return 0;
}
