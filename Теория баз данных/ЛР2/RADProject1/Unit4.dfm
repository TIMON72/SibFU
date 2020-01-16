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
    Top = 8
    Width = 913
    Height = 281
    ActivePage = TabSheet1
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = #1058#1086#1074#1072#1088#1099
      object DBGrid1: TDBGrid
        Left = 3
        Top = 3
        Width = 894
        Height = 170
        DataSource = DataModule2.DS_T_GoodsCatalog
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
    end
    object TabSheet2: TTabSheet
      Caption = #1058#1080#1087#1099' '#1090#1086#1074#1072#1088#1086#1074
      ImageIndex = 1
      object DBGrid2: TDBGrid
        Left = 3
        Top = 3
        Width = 409
        Height = 170
        DataSource = DataModule2.DS_T_TypeGoods
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'Tahoma'
        TitleFont.Style = []
      end
    end
  end
  object Edit1: TEdit
    Left = 8
    Top = 406
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 135
    Top = 402
    Width = 75
    Height = 25
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
  object DBLookupComboBox1: TDBLookupComboBox
    Left = 15
    Top = 211
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
    Left = 166
    Top = 211
    Width = 122
    Height = 21
    DataField = 'gcName'
    DataSource = DataModule2.DS_T_GoodsCatalog
    TabOrder = 4
  end
  object DBEdit3: TDBEdit
    Left = 374
    Top = 211
    Width = 66
    Height = 21
    DataField = 'gcCost'
    DataSource = DataModule2.DS_T_GoodsCatalog
    TabOrder = 5
  end
  object DBEdit2: TDBEdit
    Left = 294
    Top = 211
    Width = 74
    Height = 21
    DataField = 'gcMeasure'
    DataSource = DataModule2.DS_T_GoodsCatalog
    TabOrder = 6
  end
  object InsertButton: TButton
    Left = 15
    Top = 238
    Width = 73
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 7
    OnClick = InsertButtonClick
  end
  object EditButton: TButton
    Left = 94
    Top = 238
    Width = 73
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    TabOrder = 8
    OnClick = EditButtonClick
  end
  object DeleteButton: TButton
    Left = 173
    Top = 238
    Width = 73
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 9
    OnClick = DeleteButtonClick
  end
  object PostButton: TButton
    Left = 252
    Top = 238
    Width = 73
    Height = 25
    Caption = #1047#1072#1087#1086#1084#1085#1080#1090#1100
    TabOrder = 10
    OnClick = PostButtonClick
  end
  object CancelButton: TButton
    Left = 331
    Top = 238
    Width = 73
    Height = 25
    Caption = #1054#1090#1084#1077#1085#1080#1090#1100
    TabOrder = 11
    OnClick = CancelButtonClick
  end
end
