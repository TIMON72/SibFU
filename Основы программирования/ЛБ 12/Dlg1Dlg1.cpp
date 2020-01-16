// Dlg1Dlg1.cpp: файл реализации
//

#include "stdafx.h"
#include "MFCApplication1.h"
#include "Dlg1Dlg1.h"
#include "afxdialogex.h"


// диалоговое окно Dlg1Dlg1

IMPLEMENT_DYNAMIC(Dlg1Dlg1, CDialog)

Dlg1Dlg1::Dlg1Dlg1(CWnd* pParent /*=NULL*/)
	: CDialog(IDD_DLG1DLG1, pParent)
	, buf_name(_T(""))
	, buf_summ(_T(""))
	, buf_percent(_T(""))
	, buf_date(_T(""))
{

}

Dlg1Dlg1::~Dlg1Dlg1()
{
}

void Dlg1Dlg1::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, buf_name);
	DDX_Text(pDX, IDC_EDIT2, buf_summ);
	DDX_Text(pDX, IDC_EDIT3, buf_percent);
	DDX_Text(pDX, IDC_EDIT4, buf_date);
}


BEGIN_MESSAGE_MAP(Dlg1Dlg1, CDialog)

END_MESSAGE_MAP()
