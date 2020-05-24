using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarManagement.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace CarManagement
{
    public class Program
    {
        private static ConnectionClass connClass;
        public static void Main(string[] args)
        {
            connClass = new ConnectionClass();
            var connectionFactory = connClass.getConnectionFactored();


            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.BasicQos(0, 1, false);
            CarReceiver messageReceiver = new CarReceiver(channel);
            channel.BasicConsume("cars.queue", false, messageReceiver);


            CarService carService = new CarService();
            //var test = carService.getCarListPerLocation();


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

