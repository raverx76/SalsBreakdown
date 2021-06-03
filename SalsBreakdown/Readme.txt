SalsBreakdown - Understanding for a brighter financial future.
-------------------------------------------------------------
I used a lot of interfaces to implement dependancy injection.
Di allows us to swap items out with updated versions or add a test suite and mock out items.

Abstract tax rule is the base of all things with a rule. By obverstation I also implemented the calculate level and does rule apply.
This allows you to create concrete rules such as Medicare and override the calculation formulae as needed.
Does rule apploy method doesn't really need to be virtual has it should always be between to income values to apply.
Thanks to modern c# I also have added a helper body to the interface to grab the next low range value - this will help keep the values in sequence


IncomeCalculator- I decided not to be an interface but that could easily be extracted out for testing other items that depend on it's results.
There is only one way to work out percentages, however the rounding could change but I decided not to worry about that changing in this instance.

PayFrequency. Is a simple implementation that can be used to for the math thanks for the modern c# since 6 
This could have also be extracted away to a factory patten with exactly the same results. But not needed

ConfiureRules - This is the hub where to add all the rules for the 3 listed types.
This could be coverted to a factory pattern if the thought of more types of rules where to come into place, but this will suffice with very low risk for code changes.

RuleManager - this just takes a bunch of rules with the income to find a fule that applies

ConsoleUserPrompt - Console implementation of user input.

Validation - The validation for the user input with appropriate message back to the user.

UserEntry - The two questions, that use the appropriate validation for them.

SalsBreakDown - The main entry point with the text from the calculations.
Notice CalculateLevel takes the deductableTaxIncome, it could have got it from 'this' ITaxRule, but as a shared object, this would be bad news if it was multiple users as a race condition would easily occur.

How to extend it.
Probably use either json, but most likely a csv file to bring in the values as needed. Most likely the csv file would be the one from the ato or similar website.
You could read the file in have all your deductions and numbers in place ready to assume.
If the calculations were to change you would need a little more sophistication in having a formula parser.

For future and past years.
Repeat the same process but add the year into each concrete class.
This would definitely become a factory pattern as you would have unknown set of year to determine which set of rules to use.

