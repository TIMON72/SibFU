unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, VclTee.TeeGDIPlus, Data.DB,
  Data.Win.ADODB, VCLTee.TeEngine, VCLTee.Series, Vcl.ExtCtrls, VCLTee.TeeProcs, VCLTee.Teeprevi,
  VCLTee.Chart, VCLTee.DBChart, Vcl.StdCtrls;

type
  TForm2 = class(TForm)
    DBChart1: TDBChart;
    Series1: THorizBarSeries;
    ADOQuery1: TADOQuery;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Series2: TBarSeries;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm2.Button1Click(Sender: TObject);
begin
  TeePreview(Form2, DBChart1);
end;

procedure TForm2.Button2Click(Sender: TObject);
begin
  if DBChart1.Series[0].Active = true then
  begin
   DBChart1.Series[0].Active := false;
   DBChart1.Series[1].Active := true;
  end
  else
  begin
   DBChart1.Series[0].Active := true;
   DBChart1.Series[1].Active := false;
  end;
end;

procedure TForm2.Button3Click(Sender: TObject);
begin
  if DBChart1.Series[0].Marks.Visible = false then
  begin
   DBChart1.Series[0].Marks.Visible := true;
   DBChart1.Series[0].VertAxis := aLeftAxis;
   DBChart1.Series[0].Marks.Transparent := true;
  end
  else
  begin
   DBChart1.Series[0].Marks.Visible := false;
   DBChart1.Series[0].VertAxis := aRightAxis;
  end;

  DBChart1.Series[0].ValueColor[1] := clBlue;
  DBChart1.Series[0].ValueColor[2] := clGreen;
end;

end.
