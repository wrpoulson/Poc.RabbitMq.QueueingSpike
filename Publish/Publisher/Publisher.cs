using System;
using System.Threading;
using Publisher.RabbitMqExamples;
using Config = RabbitMqExamples.Configuration;
using RabbitMqExamples.Data;

namespace Publisher
{
  class Publisher
  {
    static void Main(string[] args)
    {
      Console.Title = "Publisher";
      IPublish publisher;

      switch (Config.Examples.CURRENT_EXAMPLE)
      {
        case Config.Examples.HELLO_WORLD:
          publisher = new HelloWorld();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Config.Examples.WORK_QUEUES:
          Thread.Sleep(500);
          publisher = new WorkQueues();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Config.Examples.PUBLISH_SUBSCRIBE:
          Thread.Sleep(500);
          publisher = new PublishSubscribe();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Config.Examples.ROUTING:
          Thread.Sleep(500);
          publisher = new Routing();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Config.Examples.TOPIC:
          publisher = new Topics();
          publisher.Start(args, new Messages().RandomDefaultStartMessages(true));
          break;
        case Config.Examples.RPC:
          publisher = new Rpc();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
      }
    }
  }
}
