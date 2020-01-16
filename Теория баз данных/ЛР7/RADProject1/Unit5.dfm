object Form5: TForm5
  Left = 0
  Top = 0
  Caption = 'Form5'
  ClientHeight = 324
  ClientWidth = 560
  Color = clGradientInactiveCaption
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object DBChart1: TDBChart
    Left = -4
    Top = 0
    Width = 561
    Height = 321
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 0
    DefaultCanvas = 'TGDIPlusCanvas'
    ColorPaletteIndex = 13
    object Series1: TBarSeries
      Marks.Children = <
        item
          Shape.ShapeStyle = fosRectangle
          Shape.Visible = False
          Shape.Style = smsValue
        end>
      DataSource = ADOQuery1
      XLabelsSource = 'sdName'
      XValues.Name = 'X'
      XValues.Order = loAscending
      YValues.Name = 'Bar'
      YValues.Order = loNone
      YValues.ValueSource = 'countAmount'
    end
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = Form1.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'SELECT'
      '  storagedescription.sdName AS sdName,'
      '  typegoods.tgName AS tgName,'
      '  goodscatalog.gcCost * goodsstorage.gsAmount AS countAmount'
      'FROM goodsstorage'
      '  INNER JOIN goodscatalog'
      '    ON goodsstorage.IDgc = goodscatalog.IDgc'
      '  INNER JOIN typegoods'
      '    ON goodscatalog.IDtg = typegoods.IDtg'
      '  INNER JOIN storagedescription'
      '    ON goodsstorage.IDsd = storagedescription.IDsd')
    Left = 648
    Top = 24
  end
end
