using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace _5
{
    internal class Program
    {
//        Create a application that will take username and password from user.check if username is "ABC" and passwod is "123". 
//Print error message if username or password is wrong
//        Allow user 3 attemts.
//After 3rd attempt if user enters invalid credentials then print msg to intimate user taht he/she has exceeded the number of attempts and stop

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to xyz.com");
            string username = "ABC";
            string password = "123";
            Console.WriteLine("Please enter your Username and Password to login");
            int attempts = 3;
            while (attempts > 0)
            {
                Console.WriteLine("Please enter your Username:");
                string u1=Console.ReadLine();

                Console.WriteLine("Please enter your Password:");
                string p1=Console.ReadLine();

                if (u1==username && p1 == password)
                {
                    Console.WriteLine("Logged In Sucessfully");
                    break;
                }
                else
                {
                    Console.WriteLine("The entered Username or Password is Invalid");
                    attempts--;
                    Console.WriteLine($"You have got {attempts} left");
                    
                }
                if (attempts == 0)
                {
                    Console.WriteLine("You have exceeded the number of Attempts. ");
                    Console.WriteLine("Thank You");
                }
                }

        }
    }
}
