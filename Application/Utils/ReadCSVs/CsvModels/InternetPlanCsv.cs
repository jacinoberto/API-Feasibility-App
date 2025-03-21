using CsvHelper.Configuration.Attributes;

namespace Application.Utils.ReadCSVs.CsvModels;

public class InternetPlanCsv
{
    [Name("Operadora")]
    public string Operator  { get; set; }
    
    [Name("Plano")]
    public string PlanName  { get; set; }
    
    [Name("Internet/Velocidade")]
    public int InternetSpeed  { get; set; }
    
    [Name("Internet/Tipo de Velocidade")]
    public string SpeedType  { get; set; }
    
    [Name("Valor")]
    public decimal Value { get; set; }
}