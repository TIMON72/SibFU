unit Unit4;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, VclTee.TeeGDIPlus, Vcl.StdCtrls,
  VCLTee.TeEngine, VCLTee.Series, Data.DB, Data.Win.ADODB, Vcl.ExtCtrls,
  VCLTee.TeeProcs, VCLTee.Chart, VCLTee.DBChart;

type
  TForm4 = class(TForm)
    DBChart1: TDBChart;
    ADOQuery1: TADOQuery;
    Series1: THorizBarSeries;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm4.Button1Click(Sender: TObject);
var
  MySeries: TBarSeries;
begin
  MySeries := TBarSeries.Create(Self);
  MySeries.ParentChart := DBChart1;
  MySeries.SeriesColor := clGreen;
  MySeries.DataSource := ADOQuery1;
  MySeries.XLabelsSource := 'StoragTo';
  MySeries.YValues.ValueSource := 'sdTransferAmount';
  MySeries.Active := true;
  MySeries.Title := 'Перемещения со склада';
end;

end.
