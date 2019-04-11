using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class PublishSubscribe : SubscribeBase, ISubscribe
  {
    public PublishSubscribe()
    {
      ExchangeName = "logs";
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }

    public void Start(string[] args)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.ExchangeDeclare(ExchangeName, "fanout");

        QueueName = channel.QueueDeclare().QueueName;

        channel.QueueBind(queue: QueueName,
                          exchange: ExchangeName,
                          routingKey: RoutingKey);

        Console.WriteLine(" [*] Waiting for logs.");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
          var body = ea.Body;
          var message = Encoding.UTF8.GetString(body);
          Console.WriteLine($" [x] Received {message}");

          int dots = message.Split('.').Length - 2;
          Thread.Sleep(dots * 1000);

          Console.WriteLine($" [x] Done processing '{message}' in {dots} seconds.");
        };

        channel.BasicConsume(queue: QueueName,
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
      }
    }
  }
}
