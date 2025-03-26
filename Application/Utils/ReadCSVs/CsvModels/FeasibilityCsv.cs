using CsvHelper.Configuration.Attributes;

namespace Application.Utils.ReadCSVs.CsvModels;

public class FeasibilityCsv
{
    [Name("Operadora")]
    public string Operator { get; set; }
    
    [Name("CEP")]
    public string? ZipCode { get; set; }
    
    [Name("Rua")]
    public string? Street { get; set; }
    
    [Name("Numero")]
    public int? Number { get; set; }
    
    [Name("Bairro")]
    public string? Area { get; set; }
    
    [Name("Cidade")]
    public string? City { get; set; }
    
    [Name("Estado/UF")]
    public string? State { get; set; }
}