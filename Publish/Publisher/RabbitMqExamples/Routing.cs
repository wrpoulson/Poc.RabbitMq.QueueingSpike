using RabbitMQ.Client;
using Config = RabbitMqExamples.Configuration;
using System;
using System.Text;

namespace Publisher.RabbitMqExamples
{
  public class Routing : PublishBase, IPublish
  {
    private Random rng = new Random();

    public Routing()
    {
      ExchangeName = "direct_logs";
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }

    public override void SendMessage(string message)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.ExchangeDeclare(ExchangeName, "direct");

        var severity = GetSeverity();

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: ExchangeName,
                             routingKey: severity,
                             basicProperties: null,
                             body: body);

        PrintSentMessage(message, severity);
      }
    }

    private string GetSeverity()
    {
      var randomness = rng.Next(0, 3);

      switch (randomness)
      {
        case 0:
          return Config.Severity.INFO;
        case 1:
          return Config.Severity.WARNING;
        case 2:
          return Config.Severity.CRITICAL;
        default:
          return Config.Severity.UNKNOWN;
      }
    }

    private void PrintSentMessage(string message, string severity)
    {
      Console.Write(" [x] Sent ");

      switch (severity)
      {
        case Config.Severity.INFO:
          Console.ForegroundColor = ConsoleColor.Blue;
          break;
        case Config.Severity.WARNING:
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case Config.Severity.CRITICAL:
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        default:
          break;
      }

      Console.Write(severity.ToUpper());
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine($" {message}");
    }
  }
}
