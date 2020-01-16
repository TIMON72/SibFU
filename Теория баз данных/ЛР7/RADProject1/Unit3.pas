unit Unit3;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, VclTee.TeeGDIPlus, VCLTee.TeEngine,
  VCLTee.Series, Data.DB, Data.Win.ADODB, Vcl.ExtCtrls, VCLTee.TeeProcs,
  VCLTee.Chart, VCLTee.TeeStore, VCLTee.DBChart, VCLTee.TeeFunci, Vcl.StdCtrls;

type
  TForm3 = class(TForm)
    DBChart1: TDBChart;
    ADOQuery1: TADOQuery;
    ADOQuery2: TADOQuery;
    TeeFunction1: TSubtractTeeFunction;
    Series1: TBarSeries;
    Series2: TBarSeries;
    Series3: TBarSeries;
    Button1: TButton;
    Button2: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form3: TForm3;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm3.Button1Click(Sender: TObject);
begin
  With TSeriesDataXLS.Create(DBChart1, nil) do
  Begin
    IncludeHeader := True;
    SaveToFile('c:\Temp\DataDBChart3.xls');
  End;
end;

procedure TForm3.Button2Click(Sender: TObject);
begin
  DBChart1.Series[1].Delete(1);
end;

end.
