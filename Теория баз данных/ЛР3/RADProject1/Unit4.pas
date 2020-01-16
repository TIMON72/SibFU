unit Unit4;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Grids, Vcl.DBGrids,
  Vcl.ComCtrls, Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls, IWVCLBaseControl,
  IWBaseControl, IWBaseHTMLControl, IWControl, IWCompListbox, IWDBStdCtrls;

type
  TForm4 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    DBGrid1: TDBGrid;
    TabSheet2: TTabSheet;
    DBGrid2: TDBGrid;
    InsertButton: TButton;
    EditButton: TButton;
    DBLookupComboBox1: TDBLookupComboBox;
    DBEdit1: TDBEdit;
    DeleteButton: TButton;
    PostButton: TButton;
    DBEdit2: TDBEdit;
    CancelButton: TButton;
    DBEdit3: TDBEdit;
    EditTgName: TEdit;
    ButtonEdit: TButton;
    procedure Button1Click(Sender: TObject);
    procedure InsertButtonClick(Sender: TObject);
    procedure EditButtonClick(Sender: TObject);
    procedure DeleteButtonClick(Sender: TObject);
    procedure PostButtonClick(Sender: TObject);
    procedure CancelButtonClick(Sender: TObject);
    procedure ButtonEditClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

uses Unit1, Unit2, Unit3;

procedure TForm4.Button1Click(Sender: TObject);
begin
  DataModule2.Q_GoodsCatalogDgcCost.DisplayFormat := Edit1.Text;
end;

procedure TForm4.ButtonEditClick(Sender: TObject);
begin
  DataModule2.T_TypeGoods.Edit;
  DataModule2.T_TypeGoods.SetFields([nil, EditTgName.Text]);
  DataModule2.T_TypeGoods.Post;
end;

procedure TForm4.CancelButtonClick(Sender: TObject);
begin
  if DataModule2.T_GoodsCatalog.State in [dsInsert, dsEdit] then
    DataModule2.T_GoodsCatalog.Cancel;
end;

procedure TForm4.DeleteButtonClick(Sender: TObject);
begin
  if DataModule2.T_GoodsCatalog.State = dsBrowse then
    if MessageDlg('Подтвердите удаление записи', mtConfirmation, [mbYes, mbNo],
      0) = mrYes then
      DataModule2.T_GoodsCatalog.Delete;
end;

procedure TForm4.EditButtonClick(Sender: TObject);
begin
  if DataModule2.T_GoodsCatalog.State = dsBrowse then
    DataModule2.T_GoodsCatalog.Edit;
end;

procedure TForm4.InsertButtonClick(Sender: TObject);
begin
  if DataModule2.T_GoodsCatalog.State = dsBrowse then
    DataModule2.T_GoodsCatalog.Insert;
end;

procedure TForm4.PostButtonClick(Sender: TObject);
begin
  if DataModule2.T_GoodsCatalog.State in [dsInsert, dsEdit] then
    DataModule2.T_GoodsCatalog.Post;
end;

end.
