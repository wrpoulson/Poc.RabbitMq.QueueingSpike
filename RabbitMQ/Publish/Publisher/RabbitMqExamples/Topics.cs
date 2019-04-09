using RabbitMQ.Client;
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
        var fileType = GetFileType(message);
        var lCode = GetLCode(message);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: ExchangeName,
                             routingKey: $"{lCode}.{fileType}.{severity}",
                             basicProperties: null,
                             body: body);

        PrintSentMessage(message, severity);
      }
    }

    private object GetLCode(string message)
    {
      Regex lCodeRegex = new Regex(@"^([Ll]([0-4]\d{2}))$");
      var matchResult = lCodeRegex.Match(message);
      return matchResult.Success ? matchResult.Value : "unknown";
    }

    private object GetFileType(string message)
    {
      string fileType837 = "837";
      string fileType277 = "277";
      string fileType271 = "271";

      if (message != null)
      {
        if (message.Contains(fileType837)) return fileType837;
        if (message.Contains(fileType277)) return fileType277;
        if (message.Contains(fileType271)) return fileType271;
      }

      return "unknown";
    }

    private string GetSeverity()
    {
      var randomness = rng.Next(0, 3);

      switch (randomness)
      {
        case 0:
          return "info";
        case 1:
          return "warning";
        case 2:
          return "critical";
        default:
          return "unknown";
      }
    }

    private void PrintSentMessage(string message, string severity)
    {
      Console.Write(" [x] Sent ");

      switch (severity)
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

      Console.Write(severity.ToUpper());
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine($" message");
    }
  }
}
