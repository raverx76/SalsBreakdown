using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.IncomeRules {

    public abstract class TaxRule : ITaxRule {
        private int lowRange;
        private int? highRange;

        public int LowRange {
            get => this.lowRange;
            set {
                if (value > this.highRange)
                    throw new ArgumentOutOfRangeException($"LowRange {value} is higher than highRange {this.highRange}");
                this.lowRange = value;
            }
        }
        public int? HighRange {
            get => this.highRange;
            set {
                if (value < this.lowRange)
                    throw new ArgumentOutOfRangeException($"HighRnge {value} is lower than lowRange {this.lowRange}");
                this.highRange = value;
            }
        }
        /// <summary>
        /// the value of a percent e.g 0.01
        /// </summary>
        public decimal Percent { get; set; }
        public decimal? Amount { get; set; }
        public bool HasLowRangeOffset { get; set; }

        public bool DoesRuleApply(decimal taxableIncome) {
            return taxableIncome >= this.LowRange && taxableIncome <= (this.HighRange ?? int.MaxValue);
        }

        public virtual decimal CalculateLevy(decimal taxableIncome) {
            decimal value =  (this.Amount ?? 0) + ((taxableIncome - (this.HasLowRangeOffset ? this.LowRange - 1 : 0)) * this.Percent);
            return Math.Round(value, 0, MidpointRounding.ToPositiveInfinity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowRange"></param>
        /// <param name="highRange"></param>
        /// <param name="percent">the percent value e.g 10</param>
        /// <param name="amount"></param>
        /// <param name="hasLowRangeOffset"></param>
        /// <returns></returns>
        public ITaxRule SetRule(int lowRange, int? highRange, decimal percent, decimal? amount, bool hasLowRangeOffset) {
            this.LowRange = lowRange;
            this.HighRange = highRange;
            this.Percent = percent/100;
            this.Amount = amount;
            this.HasLowRangeOffset = hasLowRangeOffset;
            return this;
        }


    }
}
