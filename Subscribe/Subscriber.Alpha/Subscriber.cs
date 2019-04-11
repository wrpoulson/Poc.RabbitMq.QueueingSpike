using System;
using System.Threading;
using Config = RabbitMqExamples.Configuration;
using Subscribe.Shared.RabbitMqExamples;

namespace Subscriber.Alpha
{
  class Subscriber
  {
    static void Main(string[] args)
    {
      Console.Title = "Subscriber.Alpha";
      ISubscribe subscriber;

      switch (Config.Examples.CURRENT_EXAMPLE)
      {
        case Config.Examples.HELLO_WORLD:
          subscriber = new HelloWorld();
          subscriber.Start(args);
          break;
        case Config.Examples.WORK_QUEUES:
          Thread.Sleep(500);
          subscriber = new WorkQueues();
          subscriber.Start(args);
          break;
        case Config.Examples.PUBLISH_SUBSCRIBE:
          Thread.Sleep(500);
          subscriber = new PublishSubscribe();
          subscriber.Start(args);
          break;
        case Config.Examples.ROUTING:
          Thread.Sleep(500);
          subscriber = new Routing();
          subscriber.Start(new string[] { Config.Severity.INFO });
          break;
        case Config.Examples.TOPIC:
          Console.Title = Config.Topics.ALPHA_CONSOLE_TITLE;
          subscriber = new Topics();
          subscriber.Start(new string[] { Config.Topics.LCODE_ROUTING_KEY });
          break;
        case Config.Examples.RPC:
          subscriber = new Rpc();
          subscriber.Start(args);
          break;
      }
    }
  }
}
