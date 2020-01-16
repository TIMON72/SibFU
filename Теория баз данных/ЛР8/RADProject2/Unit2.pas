unit Unit2;

interface

uses
  System.SysUtils, System.Classes, Data.DB, Data.Win.ADODB, Dialogs, frxClass,
  frxDBSet;

type
  TDataModule2 = class(TDataModule)
    ADOConnection1: TADOConnection;
    T_GoodsCatalog: TADOTable;
    T_SuppliersCatalog: TADOTable;
    T_TypeGoods: TADOTable;
    T_IncomingGoods: TADOTable;
    Q_GoodsCatalogD: TADOQuery;
    Q_IncomingGoodsD: TADOQuery;
    DS_T_GoodsCatalog: TDataSource;
    DS_T_SuppliersCatalog: TDataSource;
    DS_T_TypeGoods: TDataSource;
    DS_T_IncomingGoods: TDataSource;
    DS_Q_GoodsCatalogD: TDataSource;
    DS_Q_IncomingGoodsD: TDataSource;
    T_SuppliersCatalogscName: TWideStringField;
    Q_GoodsCatalogDgcCost: TBCDField;
    T_SuppliersCatalogscPhone: TWideStringField;
    T_SuppliersCatalogscEmail: TWideStringField;
    T_GoodsCataloggcCost: TBCDField;
    T_GoodsCataloggcName: TWideStringField;
    T_GoodsCataloggcMeasure: TWideStringField;
    T_SuppliersCatalogscAddress: TWideStringField;
    Q_GoodsCatalogDIDgc: TAutoIncField;
    Q_GoodsCatalogDgcName: TWideStringField;
    Q_GoodsCatalogDtgName: TWideStringField;
    Q_GoodsCatalogDgcMeasure: TWideStringField;
    T_GoodsCatalogIDgc: TAutoIncField;
    T_GoodsCatalogIDtg: TIntegerField;
    T_SuppliersCatalogIDsc: TAutoIncField;
    T_TypeGoodsIDtg: TAutoIncField;
    T_TypeGoodstgName: TWideStringField;
    T_IncomingGoodsIDig: TAutoIncField;
    T_IncomingGoodsigDate: TDateTimeField;
    T_IncomingGoodsIDgc: TIntegerField;
    T_IncomingGoodsigAmount: TIntegerField;
    T_IncomingGoodsIDsc: TIntegerField;
    Q_IncomingGoodsDCost: TCurrencyField;
    Q_IncomingGoodsDIDig: TAutoIncField;
    Q_IncomingGoodsDIDgc: TAutoIncField;
    Q_IncomingGoodsDgcName: TWideStringField;
    Q_IncomingGoodsDigDate: TDateTimeField;
    Q_IncomingGoodsDigAmount: TIntegerField;
    Q_IncomingGoodsDscName: TWideStringField;
    Q_IncomingGoodsDTotalCost: TCurrencyField;
    frxDBDataset1: TfrxDBDataset;
    frxReport2: TfrxReport;
    frxReport1: TfrxReport;
    frxDBDataset2: TfrxDBDataset;
    procedure T_SuppliersCatalogscNameGetText(Sender: TField; var Text: string;
      DisplayText: Boolean);
    procedure T_SuppliersCatalogscEmailValidate(Sender: TField);
    procedure T_GoodsCataloggcCostSetText(Sender: TField; const Text: string);
    procedure T_GoodsCataloggcCostChange(Sender: TField);
    procedure T_GoodsCatalogBeforePost(DataSet: TDataSet);
    procedure Q_IncomingGoodsDCalcFields(DataSet: TDataSet);
    procedure T_GoodsCatalogAfterDelete(DataSet: TDataSet);
    procedure T_GoodsCatalogAfterPost(DataSet: TDataSet);
    procedure Q_GoodsCatalogDAfterScroll(DataSet: TDataSet);
    procedure DataModuleCreate(Sender: TObject);
    procedure Q_IncomingGoodsDAfterScroll(DataSet: TDataSet);
    procedure T_IncomingGoodsAfterPost(DataSet: TDataSet);
    procedure T_IncomingGoodsAfterDelete(DataSet: TDataSet);
    procedure T_IncomingGoodsigAmountChange(Sender: TField);
    procedure Q_GoodsCatalogDFilterRecord(DataSet: TDataSet;
      var Accept: Boolean);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DataModule2: TDataModule2;
  PrihodBookmark: TBookmark;

implementation

{ %CLASSGROUP 'Vcl.Controls.TControl' }

uses Unit4;

{$R *.dfm}

