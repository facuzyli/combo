using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Application;
using Real.Application;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                IRepository repo = new CustomerRepositoryProxy();

                Session.CanSave = true;
                Session.CanGetAll = true;

                Customer p1 = new Customer("customer 1");
                Customer p2 = new Customer("customer 2");

                repo.Save(p1);
                repo.Save(p2);

                foreach (var p in repo.GetAll())
                {
                    Console.WriteLine($"{p.Name}");
                }



            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
          


        }
    }
}
