object DataModule2: TDataModule2
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  Height = 385
  Width = 685
  object ADOConnection1: TADOConnection
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Cloud Drivers\On' +
      'eDrive\'#1058#1041#1044'\'#1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1099#1077' '#1088#1072#1073#1086#1090#1099'\'#1051#1056'2\RADProject1\DBAccess\Database' +
      '11.mdb;Persist Security Info=False;'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 32
    Top = 8
  end
  object T_GoodsCatalog: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    BeforePost = T_GoodsCatalogBeforePost
    AfterPost = T_GoodsCatalogAfterPost
    AfterDelete = T_GoodsCatalogAfterDelete
    TableDirect = True
    TableName = 'GoodsCatalog'
    Left = 32
    Top = 64
    object T_GoodsCataloggcCost: TBCDField
      FieldName = 'gcCost'
      OnChange = T_GoodsCataloggcCostChange
      OnSetText = T_GoodsCataloggcCostSetText
      Precision = 19
    end
    object T_GoodsCataloggcName: TWideStringField
      FieldName = 'gcName'
      Size = 50
    end
    object T_GoodsCataloggcMeasure: TWideStringField
      FieldName = 'gcMeasure'
    end
    object T_GoodsCatalogIDgc: TAutoIncField
      FieldName = 'IDgc'
      ReadOnly = True
    end
    object T_GoodsCatalogIDtg: TIntegerField
      FieldName = 'IDtg'
    end
  end
  object T_SuppliersCatalog: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'SuppliersCatalog'
    Left = 32
    Top = 120
    object T_SuppliersCatalogscName: TWideStringField
      FieldName = 'scName'
      OnGetText = T_SuppliersCatalogscNameGetText
      Size = 40
    end
    object T_SuppliersCatalogscPhone: TWideStringField
      FieldName = 'scPhone'
      EditMask = '!\(999\)000-0000;0;_'
    end
    object T_SuppliersCatalogscEmail: TWideStringField
      FieldName = 'scEmail'
      OnValidate = T_SuppliersCatalogscEmailValidate
      Size = 30
    end
    object T_SuppliersCatalogscAddress: TWideStringField
      FieldName = 'scAddress'
      Size = 80
    end
    object T_SuppliersCatalogIDsc: TAutoIncField
      FieldName = 'IDsc'
      ReadOnly = True
    end
  end
  object T_TypeGoods: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'TypeGoods'
    Left = 32
    Top = 176
    object T_TypeGoodsIDtg: TAutoIncField
      FieldName = 'IDtg'
      ReadOnly = True
    end
    object T_TypeGoodstgName: TWideStringField
      FieldName = 'tgName'
      Size = 50
    end
  end
  object T_IncomingGoods: TADOTable
    Connection = ADOConnection1
    CursorType = ctStatic
    AfterPost = T_IncomingGoodsAfterPost
    AfterDelete = T_IncomingGoodsAfterDelete
    TableName = 'IncomingGoods'
    Left = 32
    Top = 232
    object T_IncomingGoodsIDig: TAutoIncField
      FieldName = 'IDig'
      ReadOnly = True
    end
    object T_IncomingGoodsigDate: TDateTimeField
      FieldName = 'igDate'
    end
    object T_IncomingGoodsIDgc: TIntegerField
      FieldName = 'IDgc'
    end
    object T_IncomingGoodsigAmount: TIntegerField
      FieldName = 'igAmount'
      OnChange = T_IncomingGoodsigAmountChange
    end
    object T_IncomingGoodsIDsc: TIntegerField
      FieldName = 'IDsc'
    end
  end
  object Q_GoodsCatalogD: TADOQuery
    Connection = ADOConnection1
    CursorType = ctStatic
    AfterScroll = Q_GoodsCatalogDAfterScroll
    OnFilterRecord = Q_GoodsCatalogDFilterRecord
    Parameters = <>
    SQL.Strings = (
      'SELECT GC.IDgc, GC.gcName, TG.tgName, GC.gcMeasure, GC.gcCost'
      'FROM GoodsCatalog GC, TypeGoods TG'
      'WHERE GC.IDtg = TG.IDtg'
      'ORDER BY TG.tgName, GC.gcName;')
    Left = 240
    Top = 64
    object Q_GoodsCatalogDgcCost: TBCDField
      FieldName = 'gcCost'
      Precision = 19
    end
    object Q_GoodsCatalogDIDgc: TAutoIncField
      FieldName = 'IDgc'
      ReadOnly = True
    end
    object Q_GoodsCatalogDgcName: TWideStringField
      FieldName = 'gcName'
      Size = 50
    end
    object Q_GoodsCatalogDtgName: TWideStringField
      FieldName = 'tgName'
      Size = 50
    end
    object Q_GoodsCatalogDgcMeasure: TWideStringField
      FieldName = 'gcMeasure'
    end
  end
  object Q_IncomingGoodsD: TADOQuery
    Connection = ADOConnection1
    CursorType = ctStatic
    AfterScroll = Q_IncomingGoodsDAfterScroll
    OnCalcFields = Q_IncomingGoodsDCalcFields
    Parameters = <>
    SQL.Strings = (
      
        'SELECT IncomingGoods.IDig, GoodsCatalog.IDgc, GoodsCatalog.gcNam' +
        'e, IncomingGoods.igDate, IncomingGoods.igAmount, SuppliersCatalo' +
        'g.scName'
      
        'FROM SuppliersCatalog INNER JOIN (GoodsCatalog INNER JOIN Incomi' +
        'ngGoods ON GoodsCatalog.IDgc = IncomingGoods.IDgc) ON SuppliersC' +
        'atalog.IDsc = IncomingGoods.IDsc;')
    Left = 248
    Top = 232
    object Q_IncomingGoodsDCost: TCurrencyField
      FieldKind = fkLookup
      FieldName = 'Cost'
      LookupDataSet = T_GoodsCatalog
      LookupKeyFields = 'IDgc'
      LookupResultField = 'gcCost'
      KeyFields = 'IDgc'
      Lookup = True
    end
    object Q_IncomingGoodsDIDig: TAutoIncField
      FieldName = 'IDig'
      ReadOnly = True
    end
    object Q_IncomingGoodsDIDgc: TAutoIncField
      FieldName = 'IDgc'
      ReadOnly = True
    end
    object Q_IncomingGoodsDgcName: TWideStringField
      FieldName = 'gcName'
      Size = 50
    end
    object Q_IncomingGoodsDigDate: TDateTimeField
      FieldName = 'igDate'
    end
    object Q_IncomingGoodsDigAmount: TIntegerField
      FieldName = 'igAmount'
    end
    object Q_IncomingGoodsDscName: TWideStringField
      FieldName = 'scName'
      Size = 40
    end
    object Q_IncomingGoodsDTotalCost: TCurrencyField
      FieldKind = fkCalculated
      FieldName = 'TotalCost'
      Calculated = True
    end
  end
  object DS_T_GoodsCatalog: TDataSource
    AutoEdit = False
    DataSet = T_GoodsCatalog
    Left = 136
    Top = 64
  end
  object DS_T_SuppliersCatalog: TDataSource
    DataSet = T_SuppliersCatalog
    Left = 144
    Top = 120
  end
  object DS_T_TypeGoods: TDataSource
    DataSet = T_TypeGoods
    Left = 120
    Top = 176
  end
  object DS_T_IncomingGoods: TDataSource
    DataSet = T_IncomingGoods
    Left = 136
    Top = 232
  end
  object DS_Q_GoodsCatalogD: TDataSource
    DataSet = Q_GoodsCatalogD
    Left = 352
    Top = 64
  end
  object DS_Q_IncomingGoodsD: TDataSource
    DataSet = Q_IncomingGoodsD
    Left = 360
    Top = 232
  end
  object frxDBDataset1: TfrxDBDataset
    UserName = 'frxDBDataset1'
    CloseDataSource = False
    DataSet = Q_GoodsCatalogD
    BCDToCurrency = False
    Left = 472
    Top = 112
  end
  object frxReport2: TfrxReport
    Version = '5.3.14'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 1.000000000000000000
    PrintOptions.Printer = 'Default'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 42856.593690138900000000
    ReportOptions.LastChange = 42856.602346030090000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      ''
      'begin'
      ''
      'end.')
    Left = 552
    Top = 184
    Datasets = <
      item
        DataSet = frxDBDataset2
        DataSetName = 'Goods'
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
      Columns = 2
      ColumnWidth = 95.000000000000000000
      ColumnPositions.Strings = (
        '0'
        '95')
      object ReportTitle1: TfrxReportTitle
        FillType = ftBrush
        Height = 22.677180000000000000
        Top = 18.897650000000000000
        Width = 718.110700000000000000
      end
      object MasterData1: TfrxMasterData
        FillType = ftBrush
        Height = 56.692950000000000000
        Top = 102.047310000000000000
        Width = 359.055350000000000000
        Child = frxReport2.Child1
        DataSet = frxDBDataset2
        DataSetName = 'Goods'
        KeepChild = True
        RowCount = 0
        Stretched = True
        object Memo2: TfrxMemoView
          Left = 7.559060000000000000
          Top = 11.338590000000000000
          Width = 94.488250000000000000
          Height = 18.897650000000000000
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Memo.UTF8W = (
            #1040#1088#1090#1080#1082#1091#1083)
          ParentFont = False
        end
        object Memo3: TfrxMemoView
          Left = 7.559060000000000000
          Top = 34.015769999999990000
          Width = 94.488250000000000000
          Height = 18.897650000000000000
          Memo.UTF8W = (
            #1053#1072#1080#1084#1077#1085#1086#1074#1072#1085#1080#1077)
        end
        object GoodsIDgc: TfrxMemoView
          Left = 113.385900000000000000
          Top = 11.338590000000000000
          Width = 79.370130000000000000
          Height = 18.897650000000000000
          DataField = 'IDgc'
          DataSet = frxDBDataset2
          DataSetName = 'Goods'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Memo.UTF8W = (
            '[Goods."IDgc"]')
          ParentFont = False
        end
        object GoodsgeName: TfrxMemoView
          Left = 113.385900000000000000
          Top = 34.015769999999990000
          Width = 113.385900000000000000
          Height = 18.897650000000000000
          StretchMode = smActualHeight
          DataField = 'geName'
          DataSet = frxDBDataset2
          DataSetName = 'Goods'
          Memo.UTF8W = (
            '[Goods."geName"]')
        end
      end
      object PageFooter1: TfrxPageFooter
        FillType = ftBrush
        Height = 22.677180000000000000
        Top = 298.582870000000000000
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
      object Child1: TfrxChild
        FillType = ftBrush
        Height = 56.692950000000000000
        Top = 181.417440000000000000
        Width = 359.055350000000000000
        object Memo4: TfrxMemoView
          Left = 7.559060000000000000
          Top = 7.559059999999988000
          Width = 94.488250000000000000
          Height = 18.897650000000000000
          Memo.UTF8W = (
            #1045#1076'. '#1080#1079#1084#1077#1088#1077#1085#1080#1103)
        end
        object Memo5: TfrxMemoView
          Left = 7.559060000000000000
          Top = 30.236240000000010000
          Width = 94.488250000000000000
          Height = 18.897650000000000000
          Memo.UTF8W = (
            #1062#1077#1085#1072)
        end
        object GoodsgeMeasure: TfrxMemoView
          Left = 113.385900000000000000
          Top = 7.559059999999988000
          Width = 128.504020000000000000
          Height = 18.897650000000000000
          DataField = 'geMeasure'
          DataSet = frxDBDataset2
          DataSetName = 'Goods'
          Memo.UTF8W = (
            '[Goods."geMeasure"]')
        end
        object GoodsgeCost: TfrxMemoView
          Left = 113.385900000000000000
          Top = 30.236240000000010000
          Width = 105.826840000000000000
          Height = 18.897650000000000000
          DataField = 'geCost'
          DataSet = frxDBDataset2
          DataSetName = 'Goods'
          Memo.UTF8W = (
            '[Goods."geCost"]')
        end
      end
    end
  end
  object frxReport1: TfrxReport
    Version = '5.3.14'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 1.000000000000000000
    PrintOptions.Printer = 'Default'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 42856.572497372700000000
    ReportOptions.LastChange = 42856.685337210600000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      ''
      'begin'
      ''
      'end.')
    Left = 552
    Top = 112
    Datasets = <
      item
        DataSet = frxDBDataset1
        DataSetName = 'frxDBDataset1'
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
        Height = 45.354360000000000000
        Top = 18.897650000000000000
        Width = 718.110700000000000000
        object Memo2: TfrxMemoView
          Left = 279.685220000000000000
          Top = 18.897650000000000000
          Width = 120.944960000000000000
          Height = 18.897650000000000000
          Memo.UTF8W = (
            #1057#1087#1080#1089#1086#1082' '#1090#1086#1074#1072#1088#1086#1074)
        end
      end
      object MasterData1: TfrxMasterData
        FillType = ftBrush
        Height = 34.015770000000000000
        Top = 124.724490000000000000
        Width = 718.110700000000000000
        DataSet = frxDBDataset1
        DataSetName = 'frxDBDataset1'
        RowCount = 0
        object frxDBDataset1geName: TfrxMemoView
          Left = 34.015770000000000000
          Top = 7.559059999999988000
          Width = 400.630180000000000000
          Height = 18.897650000000000000
          DataField = 'geName'
          DataSet = frxDBDataset1
          DataSetName = 'frxDBDataset1'
          Memo.UTF8W = (
            '[frxDBDataset1."geName"]')
        end
        object frxDBDataset1tgName: TfrxMemoView
          Left = 196.535560000000000000
          Top = 7.559059999999988000
          Width = 400.630180000000000000
          Height = 18.897650000000000000
          DataField = 'tgName'
          DataSet = frxDBDataset1
          DataSetName = 'frxDBDataset1'
          Memo.UTF8W = (
            '[frxDBDataset1."tgName"]')
        end
        object frxDBDataset1geMeasure: TfrxMemoView
          Left = 359.055350000000000000
          Top = 7.559059999999988000
          Width = 158.740260000000000000
          Height = 18.897650000000000000
          DataField = 'geMeasure'
          DataSet = frxDBDataset1
          DataSetName = 'frxDBDataset1'
          Memo.UTF8W = (
            '[frxDBDataset1."geMeasure"]')
        end
        object frxDBDataset1geCost: TfrxMemoView
          Left = 529.134200000000000000
          Top = 7.559059999999988000
          Width = 158.740260000000000000
          Height = 18.897650000000000000
          DataField = 'geCost'
          DataSet = frxDBDataset1
          DataSetName = 'frxDBDataset1'
          Memo.UTF8W = (
            '[frxDBDataset1."geCost"]')
        end
        object Memo3: TfrxMemoView
          Left = 34.015770000000000000
          Top = 11.338590000000010000
          Width = 653.858690000000000000
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
        Top = 219.212740000000000000
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
    end
  end
  object frxDBDataset2: TfrxDBDataset
    UserName = 'Goods'
    CloseDataSource = False
    DataSet = T_GoodsCatalog
    BCDToCurrency = False
    Left = 472
    Top = 184
  end
end
