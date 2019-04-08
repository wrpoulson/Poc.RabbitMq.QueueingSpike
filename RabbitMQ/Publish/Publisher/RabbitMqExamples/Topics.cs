using System;
using System.Collections.Generic;

namespace Publisher.RabbitMqExamples
{
  public class Topics : PublishBase, IPublish
  {
    public Topics()
    {
      ExchangeName = string.Empty;
      QueueName = string.Empty;
      RoutingKey = string.Empty;
    }
  }
}
