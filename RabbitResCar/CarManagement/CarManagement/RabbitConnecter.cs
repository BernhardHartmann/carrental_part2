﻿using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement
{    
    public class RabbitConnecter
    {
        private string UName;
        private string PWD;
        private string HName;

        public RabbitConnecter()
        {
            UName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Rabbit")["DB_Password"];
            PWD = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Rabbit")["DB_User"];
            HName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DB_Rabbit")["DB_Host"];
        }

        public ConnectionFactory getConnectionFactored()
        {
           return new ConnectionFactory()
            {
                UserName = UName,
                Password = PWD,
                HostName = HName
            };
        }

        public IModel getModel()
        {
            var connection = getConnectionFactored().CreateConnection();
            return connection.CreateModel();
          
        }

        public IBasicProperties getProperties()
        {
            return getModel().CreateBasicProperties();
        }

    }
}
