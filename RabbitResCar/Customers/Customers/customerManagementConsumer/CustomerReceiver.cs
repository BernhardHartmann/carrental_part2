using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Threading;
using CarManagement.Data;
using Customers.Data;
using Customers;

namespace CustomersMangement
{
    public class CustomerReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private CustomerService carservice;
        private ConnectionClass connClass;
        private static QueueingBasicConsumer _consumer;
        public CustomerReceiver(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            //RabbitDataHandler rabbitDataHandler = new RabbitDataHandler();
            CustomerService carService = new CustomerService();
            string result = "";
            string documentID = "";
            Customer customer;
            try
            {
                if (exchange.Equals("request.customers"))
                {
                    connClass = new ConnectionClass();
                    ConnectionFactory connectionFactory = connClass.getConnectionFactored();
                    var model = connClass.getModel();
                    connClass.getProperties().Persistent = false;
                    switch (routingKey)
                    {
                        // update is Available
                        case "request.register.customer":
                            customer = JsonConvert.DeserializeObject<Customer>(Encoding.UTF8.GetString(body));
                            result = carService.RegisterCustomer(customer.FirstName, customer.LastName, customer.Password, customer.Email, customer.DrivingLicenseNumber, customer.Mobile, customer.State, customer.City, customer.Country, customer.Zipcode, customer.Phone, customer.RegistrationDate);
                            break;

                        // get available Cars Count By Category & Location
                        case "request.get.customer.login":
                            var emailAndPassword = JsonConvert.DeserializeObject<Object>(Encoding.UTF8.GetString(body));
                            var email = ((Newtonsoft.Json.Linq.JContainer)emailAndPassword).First;
                            var emailID = ((Newtonsoft.Json.Linq.JProperty)email).Value;
                            var password = ((Newtonsoft.Json.Linq.JContainer)emailAndPassword).Last;
                            var passwordID = ((Newtonsoft.Json.Linq.JProperty)password).Value;
                            result = carService.CustomerLogin((string)emailID, (string)passwordID);
                            break;                                   

                        case "request.customer.delete":
                            documentID = JsonConvert.DeserializeObject<string>(Encoding.UTF8.GetString(body));
                            result =  carService.DeleteUserByDocumentID(documentID);
                            break;                      

                    }
                    byte[] messagebuffer = Encoding.Default.GetBytes(result);
                    model.BasicPublish(exchange, routingKey, connClass.getProperties(), messagebuffer);
                    
                    //var ea = _consumer.Queue.Dequeue();
                    //var props = ea.BasicProperties;
                    //var replyProps = _channel.CreateBasicProperties();
                    //replyProps.CorrelationId = props.CorrelationId;

                    //long deliveryTag = envelope.getDeliveryTag();
                    _channel.BasicAck(deliveryTag, true);
                }
                
            }
            catch(Exception ex)
            {
                _channel.BasicNack(deliveryTag, true,true);
            }         
            
        }
    }
}
