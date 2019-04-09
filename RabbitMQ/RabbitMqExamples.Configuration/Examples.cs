
namespace RabbitMqExamples.Configuration
{
  public class Examples
  {
    public const string CURRENT_EXAMPLE = TOPIC;    
    public const string HELLO_WORLD = "HELLO_WORLD"; // 1 publisher, 3 subscribers, round-robin
    public const string PUBLISH_SUBSCRIBE = "PUBLISH_SUBSCRIBE"; // 1 publisher, 3 subscribers, message fanout to 3 queues with 1 subscriber on each queue
    public const string ROUTING = "ROUTING"; // 1 publisher, 3 subscribers, messages routed using routeKey based on Severity
    public const string RPC = "RPC"; 
    public const string TOPIC = "TOPIC"; // 1 publisher, 3 subscribers, messages routed using combination of LCode, Severity, FileType, subscribers filter what is observed
    public const string WORK_QUEUES = "WORK_QUEUES"; // 1 publisher, 3 subscribers, round-robin with delayed task execution
  }
}
