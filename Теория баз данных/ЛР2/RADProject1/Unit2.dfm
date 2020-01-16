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
    end
    object T_IncomingGoodsIDsc: TIntegerField
      FieldName = 'IDsc'
    end
  end
  object Q_GoodsCatalogD: TADOQuery
    Connection = ADOConnection1
    CursorType = ctStatic
    AfterScroll = Q_GoodsCatalogDAfterScroll
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
end
