unit Unit2;

interface

uses
  System.SysUtils, System.Classes, Data.DB, Data.Win.ADODB, Dialogs;

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
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DataModule2: TDataModule2;

implementation

{ %CLASSGROUP 'Vcl.Controls.TControl' }

{$R *.dfm}

procedure TDataModule2.Q_IncomingGoodsDCalcFields(DataSet: TDataSet);
begin
  Q_IncomingGoodsDTotalCost.Value := Q_IncomingGoodsDigAmount.Value *
    Q_IncomingGoodsDCost.Value;
end;

procedure TDataModule2.T_GoodsCatalogBeforePost(DataSet: TDataSet);
begin
  if (Length(T_GoodsCataloggcName.AsString) < 3) or
    (Length(T_GoodsCataloggcMeasure.AsString) < 2) then
    raise Exception.Create('������������ ������ � ' +
      '������� ��������� �� ������ ����� ������ �������� ' +
      '��� �������� ������');
end;

procedure TDataModule2.DataModuleCreate(Sender: TObject);
begin
ADOConnection1.ConnectionString :=
    'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+ ExtractFilePath(paramstr(0)
    ) + 'DBAccess\Database11.mdb;Mode=ReadWrite;Persist ' +
    'Security Info=False';
  try
    ADOConnection1.Connected := true;
    showmessage('�������� ����������!');
    T_TypeGoods.Active := true;
    T_GoodsCatalog.Active := true;
    T_SuppliersCatalog.Active := true;
    T_IncomingGoods.Active := true;
    Q_GoodsCatalogD.Active := true;
    Q_IncomingGoodsD.Active := true;
  except
    showmessage('�� ������� �����������!');
  end;
end;

procedure TDataModule2.Q_GoodsCatalogDAfterScroll(DataSet: TDataSet);
begin
  if Q_GoodsCatalogD.RecordCount > 0 then
    T_GoodsCatalog.Locate('IDgc', Q_GoodsCatalogDIDgc.Value, [])
end;

procedure TDataModule2.T_GoodsCatalogAfterDelete(DataSet: TDataSet);
begin
  Q_GoodsCatalogD.Active := False;
  Q_GoodsCatalogD.Active := True;
end;

procedure TDataModule2.T_GoodsCatalogAfterPost(DataSet: TDataSet);
begin
  Q_GoodsCatalogD.Active := False;
  Q_GoodsCatalogD.Active := True;
end;

procedure TDataModule2.T_GoodsCataloggcCostChange(Sender: TField);
begin
  if T_GoodsCataloggcCost.Value > 1000 then
    raise Exception.Create('�������� ������ ���� <= 1000');
end;

procedure TDataModule2.T_GoodsCataloggcCostSetText(Sender: TField;
  const Text: string);
var
  Tmp: Real;
begin
  Tmp := StrToFloat(Text);
  if Tmp < 5 then
    ShowMessage('�������� ������ ���� >= 5')
  else
    T_GoodsCataloggcCost.Value := Tmp;
end;

procedure TDataModule2.T_SuppliersCatalogscEmailValidate(Sender: TField);
begin
  if not (pos('@', T_SuppliersCatalogscEmail.AsString) > 0) then
  begin
    ShowMessage('� ���� ����������� ������ @!');
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
