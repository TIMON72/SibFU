unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, VclTee.TeeGDIPlus, VCLTee.TeEngine,
  VCLTee.Series, Vcl.ExtCtrls, VCLTee.TeeProcs, VCLTee.Chart, VCLTee.DBChart,
  Data.DB, Data.Win.ADODB, Vcl.Menus, VCLTee.TeeStore, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    ADOConnection1: TADOConnection;
    ADOQuery1: TADOQuery;
    DBChart1: TDBChart;
    MainMenu1: TMainMenu;
    N21: TMenuItem;
    N31: TMenuItem;
    N41: TMenuItem;
    Button1: TButton;
    Series1: TLineSeries;
    N1: TMenuItem;
    procedure N21Click(Sender: TObject);
    procedure N31Click(Sender: TObject);
    procedure N41Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure N1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

uses Unit2, Unit3, Unit4, Unit5;

procedure TForm1.Button1Click(Sender: TObject);
begin
  With TSeriesDataHTML.Create(DBChart1, Series1) do
  Begin
    IncludeHeader := True;
    SaveToFile('c:\Temp\Series1HTMLData.html');
  End;
end;

procedure TForm1.N1Click(Sender: TObject);
begin
  Form5.Show;
end;

procedure TForm1.N21Click(Sender: TObject);
begin
  Form2.Show;
end;

procedure TForm1.N31Click(Sender: TObject);
begin
  Form3.Show;
end;

procedure TForm1.N41Click(Sender: TObject);
begin
  Form4.Show;
end;

end.
