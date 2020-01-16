unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.Menus, Data.DB, Vcl.Grids,
  Vcl.DBGrids, Vcl.StdCtrls, Vcl.DBCtrls, Vcl.ExtCtrls, Vcl.ComCtrls, Vcl.Mask;

type
  TForm1 = class(TForm)
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N2: TMenuItem;
    N3: TMenuItem;
    N4: TMenuItem;
    DBText1: TDBText;
    DBGrid1: TDBGrid;
    ButtonFirstRecord: TButton;
    ButtonLastRecord: TButton;
    ButtonNextRecord: TButton;
    ButtonPreviousRecord: TButton;
    ButtonGetBookmark: TButton;
    ButtonGotoBookmark: TButton;
    ButtonFreeBookmark: TButton;
    Panel1: TPanel;
    Panel2: TPanel;
    PanelInsertEditDelete: TPanel;
    ButtonInsert: TButton;
    ButtonEdit: TButton;
    ButtonDelete: TButton;
    PanelToInputValues: TPanel;
    DBLookupComboBox1: TDBLookupComboBox;
    DBLookupComboBox2: TDBLookupComboBox;
    DateTimePicker1: TDateTimePicker;
    ButtonPost: TButton;
    ButtonCancel: TButton;
    DBEdit1: TDBEdit;
    procedure N2Click(Sender: TObject);
    procedure N3Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure ButtonFirstRecordClick(Sender: TObject);
    procedure ButtonLastRecordClick(Sender: TObject);
    procedure ButtonNextRecordClick(Sender: TObject);
    procedure ButtonPreviousRecordClick(Sender: TObject);
    procedure ButtonGetBookmarkClick(Sender: TObject);
    procedure ButtonGotoBookmarkClick(Sender: TObject);
    procedure ButtonFreeBookmarkClick(Sender: TObject);
    procedure ButtonInsertClick(Sender: TObject);
    procedure ButtonEditClick(Sender: TObject);
    procedure ButtonDeleteClick(Sender: TObject);
    procedure ButtonPostClick(Sender: TObject);
    procedure ButtonCancelClick(Sender: TObject);
    procedure FormDeactivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  MyBookmark: TBookmark;

implementation

{$R *.dfm}

uses Unit2, Unit3, Unit4;

procedure TForm1.ButtonCancelClick(Sender: TObject);
begin
  DataModule2.T_IncomingGoods.Cancel;
  PanelToInputValues.Visible := false;
  PanelInsertEditDelete.Visible := true;
  DBGrid1.Enabled := true;
  DBGrid1.SetFocus;
end;

procedure TForm1.ButtonDeleteClick(Sender: TObject);
begin
  if MessageDlg('Подтвердите удаление записи', mtConfirmation, [mbYes, mbNo], 0)
    = mrYes then
    DataModule2.T_IncomingGoods.Delete;
  DBGrid1.SetFocus;
end;

procedure TForm1.ButtonEditClick(Sender: TObject);
begin
  PrihodBookmark := DataModule2.Q_GoodsCatalogD.GetBookmark;
  DBGrid1.Enabled := false;
  PanelInsertEditDelete.Visible := false;
  PanelToInputValues.Visible := true;
  DataModule2.T_IncomingGoods.Edit;
  DateTimePicker1.Date := DataModule2.Q_IncomingGoodsDigDate.Value;
  DateTimePicker1.SetFocus;
end;

procedure TForm1.ButtonFirstRecordClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.First;
end;

procedure TForm1.ButtonFreeBookmarkClick(Sender: TObject);
begin
  if DataModule2.Q_IncomingGoodsD.BookmarkValid(MyBookmark) then
    MyBookmark := nil;
end;

procedure TForm1.ButtonGetBookmarkClick(Sender: TObject);
begin
  MyBookmark := DataModule2.Q_IncomingGoodsD.GetBookmark;
end;

procedure TForm1.ButtonGotoBookmarkClick(Sender: TObject);
begin
  if DataModule2.Q_IncomingGoodsD.BookmarkValid(MyBookmark) then
    DataModule2.Q_IncomingGoodsD.GotoBookmark(MyBookmark);
end;

procedure TForm1.ButtonInsertClick(Sender: TObject);
begin
  DBGrid1.Enabled := false;
  PanelInsertEditDelete.Visible := false;
  PanelToInputValues.Visible := true;
  DataModule2.T_IncomingGoods.Append;
  DateTimePicker1.Date := now;
  DateTimePicker1.SetFocus;
end;

procedure TForm1.ButtonLastRecordClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Last;
end;

procedure TForm1.ButtonNextRecordClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Next;
end;

procedure TForm1.ButtonPostClick(Sender: TObject);
begin
  DataModule2.T_IncomingGoodsigDate.Value := DateTimePicker1.Date;
  try
    DataModule2.T_IncomingGoods.Post
  finally
    PanelToInputValues.Visible := false;
    PanelInsertEditDelete.Visible := true;
    DBGrid1.Enabled := true;
    DBGrid1.SetFocus;
  end;
end;

procedure TForm1.ButtonPreviousRecordClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Prior;
end;

procedure TForm1.FormDeactivate(Sender: TObject);
begin
  if DataModule2.T_IncomingGoods.State <> dsBrowse then
    ButtonCancelClick(nil);
end;

procedure TForm1.N2Click(Sender: TObject);
begin
  Application.Terminate;
end;

procedure TForm1.N3Click(Sender: TObject);
begin
  Form3.ShowModal;
end;

procedure TForm1.N4Click(Sender: TObject);
begin
  Form4.ShowModal;
end;

end.
