//namespace ShoppingFE
//{
//    internal class Program
//    {
//        int GetResultFromDatabaseServer()
//        {
//            return new Random().Next();
//        }

//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//            Program program = new Program();
//            int number = program.GetResultFromDatabaseServer();
//            Console.WriteLine("This is the random number from main" + new Random().Next());
//            Console.WriteLine("This is the random number from server " + number);

//        }
//    }




//}

//namespace ShoppingFE
//{
//    internal class Program
//    {
//        void PrintNumbers()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
//                Thread.Sleep(1000);
//                //Console.WriteLine("After the thread call");
//            }
//        }

//        static void Main(string[] args)
//        {
//            Program program = new Program();
//            Thread t1 = new Thread(program.PrintNumbers);
//            t1.Name = "You";
//            Thread t2 = new Thread(program.PrintNumbers);
//            t2.Name = "Me";
//            t1.Start();
//            t2.Start();
//            Console.WriteLine("After the thread call");

//        }
//    }
//}
namespace ShoppingFE
{
    internal class Program
    {
        void PrintNumbers()
        {
            lock (this)//Thread safe code
            {
                for (int i = 0; i < 10; i++)
                {

                    Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
                    Thread.Sleep(1000);

                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Thread t1 = new Thread(program.PrintNumbers);
            t1.Name = "You";
            Thread t2 = new Thread(program.PrintNumbers);
            t2.Name = "Me";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread call");
        }
    }
}



