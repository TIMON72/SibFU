unit Lab1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Grids, Vcl.DBGrids,
  Data.Win.ADODB, frxClass, frxDBSet;

type
  TForm4 = class(TForm)
    ADOConnection1: TADOConnection;
    DataSource1: TDataSource;
    ADOTable1: TADOTable;
    ADOQuery1: TADOQuery;
    DBGrid1: TDBGrid;
    ADOTable2: TADOTable;
    DataSource2: TDataSource;
    DBGrid2: TDBGrid;
    ADOTable2gcName: TWideStringField;
    ADOTable2IDtg: TIntegerField;
    ADOTable2gcMeasure: TWideStringField;
    ADOTable2gcCost: TBCDField;
    DataSource3: TDataSource;
    DBGrid3: TDBGrid;
    frxDBDataset1: TfrxDBDataset;
    frxDBDataset2: TfrxDBDataset;
    frxReport1: TfrxReport;
    frxDBDataset3: TfrxDBDataset;
    frxReport2: TfrxReport;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

end.
