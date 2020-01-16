object Form4: TForm4
  Left = 0
  Top = 0
  Caption = 'Form4'
  ClientHeight = 368
  ClientWidth = 638
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
    Width = 633
    Height = 297
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 0
    DefaultCanvas = 'TGDIPlusCanvas'
    ColorPaletteIndex = 0
    object Series1: THorizBarSeries
      BarBrush.Gradient.Direction = gdLeftRight
      Marks.Visible = False
      DataSource = ADOQuery1
      XLabelsSource = 'StoragTo'
      Gradient.Direction = gdLeftRight
      XValues.Name = 'Bar'
      XValues.Order = loNone
      YValues.Name = 'Y'
      YValues.Order = loAscending
      YValues.ValueSource = 'sdTransferAmount'
    end
  end
  object Button1: TButton
    Left = 0
    Top = 303
    Width = 633
    Height = 61
    Caption = #1055#1077#1088#1077#1084#1077#1097#1077#1085#1080#1077' '#1089#1086' '#1089#1082#1083#1072#1076#1072
    TabOrder = 1
    OnClick = Button1Click
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = Form1.ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'SELECT'
      '  `goodstransfers`.`IDgt` AS `IDgt`,'
      '  `goodstransfers`.`gtDate` AS `gtDate`,'
      '  `goodstransfers`.`gtAmount` AS `sdTransferAmount`,'
      '  `goodscatalog`.`gcName` AS `gcName`,'
      
        '  CONCAT(`storagedescription`.`sdName`, '#39', '#39', `storagedescriptio' +
        'n`.`sdAddress`, '#39', '#39', `cities`.`cName`) AS `StorageFrom`,'
      
        '  CONCAT(`virtualstorage`.`sdName`, '#39', '#39', `virtualstorage`.`sdAd' +
        'dress`, '#39', '#39', `virtualcities`.`cName`) AS `StoragTo`'
      'FROM (((((`goodstransfers`'
      '  LEFT JOIN `storagedescription`'
      
        '    ON ((`goodstransfers`.`IDsdFrom` = `storagedescription`.`IDs' +
        'd`)))'
      '  LEFT JOIN `storagedescription` `virtualstorage`'
      '    ON ((`goodstransfers`.`IDsdTo` = `virtualstorage`.`IDsd`)))'
      '  JOIN `goodscatalog`'
      '    ON ((`goodstransfers`.`IDgc` = `goodscatalog`.`IDgc`)))'
      '  LEFT JOIN `cities`'
      '    ON ((`storagedescription`.`IDc` = `cities`.`IDc`)))'
      '  LEFT JOIN `cities` `virtualcities`'
      '    ON ((`virtualstorage`.`IDc` = `virtualcities`.`IDc`)))')
    Left = 688
    Top = 16
  end
end
