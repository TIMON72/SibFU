#pragma once

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <iterator>
#include <iomanip>
#include "Dlg1Dlg1.h"
#include "afxcmn.h"

using namespace std;

// ���������� ���� Dlg1s

class Dlg1 : public CDialog
{
	DECLARE_DYNAMIC(Dlg1)

public:
	Dlg1(CWnd* pParent = NULL);   // ����������� �����������
	virtual ~Dlg1();
	struct client
	{
		CString name;
		CString summ;
		CString percent;
		CString date;
		CString debt;
	};
	vector<client> clients;
	

// ������ ����������� ����
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_DLG1 };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // ��������� DDX/DDV
	/// ���������� �-��� ���������� �����
	void Filling();
	/// ���������� �-��� ����������
	static int CALLBACK Compare(LPARAM lparam1, LPARAM lparam2, LPARAM lparamCompare);
	

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButton1();
	CListCtrl list1_ctrl;
	virtual BOOL OnInitDialog();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnHdnItemclickList1(NMHDR *pNMHDR, LRESULT *pResult);
protected:
	int number_of_column; // ����� �������
	bool switch_of_column; // � ����� ������� ������ ���������� ������� (TRUE � FALSE)
};
