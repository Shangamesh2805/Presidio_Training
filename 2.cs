using System;
namespace Day1
{
	public class Class1
	{
		static void main(string[] )
		{
			//create an application that will find the greatest of the given numbers. Take input until the user enters a negative number

			int num;
			Console.WriteLine("Enter a +ve number to Start [Enter a -ve to Stop] ")
			
			num=Convert.ToInt32(Console.ReadLine());
			int max_num;
			max_num = num;
			while(num>0)
			{
                num = Convert.ToInt32(Console.ReadLine());
				if (num > max_num):
						max_num = num;

            }
			Console.WriteLine("The Greatest number is "+max_num)

        }
	}
}