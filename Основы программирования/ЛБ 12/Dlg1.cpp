// Dlg1.cpp: файл реализации
//

#include "stdafx.h"
#include "MFCApplication1.h"
#include "Dlg1.h"
#include "afxdialogex.h"


// диалоговое окно Dlg1

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


// обработчики сообщений Dlg1

/// Заполнение таблицы столбцами
BOOL Dlg1::OnInitDialog()
{
	CDialog::OnInitDialog();
	list1_ctrl.InsertColumn(0, L"ФИО", LVCFMT_LEFT, 200);
	list1_ctrl.InsertColumn(1, L"Сумма кредита", LVCFMT_LEFT, 100);
	list1_ctrl.InsertColumn(2, L"Процентная ставка в год", LVCFMT_LEFT, 150);
	list1_ctrl.InsertColumn(3, L"Срок кредита", LVCFMT_LEFT, 100);
	list1_ctrl.InsertColumn(4, L"Сумма выплаты", LVCFMT_LEFT, 100);
	return TRUE;  // return TRUE unless you set the focus to a control
				  // Исключение: страница свойств OCX должна возвращать значение FALSE
}

/// Добавление клиента при нажатии "Добавить клиента" 
void Dlg1::OnBnClickedButton1()
{
	Dlg1Dlg1 dlg1dlg1;
	if (dlg1dlg1.DoModal() == IDOK) // Вызов окна для заполнения данных о клиенте
	{
		client *newclient = new client; // или Dlg1::client
		newclient->name = dlg1dlg1.buf_name;
		newclient->summ = dlg1dlg1.buf_summ;
		newclient->percent = dlg1dlg1.buf_percent;
		newclient->date = dlg1dlg1.buf_date;
		// Расчет суммы долга клиента за срок
		int x = _wtoi(dlg1dlg1.buf_summ);
		int y = _wtoi(dlg1dlg1.buf_percent);
		float z = (float)_wtoi(dlg1dlg1.buf_date);
		double result = x + ((0.01 * y) * x) * z;
		CString buf_debt;
		buf_debt.Format(_T("%.0f"), result);
		newclient->debt = buf_debt; // _T() для Unicode
		clients.push_back(*newclient); // Добавление клиента в список
		Filling(); // Добавление клиента в таблицу
	}
}

/// Редактирование клиента при нажатии кнопки "Редактировать"
void Dlg1::OnBnClickedButton2()
{
	Dlg1Dlg1 dlg1dlg1;
	if (list1_ctrl.GetSelectedCount() == NULL)
	{
		MessageBox(L"Вы не выбрали клиента для редактирования", L"Предупреждение",
			MB_OK | MB_ICONWARNING);
		return;
	}
	POSITION selected_client = list1_ctrl.GetFirstSelectedItemPosition(); // получаем позицию выбранного клиента
	if (selected_client != NULL) // Если получили позицию
	{
		int i = list1_ctrl.GetNextSelectedItem(selected_client); // получаем индекс клиента
		// Автозаполнение окна редактирования текущими параметрами клиента
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
			// Расчет суммы долга клиента за срок
			int x = _wtoi(dlg1dlg1.buf_summ);
			int y = _wtoi(dlg1dlg1.buf_percent);
			float z = (float)_wtoi(dlg1dlg1.buf_date);
			double result = x + ((0.01 * y) * x) * z;
			CString buf_debt;
			buf_debt.Format(_T("%.0f"), result); // _T() для Unicode
			clients[i].debt = buf_debt;
			Filling(); // Изменение данных клиента в таблице
		}
	}
}

/// Удаление клиента при нажатии кнопки "Удалить"
void Dlg1::OnBnClickedButton3()
{
	Dlg1Dlg1 dlg1dlg1;
	if (list1_ctrl.GetSelectedCount() == NULL)
	{
		MessageBox(L"Вы не выбрали клиента для удаления", L"Предупреждение",
			MB_OK | MB_ICONWARNING);
		return;
	}
	POSITION selected_client = list1_ctrl.GetFirstSelectedItemPosition(); // получаем позицию выбранного клиента
	if (selected_client != NULL)
	{
		int i = list1_ctrl.GetNextSelectedItem(selected_client);
		// Удаление клиента из списка
		clients.erase(clients.begin() + i); // через итератор удаляем нужный элемент списка
		// Удаление клиента из таблицы
		list1_ctrl.DeleteItem(i);
	}
}

/// Событие при щелчке по заголовку колонки таблицы
void Dlg1::OnHdnItemclickList1(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMHEADER phdr = reinterpret_cast<LPNMHEADER>(pNMHDR);
	// Переключение сортировок
	if (switch_of_column == FALSE)
	{
		number_of_column = phdr->iItem; // Номеру колонки присваиваем выбранную колонку в таблице
		switch_of_column = TRUE;
	}
	else if (switch_of_column == TRUE)
	{
		number_of_column = phdr->iItem; // Номеру колонки присваиваем выбранную колонку в таблице
		switch_of_column = FALSE;
	}
	// Сортировка
	list1_ctrl.SortItems(Compare, (DWORD_PTR) this);
	*pResult = 0;
}
/// Ф-ция сортировки
int CALLBACK Dlg1::Compare(LPARAM lparam1, LPARAM lparam2, LPARAM lparamCompare)
{
	client* client1 = (client*)lparam1; // клиент a
	client* client2 = (client*)lparam2; // клиент b
	Dlg1* pointer = (Dlg1*)lparamCompare; // указатель на экземпляр класса

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

/// Заполнение таблицы
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
		list1_ctrl.SetItemData(i, (DWORD_PTR)&clients[i]); //  Делаем указатели для каждого клиента
	}
}
