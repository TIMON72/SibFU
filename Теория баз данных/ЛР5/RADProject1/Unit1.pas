unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Data.Win.ADODB, Vcl.StdCtrls,
  Vcl.Grids, Vcl.DBGrids;

type
  TForm1 = class(TForm)
    ADOConnection1: TADOConnection;
    ADOQuery1: TADOQuery;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    ButtonSelect: TButton;
    ButtonInsert: TButton;
    ButtonDelete: TButton;
    ButtonUpdate: TButton;
    EditName: TEdit;
    EditType: TEdit;
    EditMeasure: TEdit;
    EditCost: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure ButtonSelectClick(Sender: TObject);
    procedure ButtonInsertClick(Sender: TObject);
    procedure ButtonDeleteClick(Sender: TObject);
    procedure ButtonUpdateClick(Sender: TObject);
    procedure DBGrid1CellClick(Column: TColumn);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.ButtonDeleteClick(Sender: TObject);
var
  QueryString: AnsiString;
begin
  QueryString := 'DELETE FROM goodscatalog WHERE IDgc = ' + DBGrid1.Fields
    [0].AsString;
  with ADOQuery1 do
  begin
    SQL.Clear;
    SQL.Add(QueryString);
    ExecSQL;
    SQL.Text := 'SELECT * FROM goodscatalog';
    Open;
  end;
end;

procedure TForm1.ButtonInsertClick(Sender: TObject);
begin
  with ADOQuery1 do
  begin
    SQL.Clear();
    SQL.Add('INSERT INTO goodscatalog (gcName, IDtg, gcMeasure, gcCost)');
    SQL.Add('VALUES (:Name, :Type, :Measure, :Cost)');
    Parameters.ParamByName('Name').Value := EditName.Text;
    Parameters.ParamByName('Type').Value := EditType.Text;
    Parameters.ParamByName('Measure').Value := EditMeasure.Text;
    Parameters.ParamByName('Cost').Value := EditCost.Text;
    ExecSQL;
    SQL.Text := 'SELECT * FROM goodscatalog';
    Open;
  end;
end;

procedure TForm1.ButtonSelectClick(Sender: TObject);
begin
  try
    with ADOQuery1 do
    begin
      SQL.Clear;
      SQL.Add('SELECT * FROM goodscatalog');
      Active := True;
      ShowMessage(IntToStr(RecordCount));
    end;
  except
    on e: Exception do
  end;
end;

procedure TForm1.ButtonUpdateClick(Sender: TObject);
var
  qry: AnsiString;
begin
  qry := 'UPDATE goodscatalog SET ';
  qry := qry + 'gcName=' + QuotedStr(EditName.Text) + ', ';
  qry := qry + 'IDtg=' + QuotedStr(EditType.Text) + ', ';
  qry := qry + 'gcMeasure=' + QuotedStr(EditMeasure.Text) + ', ';
  qry := qry + 'gcCost=' + QuotedStr(EditCost.Text) + ' ';
  qry := qry + 'WHERE IDgc=' + DBGrid1.Fields[0].AsString;
  with ADOQuery1 do
  begin
    SQL.Clear;
    SQL.Add(qry);
    ExecSQL;
    SQL.Text := 'SELECT * FROM goodscatalog';
    Open;
  end;
end;

procedure TForm1.DBGrid1CellClick(Column: TColumn);
var
  i: Integer;
begin
  for i := 1 to DBGrid1.FieldCount - 1 do
    TEdit(FindComponent('Edit' + IntToStr(i))).Text :=
      DBGrid1.Fields[i].AsString;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  ADOConnection1.ConnectionString :=
    'Provider=MSDASQL.1;Persist Security Info=True;User ID=root;Extended Properties="'
    + 'Driver=MySQL ODBC 5.1 Driver;SERVER=localhost;UID=root;DATABASE=mydatabase;'
    + 'PORT=3306;COLUMN_SIZE_S32=1";Initial Catalog=mydatabase';
  try
    ADOConnection1.Connected := True;
    ShowMessage('Успешное соединение!');
    // ADOQuery1.Active = true;
    // T_TypeGoods.Active := true;
    // T_GoodsCatalog.Active := true;
    // T_SuppliersCatalog.Active := true;
    // T_IncomingGoods.Active := true;
    // Q_GoodsCatalogD.Active := true;
    // Q_IncomingGoodsD.Active := true;
  except
    ShowMessage('Не удалось соединиться!');
  end;
end;

end.
