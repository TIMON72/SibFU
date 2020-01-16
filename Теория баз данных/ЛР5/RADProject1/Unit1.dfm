object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 573
  ClientWidth = 1037
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 1021
    Height = 248
    DataSource = DataSource1
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    OnCellClick = DBGrid1CellClick
  end
  object ButtonSelect: TButton
    Left = 8
    Top = 262
    Width = 75
    Height = 25
    Caption = 'Select'
    TabOrder = 1
    OnClick = ButtonSelectClick
  end
  object ButtonInsert: TButton
    Left = 8
    Top = 324
    Width = 75
    Height = 25
    Caption = 'Insert'
    TabOrder = 2
    OnClick = ButtonInsertClick
  end
  object ButtonDelete: TButton
    Left = 89
    Top = 324
    Width = 75
    Height = 25
    Caption = 'Delete'
    TabOrder = 3
    OnClick = ButtonDeleteClick
  end
  object ButtonUpdate: TButton
    Left = 170
    Top = 324
    Width = 75
    Height = 25
    Caption = 'Update'
    TabOrder = 4
    OnClick = ButtonUpdateClick
  end
  object EditName: TEdit
    Left = 8
    Top = 297
    Width = 75
    Height = 21
    TabOrder = 5
    Text = 'Name'
  end
  object EditType: TEdit
    Left = 89
    Top = 297
    Width = 75
    Height = 21
    TabOrder = 6
    Text = 'Type'
  end
  object EditMeasure: TEdit
    Left = 170
    Top = 297
    Width = 75
    Height = 21
    TabOrder = 7
    Text = 'Measure'
  end
  object EditCost: TEdit
    Left = 251
    Top = 297
    Width = 75
    Height = 21
    TabOrder = 8
    Text = 'Cost'
  end
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=MSDASQL.1;Persist Security Info=True;User ID=root;Exten' +
      'ded Properties="Driver=MySQL ODBC 5.1 Driver;SERVER=localhost;UI' +
      'D=root;DATABASE=mydatabase;PORT=3306;COLUMN_SIZE_S32=1";Initial ' +
      'Catalog=mydatabase'
    DefaultDatabase = 'mydatabase'
    LoginPrompt = False
    Provider = 'MSDASQL.1'
    Left = 32
    Top = 528
  end
  object ADOQuery1: TADOQuery
    Connection = ADOConnection1
    Parameters = <>
    Left = 112
    Top = 528
  end
  object DataSource1: TDataSource
    DataSet = ADOQuery1
    Left = 184
    Top = 528
  end
end
