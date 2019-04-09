using System.Threading;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class SharedSubscriber
  {
    private ISubscribe _subscriber;

    public void Start(string[] args)
    {
      bool delayStart = true;

      //_subscriber = new HelloWorld();
      //_subscriber = new WorkQueues();
      //_subscriber = new PublishSubscribe();
      _subscriber = new Routing();
      //_subscriber = new Topics();
      //_subscriber = new Rpc();

      if (delayStart) Thread.Sleep(500);
      _subscriber.Start(args);
    }
  }
}
