using System;
using System.Linq;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Config = RabbitMqExamples.Configuration;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class Topics : SubscribeBase, ISubscribe
  {
    public Topics()
    {
      ExchangeName = "topic_logs";
      QueueName = string.Empty;
      RoutingKey = "unknown.#";
    }

    public void Start(string[] args)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        RoutingKey = args.Any() ? args[0] : RoutingKey;
        channel.ExchangeDeclare(ExchangeName, "topic");

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

    private void PrintReceivedMessage(string message, string routingKey)
    {
      string severity = string.Empty;

      Console.Write(" [x] Received ");

      if (routingKey.Contains($".{Config.Severity.INFO}"))
      {
        Console.ForegroundColor = ConsoleColor.Blue;
        severity = Config.Severity.INFO;
      }
      if (routingKey.Contains($".{Config.Severity.WARNING}"))
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        severity = Config.Severity.WARNING;
      }
      if (routingKey.Contains($".{Config.Severity.CRITICAL}"))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        severity = Config.Severity.CRITICAL;
      }

      if (!string.IsNullOrEmpty(severity))
      {
        Console.Write(severity.ToUpper());
      }

      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine($" {message}");
    }
  }
}
