#include <iostream>
#include <time.h>
#include <iomanip>

using namespace std;

int main()
{
	setlocale(0, "");
	int n = 0, m = 0, menu, error = 1, min, max, jmin, jmax;
	int **arr = NULL; // ������ ��������� "������� ������"
	char ch;
	
	do
	{
		cout << "\n>>>>>>>>>><<<<<<<<<<";
		cout << "\n>>>>>>> ���� <<<<<<<\n";
		cout << "1. ���� ��������� �������\n";
		cout << "2. ��������� �������\n";
		cout << "3. ����� ������� �� �����\n";
		cout << "4. �����\n";
		cout << ">>>>>>>>>><<<<<<<<<<\n\n";
		cout << "������� ����� ����: ";
		while (!(cin >> menu))
		{
			cout << "�� ����� ������������ ������\n";
			cout << "������� ����� ����: ";
			cin.clear();
			while (cin.get() != '\n');
		}
		
		switch (menu)
		{
		case 1:

			// ������� ������ �������

			if (arr != NULL)
			{
				for (int i = 0; i < n; i++)
				{
					delete[]arr[i];
				}
				delete[]arr;
			}
			
			// ���� ������� �������

			cout << "������� ������ ������� (���������� ����� � ��������): ";
			while (!(cin >> n >> m) || n < 0 || m < 0)
			{
				cout << "�� ����� ������������ ������\n";
				cout << "������� ������ �������: ";
				cin.clear();
				while (cin.get() != '\n');
			}
			
			
			// ��������� ������ ��� ������
			
			arr = new int*[n]; // �������� ������ � �������� ���������
			for (int i = 0; i<n; i++)
			{
				arr[i] = new int[m];
			}

			// ����� ��������������� ��� ������� �����
			
			cout << "�� ������ ��������������� �������������� ������? (y/n): "; cin >> ch;
			while (ch != 'y' && ch != 'n')
			{
				cout << "�� ����� ������������ ������\n";
				cout << "�� ������ ��������������� �������������� ������? (y/n): "; cin >> ch;
				cin.clear();
				while (cin.get() != '\n');
			}
			
			// �������������� ���������� �������

			if (ch == 'y')
			{
				srand((unsigned int)time(NULL)); // ��� ��������� �����
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						arr[i][j] = (int)-50 + rand() % 100;
					}
				}
			}

			// ������ ���������� �������

			if (ch == 'n')
			{
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						printf_s("a[%d, %d] = ", i, j);
						while (!(cin >> arr[i][j]))
						{
							cout << "�� ����� ������������ ������\n";
							printf_s("a[%d, %d] = ", i, j);
							cin.clear();
							while (cin.get() != '\n');
						}
					}
				}
			}
			error = 0;
			break;

		case 2:

			if (error == 1)
			{
				cout << ("������� ��������� ������ (1 ����� ����)\n");
			}

			// ����� ������������� � ������������ �������� ������, ������������ ������������ � ������������� �������� ������

			for (int i = 0; i < n; i++)
			{
				min = arr[i][0];
				max = arr[i][0];
				jmin = 0;
				jmax = 0;
				for (int j = 0; j < m; j++)
				{
					if (arr[i][j] < min)
					{
						min = arr[i][j];
						jmin = j;
					}
					if (arr[i][j] > max)
					{
						max = arr[i][j];
						jmax = j;
					}
				}

				// ������������ ������� ������������ (jmin) � ������������� (jmax) �������� ������

				int a = arr[i][jmin];
				int b = arr[i][jmax];
				arr[i][jmin] = b;
				arr[i][jmax] = a;
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
				for (int j = 0; j < m; j++)
				{
					cout << setw(4) << arr[i][j];
				}
				cout << endl;
			}
			break;

		case 4: 
			break;
		
		default:
			cout << "�� ������� ����� ����� ����!\n";
			break;
		}

	} while (menu != 4);
	
	// ������� ������ �������

	if (arr != NULL)
	{
		for (int i = 0; i < n; i++) 
		{
			delete[]arr[i];
		}
		delete[]arr;
	}

	// ���� ������ �� �����
	
	return 0;
}