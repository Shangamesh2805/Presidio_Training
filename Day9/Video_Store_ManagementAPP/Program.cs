//using System;
//using Video_Store_Management_Models;
//using VideoStoreManagmentDALLibrary;
//using VideoStoreManagementBLLibrary;

//namespace VideoStoreManagement
//{
//    internal class Program
//    {
//        static void DisplayMainMenu()
//        {
//            Console.WriteLine("1. Add Video");
//            Console.WriteLine("2. Add Customer");
//            Console.WriteLine("3. Show All Videos");
//            Console.WriteLine("4. Rent Video (Customer)");
//            Console.WriteLine("5. Exit");
//        }

//        static int GetMenuChoice()
//        {
//            Console.Write("\nEnter your choice: ");
//            return int.Parse(Console.ReadLine());
//        }

//        static void AddVideo(IVideoCatalogService videoService)
//        {
//            Console.WriteLine("Enter Video details:");
//            Console.WriteLine("Title: ");
//            string title = Console.ReadLine();
//            Console.WriteLine("Genre: ");
//            string genre = Console.ReadLine();

//            Console.WriteLine("Availability Status (true/false): ");
//            bool availabilityStatus = bool.Parse(Console.ReadLine());
//            Console.WriteLine("Rental Price: ");
//            int rentalPrice = int.Parse(Console.ReadLine());

//            var video = new Video { Title = title, Genre = genre, IsAvailable = availabilityStatus, RentalPrice = rentalPrice };
//            videoService.AddVideo(video);
//            Console.WriteLine("Video added successfully.");
//        }

//        static void AddCustomer(ICustomerService customerService)
//        {
//            Console.WriteLine("Enter Customer details:");
//            Console.WriteLine("Name: ");
//            string name = Console.ReadLine();
//            Console.WriteLine("Address: ");
//            string address = Console.ReadLine();
//            Console.WriteLine("Gender: ");
//            string gender = Console.ReadLine();

//            var customer = new Customer { Name = name, Address = address, Gender = gender };
//            customerService.AddCustomer(customer);
//            Console.WriteLine("Customer added successfully.");
//        }

//        static void ShowAllVideos(IVideoCatalogService videoService)
//        {
//            var allVideos = videoService.GetAllVideos();
//            Console.WriteLine("\nAll Videos:");
//            foreach (var v in allVideos)
//            {
//                Console.WriteLine($"Title: {v.Title}, Genre: {v.Genre}, Availability: {(v.IsAvailable ? "Available" : "Not Available")}, Rental Price: {v.RentalPrice}");
//            }
//        }

//        static void Main(string[] args)
//        {
//            var videoRepo = new VideoRepository();
//            var customerRepo = new CustomerRepository();

//            var videoService = new VideoCatalogBL(videoRepo);
//            var customerService = new CustomerBL(customerRepo);

//            bool exit = false;
//            while (!exit)
//            {
//                DisplayMainMenu();
//                int choice = GetMenuChoice();

//                switch (choice)
//                {
//                    case 1:
//                        AddVideo(videoService);
//                        break;
//                    case 2:
//                        AddCustomer(customerService);
//                        break;
//                    case 3:
//                        ShowAllVideos(videoService);
//                        break;
//                    case 5:
//                        exit = true;
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }
//            }
//        }
//    }
//}
using VideoStoreManagmentDALLibrary;
using VideoStoreManagementBLLibrary;

namespace VideoStoreManagement
{
    internal class Program
    {
        static void DisplayMainMenu()
        {
            Console.WriteLine();
        }
    }
}