using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SalsBreakdown.IncomeCalc {
    public class IncomeCalculator {

        /// <summary>
        /// Constucts the calculator with the default super contribution rate of  9.5%
        /// </summary>
        public IncomeCalculator() {
            this.SuperContributionPercent = 9.5m / 100;
        }

        private decimal superContribution;

        /// <summary>
        /// The super contrubtion percentage value number e.g 0.095
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown wehen values is negative</exception>
        /// </summary>
        public decimal SuperContributionPercent {
            get {
                return this.superContribution;
            }
            set {
                if (!(value >= 0 && value < 1))
                    throw new ArgumentOutOfRangeException($"Super Contribution Value {value} must be a between 0 and 1");

                this.superContribution = value;
            }
        }


        /// <summary>
        /// Calulates teh super contribution 
        /// </summary>
        /// <param name="grossPackage"></param>
        /// <returns></returns>
        public decimal CalcSuperContibutionAmount(decimal grossPackage) {
            decimal super = this.SuperContributionPercent * grossPackage / (1 + this.SuperContributionPercent);
            //round up to nearest cent
            return Math.Round(super, 2, MidpointRounding.ToPositiveInfinity);
        }

        /// <summary>
        /// Calculates the taxible income from the gross package and inclusive super contribution
        /// </summary>
        /// <param name="grossPackage"></param>
        /// <returns></returns>
        public decimal CalcTaxableIncome(decimal grossPackage, bool forDeducations = false) {
            decimal tiValue = grossPackage - this.CalcSuperContibutionAmount(grossPackage);

            if (forDeducations)//rounded down to the nearest dollar when calculated decuctions
                return Math.Round(tiValue, 0, MidpointRounding.ToZero);
            else//round down to nearest cent
                return Math.Round(tiValue, 2, MidpointRounding.ToZero);
        }

        public decimal CalcNetIncome(decimal grossPackage, params decimal[] deductions) {
            decimal net = grossPackage - this.CalcSuperContibutionAmount(grossPackage) - deductions.Sum();
            return net;
        }

        public decimal CalcPayPacket(decimal grossPackage, PayFrequency frequency, params decimal[] deductions) {
            decimal pay = this.CalcNetIncome(grossPackage, deductions) / (int)frequency;
            //round up to nearest cent
            return Math.Round(pay, 2, MidpointRounding.ToPositiveInfinity);
        }

    }
}
