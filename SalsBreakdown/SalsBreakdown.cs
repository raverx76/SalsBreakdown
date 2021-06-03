using SalsBreakdown.IncomeCalc;
using SalsBreakdown.IncomeRules;
using SalsBreakdown.IncomeRules.Rules;
using SalsBreakdown.UserEntry;
using System;

namespace SalsBreakdown
{
    class SalsBreakdown
    {       
        static void Main(string[] args)
        {
            SalsBreakdown salsBreakdown = new SalsBreakdown(
                new ConfigureRules(),
                new ConsoleUerPrompt(),
                new RuleManager()
                ); ;

            UserEntry.UserEntry userEntry = new UserEntry.UserEntry(new Validation(), salsBreakdown.userPrompts);

            decimal salary = userEntry.EnterSalaryPackage();
            PayFrequency payFrequency = userEntry.EnterPayFrequency();

            salsBreakdown.DisplaySalaryBreakdown(salary, payFrequency);
            salsBreakdown.userPrompts.Display("Press any key to end...");
            Console.ReadKey();

        }



        IConfigureRules configureRules;
        IncomeCalculator incomeCalculator;
        IRuleManager ruleManager;
        public IUserPrompts userPrompts { get; private set; }

        SalsBreakdown(IConfigureRules configureRules, IUserPrompts userPrompts, IRuleManager ruleManager) {
            this.configureRules = configureRules;
            this.userPrompts = userPrompts;
            this.ruleManager = ruleManager;

            this.incomeCalculator = new IncomeCalculator();
        }

        public void DisplaySalaryBreakdown(decimal grossSalary, PayFrequency payFrequency) {            
            this.userPrompts.DataBreak();
            this.userPrompts.Display("Calculating salary details");
            this.userPrompts.DataBreak();
            this.userPrompts.Display($"Gross package: {grossSalary:C0}");
            this.userPrompts.Display($"Superannuation: {this.incomeCalculator.CalcSuperContibutionAmount(grossSalary):C}");
            this.userPrompts.DataBreak();            
            this.userPrompts.Display($"Taxable income: {this.incomeCalculator.CalcTaxableIncome(grossSalary):C}");            
            this.userPrompts.DataBreak();
            this.userPrompts.Display("Deductions: ");
            decimal deductTaxableIncome = this.incomeCalculator.CalcTaxableIncome(grossSalary, true);
            decimal medicare = this.ruleManager.FindRuleInRange(this.configureRules.Medicare, deductTaxableIncome).CalculateLevy(deductTaxableIncome);
            decimal budget = this.ruleManager.FindRuleInRange(this.configureRules.BudgetRepair, deductTaxableIncome).CalculateLevy(deductTaxableIncome);
            decimal incomeTax = this.ruleManager.FindRuleInRange(this.configureRules.IncomeTax, deductTaxableIncome).CalculateLevy(deductTaxableIncome);
            this.userPrompts.Display($"Medicare Levy: {medicare:C}");
            this.userPrompts.Display($"Budget: {budget:C}");
            this.userPrompts.Display($"Income Tax: {incomeTax:C}");
            this.userPrompts.DataBreak();
            decimal netSalary = this.incomeCalculator.CalcNetIncome(grossSalary, medicare, budget, incomeTax);
            this.userPrompts.Display($"Net income: {netSalary:C}");
            decimal payPacket = this.incomeCalculator.CalcPayPacket(grossSalary, payFrequency, medicare, budget, incomeTax);
            this.userPrompts.Display($"Pay packet: {payPacket:C} {payFrequency}");
            this.userPrompts.DataBreak();                
        }
    }
}
