using SalsBreakdown.IncomeCalc;

namespace SalsBreakdown.UserEntry {
    public interface IValidation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value">not null and valid converstion</param>
        /// <returns>text to aid in correcting ebkac</returns></returns>
        string SalaryAmount(string input, out decimal? value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="payFrequency">not null and valid conversion </param>
        /// <returns>text to aid in correcting ebkac</returns>
        string PayFrequencys(string input, out PayFrequency? payFrequency);
    }
}