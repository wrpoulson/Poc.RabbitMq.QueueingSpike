using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class Routing : SubscribeBase, ISubscribe
  {
    public Routing()
    {
      ExchangeName = "direct_logs";
      QueueName = string.Empty;
      RoutingKey = "unknown";
    }

    public void Start(string[] args)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        RoutingKey = args.Any() ? args[0] : RoutingKey;
        channel.ExchangeDeclare(ExchangeName, "direct");

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

          PrintReceivedMessage(message, RoutingKey);

          int dots = message.Split('.').Length - 1;
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

    private void PrintReceivedMessage(string message, string routingKey)
    {
      Console.Write(" [x] Received ");

      switch (routingKey)
      {
        case "info":
          Console.ForegroundColor = ConsoleColor.Blue;
          break;
        case "warning":
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case "critical":
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        default:
          break;
      }

      Console.Write(routingKey.ToUpper());
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine($" {message}");
    }
  }
}
