unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Grids, Vcl.DBGrids,
  Data.Win.ADODB, Vcl.StdCtrls, Vcl.DBCtrls, Vcl.Mask;

type
  TForm1 = class(TForm)
    ADOConnection1: TADOConnection;
    ADOTable1: TADOTable;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    ADOTable2: TADOTable;
    DataSource2: TDataSource;
    DBGrid2: TDBGrid;
    ADOTable2gcName: TWideStringField;
    ADOTable2IDtg: TIntegerField;
    ADOTable2gcMeasure: TWideStringField;
    ADOTable2gcCost: TBCDField;
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    DBEdit3: TDBEdit;
    DBLookupComboBox1: TDBLookupComboBox;
    InsertButton: TButton;
    EditButton: TButton;
    DeleteButton: TButton;
    PostButton: TButton;
    CancelButton: TButton;
    ADOQuery1: TADOQuery;
    DataSource3: TDataSource;
    DBGrid3: TDBGrid;
    ADOTable2IDgc: TAutoIncField;
    ADOQuery1IDgc: TAutoIncField;
    ADOQuery1gcName: TWideStringField;
    ADOQuery1tgName: TWideStringField;
    ADOQuery1gcMeasure: TWideStringField;
    ADOQuery1gcCost: TBCDField;
    procedure InsertButtonClick(Sender: TObject);
    procedure EditButtonClick(Sender: TObject);
    procedure DeleteButtonClick(Sender: TObject);
    procedure PostButtonClick(Sender: TObject);
    procedure CancelButtonClick(Sender: TObject);
    procedure ADOQuery1AfterScroll(DataSet: TDataSet);
    procedure ADOTable2AfterPost(DataSet: TDataSet);
    procedure ADOTable2AfterDelete(DataSet: TDataSet);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.ADOQuery1AfterScroll(DataSet: TDataSet);
begin
  if ADOQuery1.RecordCount > 0 then
    ADOTable2.Locate('IDgc', ADOQuery1IDgc.Value, [])
end;

procedure TForm1.ADOTable2AfterDelete(DataSet: TDataSet);
begin
  ADOQuery1.Active := False;
  ADOQuery1.Active := True;
end;

procedure TForm1.ADOTable2AfterPost(DataSet: TDataSet);
begin
  ADOQuery1.Active := False;
  ADOQuery1.Active := True;
end;

procedure TForm1.CancelButtonClick(Sender: TObject);
begin
  if ADOTable2.State in [dsInsert, dsEdit] then
    ADOTable2.Cancel;
end;

procedure TForm1.DeleteButtonClick(Sender: TObject);
begin
  if ADOTable2.State = dsBrowse then
    if MessageDlg('Подтвердите удаление записи', mtConfirmation, [mbYes, mbNo],
      0) = mrYes then
      ADOTable2.Delete;
end;

procedure TForm1.EditButtonClick(Sender: TObject);
begin
  if ADOTable2.State = dsBrowse then
    ADOTable2.Edit;
end;

procedure TForm1.InsertButtonClick(Sender: TObject);
begin
  if ADOTable2.State = dsBrowse then
    ADOTable2.Insert;
end;

procedure TForm1.PostButtonClick(Sender: TObject);
begin
  if ADOTable2.State in [dsInsert, dsEdit] then
    ADOTable2.Post;
end;

end.
