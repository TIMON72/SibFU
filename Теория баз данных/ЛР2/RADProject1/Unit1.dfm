object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 449
  ClientWidth = 1040
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object DBText1: TDBText
    Left = 24
    Top = 304
    Width = 65
    Height = 17
    DataField = 'Cost'
    DataSource = DataModule2.DS_Q_IncomingGoodsD
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 1024
    Height = 281
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
        Width = 64
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
  object MainMenu1: TMainMenu
    Left = 32
    Top = 336
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
