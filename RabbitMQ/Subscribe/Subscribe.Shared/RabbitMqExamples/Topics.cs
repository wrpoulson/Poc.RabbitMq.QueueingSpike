using System;

namespace Subscribe.Shared.RabbitMqExamples
{
  public class Topics : SubscribeBase, ISubscribe
  {
    public Topics()
    {
      ExchangeName = string.Empty;
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }

    public void Start(string[] args)
    {
      throw new NotImplementedException();
    }
  }
}
