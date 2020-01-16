object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 299
  ClientWidth = 1017
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 320
    Height = 233
    DataSource = DataSource1
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object DBGrid2: TDBGrid
    Left = 334
    Top = 8
    Width = 251
    Height = 233
    DataSource = DataSource2
    TabOrder = 1
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object DBGrid3: TDBGrid
    Left = 591
    Top = 8
    Width = 330
    Height = 233
    DataSource = DataSource3
    TabOrder = 2
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object ADOConnection1: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Cloud Drivers\On' +
      'eDrive\'#1058#1041#1044'\'#1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1099#1077' '#1088#1072#1073#1086#1090#1099'\'#1051#1056'1\DBAccess\Database11.mdb;Persi' +
      'st Security Info=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 952
    Top = 8
  end
  object ADOTable1: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'TypeGoods'
    Left = 24
    Top = 248
  end
  object DataSource1: TDataSource
    DataSet = ADOTable1
    Left = 88
    Top = 248
  end
  object ADOTable2: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'IDtg'
    MasterFields = 'IDtg'
    MasterSource = DataSource1
    TableName = 'GoodsCatalog'
    Left = 352
    Top = 248
  end
  object DataSource2: TDataSource
    DataSet = ADOTable2
    Left = 416
    Top = 248
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    DataSource = DataSource1
    Parameters = <
      item
        Name = 'IDtg'
        Attributes = [paNullable]
        DataType = ftInteger
        NumericScale = 255
        Precision = 255
        Value = 1
      end>
    SQL.Strings = (
      'SELECT GC.IDgc, GC.gcName, TG.tgName, GC.gcMeasure, GC.gcCost'
      'FROM GoodsCatalog GC, TypeGoods TG'
      'WHERE GC.IDtg = TG.IDtg AND GC.IDtg = :IDtg'
      'ORDER BY TG.tgName, GC.gcName;')
    Left = 608
    Top = 248
  end
  object DataSource3: TDataSource
    DataSet = ADOQuery1
    Left = 672
    Top = 248
  end
end
