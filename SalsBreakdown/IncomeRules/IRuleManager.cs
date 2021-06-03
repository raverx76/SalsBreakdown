using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.IncomeRules {
    interface IRuleManager {
        ITaxRule FindRuleInRange(List<ITaxRule> taxRules, decimal taxableIncome);        
    }
}
