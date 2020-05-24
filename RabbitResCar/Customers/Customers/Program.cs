using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomersMangement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string json = "{'_id':{'$oid':'5ec5c4baf72318076026c7fc'},'CustomerId':'1','FirstName':'234','LastName':'234','Password':'234','Email':'234','DrivingLicenseNumber':'232323535','RegistrationDate':{'$date':'0001 - 01 - 01T00: 00:00.000Z'},'State':' ','City':'Vienna','Country':'AT','Zipcode':'1110','Phone':'0660555471556'}";
            CustomerService customerService = new CustomerService();
            //customerService.RegisterCustomer("kk", "kkk", "werwr", "werwe", "ewr3433", "lkkkkk", "werwe", "ewr3433", "lkkkkk", "werwe", "ewr3433", Convert.ToDateTime("2020-10-10"));
            //customerService.DeleteByCustomerID(1);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
       
    }
}
