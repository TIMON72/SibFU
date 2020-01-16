
// Dlg.cpp : ���� ����������
//

#include "stdafx.h"
#include "�� 9.h"
#include "Dlg.h"
#include "afxdialogex.h"
#include <C:\Users\TIMON_Dark\OneDrive\Google Drive\Study\������ ����������������\���������\������������ ������\�� 9\Button3\Header\Button3.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// ���������� ���� CAboutDlg ������������ ��� �������� �������� � ����������

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

	// ������ ����������� ����
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // ��������� DDX/DDV

// ����������
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// ���������� ���� Dlg



Dlg::Dlg(CWnd* pParent /*=NULL*/)
	: CDialog(IDD_MY9_DIALOG, pParent)
	, nameFileIn(_T(""))
	, nameFileOut(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, nameFileIn);
	DDX_Text(pDX, IDC_EDIT2, nameFileOut);
}

BEGIN_MESSAGE_MAP(Dlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_EN_CHANGE(IDC_EDIT1, &Dlg::OnEnChangeEdit1)
	ON_EN_CHANGE(IDC_EDIT2, &Dlg::OnEnChangeEdit2)
	ON_BN_CLICKED(IDC_BUTTON1, &Dlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &Dlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &Dlg::OnBnClickedButton3)
END_MESSAGE_MAP()


// ����������� ��������� Dlg

BOOL Dlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// ���������� ������ "� ���������..." � ��������� ����.

	// IDM_ABOUTBOX ������ ���� � �������� ��������� �������.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// ������ ������ ��� ����� ����������� ����.  ����� ������ ��� �������������,
	//  ���� ������� ���� ���������� �� �������� ����������
	SetIcon(m_hIcon, TRUE);			// ������� ������
	SetIcon(m_hIcon, FALSE);		// ������ ������

	// TODO: �������� �������������� �������������

	return TRUE;  // ������� �������� TRUE, ���� ����� �� ������� �������� ����������
}

void Dlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// ��� ���������� ������ ����������� � ���������� ���� ����� ��������������� ����������� ���� �����,
//  ����� ���������� ������.  ��� ���������� MFC, ������������ ������ ���������� ��� �������������,
//  ��� ������������� ����������� ������� ��������.

void Dlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // �������� ���������� ��� ���������

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// ������������ ������ �� ������ ����������� ��������������
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// ��������� ������
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// ������� �������� ��� ������� ��� ��������� ����������� ������� ��� �����������
//  ���������� ����.
HCURSOR Dlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void Dlg::OnEnChangeEdit1()
{
	// TODO:  ���� ��� ������� ���������� RICHEDIT, �� ������� ���������� �� �����
	// send this notification unless you override the CDialog::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.

	// TODO:  �������� ��� �������� ����������
}


void Dlg::OnEnChangeEdit2()
{
	// TODO:  ���� ��� ������� ���������� RICHEDIT, �� ������� ���������� �� �����
	// send this notification unless you override the CDialog::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.

	// TODO:  �������� ��� �������� ����������
}


void Dlg::OnBnClickedButton1()
{
	CFileDialog dlg(TRUE);
	if (dlg.DoModal() == IDOK)
	{
		nameFileIn = dlg.GetPathName();
		UpdateData(FALSE);
	}
}


void Dlg::OnBnClickedButton2()
{
	CFileDialog dlg(FALSE);
	if (dlg.DoModal() == IDOK)
	{
		nameFileOut = dlg.GetPathName();
		UpdateData(FALSE);
	}
}


void Dlg::OnBnClickedButton3()
{
	UpdateData(TRUE);
	if (!perform(nameFileIn, nameFileOut))
	{
		MessageBox(L"��������� ������ ����������� � �������", L"���������", MB_OK | MB_ICONERROR);
	}
	else
	{
		MessageBox(L"����� ����������", L"���������", MB_OK | MB_ICONINFORMATION);
	}
}

bool Dlg::perform(CString nameFileIn, CString nameFileOut)
{
	vector<string> vecStr;
	/// �������� �����
	if (!open_file(vecStr, nameFileIn))
	{
		CString message;
		message.Format(L"������ ��� �������� ����� ������ %s", nameFileIn);
		MessageBox(message, L"������", MB_OK | MB_ICONERROR);
		return FALSE;
	}
	/// ���������� �� � �� �
	sort_down(vecStr);
	/// ������ � ����
	if (!rewriting(vecStr, nameFileOut))
	{
		CString message;
		message.Format(L"������ ��� �������� ����� ������ %s", nameFileOut);
		MessageBox(message, L"������", MB_OK | MB_ICONERROR);
		return FALSE;
	}
	return TRUE;
}
