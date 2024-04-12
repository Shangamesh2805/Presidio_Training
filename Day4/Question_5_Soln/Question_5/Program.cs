using System;

namespace Question_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Card Number:");

            string cardNum;
            do
            {
                cardNum = Console.ReadLine();
                if (cardNum.Length == 16)
                    break;
                else
                    Console.WriteLine("Please enter a valid 16-digit card number.");
            } while (true);

            string reversedCardNum = Reverse(cardNum);
            int sum = 0;

            for (int i = 0; i < reversedCardNum.Length; i++)
            {
                int digit = int.Parse(reversedCardNum[i].ToString());
                if (i % 2 == 1) // Changed to odd positions (0-indexed)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = digit / 10 + digit % 10;
                    }
                }
                sum += digit;
            }

            if (sum % 10 == 0)
            {
                Console.WriteLine("Valid credit card number.");
            }
            else
            {
                Console.WriteLine("Invalid credit card number.");
            }
        }

        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
