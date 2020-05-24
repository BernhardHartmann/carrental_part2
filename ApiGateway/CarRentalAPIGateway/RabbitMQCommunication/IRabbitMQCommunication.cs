namespace CarRentalAPIGateway.RabbitMQCommunication
{
    public interface IRabbitMQCommunication
    {
        bool SendMessage(string message, string queueName);
        string ReceiveMessage(string queueName);
    }
}
