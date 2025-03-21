using Application.Utils.ReadCSVs.CsvModels;

namespace Application.Utils.ReadCSVs.CSVs;

public interface IReadCvsUtil
{
    IEnumerable<InternetPlanCsv> ReadCvsInternetPlan(Stream csvStream);
}