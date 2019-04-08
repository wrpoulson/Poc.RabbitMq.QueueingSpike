using System;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Bravo
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Bravo";
      new SharedSubscriber().Start(args);
    }
  }
}
