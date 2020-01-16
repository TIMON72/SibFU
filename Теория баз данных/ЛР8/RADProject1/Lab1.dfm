object Form4: TForm4
  Left = 0
  Top = 0
  Caption = 'Form4'
  ClientHeight = 516
  ClientWidth = 703
  Color = clGradientInactiveCaption
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
    Width = 277
    Height = 105
    DataSource = DataSource1
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object DBGrid2: TDBGrid
    Left = 8
    Top = 119
    Width = 388
    Height = 113
    DataSource = DataSource2
    TabOrder = 1
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object DBGrid3: TDBGrid
    Left = 8
    Top = 238
    Width = 449
    Height = 270
    DataSource = DataSource3
    TabOrder = 2
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
  end
  object ADOConnection1: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Password="";Data Source=D:\Clou' +
      'd Drivers\OneDrive\'#1058#1041#1044'\'#1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1099#1077' '#1088#1072#1073#1086#1090#1099'\'#1051#1056'8\RADProject1\Win32' +
      '\Debug\Database11.mdb;Persist Security Info=True'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 320
    Top = 8
  end
  object DataSource1: TDataSource
    DataSet = ADOTable1
    Left = 400
    Top = 8
  end
  object ADOTable1: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'TypeGoods'
    Left = 400
    Top = 56
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    Filtered = True
    DataSource = DataSource1
    Parameters = <>
    SQL.Strings = (
      
        'SELECT GC.IDgc, GC.gcName, GC.IDtg, TG.tgName, GC.gcMeasure, GC.' +
        'gcCost'
      'FROM GoodsCatalog GC, TypeGoods TG'
      'WHERE GC.IDtg = TG.IDtg'
      'ORDER BY  GC.IDtg, TG.tgName, GC.gcName;')
    Left = 584
    Top = 56
  end
  object ADOTable2: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = 'IDtg'
    MasterFields = 'IDtg'
    MasterSource = DataSource1
    TableName = 'GoodsCatalog'
    Left = 488
    Top = 56
    object ADOTable2gcName: TWideStringField
      DisplayWidth = 40
      FieldName = 'gcName'
      Size = 50
    end
    object ADOTable2IDtg: TIntegerField
      DisplayWidth = 5
      FieldName = 'IDtg'
    end
    object ADOTable2gcMeasure: TWideStringField
      DisplayWidth = 12
      FieldName = 'gcMeasure'
    end
    object ADOTable2gcCost: TBCDField
      DisplayWidth = 11
      FieldName = 'gcCost'
      Precision = 19
    end
  end
  object DataSource2: TDataSource
    DataSet = ADOTable2
    Left = 488
    Top = 8
  end
  object DataSource3: TDataSource
    DataSet = ADOQuery1
    Left = 584
    Top = 8
  end
  object frxDBDataset1: TfrxDBDataset
    UserName = 'TypeGoods'
    CloseDataSource = False
    DataSet = ADOTable1
    BCDToCurrency = False
    Left = 432
    Top = 112
  end
  object frxDBDataset2: TfrxDBDataset
    UserName = 'GoodsCatalog'
    CloseDataSource = False
    DataSet = ADOTable2
    BCDToCurrency = False
    Left = 512
    Top = 112
  end
  object frxReport1: TfrxReport
    Version = '5.3.14'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 1.000000000000000000
    PrintOptions.Printer = 'Default'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 42856.631011689800000000
    ReportOptions.LastChange = 42856.638877326400000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      ''
      'begin'
      ''
      'end.')
    Left = 592
    Top = 112
    Datasets = <
      item
        DataSet = frxDBDataset2
        DataSetName = 'GoodsCatalog'
      end
      item
        DataSet = frxDBDataset1
        DataSetName = 'TypeGoods'
      end>
    Variables = <>
    Style = <>
    object Data: TfrxDataPage
      Height = 1000.000000000000000000
      Width = 1000.000000000000000000
    end
    object Page1: TfrxReportPage
      PaperWidth = 210.000000000000000000
      PaperHeight = 297.000000000000000000
      PaperSize = 9
      LeftMargin = 10.000000000000000000
      RightMargin = 10.000000000000000000
      TopMargin = 10.000000000000000000
      BottomMargin = 10.000000000000000000
      object ReportTitle1: TfrxReportTitle
        FillType = ftBrush
        Height = 22.677180000000000000
        Top = 18.897650000000000000
        Width = 718.110700000000000000
      end
      object MasterData1: TfrxMasterData
        FillType = ftBrush
        Height = 26.456710000000000000
        Top = 102.047310000000000000
        Width = 718.110700000000000000
        DataSet = frxDBDataset1
        DataSetName = 'TypeGoods'
        RowCount = 0
        object TypeGoodsIDtg: TfrxMemoView
          Left = 11.338590000000000000
          Top = 3.779530000000000000
          Width = 634.961040000000000000
          Height = 18.897650000000000000
          DataField = 'IDtg'
          DataSet = frxDBDataset1
          DataSetName = 'TypeGoods'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Fill.BackColor = 4643583
          Memo.UTF8W = (
            '[TypeGoods."IDtg"]')
          ParentFont = False
        end
        object TypeGoodstgName: TfrxMemoView
          Left = 132.283550000000000000
          Top = 3.779530000000000000
          Width = 143.622140000000000000
          Height = 18.897650000000000000
          DataField = 'tgName'
          DataSet = frxDBDataset1
          DataSetName = 'TypeGoods'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Memo.UTF8W = (
            '[TypeGoods."tgName"]')
          ParentFont = False
        end
      end
      object PageFooter1: TfrxPageFooter
        FillType = ftBrush
        Height = 22.677180000000000000
        Top = 238.110390000000000000
        Width = 718.110700000000000000
        object Memo1: TfrxMemoView
          Left = 642.520100000000000000
          Width = 75.590600000000000000
          Height = 18.897650000000000000
          HAlign = haRight
          Memo.UTF8W = (
            '[Page#]')
        end
      end
      object DetailData1: TfrxDetailData
        FillType = ftBrush
        Height = 26.456710000000000000
        Top = 151.181200000000000000
        Width = 718.110700000000000000
        DataSet = frxDBDataset2
        DataSetName = 'GoodsCatalog'
        RowCount = 0
        object GoodsCatalogIDtg: TfrxMemoView
          Left = 11.338590000000000000
          Top = 3.779530000000000000
          Width = 136.063080000000000000
          Height = 18.897650000000000000
          DataField = 'IDtg'
          DataSet = frxDBDataset2
          DataSetName = 'GoodsCatalog'
          Memo.UTF8W = (
            '[GoodsCatalog."IDtg"]')
        end
        object GoodsCataloggcName: TfrxMemoView
          Left = 151.181200000000000000
          Top = 3.779530000000000000
          Width = 158.740260000000000000
          Height = 18.897650000000000000
          DataField = 'gcName'
          DataSet = frxDBDataset2
          DataSetName = 'GoodsCatalog'
          Memo.UTF8W = (
            '[GoodsCatalog."gcName"]')
        end
        object GoodsCataloggcMeasure: TfrxMemoView
          Left = 313.700990000000000000
          Top = 3.779530000000000000
          Width = 177.637910000000000000
          Height = 18.897650000000000000
          DataField = 'gcMeasure'
          DataSet = frxDBDataset2
          DataSetName = 'GoodsCatalog'
          Memo.UTF8W = (
            '[GoodsCatalog."gcMeasure"]')
        end
        object GoodsCataloggcCost: TfrxMemoView
          Left = 495.118430000000000000
          Top = 3.779530000000000000
          Width = 151.181200000000000000
          Height = 18.897650000000000000
          DataField = 'gcCost'
          DataSet = frxDBDataset2
          DataSetName = 'GoodsCatalog'
          Memo.UTF8W = (
            '[GoodsCatalog."gcCost"]')
        end
      end
    end
  end
  object frxDBDataset3: TfrxDBDataset
    UserName = 'Group'
    CloseDataSource = False
    DataSet = ADOQuery1
    BCDToCurrency = False
    Left = 504
    Top = 184
  end
  object frxReport2: TfrxReport
    Version = '5.3.14'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 1.000000000000000000
    PrintOptions.Printer = 'Default'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 42856.651869432900000000
    ReportOptions.LastChange = 42856.681115034720000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      ''
      'begin'
      ''
      'end.')
    Left = 592
    Top = 184
    Datasets = <
      item
        DataSet = frxDBDataset3
        DataSetName = 'Group'
      end>
    Variables = <>
    Style = <>
    object Data: TfrxDataPage
      Height = 1000.000000000000000000
      Width = 1000.000000000000000000
    end
    object Page1: TfrxReportPage
      PaperWidth = 210.000000000000000000
      PaperHeight = 297.000000000000000000
      PaperSize = 9
      LeftMargin = 10.000000000000000000
      RightMargin = 10.000000000000000000
      TopMargin = 10.000000000000000000
      BottomMargin = 10.000000000000000000
      object ReportTitle1: TfrxReportTitle
        FillType = ftBrush
        Height = 22.677180000000000000
        Top = 18.897650000000000000
        Width = 718.110700000000000000
      end
      object MasterData1: TfrxMasterData
        FillType = ftBrush
        Height = 30.236240000000000000
        Top = 151.181200000000000000
        Width = 718.110700000000000000
        DataSet = frxDBDataset3
        DataSetName = 'Group'
        RowCount = 0
        object GroupIDgc1: TfrxMemoView
          Left = 86.929190000000000000
          Top = 3.779530000000000000
          Width = 79.370130000000000000
          Height = 18.897650000000000000
          DataSet = frxDBDataset3
          DataSetName = 'Group'
          Memo.UTF8W = (
            '[Group."IDtg"]')
        end
        object GroupgcName: TfrxMemoView
          Left = 109.606370000000000000
          Top = 3.779530000000000000
          Width = 359.055350000000000000
          Height = 18.897650000000000000
          DataField = 'gcName'
          DataSet = frxDBDataset3
          DataSetName = 'Group'
          Memo.UTF8W = (
            '[Group."gcName"]')
        end
        object GroupgcMeasure: TfrxMemoView
          Left = 472.441250000000000000
          Top = 3.779530000000000000
          Width = 128.504020000000000000
          Height = 18.897650000000000000
          DataField = 'gcMeasure'
          DataSet = frxDBDataset3
          DataSetName = 'Group'
          Memo.UTF8W = (
            '[Group."gcMeasure"]')
        end
        object GroupgcCost: TfrxMemoView
          Left = 604.724800000000000000
          Top = 3.779530000000000000
          Width = 105.826840000000000000
          Height = 18.897650000000000000
          DataSet = frxDBDataset3
          DataSetName = 'Group'
          DisplayFormat.FormatStr = '%2.2m'
          DisplayFormat.Kind = fkNumeric
          Memo.UTF8W = (
            '[Group."gcCost"]')
          Highlights = <
            item
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clBlack
              Font.Height = -13
              Font.Name = 'Arial'
              Font.Style = []
              Condition = 'Value < 25'
              FillType = ftBrush
              Fill.BackColor = 13434828
              Fill.ForeColor = clBlue
            end
            item
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clBlack
              Font.Height = -13
              Font.Name = 'Arial'
              Font.Style = []
              Condition = 'Value > 25 < 55'
              FillType = ftBrush
              Fill.BackColor = 16629143
            end>
        end
        object Memo4: TfrxMemoView
          Left = 109.606370000000000000
          Top = 7.559060000000000000
          Width = 600.945270000000000000
          Height = 18.897650000000000000
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Frame.Typ = [ftBottom]
          ParentFont = False
        end
      end
      object PageFooter1: TfrxPageFooter
        FillType = ftBrush
        Height = 22.677180000000000000
        Top = 317.480520000000000000
        Width = 718.110700000000000000
        object Memo1: TfrxMemoView
          Left = 642.520100000000000000
          Width = 75.590600000000000000
          Height = 18.897650000000000000
          HAlign = haRight
          Memo.UTF8W = (
            '[Page#]')
        end
      end
      object GroupHeader1: TfrxGroupHeader
        FillType = ftBrush
        Height = 26.456710000000000000
        Top = 102.047310000000000000
        Width = 718.110700000000000000
        Condition = 'Group."tgName"'
        DrillDown = True
        ExpandDrillDown = True
        object GroupIDgc: TfrxMemoView
          Left = 15.118120000000000000
          Top = 3.779530000000000000
          Width = 695.433520000000000000
          Height = 18.897650000000000000
          DataSet = frxDBDataset3
          DataSetName = 'Group'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Fill.BackColor = 10218495
          Memo.UTF8W = (
            '[Group."IDtg"]')
          ParentFont = False
        end
        object GrouptgName: TfrxMemoView
          Left = 109.606370000000000000
          Top = 3.779530000000000000
          Width = 105.826840000000000000
          Height = 18.897650000000000000
          DataField = 'tgName'
          DataSet = frxDBDataset3
          DataSetName = 'Group'
          Memo.UTF8W = (
            '[Group."tgName"]')
        end
      end
      object GroupFooter1: TfrxGroupFooter
        FillType = ftBrush
        Height = 52.913420000000000000
        Top = 204.094620000000000000
        Width = 718.110700000000000000
        object Memo2: TfrxMemoView
          Left = 517.795610000000000000
          Top = 7.559060000000000000
          Width = 192.756030000000000000
          Height = 34.015770000000000000
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Fill.BackColor = 16774348
          Memo.UTF8W = (
            #1057#1088#1077#1076#1085#1103#1103' '#1089#1090#1080#1084#1086#1089#1090#1100': [AVG(<Group."gcCost">,MasterData1,1) #n%2,2m]'
            #1050#1086#1083#1080#1095#1077#1089#1090#1074#1086': [COUNT(MasterData1)]')
          ParentFont = False
        end
      end
    end
  end
end
