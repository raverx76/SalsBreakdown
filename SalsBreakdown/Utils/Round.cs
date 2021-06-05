using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.Utils {
    public class RoundHelper {

        /// <summary>
        /// Round down to precision
        /// </summary>
        /// <param name="value"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static decimal RoundDown(decimal value, int precision) {
            //not the most efficient but will work
            /*1.53 precsion 0 => 1
             * 2.255 precision 1 => 2.2
             * 
             */
            bool isNegative = value < 0;


            decimal expanded = Math.Abs(value) * (decimal)Math.Pow(10d, (double)precision);//1.53, 22.55
            decimal lhs = Math.Floor(expanded); //1, 22
            decimal tmpValue = expanded - lhs; //1.53-1 = 0.53, 22.55- 22=0.55
            expanded = tmpValue * 10;//5.3, 5.5
            tmpValue = Math.Floor(expanded);//5.3=5, 5.5=5

            if (tmpValue != 5)
                return Math.Round(value, precision);
            else
                return (isNegative ? -1 : 1) * lhs / (decimal)Math.Pow(10d, (double)precision);

        }

    }
}
