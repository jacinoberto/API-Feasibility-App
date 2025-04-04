﻿using Application.Utils.ReadCSVs.CsvModels;
using Domain.Entities;

namespace Application.Utils.ReadCSVs.CSVs;

public interface IReadCvsUtil
{
    IEnumerable<InternetPlanCsv> ReadCvsInternetPlan(Stream csvStream);
    IEnumerable<PlanFeasibilityCsv> ReadCvsPlanFeasibility(Stream csvStream);
    IEnumerable<FeasibilityCsv> ReadCvsFeasibility(Stream csvStream);
    IEnumerable<PlanByStateCsv> ReadCvsPlanByState(Stream csvStream);
    IEnumerable<PlanByCityCsv> ReadCvsPlanByCity(Stream csvStream);
}