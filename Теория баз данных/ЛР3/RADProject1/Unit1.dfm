object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 451
  ClientWidth = 792
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnDeactivate = FormDeactivate
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 792
    Height = 371
    Align = alClient
    Caption = 'Panel1'
    TabOrder = 0
    ExplicitHeight = 377
    object DBGrid1: TDBGrid
      Left = 1
      Top = 1
      Width = 790
      Height = 303
      Align = alClient
      DataSource = DataModule2.DS_Q_IncomingGoodsD
      Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgConfirmDelete, dgCancelOnExit, dgTitleClick, dgTitleHotTrack]
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
      Columns = <
        item
          Expanded = False
          FieldName = 'IDig'
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'IDgc'
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'gcName'
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'igDate'
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'igAmount'
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'scName'
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'Cost'
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'TotalCost'
          Visible = True
        end>
    end
    object Panel2: TPanel
      Left = 1
      Top = 304
      Width = 790
      Height = 66
      Align = alBottom
      Caption = 'Panel2'
      ShowCaption = False
      TabOrder = 1
      ExplicitTop = 338
      object DBText1: TDBText
        Left = 455
        Top = 6
        Width = 65
        Height = 17
        DataField = 'Cost'
        DataSource = DataModule2.DS_Q_IncomingGoodsD
      end
      object ButtonGotoBookmark: TButton
        Left = 120
        Top = 36
        Width = 114
        Height = 25
        Caption = #1055#1077#1088#1077#1081#1090#1080' '#1082' '#1079#1072#1082#1083#1072#1076#1082#1077
        TabOrder = 0
        OnClick = ButtonGotoBookmarkClick
      end
      object ButtonGetBookmark: TButton
        Left = 8
        Top = 36
        Width = 106
        Height = 25
        Caption = #1057#1086#1079#1076#1072#1090#1100' '#1079#1072#1082#1083#1072#1076#1082#1091
        TabOrder = 1
        OnClick = ButtonGetBookmarkClick
      end
      object ButtonFreeBookmark: TButton
        Left = 240
        Top = 36
        Width = 114
        Height = 25
        Caption = #1054#1095#1080#1089#1090#1080#1090#1100' '#1079#1072#1082#1083#1072#1076#1082#1091
        TabOrder = 2
        OnClick = ButtonFreeBookmarkClick
      end
      object ButtonFirstRecord: TButton
        Left = 8
        Top = 5
        Width = 97
        Height = 25
        Caption = #1055#1077#1088#1074#1072#1103' '#1079#1072#1087#1080#1089#1100
        TabOrder = 3
        OnClick = ButtonFirstRecordClick
      end
      object ButtonLastRecord: TButton
        Left = 111
        Top = 5
        Width = 106
        Height = 25
        Caption = #1055#1086#1089#1083#1077#1076#1085#1103#1103' '#1079#1072#1087#1080#1089#1100
        TabOrder = 4
        OnClick = ButtonLastRecordClick
      end
      object ButtonNextRecord: TButton
        Left = 223
        Top = 5
        Width = 106
        Height = 25
        Caption = #1057#1083#1077#1076#1091#1102#1097#1072#1103' '#1079#1072#1087#1080#1089#1100
        TabOrder = 5
        OnClick = ButtonNextRecordClick
      end
      object ButtonPreviousRecord: TButton
        Left = 335
        Top = 5
        Width = 114
        Height = 25
        Caption = #1055#1088#1077#1076#1099#1076#1091#1097#1072#1103' '#1079#1072#1087#1080#1089#1100
        TabOrder = 6
        OnClick = ButtonPreviousRecordClick
      end
    end
  end
  object PanelInsertEditDelete: TPanel
    Left = 0
    Top = 371
    Width = 792
    Height = 39
    Align = alBottom
    Caption = 'PanelInsertEditDelete'
    ShowCaption = False
    TabOrder = 1
    ExplicitLeft = -1
    ExplicitTop = 364
    object ButtonInsert: TButton
      Left = 9
      Top = 6
      Width = 75
      Height = 25
      Caption = #1042#1089#1090#1072#1074#1080#1090#1100
      TabOrder = 0
      OnClick = ButtonInsertClick
    end
    object ButtonEdit: TButton
      Left = 90
      Top = 6
      Width = 75
      Height = 25
      Caption = #1048#1079#1084#1077#1085#1080#1090#1100
      TabOrder = 1
      OnClick = ButtonEditClick
    end
    object ButtonDelete: TButton
      Left = 171
      Top = 6
      Width = 75
      Height = 25
      Caption = #1059#1076#1072#1083#1080#1090#1100
      TabOrder = 2
      OnClick = ButtonDeleteClick
    end
  end
  object PanelToInputValues: TPanel
    Left = 0
    Top = 410
    Width = 792
    Height = 41
    Align = alBottom
    Caption = 'PanelToInputValues'
    ShowCaption = False
    TabOrder = 2
    Visible = False
    ExplicitTop = 400
    object DBLookupComboBox1: TDBLookupComboBox
      AlignWithMargins = True
      Left = 9
      Top = 6
      Width = 145
      Height = 21
      DataField = 'IDgc'
      DataSource = DataModule2.DS_T_IncomingGoods
      KeyField = 'IDgc'
      ListField = 'gcName'
      ListSource = DataModule2.DS_T_GoodsCatalog
      TabOrder = 0
    end
    object DBLookupComboBox2: TDBLookupComboBox
      AlignWithMargins = True
      Left = 287
      Top = 6
      Width = 145
      Height = 21
      DataField = 'IDsc'
      DataSource = DataModule2.DS_T_IncomingGoods
      KeyField = 'IDsc'
      ListField = 'scName'
      ListSource = DataModule2.DS_T_SuppliersCatalog
      TabOrder = 1
    end
    object DateTimePicker1: TDateTimePicker
      AlignWithMargins = True
      Left = 438
      Top = 6
      Width = 107
      Height = 21
      Date = 42826.000000000000000000
      Time = 42826.000000000000000000
      TabOrder = 2
    end
    object ButtonPost: TButton
      AlignWithMargins = True
      Left = 551
      Top = 6
      Width = 75
      Height = 25
      Caption = #1047#1072#1087#1086#1084#1085#1080#1090#1100
      TabOrder = 3
      OnClick = ButtonPostClick
    end
    object ButtonCancel: TButton
      AlignWithMargins = True
      Left = 632
      Top = 6
      Width = 75
      Height = 25
      Caption = #1054#1090#1084#1077#1085#1080#1090#1100
      TabOrder = 4
      OnClick = ButtonCancelClick
    end
    object DBEdit1: TDBEdit
      Left = 160
      Top = 6
      Width = 121
      Height = 21
      DataField = 'igAmount'
      DataSource = DataModule2.DS_T_IncomingGoods
      TabOrder = 5
    end
  end
  object MainMenu1: TMainMenu
    Left = 672
    Top = 216
    object N1: TMenuItem
      Caption = #1060#1072#1081#1083
      object N2: TMenuItem
        Caption = #1042#1099#1093#1086#1076
        OnClick = N2Click
      end
    end
    object N3: TMenuItem
      Caption = #1055#1086#1089#1090#1072#1074#1097#1080#1082#1080
      OnClick = N3Click
    end
    object N4: TMenuItem
      Caption = #1058#1086#1074#1072#1088#1099
      OnClick = N4Click
    end
  end
end
