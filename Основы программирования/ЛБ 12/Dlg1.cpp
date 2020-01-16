// Dlg1.cpp: ���� ����������
//

#include "stdafx.h"
#include "MFCApplication1.h"
#include "Dlg1.h"
#include "afxdialogex.h"


// ���������� ���� Dlg1

IMPLEMENT_DYNAMIC(Dlg1, CDialog)

Dlg1::Dlg1(CWnd* pParent /*=NULL*/)
	: CDialog(IDD_DLG1, pParent)
{
	number_of_column = 0;
	switch_of_column = FALSE;
}

Dlg1::~Dlg1()
{
}

void Dlg1::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST1, list1_ctrl);
}


BEGIN_MESSAGE_MAP(Dlg1, CDialog)
	ON_BN_CLICKED(IDC_BUTTON1, &Dlg1::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &Dlg1::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &Dlg1::OnBnClickedButton3)
	ON_NOTIFY(HDN_ITEMCLICK, 0, &Dlg1::OnHdnItemclickList1)
END_MESSAGE_MAP()


// ����������� ��������� Dlg1

/// ���������� ������� ���������
BOOL Dlg1::OnInitDialog()
{
	CDialog::OnInitDialog();
	list1_ctrl.InsertColumn(0, L"���", LVCFMT_LEFT, 200);
	list1_ctrl.InsertColumn(1, L"����� �������", LVCFMT_LEFT, 100);
	list1_ctrl.InsertColumn(2, L"���������� ������ � ���", LVCFMT_LEFT, 150);
	list1_ctrl.InsertColumn(3, L"���� �������", LVCFMT_LEFT, 100);
	list1_ctrl.InsertColumn(4, L"����� �������", LVCFMT_LEFT, 100);
	return TRUE;  // return TRUE unless you set the focus to a control
				  // ����������: �������� ������� OCX ������ ���������� �������� FALSE
}

/// ���������� ������� ��� ������� "�������� �������" 
void Dlg1::OnBnClickedButton1()
{
	Dlg1Dlg1 dlg1dlg1;
	if (dlg1dlg1.DoModal() == IDOK) // ����� ���� ��� ���������� ������ � �������
	{
		client *newclient = new client; // ��� Dlg1::client
		newclient->name = dlg1dlg1.buf_name;
		newclient->summ = dlg1dlg1.buf_summ;
		newclient->percent = dlg1dlg1.buf_percent;
		newclient->date = dlg1dlg1.buf_date;
		// ������ ����� ����� ������� �� ����
		int x = _wtoi(dlg1dlg1.buf_summ);
		int y = _wtoi(dlg1dlg1.buf_percent);
		float z = (float)_wtoi(dlg1dlg1.buf_date);
		double result = x + ((0.01 * y) * x) * z;
		CString buf_debt;
		buf_debt.Format(_T("%.0f"), result);
		newclient->debt = buf_debt; // _T() ��� Unicode
		clients.push_back(*newclient); // ���������� ������� � ������
		Filling(); // ���������� ������� � �������
	}
}

/// �������������� ������� ��� ������� ������ "�������������"
void Dlg1::OnBnClickedButton2()
{
	Dlg1Dlg1 dlg1dlg1;
	if (list1_ctrl.GetSelectedCount() == NULL)
	{
		MessageBox(L"�� �� ������� ������� ��� ��������������", L"��������������",
			MB_OK | MB_ICONWARNING);
		return;
	}
	POSITION selected_client = list1_ctrl.GetFirstSelectedItemPosition(); // �������� ������� ���������� �������
	if (selected_client != NULL) // ���� �������� �������
	{
		int i = list1_ctrl.GetNextSelectedItem(selected_client); // �������� ������ �������
		// �������������� ���� �������������� �������� ����������� �������
		dlg1dlg1.buf_name = clients[i].name;
		dlg1dlg1.buf_summ = clients[i].summ;
		dlg1dlg1.buf_percent = clients[i].percent;
		dlg1dlg1.buf_date = clients[i].date;

		if (dlg1dlg1.DoModal() == IDOK)
		{
			clients[i].name = dlg1dlg1.buf_name;
			clients[i].summ = dlg1dlg1.buf_summ;
			clients[i].percent = dlg1dlg1.buf_percent;
			clients[i].date = dlg1dlg1.buf_date;
			// ������ ����� ����� ������� �� ����
			int x = _wtoi(dlg1dlg1.buf_summ);
			int y = _wtoi(dlg1dlg1.buf_percent);
			float z = (float)_wtoi(dlg1dlg1.buf_date);
			double result = x + ((0.01 * y) * x) * z;
			CString buf_debt;
			buf_debt.Format(_T("%.0f"), result); // _T() ��� Unicode
			clients[i].debt = buf_debt;
			Filling(); // ��������� ������ ������� � �������
		}
	}
}

