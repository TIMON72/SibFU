#include <iostream>
#include <time.h>

using namespace std;

int main()
{
	setlocale(0, "");
	int n = 0, menu, error = 1;
	double middleA = 0, max, imax, sum = 0;
	int *arr = NULL; // int *arr - �������� ������ ������ ��� ������ �������
	char ch;

	do
	{
		cout << "\n>>>>>>>>>><<<<<<<<<<";
		cout << "\n>>>>>>> ���� <<<<<<<\n";
		cout << "1. ���� ��������� �������\n";
		cout << "2. ��������� �������\n";
		cout << "3. ����� ������� �� �����\n";
		cout << "4. �����\n";
		cout << "������� ����� ����: ";
		// ������, ���������� �� ������������ �����
			// !-- ������ --!
		while (!(cin >> menu))
		{
			cout << "�� ����� ������������ ������\n";
			cout << "������� ����� ����: ";
			cin.clear();
			while (cin.get() != '\n');
		}
		// !-- ����� --!
		cout << ">>>>>>>>>><<<<<<<<<<\n\n";

		switch (menu)
		{
		case 1:

			// ���� ������� �������

			cout << "������� ������ �������: ";
			// ������, ���������� �� ������������ �����
			// !-- ������ --!
			while (!(cin >> n) || n < 0)
			{
				cout << "�� ����� ������������ ������\n";
				cout << "������� ������ �������: ";
				cin.clear();
				while (cin.get() != '\n');
			}
			// !-- ����� --!
			if (arr != NULL)
				delete[] arr;
			arr = new int[n];

			// �������������� ���������� �������

			cout << "�� ������ ��������������� �������������� ������? (y/n): "; cin >> ch;
			// ������, ���������� �� ������������ �����
			// !-- ������ --!
			while (ch != 'y' && ch != 'n')
			{
				cout << "�� ����� ������������ ������\n";
				cout << "�� ������ ��������������� �������������� ������? (y/n): "; cin >> ch;
				cin.clear();
				while (cin.get() != '\n');
			}
			// !-- ����� --!
			if (ch == 'y')
			{
				srand((unsigned int)time(NULL)); // ��� ��������� �����
				for (int i = 0; i < n; i++)
				{
					arr[i] = (int)-50 + rand() % 100;
				}
			}

			// ������ ���������� �������

			if (ch == 'n')
			{
				for (int i = 0; i < n; i++)
				{
					printf_s("a[%d] = ", i);
					// ������, ���������� �� ������������ �����
					// !-- ������ --!
					while (!(cin >> arr[i]))
					{
						cout << "�� ����� ������������ ������\n";
						printf_s("a[%d] = ", i);
						// cout << "[" << i << "]" << ": ";
						cin.clear();
						while (cin.get() != '\n');
					}
					// !-- ����� --!
				}
			}
			error = 0;
			break;

		case 2:

			if (error == 1)
			{
				cout << ("������� ��������� ������ (1 ����� ����)\n");
			}
			else
			{
				// ���������� �������� ��������������� ������������� ����� � �������

				for (int i = 0, S = 0, t = 0; i < n;)
				{
					// cout << "S = " << S << endl;
					if (arr[i] > 0)
					{
						S += arr[i], i++;
						t = t++;
					}
					else i++;
					middleA = (double)S / t;
				}

				// ���������� ����� ��������� ������� �� ������������� �������� �������

				max = arr[0];
				for (int i = 0; i < n; i++)
				{
					if (max < arr[i])
					{
						max = arr[i];
						imax = i;
					}
					else if (max == arr[0]) imax = 0;
				}
				for (int i = 0; i < imax; i++)
				{
					sum += arr[i];
				}

				// ����� �������

				printf_s("������� �������������� ����� = %.3f\n", middleA);
				//cout << "������� �������������� ����� = " << middleA << endl;
				//printf_s("������������ ������� ������� = %.0f\n", max);
				//cout << "������������ ������� ������� = " << max << endl;
				printf_s("����� ��������� �� ������������� �������� ������� = %.0f\n", sum);
				//cout << "����� ��������� �� ������������� �������� ������� = " << sum << endl;
				sum = 0;
				middleA = 0;
			}
			break;

		case 3:

			if (error == 1)
			{
				cout << ("������� ��������� ������ (1 ����� ����)\n");
			}
			// ����� ��������� �������

			for (int i = 0; i < n; i++)
			{
				printf_s("a[%d] = %d\n", i, arr[i]);
				//cout << "[" << i << "]" << " = " << arr[i] << endl;
			}
			break;

		case 4:
			break;

		default:
			cout << "�� ������� ����� ����� ����!\n";
			break;
		}

	} while (menu != 4);
	if (arr != NULL)
		delete[] arr;
	system("pause");
	return 0;
}