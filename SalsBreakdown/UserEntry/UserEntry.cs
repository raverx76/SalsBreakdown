using SalsBreakdown.IncomeCalc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalsBreakdown.UserEntry {
    public class UserEntry
    {
        private IValidation validation;
        private IUserPrompts userPrompts;

        public UserEntry(IValidation validation, IUserPrompts userPrompts) {
            this.validation = validation;
            this.userPrompts = userPrompts;
        }

        public decimal EnterSalaryPackage() {
            string result = this.userPrompts.Ask("Enter your salary package amount: ");
            decimal? value;
            string message =this.validation.SalaryAmount(result, out value);
            if (value == null) {
                this.userPrompts.Display(message);
                return this.EnterSalaryPackage();
            }

            return value??0;
        }

        public PayFrequency EnterPayFrequency() {
            string result = this.userPrompts.Ask("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
            PayFrequency? payFrequency;
            string message = this.validation.PayFrequencys(result, out payFrequency);
            if (payFrequency == null) {
                this.userPrompts.Display(message);
                return this.EnterPayFrequency();
            }

            return (PayFrequency)payFrequency;
        }
      
    }
}
