using System.Text.RegularExpressions;

var fileName = "read.txt";

var wordCounts = new Dictionary<string, int>();

if (File.Exists(fileName))
{
    using (StreamReader fs = new StreamReader(fileName))
    {
        while (true)
        {
            var temp = fs.ReadLine();

            if (temp == null)
            {
                break;
            }

            temp = Regex.Replace(temp, "(?i)[^А-ЯЁA-Z]", " ");

            var words = temp.ToLower().Split(' ');

            foreach (var word in words)
            {
                if (word != "")
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts.Add(word, 1);
                    }
                }
            }
        }
    }

    using (StreamWriter sw = new StreamWriter("write.txt"))
    {
        foreach (var wordCount in wordCounts.OrderByDescending(wordCount => wordCount.Value))
        {
            sw.WriteLine($"{wordCount.Key} {wordCount.Value}");
        }
    }
}
