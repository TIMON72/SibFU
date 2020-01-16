object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 381
  ClientWidth = 579
  Color = clGradientInactiveCaption
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object DBChart1: TDBChart
    Left = 0
    Top = 0
    Width = 577
    Height = 313
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 0
    DefaultCanvas = 'TGDIPlusCanvas'
    PrintMargins = (
      15
      23
      15
      23)
    ColorPaletteIndex = 0
    object Series1: TLineSeries
      ColorEachPoint = True
      DataSource = ADOQuery1
      Brush.BackColor = clDefault
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      XValues.DateTime = True
      XValues.Name = 'X'
      XValues.Order = loAscending
      XValues.ValueSource = 'igDate'
      YValues.Name = 'Y'
      YValues.Order = loNone
      YValues.ValueSource = 'igAmountcount'
    end
  end
  object Button1: TButton
    Left = 0
    Top = 319
    Width = 577
    Height = 58
    Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100' '#1074' C:/Temp'
    TabOrder = 1
    OnClick = Button1Click
  end
  object ADOConnection1: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=MSDASQL.1;Persist Security Info=False;User ID=root;Exte' +
      'nded Properties="Driver=MySQL ODBC 5.1 Driver;SERVER=localhost;U' +
      'ID=root;DATABASE=mydatabase;PORT=3306;COLUMN_SIZE_S32=1"'
    Left = 648
    Top = 16
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      'SELECT'
      '  `incominggoods`.`igDate` AS `igDate`,'
      '  SUM(`incominggoods`.`igAmount`) AS `igAmountcount`'
      'FROM `incominggoods`'
      'GROUP BY `incominggoods`.`igDate`')
    Left = 648
    Top = 64
  end
  object MainMenu1: TMainMenu
    Left = 648
    Top = 112
    object N21: TMenuItem
      Caption = #1060#1086#1088#1084#1072' 2'
      OnClick = N21Click
    end
    object N31: TMenuItem
      Caption = #1060#1086#1088#1084#1072' 3'
      OnClick = N31Click
    end
    object N41: TMenuItem
      Caption = #1060#1086#1088#1084#1072' 4'
      OnClick = N41Click
    end
    object N1: TMenuItem
      Caption = #1060#1086#1088#1084#1072' 5'
      OnClick = N1Click
    end
  end
end
