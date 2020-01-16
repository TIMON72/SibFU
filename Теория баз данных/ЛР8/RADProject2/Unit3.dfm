object Form3: TForm3
  Left = 0
  Top = 0
  Caption = 'Form3'
  ClientHeight = 299
  ClientWidth = 1165
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
    Width = 1145
    Height = 241
    DataSource = DataModule2.DS_T_SuppliersCatalog
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    OnTitleClick = DBGrid1TitleClick
    Columns = <
      item
        Expanded = False
        FieldName = 'IDsc'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'scName'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'scAddress'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'scPhone'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'scEmail'
        Visible = True
      end>
  end
  object ButtonAddRecord: TButton
    Left = 516
    Top = 253
    Width = 101
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100' '#1079#1072#1087#1080#1089#1100
    TabOrder = 1
    OnClick = ButtonAddRecordClick
  end
  object EditScName: TEdit
    Left = 8
    Top = 255
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Name'
  end
  object EditScAddress: TEdit
    Left = 135
    Top = 255
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Address'
  end
  object EditScPhone: TEdit
    Left = 262
    Top = 255
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Phone'
  end
  object EditScEmail: TEdit
    Left = 389
    Top = 255
    Width = 121
    Height = 21
    TabOrder = 5
    Text = 'Email'
  end
end
