using System;
using System.Collections.Generic;

namespace RabbitMqExamples.Data
{
  public class Messages
  {
    public List<string> EmptyStartMessages() => new List<string>();

    public List<string> RandomDefaultStartMessages()
    {
      Random rng = new Random();
      return new List<string>
      {
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '837_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' Delay: {new string('.',rng.Next(0, 6))}"
      };
    }
  }
}
