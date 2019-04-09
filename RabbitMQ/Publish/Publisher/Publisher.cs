using System;
using System.Threading;
using Publisher.RabbitMqExamples;
using RabbitMqExamples.Configuration;
using RabbitMqExamples.Data;

namespace Publisher
{
  class Publisher
  {
    static void Main(string[] args)
    {
      Console.Title = "Publisher";
      IPublish publisher;

      switch (Examples.CURRENT_EXAMPLE)
      {
        case Examples.HELLO_WORLD:
          publisher = new HelloWorld();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Examples.WORK_QUEUES:
          Thread.Sleep(500);
          publisher = new WorkQueues();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Examples.PUBLISH_SUBSCRIBE:
          Thread.Sleep(500);
          publisher = new PublishSubscribe();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Examples.ROUTING:
          Thread.Sleep(500);
          publisher = new Routing();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
        case Examples.TOPIC:
          publisher = new Topics();
          publisher.Start(args, new Messages().RandomDefaultStartMessages(true));
          break;
        case Examples.RPC:
          publisher = new Rpc();
          publisher.Start(args, new Messages().RandomDefaultStartMessages());
          break;
      }
    }
  }
}
