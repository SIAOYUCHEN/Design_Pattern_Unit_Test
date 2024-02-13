using System.Text.RegularExpressions;

namespace FacadeV1;

public class MarkdownParser
{
    public Table ParseTableFromFile(string fileName)
    {
        string markdown = File.ReadAllText(fileName);
        string[] lines = markdown.Split('\n');
        List<List<string>> fields = new List<List<string>>
        {
            ParseRow(0, lines)
        };
        for (int i = 2; i < lines.Length; i++)
        {
            fields.Add(ParseRow(i, lines));
        }
        return new Table(fields);
    }

    private List<string> ParseRow(int i, string[] lines)
    {
        string pattern = "^[|\\s]+";
        string line = Regex.Replace(lines[i], pattern, "", RegexOptions.None, TimeSpan.FromMilliseconds(500));
        
        return line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList();
    }
}