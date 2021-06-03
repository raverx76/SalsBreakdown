using SalsBreakdown.IncomeCalc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SalsBreakdown.UserEntry {
    class Validation : IValidation {
      
        public string SalaryAmount(string input, out decimal? value) {
            decimal tmpValue;
            value = null;
            if (decimal.TryParse(input, out tmpValue)) {
                if (tmpValue > 0) {
                    value = tmpValue;
                    return null;
                }
                else
                    return "The value cannot be a negative value";
            }
            else
                return "The value must be a numerical value";
        }

     
        public string PayFrequencys(string input, out PayFrequency? payFrequency) {
            string frequencyName = Enum.GetNames(typeof(PayFrequency)).FirstOrDefault(f => input.Equals(f[0].ToString(), StringComparison.InvariantCultureIgnoreCase));
            if (frequencyName != null) {
                PayFrequency tmpPayFrequency;
                if (Enum.TryParse<PayFrequency>(frequencyName, out tmpPayFrequency)) {
                    payFrequency = tmpPayFrequency;
                    return null;
                }
            }

            payFrequency = null;
            return "The value must be W, F , or M";
        }
    }
}
