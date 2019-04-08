using System;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Alpha
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Alpha";
      new SharedSubscriber().Start(args);
    }
  }
}
