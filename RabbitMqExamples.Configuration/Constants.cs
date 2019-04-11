
namespace RabbitMqExamples.Configuration
{
  public static class Examples
  {
    public const string CURRENT_EXAMPLE = HELLO_WORLD;
    
    public const string HELLO_WORLD = "HELLO_WORLD"; // 1 publisher, 3 subscribers, round-robin
    public const string PUBLISH_SUBSCRIBE = "PUBLISH_SUBSCRIBE"; // 1 publisher, 3 subscribers, message fanout to 3 queues with 1 subscriber on each queue, all subscribers get each messages
    public const string ROUTING = "ROUTING"; // 1 publisher, 3 subscribers, messages routed using routeKey based on Severity
    public const string RPC = "RPC"; 
    public const string TOPIC = "TOPIC"; // 1 publisher, 3 subscribers, messages routed using combination of LCode, Severity, FileType, subscribers filter what is observed
    public const string WORK_QUEUES = "WORK_QUEUES"; // 1 publisher, 3 subscribers, round-robin with delayed task execution
  }

  public static class Severity
  {
    public const string INFO = "info";
    public const string WARNING = "warning";
    public const string CRITICAL = "critical";
    public const string UNKNOWN = "unknown";
  }

  public static class FileType
  {
    public static string Ansi271 = "271";
    public static string Ansi277 = "277";
    public static string Ansi837 = "837";
    public const string UNKNOWN = "unknown";
  }

  public static class Routing
  {
    public static string ALPHA_CONSOLE_TITLE = $"Subscriber.Alpha - {Severity.INFO}";
    public static string BRAVO_CONSOLE_TITLE = $"Subscriber.Bravo - {Severity.WARNING}";
    public static string CHARLIE_CONSOLE_TITLE = $"Subscriber.Charlie - {Severity.CRITICAL}";
  }

  public static class Topics
  {
    public static string LCODE_ROUTING_KEY = $"{LCODE}.#";
    public static string SEVERITY_ROUTING_KEY = $"*.*.{SEVERITY}";
    public static string FILETYPE_ROUTING_KEY = $"*.{FILETYPE}.*";

    public static string ALPHA_CONSOLE_TITLE = $"Subscriber.Alpha - {LCODE}";
    public static string BRAVO_CONSOLE_TITLE = $"Subscriber.Bravo - {SEVERITY}";
    public static string CHARLIE_CONSOLE_TITLE = $"Subscriber.Charlie - {FILETYPE}";

    private const string LCODE = "L042";
    private const string SEVERITY = Severity.CRITICAL;
    private const string FILETYPE = "271";
  }
}
