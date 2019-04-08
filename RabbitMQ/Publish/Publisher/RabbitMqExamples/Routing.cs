using System;
using System.Collections.Generic;

namespace Publisher.RabbitMqExamples
{
  public class Routing : PublishBase, IPublish
  {
    public Routing()
    {
      ExchangeName = string.Empty;
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }
  }
}
