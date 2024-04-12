using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Console.WriteLine("Enter the values of num1 and num2:");
            num1 = Convert.ToInt32(Console.ReadLine());
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum of num1 and num2:"+(num1+num2));
            Console.WriteLine("Subraction of num1 and num2:" + (num1 - num2));
            Console.WriteLine("Multiplication of num1 and num2:" + (num1 * num2));
            Console.WriteLine("Division of num1 on num2:" + (num1 / num2));

            int Remainders = Remainder(num1,num2);
            Console.WriteLine("Remainder of Num2 to Num1 :"+ Remainders);



        }
        static int Remainder(int num1, int num2) 
        {
            
            return num1 % num2;


        }
        

        }
    }

