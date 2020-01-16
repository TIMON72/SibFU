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
end
