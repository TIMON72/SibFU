object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 397
  ClientWidth = 1001
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
    Top = 64
    Width = 217
    Height = 265
    DataSource = DataSource1
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'IDtg'
        ImeName = '\'
        Title.Caption = #1048#1044'_'#1090#1080#1087#1072
        Width = 50
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'tgName'
        Title.Caption = #1053#1072#1079#1074#1072#1085#1080#1077' '#1090#1080#1087#1072' '#1090#1086#1074#1072#1088#1072
        Width = 130
        Visible = True
      end>
  end
  object DBGrid2: TDBGrid
    Left = 231
    Top = 66
    Width = 338
    Height = 265
    DataSource = DataSource2
    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgConfirmDelete, dgCancelOnExit, dgTitleClick, dgTitleHotTrack]
    ReadOnly = True
    TabOrder = 1
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'IDtg'
        Title.Caption = #1048#1044'_'#1090#1080#1087#1072
        Width = 50
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'gcName'
        Title.Caption = #1053#1072#1079#1074#1072#1085#1080#1077' '#1090#1086#1074#1072#1088#1072
        Width = 100
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'gcMeasure'
        Title.Caption = #1045#1076'. '#1080#1079#1084#1077#1088#1077#1085#1080#1103
        Width = 80
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'gcCost'
        Title.Caption = #1062#1077#1085#1072' '#1090#1086#1074#1072#1088#1072
        Width = 70
        Visible = True
      end>
  end
  object DBEdit1: TDBEdit
    Left = 184
    Top = 39
    Width = 122
    Height = 21
    DataField = 'gcName'
    DataSource = DataSource2
    TabOrder = 2
  end
  object DBEdit2: TDBEdit
    Left = 312
    Top = 39
    Width = 74
    Height = 21
    DataField = 'gcMeasure'
    DataSource = DataSource2
    TabOrder = 3
  end
  object DBEdit3: TDBEdit
    Left = 392
    Top = 39
    Width = 66
    Height = 21
    DataField = 'gcCost'
    DataSource = DataSource2
    TabOrder = 4
  end
  object DBLookupComboBox1: TDBLookupComboBox
    Left = 8
    Top = 39
    Width = 170
    Height = 21
    DataField = 'IDtg'
    DataSource = DataSource2
    KeyField = 'IDtg'
    ListField = 'tgName'
    ListSource = DataSource1
    TabOrder = 5
  end
  object InsertButton: TButton
    Left = 8
    Top = 8
    Width = 73
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 6
    OnClick = InsertButtonClick
  end
  object EditButton: TButton
    Left = 87
    Top = 8
    Width = 73
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    TabOrder = 7
    OnClick = EditButtonClick
  end
  object DeleteButton: TButton
    Left = 166
    Top = 8
    Width = 73
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 8
    OnClick = DeleteButtonClick
  end
  object PostButton: TButton
    Left = 245
    Top = 8
    Width = 73
    Height = 25
    Caption = #1047#1072#1087#1086#1084#1085#1080#1090#1100
    TabOrder = 9
    OnClick = PostButtonClick
  end
  object CancelButton: TButton
    Left = 324
    Top = 8
    Width = 73
    Height = 25
    Caption = #1054#1090#1084#1077#1085#1080#1090#1100
    TabOrder = 10
    OnClick = CancelButtonClick
  end
  object DBGrid3: TDBGrid
    Left = 575
    Top = 66
    Width = 418
    Height = 265
    DataSource = DataSource3
    TabOrder = 11
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'tgName'
        Title.Caption = #1053#1072#1079#1074#1072#1085#1080#1077' '#1090#1080#1087#1072' '#1090#1086#1074#1072#1088#1072
        Width = 130
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'gcName'
        Title.Caption = #1053#1072#1079#1074#1072#1085#1080#1077' '#1090#1086#1074#1072#1088#1072
        Width = 95
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'gcMeasure'
        Title.Caption = #1045#1076'. '#1080#1079#1084#1077#1088#1077#1085#1080#1103
        Width = 80
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'gcCost'
        Title.Caption = #1062#1077#1085#1072' '#1090#1086#1074#1072#1088#1072
        Width = 70
        Visible = True
      end>
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
    Left = 944
    Top = 336
  end
  object ADOTable1: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'TypeGoods'
    Left = 24
    Top = 336
  end
  object DataSource1: TDataSource
    DataSet = ADOTable1
    Left = 88
    Top = 336
  end
  object ADOTable2: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    AfterPost = ADOTable2AfterPost
    AfterDelete = ADOTable2AfterDelete
    TableDirect = True
    TableName = 'GoodsCatalog'
    Left = 248
    Top = 336
    object ADOTable2gcName: TWideStringField
      FieldName = 'gcName'
      Size = 50
    end
    object ADOTable2IDtg: TIntegerField
      FieldName = 'IDtg'
    end
    object ADOTable2gcMeasure: TWideStringField
      FieldName = 'gcMeasure'
    end
    object ADOTable2gcCost: TBCDField
      FieldName = 'gcCost'
      Precision = 19
    end
    object ADOTable2IDgc: TAutoIncField
      FieldName = 'IDgc'
      ReadOnly = True
    end
  end
  object DataSource2: TDataSource
    AutoEdit = False
    DataSet = ADOTable2
    Left = 312
    Top = 336
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    AfterScroll = ADOQuery1AfterScroll
    Parameters = <>
    SQL.Strings = (
      'SELECT GC.IDgc, GC.gcName, TG.tgName, GC.gcMeasure, GC.gcCost'
      'FROM GoodsCatalog GC, TypeGoods TG'
      'WHERE GC.IDtg = TG.IDtg'
      'ORDER BY TG.tgName, GC.gcName;')
    Left = 592
    Top = 336
    object ADOQuery1IDgc: TAutoIncField
      FieldName = 'IDgc'
      ReadOnly = True
    end
    object ADOQuery1gcName: TWideStringField
      FieldName = 'gcName'
      Size = 50
    end
    object ADOQuery1tgName: TWideStringField
      FieldName = 'tgName'
      Size = 50
    end
    object ADOQuery1gcMeasure: TWideStringField
      FieldName = 'gcMeasure'
    end
    object ADOQuery1gcCost: TBCDField
      FieldName = 'gcCost'
      Precision = 19
    end
  end
  object DataSource3: TDataSource
    DataSet = ADOQuery1
    Left = 656
    Top = 336
  end
end