procedure TDataModule2.Q_IncomingGoodsDAfterScroll(DataSet: TDataSet);
begin
  if Q_IncomingGoodsD.RecordCount > 0 then
    T_IncomingGoods.Locate('IDig', Q_IncomingGoodsDIDig.Value, [])
end;

procedure TDataModule2.Q_IncomingGoodsDCalcFields(DataSet: TDataSet);
begin
  Q_IncomingGoodsDTotalCost.Value := Q_IncomingGoodsDigAmount.Value *
    Q_IncomingGoodsDCost.Value;
end;

procedure TDataModule2.T_GoodsCatalogBeforePost(DataSet: TDataSet);
begin
  if (Length(T_GoodsCataloggcName.AsString) < 3) or
    (Length(T_GoodsCataloggcMeasure.AsString) < 2) then
    raise Exception.Create('Наименование товара и ' +
      'единицы измерения не должны иметь пустые значения ' +
      'или короткие записи');
end;

procedure TDataModule2.DataModuleCreate(Sender: TObject);
begin
  ADOConnection1.ConnectionString :=
    'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=' +
    ExtractFilePath(paramstr(0)) +
    'DBAccess\Database11.mdb;Mode=ReadWrite;Persist ' + 'Security Info=False';
  try
    ADOConnection1.Connected := true;
    showmessage('Успешное соединение!');
    T_TypeGoods.Active := true;
    T_GoodsCatalog.Active := true;
    T_SuppliersCatalog.Active := true;
    T_IncomingGoods.Active := true;
    Q_GoodsCatalogD.Active := true;
    Q_IncomingGoodsD.Active := true;
  except
    showmessage('Не удалось соединиться!');
  end;
end;

procedure TDataModule2.Q_GoodsCatalogDAfterScroll(DataSet: TDataSet);
begin
  if Q_GoodsCatalogD.RecordCount > 0 then
    T_GoodsCatalog.Locate('IDgc', Q_GoodsCatalogDIDgc.Value, [])
end;

procedure TDataModule2.Q_GoodsCatalogDFilterRecord(DataSet: TDataSet;
  var Accept: Boolean);
begin
  if Assigned(Form4) then
    Accept := DataSet['gcCost'] > (strtofloat(Form4.E_MinCost.Text))
  else
    Accept := true;
end;

procedure TDataModule2.T_GoodsCatalogAfterDelete(DataSet: TDataSet);
begin
  Q_GoodsCatalogD.Active := False;
  Q_GoodsCatalogD.Active := true;
end;

procedure TDataModule2.T_GoodsCatalogAfterPost(DataSet: TDataSet);
begin
  Q_GoodsCatalogD.Active := False;
  Q_GoodsCatalogD.Active := true;
end;

procedure TDataModule2.T_GoodsCataloggcCostChange(Sender: TField);
begin
  if T_GoodsCataloggcCost.Value > 1000 then
    raise Exception.Create('Значение должно быть <= 1000');
end;

procedure TDataModule2.T_GoodsCataloggcCostSetText(Sender: TField;
  const Text: string);
var
  Tmp: Real;
begin
  Tmp := strtofloat(Text);
  if Tmp < 5 then
    showmessage('Значение должно быть >= 5')
  else
    T_GoodsCataloggcCost.Value := Tmp;
end;

procedure TDataModule2.T_IncomingGoodsAfterDelete(DataSet: TDataSet);
begin
  Q_GoodsCatalogD.Active := False;
  Q_GoodsCatalogD.Active := true;
end;

procedure TDataModule2.T_IncomingGoodsAfterPost(DataSet: TDataSet);
begin
  Q_GoodsCatalogD.Active := False;
  Q_GoodsCatalogD.Active := true;
  if Q_GoodsCatalogD.BookmarkValid(PrihodBookmark) then
  begin
    Q_GoodsCatalogD.GotoBookmark(PrihodBookmark);
    PrihodBookmark := nil;
  end;
end;

procedure TDataModule2.T_IncomingGoodsigAmountChange(Sender: TField);
begin
  if T_IncomingGoodsigAmount.Value <= 0 then
    raise Exception.Create('Количество должно быть больше нуля');
end;

procedure TDataModule2.T_SuppliersCatalogscEmailValidate(Sender: TField);
begin
  if not(pos('@', T_SuppliersCatalogscEmail.AsString) > 0) then
  begin
    showmessage('В поле отсутствует символ @!');
    Abort;
  end;
end;

procedure TDataModule2.T_SuppliersCatalogscNameGetText(Sender: TField;
  var Text: string; DisplayText: Boolean);
begin
  if DisplayText then
    Text := '"' + T_SuppliersCatalogscName.AsString + '"'
  else
    Text := AnsiUpperCase(T_SuppliersCatalogscName.AsString);
end;

end.
