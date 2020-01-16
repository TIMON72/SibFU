#include "..\Header\Header.h"

/// �������� ���� ������ (���� 1)
void structuring(client*& clients, string* str, int& n)
{
	// ������� ������������ ������ ��� �������� ���� struct
	if (clients != NULL)
		delete[]clients;
	clients = new client[n];

	// ������� �������� ���� ������ ��� ��������������
	string* str_buf = NULL;
	if (str_buf != NULL)
		delete[]str_buf;
	str_buf = new string[n];
	for (int i = 0; i < n; i++)
	{
		str_buf[i] = str[i];
	}

	// �������� ��������������
	for (int i = 0; i < n; i++)
	{
		int pos, br;

		// ���
		br = 1;
		while (br != 0)
		{
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// �������� � name ���
			if (str_buf[i].find(' ') < str_buf[i].find('|'))
			{
				pos = str_buf[i].find(' ');
				if (clients[i].name == "")
				{
					clients[i].name = str_buf[i].substr(0, pos);
				}
				else
				{
					clients[i].name = clients[i].name + ' ' + str_buf[i].substr(0, pos);
				}
				str_buf[i].replace(0, pos, "");
			}
			else
			{
				pos = str_buf[i].find('|');
				clients[i].name = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|'); // ���������� br == 0? �� -> ��������� ����
		}
		str_buf[i].replace(0, 1, ""); // ���������� "|"

									  // ����� �������
		br = 1;
		while (br != 0)
		{
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// �������� � summ ����� �������
			if (str_buf[i].find(' ') < str_buf[i].find('|'))
			{
				pos = str_buf[i].find(' ');
				clients[i].credit.summ = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			else
			{
				pos = str_buf[i].find('|');
				clients[i].credit.summ = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|');
		}
		str_buf[i].replace(0, 1, ""); // ���������� "|"

									  // ����� �������
		br = 1;
		while (br != 0)
		{
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}
			// �������� � percent ���������� ������ �������
			if (str_buf[i].find(' ') < str_buf[i].find('|'))
			{
				pos = str_buf[i].find(' ');
				clients[i].credit.percent = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			else
			{
				pos = str_buf[i].find('|');
				clients[i].credit.percent = str_buf[i].substr(0, pos);
				str_buf[i].replace(0, pos, "");
			}
			// ������� ��������
			pos = str_buf[i].find(' ');
			while (pos == 0)
			{
				str_buf[i].replace(0, pos + 1, "");
				pos = str_buf[i].find(' ');
			}

			br = str_buf[i].find('|');
		}
		str_buf[i].replace(0, 1, ""); // ���������� "|"

									  // ���� �������
									  // ������� ��������
		pos = str_buf[i].find(' ');
		while (pos == 0)
		{
			str_buf[i].replace(0, pos + 1, "");
			pos = str_buf[i].find(' ');
		}
		// �������� � time ���� �������
		if (str_buf[i].find(' ') < str_buf[i].find('|'))
		{
			pos = str_buf[i].find(' ');
			clients[i].credit.time = str_buf[i].substr(0, pos);
			str_buf[i].replace(0, pos, "");
		}
		else
		{
			pos = str_buf[i].find('|');
			clients[i].credit.time = str_buf[i].substr(0, pos);
			str_buf[i].replace(0, pos, "");
		}
		// ������� ��������
		pos = str_buf[i].find(' ');
		while (pos == 0)
		{
			str_buf[i].replace(0, pos + 1, "");
			pos = str_buf[i].find(' ');
		}

		// �����, ������� ������ ��������� ������ �� ���� �������
		int x = stoi(clients[i].credit.summ);
		int y = stoi(clients[i].credit.percent);
		float z = stof(clients[i].credit.time);
		clients[i].credit.debt = x + ((0.01 * y) * x) * z;
	}

	// ������� ��������� �������
	if (str_buf != NULL)
		delete[]str_buf;
}