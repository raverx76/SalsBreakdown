using SalsBreakdown.IncomeRules.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.IncomeRules {

    /// <summary>
    /// 
    /// </summary>
    public class ConfigureRules: IConfigureRules {
        public List<ITaxRule> Medicare { get; private set; }
        public List<ITaxRule> BudgetRepair { get; private set; }
        public List<ITaxRule> IncomeTax { get; private set; }

        public ConfigureRules() {
            this.Medicare = SetupMedicare();
            this.BudgetRepair = SetupBudgetRepair();
            this.IncomeTax = SetupIncomeTax();
        }

        private List<ITaxRule> SetupMedicare() {
            var rules = new List<ITaxRule>();
            ITaxRule newRule;
            rules.Add(newRule = new MedicareLevyRule().SetRule(0, 21335, 0, null, false));
            rules.Add(newRule = new MedicareLevyRule().SetRule(newRule.NextLowRange, 26668, 10, null, true));
            rules.Add(newRule = new MedicareLevyRule().SetRule(newRule.NextLowRange, null, 2, null, false));
         
            return rules;
        }

        private List<ITaxRule> SetupBudgetRepair() {
            var rules = new List<ITaxRule>();
            ITaxRule newRule;
            rules.Add(newRule = new BudgetRepairLevyRule().SetRule(0, 180000, 0, 0, false));
            rules.Add(newRule = new BudgetRepairLevyRule().SetRule(newRule.NextLowRange, null, 2, null, true));
         

            return rules;
        }


        private List<ITaxRule> SetupIncomeTax() {
            var rules = new List<ITaxRule>();
            ITaxRule newRule;
            rules.Add(newRule = new IncomeTaxRule().SetRule(0, 18200, 0, null, false));
            rules.Add(newRule = new IncomeTaxRule().SetRule(newRule.NextLowRange, 37000, 19, null, true));
            rules.Add(newRule = new IncomeTaxRule().SetRule(newRule.NextLowRange, 87000, 32.5m, 3572, true));
            rules.Add(newRule = new IncomeTaxRule().SetRule(newRule.NextLowRange, 180000, 37, 19822, true));
            rules.Add(newRule = new IncomeTaxRule().SetRule(newRule.NextLowRange, null, 47, 54232, true));
           

            return rules;
        }



    }
}
