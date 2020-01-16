object Form2: TForm2
  Left = 0
  Top = 0
  Caption = 'Form2'
  ClientHeight = 360
  ClientWidth = 533
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
    Width = 529
    Height = 297
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 0
    DefaultCanvas = 'TGDIPlusCanvas'
    PrintMargins = (
      15
      19
      15
      19)
    ColorPaletteIndex = 0
    object Series1: THorizBarSeries
      BarBrush.Gradient.Direction = gdLeftRight
      DataSource = ADOQuery1
      XLabelsSource = 'gcName'
      Gradient.Direction = gdLeftRight
      XValues.Name = 'Bar'
      XValues.Order = loNone
      XValues.ValueSource = 'igAmountCount'
      YValues.Name = 'Y'
      YValues.Order = loAscending
    end
    object Series2: TBarSeries
      Active = False
      DataSource = ADOQuery1
      XLabelsSource = 'gcName'
      XValues.Name = 'X'
      XValues.Order = loAscending
      YValues.Name = 'Bar'
      YValues.Order = loNone
      YValues.ValueSource = 'igAmountCount'
    end
  end
  object Button1: TButton
    Left = 0
    Top = 303
    Width = 169
    Height = 50
    Caption = #1053#1072#1087#1077#1095#1072#1090#1100' '#1075#1088#1072#1092#1080#1082
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 175
    Top = 303
    Width = 178
    Height = 50
    Caption = #1055#1077#1088#1077#1082#1083#1102#1095#1080#1090#1100' '#1089#1077#1088#1080#1102
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 359
    Top = 303
    Width = 170
    Height = 50
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100' '#1089#1077#1088#1080#1102
    TabOrder = 3
    OnClick = Button3Click
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = Form1.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'SELECT'
      '  `goodscatalog`.`gcName` AS `gcName`,'
      '  SUM(`incominggoods`.`igAmount`) AS `igAmountCount`,'
      '  `typegoods`.`tgName` AS `tgName`'
      'FROM ((`typegoods`'
      '  JOIN `incominggoods`)'
      '  JOIN `goodscatalog`)'
      'WHERE ((`goodscatalog`.`IDgc` = `incominggoods`.`IDgc`)'
      'AND (`typegoods`.`IDtg` = `goodscatalog`.`IDtg`))'
      'GROUP BY `goodscatalog`.`gcName`')
    Left = 592
    Top = 24
  end
end
