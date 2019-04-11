using System;
using System.Collections.Generic;
using System.Linq;
using Config = RabbitMqExamples.Configuration;

namespace RabbitMqExamples.Data
{
  public class Messages
  {
    public List<string> EmptyStartMessages() => new List<string>();

    public List<string> RandomDefaultStartMessages(bool randomFileTypes = false)
    {
      Random rng = new Random();
      var messages = new List<string>
      {
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L{rng.Next(1,500).ToString("D3")}.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L042.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L042.txt' |{new string('.',rng.Next(0, 6))}|",
        $"File Received {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}: '{GetRandomFileType(rng.Next(0,3), randomFileTypes)}_{rng.Next()}_L042.txt' |{new string('.',rng.Next(0, 6))}|"
      };
      return messages.Select(m => m.Replace("||", string.Empty)).ToList();
    }

    private string GetRandomFileType(int randomness, bool randomFileTypes)
    {
      if (randomFileTypes)
      {
        switch (randomness)
        {
          case 0:
            return Config.FileType.Ansi271;
          case 1:
            return Config.FileType.Ansi277;
          case 2:
            return Config.FileType.Ansi837;
          default:
            return Config.FileType.UNKNOWN;
        }
      }

      return Config.FileType.Ansi837;
    }
  }
}
