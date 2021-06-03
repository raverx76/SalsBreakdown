using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.IncomeCalc {
    /// <summary>
    /// Pay frequncies that contain a value with the number to divide by to calculate pay packate from a yearly point of view
    /// </summary>
    public enum PayFrequency {
        Weekly = 52,
        Fortnightly = (PayFrequency.Weekly / 2),
        Monthly = 12,        
    }
}
