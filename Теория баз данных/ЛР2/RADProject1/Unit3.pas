unit Unit3;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Menus, Vcl.Grids,
  Vcl.DBGrids;

type
  TForm3 = class(TForm)
    DBGrid1: TDBGrid;
    procedure Exit1Click(Sender: TObject);
    procedure N1Click(Sender: TObject);
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

procedure TForm3.Exit1Click(Sender: TObject);
begin
  Close;
end;

procedure TForm3.N1Click(Sender: TObject);
begin
  Form3.ShowModal;
end;

end.
