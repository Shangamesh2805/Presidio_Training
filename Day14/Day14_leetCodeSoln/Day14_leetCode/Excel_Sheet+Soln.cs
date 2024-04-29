using System;
using System.Text;
using System.Threading.Tasks;

namespace day14_leetcode
{
    public class answer
    {
        public async Task<string> converttotitleasync(int columnnumber)
        {
            StringBuilder result = new StringBuilder();

            while (columnnumber > 0)
            {
                columnnumber--;

                int remainder = columnnumber % 26;

                char digit = (char)('a' + remainder);

                result.Insert(0, digit);

                columnnumber /= 26;
            }


            await Task.Delay(100);

            return result.ToString();
        }
    }

    public class excel_sheet_soln
    {
        static async Task Main(string[] args)
        {
            answer solution = new answer();

            int columnnumber1 = 1;
            Console.WriteLine("column title for column number " + columnnumber1 + ": " + await solution.converttotitleasync(columnnumber1));

            int columnnumber2 = 28;
            Console.WriteLine("column title for column number " + columnnumber2 + ": " + await solution.converttotitleasync(columnnumber2));

            int columnnumber3 = 701;
            Console.WriteLine("column title for column number " + columnnumber3 + ": " + await solution.converttotitleasync(columnnumber3));
        }
    }
}
