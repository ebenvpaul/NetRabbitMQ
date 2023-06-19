using RabbitMQ.Client;
using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672"),
            ClientProvidedName = "Rabbit Sender App"
        };

        IConnection cnn = factory.CreateConnection();
        IModel channel = cnn.CreateModel();
        string exchangeName = "DemoExchange";

        string routingKey = "demo-routing-key";
        string queueName = "DemoQueue";

        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, durable: false, autoDelete: false, arguments: null);
        channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        channel.QueueBind(queueName, exchangeName, routingKey, null);
        for (int i=0;i<60;i++)
        {
        Console.WriteLine($"Sending Message : # {i}");
        byte[] messageBodyBytes = Encoding.UTF8.GetBytes($"Message : # {i}");
        channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
        Thread.Sleep(1000);
        }
      
        channel.Close();
        cnn.Close();
    }
}
