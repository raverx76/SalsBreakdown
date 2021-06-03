using System.Collections.Generic;

namespace SalsBreakdown.IncomeRules {
    public interface IConfigureRules {
        List<ITaxRule> BudgetRepair { get; }
        List<ITaxRule> IncomeTax { get; }
        List<ITaxRule> Medicare { get; }
    }
}