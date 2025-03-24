using CsvHelper.Configuration.Attributes;

namespace Application.Utils.ReadCSVs.CsvModels;

public class PlanFeasibilityCsv
{
    [Name("Operadora")]
    public string Operator { get; set; }
    
    [Name("Plano")]
    public string PlanName { get; set; }
    
    [Name("Internet/Velocidade")]
    public int InternetSpeed { get; set; }
    
    [Name("Internet/Tipo de Velocidade")]
    public string SpeedType { get; set; }
    
    [Name("Valor")]
    public decimal Value { get; set; }
    
    [Name("CEP")]
    public string? ZipCode { get; set; }
    
    [Name("Rua")]
    public string? Street { get; set; }
    
    [Name("Número")]
    public int? Number { get; set; }
    
    [Name("Bairro")]
    public string? Area { get; set; }
    
    [Name("Cidade")]
    public string? City { get; set; }
    
    [Name("Estado/UF")]
    public string? State { get; set; }
}