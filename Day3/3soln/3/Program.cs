using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    // Find the avearage of all the numbers that are divisible by 7. Take input until the user enters a negative number
    internal class Program
    {
        static void Main(string[] args)
        {
            int num,sum=0,count=0;
            Console.WriteLine("Enter the mutiples of 7 [To end enter -ve numbers]");
            float average;
            num=Convert.ToInt32(Console.ReadLine());

            while (num > 0)
            {
                if (num % 7 == 0)
                    sum += num;
                    count += 1;
                num = Convert.ToInt32(Console.ReadLine());

             }
            average=sum/count;
            Console.WriteLine("Average of numbers divisible by 7 is :" + average);
                

        }
    }
}
