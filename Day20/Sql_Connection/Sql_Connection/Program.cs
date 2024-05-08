using Microsoft.EntityFrameworkCore;
using Sql_Connection.Model;
using System.Reflection;

namespace Sql_Connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Add_data

            // Area area = new Area();
            //area.Area1 = "POP";
            //area.Zipcode = "44331";
            //dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            //context.Areas.Add(area);
            //context.SaveChanges();

            //fetch_Data
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "FFFF");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            area = areas.SingleOrDefault(a => a.Area1 == "POP");
            context.Areas.Remove(area);
            context.SaveChanges();
            //var areas = context.Areas.ToList();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }

            //Scaffold - DbContext "Data Source=353CBX3\\DEMOINSTANCE;Initial Catalog=dbEmployeeTracker;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Model
            //Scaffold - DbContext "Data Source= 353CBX3\\DEMOINSTANCE;Initial Catalog=dbEmployeeTracker;Integrated Security=true;Microsoft.EntityFrameworkCore.SqlServer - OutputDir Model
        }
        }
}
