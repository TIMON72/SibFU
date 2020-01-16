object Form4: TForm4
  Left = 0
  Top = 0
  Caption = 'Form4'
  ClientHeight = 435
  ClientWidth = 929
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl1: TPageControl
    Left = 8
    Top = 6
    Width = 721
    Height = 390
    ActivePage = TabSheet1
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = #1058#1086#1074#1072#1088#1099
      object DBGrid1: TDBGrid
        Left = 3
        Top = 3
        Width = 710
        Height = 170
        DataSource = DataModule2.DS_Q_GoodsCatalogD
        Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgConfirmDelete, dgCancelOnExit, dgTitleClick, dgTitleHotTrack]
        ReadOnly = True
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'Tahoma'
        TitleFont.Style = []
        Columns = <
          item
            Expanded = False
            FieldName = 'gcCost'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'gcName'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'gcMeasure'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'IDgc'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'IDtg'
            Visible = True
          end>
      end
      object InsertButton: TButton
        Left = 3
        Top = 206
        Width = 73
        Height = 25
        Caption = #1044#1086#1073#1072#1074#1080#1090#1100
        TabOrder = 1
        OnClick = InsertButtonClick
      end
      object EditButton: TButton
        Left = 82
        Top = 206
        Width = 73
        Height = 25
        Caption = #1048#1079#1084#1077#1085#1080#1090#1100
        TabOrder = 2
        OnClick = EditButtonClick
      end
      object DBLookupComboBox1: TDBLookupComboBox
        Left = 3
        Top = 179
        Width = 145
        Height = 21
        DataField = 'IDtg'
        DataSource = DataModule2.DS_T_GoodsCatalog
        KeyField = 'IDtg'
        ListField = 'tgName'
        ListSource = DataModule2.DS_T_TypeGoods
        TabOrder = 3
      end
      object DBEdit1: TDBEdit
        Left = 154
        Top = 179
        Width = 122
        Height = 21
        DataField = 'gcName'
        DataSource = DataModule2.DS_T_GoodsCatalog
        TabOrder = 4
      end
      object DeleteButton: TButton
        Left = 161
        Top = 206
        Width = 73
        Height = 25
        Caption = #1059#1076#1072#1083#1080#1090#1100
        TabOrder = 5
        OnClick = DeleteButtonClick
      end
      object PostButton: TButton
        Left = 240
        Top = 206
        Width = 73
        Height = 25
        Caption = #1047#1072#1087#1086#1084#1085#1080#1090#1100
        TabOrder = 6
        OnClick = PostButtonClick
      end
      object DBEdit2: TDBEdit
        Left = 282
        Top = 179
        Width = 74
        Height = 21
        DataField = 'gcMeasure'
        DataSource = DataModule2.DS_T_GoodsCatalog
        TabOrder = 7
      end
      object CancelButton: TButton
        Left = 319
        Top = 206
        Width = 73
        Height = 25
        Caption = #1054#1090#1084#1077#1085#1080#1090#1100
        TabOrder = 8
        OnClick = CancelButtonClick
      end
      object DBEdit3: TDBEdit
        Left = 362
        Top = 179
        Width = 66
        Height = 21
        DataField = 'gcCost'
        DataSource = DataModule2.DS_T_GoodsCatalog
        TabOrder = 9
      end
      object GroupBox1: TGroupBox
        Left = 496
        Top = 179
        Width = 214
        Height = 52
        Caption = #1060#1080#1083#1100#1088#1072#1094#1080#1103' '#1087#1086' '#1094#1077#1085#1077
        TabOrder = 10
        object E_MinCost: TEdit
          Left = 9
          Top = 20
          Width = 121
          Height = 21
          TabOrder = 0
          OnChange = E_MinCostChange
        end
        object CheckBoxFilterCost: TCheckBox
          Left = 136
          Top = 24
          Width = 73
          Height = 17
          Caption = #1055#1088#1080#1084#1077#1085#1080#1090#1100
          TabOrder = 1
          OnClick = CheckBoxFilterCostClick
        end
      end
      object EditSearchByGcName: TEdit
        Left = 3
        Top = 237
        Width = 206
        Height = 20
        TabOrder = 11
        Text = #1042#1074#1077#1076#1080#1090#1077' '#1085#1072#1079#1074#1072#1085#1080#1077' '#1090#1086#1074#1072#1088#1072' '#1076#1083#1103' '#1087#1086#1080#1089#1082#1072
        OnChange = EditSearchByGcNameChange
      end
    end
    object TabSheet2: TTabSheet
      Caption = #1058#1080#1087#1099' '#1090#1086#1074#1072#1088#1086#1074
      ImageIndex = 1
      object DBGrid2: TDBGrid
        Left = 11
        Top = 3
        Width = 425
        Height = 170
        DataSource = DataModule2.DS_T_TypeGoods
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
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'tgName'
            Visible = True
          end>
      end
      object EditTgName: TEdit
        Left = 91
        Top = 179
        Width = 121
        Height = 21
        TabOrder = 1
      end
      object ButtonEdit: TButton
        Left = 10
        Top = 177
        Width = 75
        Height = 25
        Caption = #1048#1079#1084#1077#1085#1080#1090#1100
        TabOrder = 2
        OnClick = ButtonEditClick
      end
    end
  end
end
