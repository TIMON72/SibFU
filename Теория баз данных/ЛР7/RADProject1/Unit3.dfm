object Form3: TForm3
  Left = 0
  Top = 0
  Caption = 'Form3'
  ClientHeight = 359
  ClientWidth = 599
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
    Left = 0
    Top = 0
    Width = 593
    Height = 297
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 0
    DefaultCanvas = 'TGDIPlusCanvas'
    ColorPaletteIndex = 0
    object Series1: TBarSeries
      BarBrush.Gradient.Direction = gdLeftRight
      Marks.Visible = False
      DataSource = ADOQuery1
      SeriesColor = 16744448
      Gradient.Direction = gdLeftRight
      XValues.Name = 'X'
      XValues.Order = loAscending
      YValues.Name = 'Bar'
      YValues.Order = loNone
      YValues.ValueSource = 'igAmountCount'
    end
    object Series2: TBarSeries
      BarBrush.Gradient.Direction = gdLeftRight
      Marks.Visible = False
      DataSource = ADOQuery2
      SeriesColor = 33023
      XLabelsSource = 'igDate'
      Gradient.Direction = gdLeftRight
      XValues.Name = 'X'
      XValues.Order = loAscending
      YValues.Name = 'Bar'
      YValues.Order = loNone
      YValues.ValueSource = 'igAmountCount'
    end
    object Series3: TBarSeries
      BarBrush.Gradient.Direction = gdLeftRight
      Marks.Visible = False
      SeriesColor = 16711808
      Gradient.Direction = gdLeftRight
      XValues.Name = 'X'
      XValues.Order = loAscending
      YValues.Name = 'Bar'
      YValues.Order = loNone
      DataSources = (
        'Series1'
        'Series2')
      object TeeFunction1: TSubtractTeeFunction
        CalcByValue = False
      end
    end
  end
  object Button1: TButton
    Left = 0
    Top = 303
    Width = 274
    Height = 50
    Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100' '#1074' C:\Temp'
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 280
    Top = 303
    Width = 313
    Height = 50
    Caption = #1059#1076#1072#1083#1080#1090#1100' '#1074#1090'. '#1086#1088#1072#1085#1078'. '#1089#1090'.'
    TabOrder = 2
    OnClick = Button2Click
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = Form1.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'SELECT'
      '  goodscatalog.gcName AS gcName,'
      '  SUM(incominggoods.igAmount) AS igAmountCount'
      'FROM incominggoods'
      '  INNER JOIN goodscatalog'
      '    ON incominggoods.IDgc = goodscatalog.IDgc'
      'GROUP BY 1,'
      '         goodscatalog.gcName')
    Left = 624
    Top = 24
  end
  object ADOQuery2: TADOQuery
    Active = True
    Connection = Form1.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'SELECT'
      '  DATE_FORMAT(incominggoods.igDate, '#39'%m.%Y'#39') AS igDate,'
      '  SUM(incominggoods.igAmount) AS igAmountCount,'
      '  supplierscatalog.scName AS scName,'
      '  goodscatalog.gcName AS gcName'
      'FROM incominggoods'
      '  INNER JOIN supplierscatalog'
      '    ON incominggoods.IDsc = supplierscatalog.IDsc'
      '  INNER JOIN goodscatalog'
      '    ON incominggoods.IDgc = goodscatalog.IDgc'
      'GROUP BY 1,'
      '         supplierscatalog.scName,'
      '         goodscatalog.gcName')
    Left = 624
    Top = 80
  end
end
