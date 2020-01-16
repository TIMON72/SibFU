#pragma once

#include "Dlg1.h"

// диалоговое окно Dlg1Dlg1

class Dlg1Dlg1 : public CDialog
{
	DECLARE_DYNAMIC(Dlg1Dlg1)

public:
	Dlg1Dlg1(CWnd* pParent = NULL);   // стандартный конструктор
	virtual ~Dlg1Dlg1();

// Данные диалогового окна
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_DLG1DLG1 };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // поддержка DDX/DDV

	DECLARE_MESSAGE_MAP()
public:
	CString buf_name;
	CString buf_summ;
	CString buf_percent;
	CString buf_date;
};
