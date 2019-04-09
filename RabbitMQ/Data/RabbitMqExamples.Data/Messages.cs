using System;
using System.Collections.Generic;

namespace RabbitMqExamples.Data
{
  public class Messages
  {
    public List<string> EmptyStartMessages() => new List<string>();

    public List<string> RandomDefaultStartMessages(bool randomFileTypes = false)
    {
      Random rng = new Random();
      return new List<string>
      {
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{(randomFileTypes? GetRandomFileType(rng.Next(0,3)) : "837")}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}"
      };
    }

    private string GetRandomFileType(int randomness)
    {
      switch (randomness)
      {
        case 0:
          return "837";
        case 1:
          return "277";
        case 2:
          return "271";
        default:
          return "unknown";
      }
    }
  }
}