/// �������� ������� ��� ������� ������ "�������"
void Dlg1::OnBnClickedButton3()
{
	Dlg1Dlg1 dlg1dlg1;
	if (list1_ctrl.GetSelectedCount() == NULL)
	{
		MessageBox(L"�� �� ������� ������� ��� ��������", L"��������������",
			MB_OK | MB_ICONWARNING);
		return;
	}
	POSITION selected_client = list1_ctrl.GetFirstSelectedItemPosition(); // �������� ������� ���������� �������
	if (selected_client != NULL)
	{
		int i = list1_ctrl.GetNextSelectedItem(selected_client);
		// �������� ������� �� ������
		clients.erase(clients.begin() + i); // ����� �������� ������� ������ ������� ������
		// �������� ������� �� �������
		list1_ctrl.DeleteItem(i);
	}
}

/// ������� ��� ������ �� ��������� ������� �������
void Dlg1::OnHdnItemclickList1(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMHEADER phdr = reinterpret_cast<LPNMHEADER>(pNMHDR);
	// ������������ ����������
	if (switch_of_column == FALSE)
	{
		number_of_column = phdr->iItem; // ������ ������� ����������� ��������� ������� � �������
		switch_of_column = TRUE;
	}
	else if (switch_of_column == TRUE)
	{
		number_of_column = phdr->iItem; // ������ ������� ����������� ��������� ������� � �������
		switch_of_column = FALSE;
	}
	// ����������
	list1_ctrl.SortItems(Compare, (DWORD_PTR) this);
	*pResult = 0;
}
/// �-��� ����������
int CALLBACK Dlg1::Compare(LPARAM lparam1, LPARAM lparam2, LPARAM lparamCompare)
{
	client* client1 = (client*)lparam1; // ������ a
	client* client2 = (client*)lparam2; // ������ b
	Dlg1* pointer = (Dlg1*)lparamCompare; // ��������� �� ��������� ������

	int result = 0;
	switch (pointer->number_of_column)
	{
	case 0:
	{
		result = client1->name.Compare(client2->name);
		break;
	}
	case 1:
	{
		if (_wtoi(client1->summ) > _wtoi(client2->summ))
		{
			result = 1;
		}
		else if (_wtoi(client1->summ) < _wtoi(client2->summ))
		{
			result = -1;
		}
		else if (_wtoi(client1->summ) == _wtoi(client2->summ))
		{
			result = 0;
		}
		break;
	}
	case 2:
	{
		if (_wtoi(client1->percent) > _wtoi(client2->percent))
		{
			result = 1;
		}
		else if (_wtoi(client1->percent) < _wtoi(client2->percent))
		{
			result = -1;
		}
		else if (_wtoi(client1->percent) == _wtoi(client2->percent))
		{
			result = 0;
		}
		break;
	}
	case 3:
	{
		if (_wtoi(client1->date) > _wtoi(client2->date))
		{
			result = 1;
		}
		else if (_wtoi(client1->date) < _wtoi(client2->date))
		{
			result = -1;
		}
		else if (_wtoi(client1->date) == _wtoi(client2->date))
		{
			result = 0;
		}
		break;
	}
	case 4:
	{
		if (_wtoi(client1->debt) > _wtoi(client2->debt))
		{
			result = 1;
		}
		else if (_wtoi(client1->debt) < _wtoi(client2->debt))
		{
			result = -1;
		}
		else if (_wtoi(client1->debt) == _wtoi(client2->debt))
		{
			result = 0;
		}
		break;
	}
	}
	if (pointer->switch_of_column == FALSE)
	{
		result = result * -1;
	}
	return result;
}

/// ���������� �������
void Dlg1::Filling()
{
	list1_ctrl.DeleteAllItems();
	for (int i = 0; i < (int)clients.size(); i++)
	{
		list1_ctrl.InsertItem(i, clients[i].name, -1);
		list1_ctrl.SetItemText(i, 1, clients[i].summ);
		list1_ctrl.SetItemText(i, 2, clients[i].percent);
		list1_ctrl.SetItemText(i, 3, clients[i].date);
		list1_ctrl.SetItemText(i, 4, clients[i].debt);
		list1_ctrl.SetItemData(i, (DWORD_PTR)&clients[i]); //  ������ ��������� ��� ������� �������
	}
}
