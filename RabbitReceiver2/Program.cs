using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        ConnectionFactory factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672"),
            ClientProvidedName = "Rabbit Receiver1 App"
        };

        IConnection cnn = factory.CreateConnection();
        IModel channel = cnn.CreateModel();
        string exchangeName = "DemoExchange";

        string routingKey = "demo-routing-key";
        string queueName = "DemoQueue";

        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, durable: false, autoDelete: false, arguments: null);
        channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        channel.QueueBind(queueName, exchangeName, routingKey, null);
        channel.BasicQos(0,1,false);
        
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender ,args) =>
        {
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            var body =args.Body.ToArray();
            string message=Encoding.UTF8.GetString(body); 
            Console.WriteLine($"Message Recieved: {message}");
            channel.BasicAck(args.DeliveryTag,false);
        };
        string consumerTag=channel.BasicConsume(queueName,false,consumer);
        Console.ReadLine();
        channel.BasicCancel(consumerTag);
        channel.Close();
        cnn.Close();
    }
}
