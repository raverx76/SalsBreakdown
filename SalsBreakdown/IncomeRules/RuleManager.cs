using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SalsBreakdown.IncomeRules {
    public class RuleManager : IRuleManager {
        public ITaxRule FindRuleInRange(List<ITaxRule> taxRules, decimal taxableIncome) {
            return taxRules.First(r=>r.DoesRuleApply(taxableIncome));
        }
    }
}
