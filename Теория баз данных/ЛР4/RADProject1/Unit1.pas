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
    DateTimePicker4: TDateTimePicker;
    ButtonPost: TButton;
    ButtonCancel: TButton;
    DBEdit1: TDBEdit;
    EditFilter: TEdit;
    CheckBoxFilter: TCheckBox;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    EditGoodsName: TEdit;
    GroupBox3: TGroupBox;
    CheckBoxFilterDates: TCheckBox;
    ComboBox1: TComboBox;
    DateTimePicker1: TDateTimePicker;
    DateTimePicker2: TDateTimePicker;
    GroupBox4: TGroupBox;
    RadioGroup1: TRadioGroup;
    EditLocate: TEdit;
    ButtonLocate: TButton;
    ButtonFindLast: TButton;
    ButtonFindPrior: TButton;
    ButtonFindNext: TButton;
    ButtonFindFirst: TButton;
    EditFindScName: TEdit;
    FontDialog1: TFontDialog;
    ColorDialog1: TColorDialog;
    ButtonColumnsFont: TButton;
    ButtonCaptionsColumnsFont: TButton;
    ButtonSelectedColumnFont: TButton;
    ButtonSelectedColumnColor: TButton;
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
    procedure CheckBoxFilterClick(Sender: TObject);
    procedure EditGoodsNameChange(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
    procedure CheckBoxFilterDatesClick(Sender: TObject);
    procedure ButtonLocateClick(Sender: TObject);
    procedure ButtonFindLastClick(Sender: TObject);
    procedure ButtonFindFirstClick(Sender: TObject);
    procedure ButtonFindNextClick(Sender: TObject);
    procedure ButtonFindPriorClick(Sender: TObject);
    procedure EditFindScNameClick(Sender: TObject);
    procedure ButtonColumnsFontClick(Sender: TObject);
    procedure ButtonCaptionsColumnsFontClick(Sender: TObject);
    procedure ButtonSelectedColumnFontClick(Sender: TObject);
    procedure ButtonSelectedColumnColorClick(Sender: TObject);
    procedure DBGrid1DrawColumnCell(Sender: TObject; const Rect: TRect;
      DataCol: Integer; Column: TColumn; State: TGridDrawState);
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

procedure TForm1.ButtonCaptionsColumnsFontClick(Sender: TObject);
var
  i: Integer;
begin
  FontDialog1.Font := DBGrid1.Columns.Items[0].Title.Font;
  if FontDialog1.Execute then
    for i := 0 to DBGrid1.Columns.Count - 1 do
      DBGrid1.Columns.Items[i].Title.Font := FontDialog1.Font;
end;

procedure TForm1.ButtonColumnsFontClick(Sender: TObject);
var
  i: Integer;
begin
  FontDialog1.Font := DBGrid1.Columns.Items[0].Font;
  if FontDialog1.Execute then
    for i := 0 to DBGrid1.Columns.Count - 1 do
      DBGrid1.Columns.Items[i].Font := FontDialog1.Font;
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
  DateTimePicker4.Date := DataModule2.Q_IncomingGoodsDigDate.Value;
  DateTimePicker4.SetFocus;
end;

procedure TForm1.ButtonFindFirstClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Filtered := false;
  DataModule2.Q_IncomingGoodsD.FindFirst;
end;

procedure TForm1.ButtonFindLastClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Filtered := false;
  DataModule2.Q_IncomingGoodsD.FindLast;
end;

procedure TForm1.ButtonFindNextClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Filtered := false;
  DataModule2.Q_IncomingGoodsD.FindNext;
end;

procedure TForm1.ButtonFindPriorClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Filtered := false;
  DataModule2.Q_IncomingGoodsD.FindPrior;
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
  DateTimePicker4.Date := now;
  DateTimePicker4.SetFocus;
end;

procedure TForm1.ButtonLastRecordClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Last;
end;

procedure TForm1.ButtonLocateClick(Sender: TObject);
var
  Pole: ShortString;
begin
  case RadioGroup1.ItemIndex of
    0:
      Pole := 'gcName';
    1:
      Pole := 'scName';
  end;
  if not DataModule2.Q_IncomingGoodsD.Locate(Pole, EditLocate.Text,
    [loCaseInsensitive, loPartialKey]) then
    ShowMessage('Запись не найдена');
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

procedure TForm1.ButtonSelectedColumnColorClick(Sender: TObject);
begin
  ColorDialog1.Color := DBGrid1.Columns.Items[DBGrid1.SelectedIndex].Color;
  if ColorDialog1.Execute then
    DBGrid1.Columns.Items[DBGrid1.SelectedIndex].Color := ColorDialog1.Color;
end;

procedure TForm1.ButtonSelectedColumnFontClick(Sender: TObject);
begin
  FontDialog1.Font := DBGrid1.Columns.Items[DBGrid1.SelectedIndex].Font;
  if FontDialog1.Execute then
    DBGrid1.Columns.Items[DBGrid1.SelectedIndex].Font := FontDialog1.Font;
end;

procedure TForm1.CheckBoxFilterClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Filtered := false;
  DataModule2.Q_IncomingGoodsD.Filter := EditFilter.Text;
  DataModule2.Q_IncomingGoodsD.Filtered := CheckBoxFilter.Checked;
end;

procedure TForm1.CheckBoxFilterDatesClick(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Filtered := false;
  if not DateTimePicker2.Visible then
    DataModule2.Q_IncomingGoodsD.Filter := '[igDate]' + ComboBox1.Text +
      QuotedStr(FormatDateTime('dd/mm/yy', DateTimePicker1.Date))
  else if (ComboBox1.Text = 'В диапазоне') then
    DataModule2.Q_IncomingGoodsD.Filter := '([igDate] >= ' +
      QuotedStr(FormatDateTime('dd/mm/yy', DateTimePicker1.Date)) +
      ') and ([igDate] <= ' + QuotedStr(FormatDateTime('dd/mm/yy',
      DateTimePicker2.Date)) + ')'
  else if (ComboBox1.Text = 'Вне диапазона') then
    DataModule2.Q_IncomingGoodsD.Filter := '([igDate] < ' +
      QuotedStr(FormatDateTime('dd/mm/yy', DateTimePicker1.Date)) +
      ') or ([igDate] > ' + QuotedStr(FormatDateTime('dd/mm/yy',
      DateTimePicker2.Date)) + ')';
  DataModule2.Q_IncomingGoodsD.Filtered := CheckBoxFilterDates.Checked;
end;

procedure TForm1.ComboBox1Change(Sender: TObject);
begin
  if (ComboBox1.Text = 'В диапазоне') or (ComboBox1.Text = 'Вне диапазона') then
    DateTimePicker2.Visible := true
  else
    DateTimePicker2.Visible := false;
  CheckBoxFilterDatesClick(self);
end;

procedure TForm1.DBGrid1DrawColumnCell(Sender: TObject; const Rect: TRect;
  DataCol: Integer; Column: TColumn; State: TGridDrawState);
begin
  with DBGrid1.Canvas do
  begin
    if (DataModule2.Q_IncomingGoodsDigAmount.Value <= 15) and
      not(gdSelected in State) then
    begin
      Brush.Color := clRed;
      Font.Color := clWhite;
    end;
  end;
  DBGrid1.DefaultDrawColumnCell(Rect, DataCol, Column, State);
end;

procedure TForm1.EditFindScNameClick(Sender: TObject);
var
  LookupResult: Variant;
begin
  LookupResult := DataModule2.Q_IncomingGoodsD.Lookup('gcName',
    EditGoodsName.Text, 'scName');
  if LookupResult = null then
    EditFindScName.Text := 'Результат не найден'
  else
    EditFindScName.Text := LookupResult;
end;

procedure TForm1.EditGoodsNameChange(Sender: TObject);
begin
  DataModule2.Q_IncomingGoodsD.Filtered := false;
  if length(EditGoodsName.Text) > 0 then
  begin
    DataModule2.Q_IncomingGoodsD.Filter := '[gcName] like ' +
      QuotedStr('%' + EditGoodsName.Text + '%');
    DataModule2.Q_IncomingGoodsD.Filtered := true;
  end;
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
