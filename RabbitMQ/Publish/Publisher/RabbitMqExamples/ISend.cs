
using System.Collections.Generic;

namespace Publisher.RabbitMqExamples
{
  public interface IPublish
  {
    void Start(string[] args, List<string> messages);
  }
}
