using System;


/*
 * TODO
 * [x] GenerateInvoice
 * [x] Convert Date to roman style
 * 
 * FORMAT : INV/202108/TH/XIX/XXI/10983
 */

namespace InvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 10983;
            GenerateInvoice(counter);
        }

        private static void GenerateInvoice(int counter)
        {
            string invoice = "INV";

            DateTime datetime = DateTime.Now;
            string date = datetime.ToString("yyyyMM");
            string dayName = datetime.ToString("ddd").ToUpper().Remove(2, 1);

            string dayDate = datetime.ToString("dd");
            string year = datetime.ToString("yy");

            // Convert date string to roman date form
            string romanDate = RomanNumeralsGenerator(int.Parse(dayDate));
            string romanYear = RomanNumeralsGenerator(int.Parse(year));

            Console.WriteLine($"{invoice}/{date}/{dayName}/{romanDate}/{romanYear}/{++counter}");
        }

        private static string RomanNumeralsGenerator(int num)
        {
            string[] m = { "", "M", "MM", "MMM" };
            string[] c = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] x = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] i = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            string thousands = m[num / 1000];
            string hundreds = c[(num % 1000) / 100];
            string tens = x[(num % 100) / 10];
            string ones = i[num % 10];

            string romanNum = thousands + hundreds + tens + ones;

            return romanNum;
        }
    }
}
