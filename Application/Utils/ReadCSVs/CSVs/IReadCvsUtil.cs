using Application.Utils.ReadCSVs.CsvModels;
using Domain.Entities;

namespace Application.Utils.ReadCSVs.CSVs;

public interface IReadCvsUtil
{
    IEnumerable<InternetPlanCsv> ReadCvsInternetPlan(Stream csvStream);
    IEnumerable<PlanFeasibilityCsv> ReadCvsPlanFeasibility(Stream csvStream);
}