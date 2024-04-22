namespace Bulls_Cows_game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bulls and Cows game!");
            Console.WriteLine("Enter the secret word:");
            string secret = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Enter your guess:");
                string guess = Console.ReadLine();


                if (guess == secret)
                {
                    Console.WriteLine("Congratulations! You've guessed the secret word.");
                    break;
                }


                if (secret.Length != guess.Length)
                {
                    Console.WriteLine("Error: The length of your guess should match the length of the secret word.");
                    continue;
                }

                string hint = GetHint(secret, guess);
                Console.WriteLine($"Hint: {hint}");
            }
        }

        public static string GetHint(string secret, string guess)
        {
            char[] secArr = secret.ToCharArray();
            char[] gueArr = guess.ToCharArray();
            char[] secArrCopy = new char[secArr.Length];
            Array.Copy(secArr, secArrCopy, secArr.Length);

            int x = 0, y = 0;
            for (int i = 0; i < secArr.Length; i++)
            {
                if (secArr[i] == gueArr[i])
                {
                    x++;
                    secArr[i] = '^';
                    gueArr[i] = '^';
                }
            }

            for (int i = 0; i < gueArr.Length; i++)
            {
                if (gueArr[i] != '^')
                {
                    for (int j = 0; j < secArrCopy.Length; j++)
                    {
                        if (secArrCopy[j] == gueArr[i] && secArr[j] != gueArr[j])
                        {
                            y++;
                            secArrCopy[j] = '^';
                            break;
                        }
                    }
                }
            }


            return $"{x}- Bulls and {y}- Cows";
        }
    }
}