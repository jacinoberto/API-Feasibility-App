using System.Globalization;
using Application.Utils.ReadCSVs.CsvModels;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;

namespace Application.Utils.ReadCSVs.CSVs;

public class ReadCsvUtil : IReadCvsUtil
{
    public IEnumerable<InternetPlanCsv> ReadCvsInternetPlan(Stream csvStream)
    {
        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",  // Configurando o delimitador para ponto e vírgula
            HeaderValidated = null,  // Ignorar validação de cabeçalhos
            MissingFieldFound = null  // Ignorar campos ausentes
        });
        
        return csv.GetRecords<InternetPlanCsv>().ToList();
    }

    public IEnumerable<PlanFeasibilityCsv> ReadCvsPlanFeasibility(Stream csvStream)
    {
        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",  // Configurando o delimitador para ponto e vírgula
            HeaderValidated = null,  // Ignorar validação de cabeçalhos
            MissingFieldFound = null  // Ignorar campos ausentes
        });
        
        return csv.GetRecords<PlanFeasibilityCsv>().ToList();
    }
}