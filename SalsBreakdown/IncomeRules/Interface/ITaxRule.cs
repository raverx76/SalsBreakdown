using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.IncomeRules {
    public interface ITaxRule {
        int LowRange { get; set; }
        int? HighRange { get; set; }
        decimal Percent { get; set; }
        decimal? Amount { get; set; }        
        public bool HasLowRangeOffset { get; set; }

        /// <summary>
        /// Provides access to the next low range in sequence immediately following the last high range
        /// Initially 0
        /// </summary>
        public int NextLowRange {
            get {
                return (this.HighRange ?? -1) + 1;
            }
        }

        decimal CalculateLevy(decimal taxableIncome);
        bool DoesRuleApply(decimal taxableIncome);

        public ITaxRule SetRule(int lowRange, int? highRange, decimal percent, decimal? amount, bool hasLowRangeOffset);


    }

}
