unit Unit3;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Menus, Vcl.Grids,
  Vcl.DBGrids, Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.DBCtrls;

type
  TForm3 = class(TForm)
    DBGrid1: TDBGrid;
    ButtonAddRecord: TButton;
    EditScName: TEdit;
    EditScAddress: TEdit;
    EditScPhone: TEdit;
    EditScEmail: TEdit;
    procedure Exit1Click(Sender: TObject);
    procedure N1Click(Sender: TObject);
    procedure DBGrid1TitleClick(Column: TColumn);
    procedure ButtonAddRecordClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form3: TForm3;

implementation

{$R *.dfm}

uses Unit1, Unit2, Unit4;

procedure TForm3.ButtonAddRecordClick(Sender: TObject);
begin
  DataModule2.T_SuppliersCatalog.AppendRecord
    ([EditScName.Text, EditScPhone.Text, EditScEmail.Text,
    EditScAddress.Text, nil]);
end;

procedure TForm3.DBGrid1TitleClick(Column: TColumn);
begin
  begin
    if DataModule2.T_SuppliersCatalog.Sort = Column.FieldName + ' ASC' then
      DataModule2.T_SuppliersCatalog.Sort := Column.FieldName + ' DESC'
    else
      DataModule2.T_SuppliersCatalog.Sort := Column.FieldName + ' ASC';
  end;
end;

procedure TForm3.Exit1Click(Sender: TObject);
begin
  Close;
end;

procedure TForm3.N1Click(Sender: TObject);
begin
  Form3.ShowModal;
end;

end.
