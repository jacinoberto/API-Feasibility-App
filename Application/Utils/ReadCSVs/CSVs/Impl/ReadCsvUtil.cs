using System.Globalization;
using System.Text;
using Application.Utils.ReadCSVs.CsvModels;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using InvalidDataException = Domain.Exceptions.InvalidDataException;

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
    
    public IEnumerable<FeasibilityCsv> ReadCvsFeasibility(Stream csvStream)
    {
        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",  // Configurando o delimitador para ponto e vírgula
            HeaderValidated = null,  // Ignorar validação de cabeçalhos
            MissingFieldFound = null  // Ignorar campos ausentes
        });
        
        return csv.GetRecords<FeasibilityCsv>().ToList();
    }
    
    public IEnumerable<PlanByStateCsv> ReadCvsPlanByState(Stream csvStream)
    {
        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",  // Configurando o delimitador para ponto e vírgula
            HeaderValidated = null,  // Ignorar validação de cabeçalhos
            MissingFieldFound = null  // Ignorar campos ausentes
        });
        
        csv.Read();
        csv.ReadHeader();
        int columnCount = csv.HeaderRecord?.Length ?? 0;

        if (columnCount > 6) throw new InvalidDataException("Seu aquivo possuí colunas a mais, é preciso que seja informado apenas o estado além dos dados dos planos");
        
        return csv.GetRecords<PlanByStateCsv>().ToList();
    }
    
    public IEnumerable<PlanByCityCsv> ReadCvsPlanByCity(Stream csvStream)
    {
        using var reader = new StreamReader(csvStream);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",  // Configurando o delimitador para ponto e vírgula
            HeaderValidated = null,  // Ignorar validação de cabeçalhos
            MissingFieldFound = null  // Ignorar campos ausentes
        });
        
        csv.Read();
        csv.ReadHeader();
        int columnCount = csv.HeaderRecord?.Length ?? 0;

        if (columnCount < 7) throw new InvalidDataException("Seu aquivo possuí colunas a menos, é preciso que seja informado a cidade e o estado além dos dados dos planos.");
        
        return csv.GetRecords<PlanByCityCsv>().ToList();
    }
}