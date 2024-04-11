using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    //Find the length of the given user's name
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Enter Your name :");
            name= Console.ReadLine();
            Console.WriteLine("The lenght of Username : " + name.Length);

        }
    }
}
