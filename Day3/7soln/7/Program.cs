namespace _7
{
    //7) Take a string from user the words seperated by comma(","). Seperate the words and find the words with the least number of repeating vowels. print the count and the word. If there is a tie then print all the words that tie for the least
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words separated by commas:");
            string i = Console.ReadLine();

            string[] w = i.Split(',');

            int c = int.MaxValue;
            string[] b = new string[0];

            foreach (string d in w)
            {
                int e = f(d);

                if (e < c)
                {
                    c = e;
                    b = new[] { d };
                }
                else if (e == c)
                {
                    b = b.Append(d).ToArray();
                }
            }

            Console.WriteLine($"Least repeating vowels: {c}:");

            foreach (string f in b)
            {
                Console.WriteLine($"{f}");
            }
        }

        static int f(string g)
        {
            int h = 0;
            string j = "aeiouAEIOU";

            for (int k = 0; k < g.Length; k++)
            {
                if (j.Contains(g[k]))
                {
                    for (int l = k + 1; l < g.Length; l++)
                    {
                        if (j.Contains(g[l]) && g[l] == g[k])
                        {
                            h++;
                            break;
                        }
                    }
                }
            }

            return h;
        }
    }
    }
