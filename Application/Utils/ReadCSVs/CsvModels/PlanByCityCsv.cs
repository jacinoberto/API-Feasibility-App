using CsvHelper.Configuration.Attributes;

namespace Application.Utils.ReadCSVs.CsvModels;

public class PlanByCityCsv
{
    [Name("Plano")]
    public string Plan  { get; set; }
    
    [Name("Internet/Velocidade")]
    public int InternetSpeed { get; set; }
    
    [Name("Internet/Tipo de Velocidade")]
    public string SpeedType { get; set; }
    
    [Name("Valor")]
    public decimal Value { get; set; }
    
    [Name("Cidade")]
    public string City { get; set; }
    
    [Name("Estado/UF")]
    public string State { get; set; }
}