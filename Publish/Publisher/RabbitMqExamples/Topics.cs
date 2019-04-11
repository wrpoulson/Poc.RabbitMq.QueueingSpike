using RabbitMQ.Client;
using Config = RabbitMqExamples.Configuration;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Publisher.RabbitMqExamples
{
  public class Topics : PublishBase, IPublish
  {
    private Random rng = new Random();

    public Topics()
    {
      ExchangeName = "topic_logs";
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }
    public override void SendMessage(string message)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.ExchangeDeclare(ExchangeName, "topic");

        var severity = GetSeverity();
        var routingKey = $"{GetLCode(message)}.{GetFileType(message)}.{severity}";

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: ExchangeName,
                             routingKey: routingKey,
                             basicProperties: null,
                             body: body);

        PrintSentMessage(message, severity);
      }
    }

    private object GetLCode(string message)
    {
      Regex lCodeRegex = new Regex(@"([Ll]([0-4]\d{2}))");
      var matchResult = lCodeRegex.Match(message);
      return matchResult.Success ? matchResult.Value : Config.Severity.UNKNOWN;
    }

    private object GetFileType(string message)
    {
      if (message != null)
      {
        if (message.Contains(Config.FileType.Ansi271)) return Config.FileType.Ansi271;
        if (message.Contains(Config.FileType.Ansi277)) return Config.FileType.Ansi277;
        if (message.Contains(Config.FileType.Ansi837)) return Config.FileType.Ansi837;
      }

      return Config.FileType.UNKNOWN;
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
