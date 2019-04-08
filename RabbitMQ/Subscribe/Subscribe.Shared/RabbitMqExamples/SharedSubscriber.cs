using System;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class SharedSubscriber
  {
    private ISubscribe _subscriber;

    public void Start(string[] args)
    {
      //_subscriber = new HelloWorld();
      //_subscriber = new WorkQueues();
      _subscriber = new PublishSubscribe();
      //_subscriber = new Routing();
      //_subscriber = new Topics();
      //_subscriber = new Rpc();

      _subscriber.Start(args);
    }
  }
}
