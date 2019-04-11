using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace Publisher.RabbitMqExamples
{
  public abstract class PublishBase
  {
    private int messageCount = 0;

    public string QueueName { get; set; }

    public string ExchangeName { get; set; }

    public string RoutingKey { get; set; }

    public virtual void Start(string[] args, List<string> messages)
    {
      DispatchInitialMessages(args, messages);

      while (true)
      {
        Console.WriteLine(" Enter a new message to queue or simply press enter to [exit].");
        var userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
          SendMessage(userInput);
        }
        else
        {
          break;
        }
      }
    }

    public virtual void DispatchInitialMessages(string[] args, List<string> messages)
    {
      if (messages == null || !messages.Any())
      {
        var messageFromArgs = GetMessageFromArguments(args);
        SendMessage(messageFromArgs);
      }
      else
      {
        messages.ForEach(delegate (string message)
        {
          SendMessage($"Msg #{++messageCount} - {message}");
        });
      }
    }

    public virtual void SendMessage(string message)
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.QueueDeclare(queue: QueueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: ExchangeName,
                             routingKey: RoutingKey,
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
      }
    }

    private string GetMessageFromArguments(string[] args)
    {
      var testArgs = new string[] { "Start up default message." };
      return string.Join(" ", args.Length > 0 ? args : testArgs);
    }
  }
}
