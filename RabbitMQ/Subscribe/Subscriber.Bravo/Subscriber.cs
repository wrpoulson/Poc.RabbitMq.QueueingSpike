using System;
using System.Threading;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Bravo
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Bravo";
      bool delayStart = true;
      ISubscribe subscriber;

      //subscriber = new HelloWorld();
      //subscriber = new WorkQueues();
      //subscriber = new PublishSubscribe();
      subscriber = new Routing(); args = new string[] { "warning" };
      //subscriber = new Topics();
      //subscriber = new Rpc();

      if (delayStart) Thread.Sleep(500);
      subscriber.Start(args);
    }
  }
}
