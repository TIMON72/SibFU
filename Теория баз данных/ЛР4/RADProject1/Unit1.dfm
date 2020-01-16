object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 459
  ClientWidth = 727
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
    Width = 727
    Height = 379
    Align = alClient
    TabOrder = 0
    object DBGrid1: TDBGrid
      Left = 1
      Top = 1
      Width = 725
      Height = 159
      Align = alClient
      DataSource = DataModule2.DS_Q_IncomingGoodsD
      Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgConfirmDelete, dgCancelOnExit, dgTitleClick, dgTitleHotTrack]
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
      OnDrawColumnCell = DBGrid1DrawColumnCell
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
          Width = 252
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
          Width = 64
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
      Top = 160
      Width = 725
      Height = 218
      Align = alBottom
      ShowCaption = False
      TabOrder = 1
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
      object GroupBox1: TGroupBox
        Left = 504
        Top = 6
        Width = 209
        Height = 45
        Caption = #1055#1086#1080#1089#1082' '#1087#1086' '#1092#1080#1083#1100#1090#1088#1091
        TabOrder = 7
        object EditFilter: TEdit
          Left = 3
          Top = 19
          Width = 121
          Height = 21
          TabOrder = 0
          Text = #1042#1074#1077#1076#1080#1090#1077' '#1092#1080#1083#1100#1090#1088
        end
        object CheckBoxFilter: TCheckBox
          Left = 130
          Top = 25
          Width = 97
          Height = 17
          Caption = #1055#1088#1080#1084#1077#1085#1080#1090#1100
          TabOrder = 1
          OnClick = CheckBoxFilterClick
        end
      end
      object GroupBox2: TGroupBox
        Left = 367
        Top = 57
        Width = 346
        Height = 83
        Caption = #1055#1086#1080#1089#1082' '#1087#1086' '#1085#1072#1079#1074#1072#1085#1080#1102' '#1090#1086#1074#1072#1088#1072
        TabOrder = 8
        object EditGoodsName: TEdit
          Left = 3
          Top = 19
          Width = 134
          Height = 21
          TabOrder = 0
          OnChange = EditGoodsNameChange
        end
        object ButtonFindLast: TButton
          Left = 55
          Top = 46
          Width = 62
          Height = 25
          Caption = #1055#1086#1089#1083#1077#1076#1085#1103#1103
          TabOrder = 1
          OnClick = ButtonFindLastClick
        end
        object ButtonFindPrior: TButton
          Left = 198
          Top = 46
          Width = 75
          Height = 25
          Caption = #1055#1088#1077#1076#1099#1076#1091#1097#1072#1103
          TabOrder = 2
          OnClick = ButtonFindPriorClick
        end
        object ButtonFindNext: TButton
          Left = 123
          Top = 46
          Width = 69
          Height = 25
          Caption = #1057#1083#1077#1076#1091#1102#1097#1072#1103
          TabOrder = 3
          OnClick = ButtonFindNextClick
        end
        object ButtonFindFirst: TButton
          Left = 3
          Top = 46
          Width = 46
          Height = 25
          Caption = #1055#1077#1088#1074#1072#1103
          TabOrder = 4
          OnClick = ButtonFindFirstClick
        end
        object EditFindScName: TEdit
          Left = 143
          Top = 19
          Width = 200
          Height = 21
          ReadOnly = True
          TabOrder = 5
          Text = #1058#1099#1082#1085#1080' '#1076#1083#1103' '#1086#1087#1088#1077#1076#1077#1083#1077#1085#1080#1103' '#1087#1086#1089#1090#1072#1074#1097#1080#1082#1072
          OnClick = EditFindScNameClick
        end
      end
      object GroupBox3: TGroupBox
        Left = 504
        Top = 146
        Width = 209
        Height = 64
        Caption = #1060#1080#1083#1100#1090#1088#1072#1094#1080#1103' '#1087#1086' '#1076#1080#1072#1087#1072#1079#1086#1085#1091' '#1076#1072#1090
        TabOrder = 9
        object CheckBoxFilterDates: TCheckBox
          Left = 133
          Top = 19
          Width = 73
          Height = 17
          Caption = #1055#1088#1080#1084#1077#1085#1080#1090#1100
          TabOrder = 0
          OnClick = CheckBoxFilterDatesClick
        end
        object ComboBox1: TComboBox
          Left = 3
          Top = 15
          Width = 124
          Height = 21
          Style = csDropDownList
          ItemIndex = 6
          TabOrder = 1
          Text = #1042' '#1076#1080#1072#1087#1072#1079#1086#1085#1077
          OnChange = ComboBox1Change
          Items.Strings = (
            '<'
            '<='
            '='
            '>'
            '>='
            '<>'
            #1042' '#1076#1080#1072#1087#1072#1079#1086#1085#1077
            #1042#1085#1077' '#1076#1080#1072#1087#1072#1079#1086#1085#1072)
        end
        object DateTimePicker1: TDateTimePicker
          Left = 3
          Top = 42
          Width = 94
          Height = 21
          Date = 42831.000000000000000000
          Time = 42831.000000000000000000
          TabOrder = 2
        end
        object DateTimePicker2: TDateTimePicker
          Left = 107
          Top = 42
          Width = 99
          Height = 21
          Date = 42831.000000000000000000
          Time = 42831.000000000000000000
          TabOrder = 3
        end
      end
      object GroupBox4: TGroupBox
        Left = 8
        Top = 67
        Width = 353
        Height = 70
        Caption = #1055#1086#1080#1089#1082' '#1087#1086' '#1087#1086#1083#1102
        TabOrder = 10
        object EditLocate: TEdit
          Left = 135
          Top = 25
          Width = 121
          Height = 21
          TabOrder = 0
        end
        object ButtonLocate: TButton
          Left = 262
          Top = 20
          Width = 75
          Height = 25
          Caption = #1053#1072#1081#1090#1080
          TabOrder = 1
          OnClick = ButtonLocateClick
        end
      end
      object RadioGroup1: TRadioGroup
        Left = 16
        Top = 83
        Width = 121
        Height = 46
        Caption = #1042#1099#1073#1077#1088#1077#1090#1077' '#1087#1086#1083#1077
        Items.Strings = (
          'gcName'
          'scName')
        TabOrder = 11
      end
      object ButtonColumnsFont: TButton
        Left = 8
        Top = 143
        Width = 97
        Height = 25
        Caption = #1064#1088#1080#1092#1090' '#1089#1090#1086#1083#1073#1094#1086#1074
        TabOrder = 12
        OnClick = ButtonColumnsFontClick
      end
      object ButtonCaptionsColumnsFont: TButton
        Left = 111
        Top = 143
        Width = 106
        Height = 25
        Caption = #1064#1088#1080#1092#1090' '#1079#1072#1075#1086#1083#1086#1074#1082#1086#1074
        TabOrder = 13
        OnClick = ButtonCaptionsColumnsFontClick
      end
      object ButtonSelectedColumnFont: TButton
        Left = 223
        Top = 143
        Width = 90
        Height = 25
        Caption = #1064#1088#1080#1092#1090' '#1089#1090#1086#1083#1073#1094#1072
        TabOrder = 14
        OnClick = ButtonSelectedColumnFontClick
      end
      object ButtonSelectedColumnColor: TButton
        Left = 319
        Top = 143
        Width = 74
        Height = 25
        Caption = #1060#1086#1085' '#1089#1090#1086#1083#1073#1094#1072
        TabOrder = 15
        OnClick = ButtonSelectedColumnColorClick
      end
    end
  end
  object PanelInsertEditDelete: TPanel
    Left = 0
    Top = 379
    Width = 727
    Height = 39
    Align = alBottom
    Caption = 'PanelInsertEditDelete'
    ShowCaption = False
    TabOrder = 1
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
    Top = 418
    Width = 727
    Height = 41
    Align = alBottom
    Caption = 'PanelToInputValues'
    ShowCaption = False
    TabOrder = 2
    Visible = False
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
    object DateTimePicker4: TDateTimePicker
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
    Top = 112
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
  object FontDialog1: TFontDialog
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    Left = 529
    Top = 112
  end
  object ColorDialog1: TColorDialog
    Left = 601
    Top = 112
  end
end
