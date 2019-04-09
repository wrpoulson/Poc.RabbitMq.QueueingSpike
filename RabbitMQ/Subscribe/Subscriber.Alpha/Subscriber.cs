using System;
using System.Threading;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Alpha
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Alpha";
      bool delayStart = false;
      ISubscribe subscriber;

      //subscriber = new HelloWorld();
      //subscriber = new WorkQueues();
      //subscriber = new PublishSubscribe();
      subscriber = new Routing(); args = new string[] { "info" };
      //subscriber = new Topics();
      //subscriber = new Rpc();

      if (delayStart) Thread.Sleep(500);
      subscriber.Start(args);
    }
  }
}
