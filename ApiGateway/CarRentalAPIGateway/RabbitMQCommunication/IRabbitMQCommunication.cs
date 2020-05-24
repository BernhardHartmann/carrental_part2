namespace CarRentalAPIGateway.RabbitMQCommunication
{
    public interface IRabbitMQCommunication
    {
        bool SendMessage(string message, string queueName, string exchange, string routingKey);
        string ReceiveMessage(string queueName);
    }
}
