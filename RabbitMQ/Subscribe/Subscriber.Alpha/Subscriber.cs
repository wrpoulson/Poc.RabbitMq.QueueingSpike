using System;
using System.Threading;
using RabbitMqExamples.Configuration;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Alpha
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Alpha";
      ISubscribe subscriber;

      switch (Examples.CURRENT_EXAMPLE)
      {
        case Examples.HELLO_WORLD:
          subscriber = new HelloWorld();
          subscriber.Start(args);
          break;
        case Examples.WORK_QUEUES:
          Thread.Sleep(500);
          subscriber = new WorkQueues();
          subscriber.Start(args);
          break;
        case Examples.PUBLISH_SUBSCRIBE:
          Thread.Sleep(500);
          subscriber = new PublishSubscribe();
          subscriber.Start(args);
          break;
        case Examples.ROUTING:
          Thread.Sleep(500);
          subscriber = new Routing();
          subscriber.Start(new string[] { "info" });
          break;
        case Examples.TOPIC:
          subscriber = new Topics();
          subscriber.Start(args);
          break;
        case Examples.RPC:
          subscriber = new Rpc();
          subscriber.Start(args);
          break;
      }
    }
  }
}
