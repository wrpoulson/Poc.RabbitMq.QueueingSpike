
using System.Collections.Generic;

namespace Publisher.RabbitMqExamples
{
  public interface ISend
  {
    void Start(string[] args, List<string> messages);
  }
}
