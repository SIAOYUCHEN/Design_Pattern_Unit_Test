using System.Text;

namespace ChainV3;

public class DcardHandler : MessageHandler
{
    public DcardHandler(MessageHandler next) : base(next)
    {
    }

    protected override async Task<bool> Match(IMessage message)
    {
        return string.Equals(message.Content, "dcard", StringComparison.OrdinalIgnoreCase);
    }

    protected override async Task DoHandling(IMessage message, IMessageChannel channel)
    {
        string dcardBody = await CrawlDcardBodyAsync();
        await channel.SendMessageAsync("▋ DCARD ▋");
        await channel.SendMessageAsync(dcardBody);
    }

    private async Task<string> CrawlDcardBodyAsync()
    {
        const string Link = "https://www.dcard.tw";
        const string Topic = "/f/talk";
        var url = Link + Topic;
        var stringBuilder = new StringBuilder();

        using (var httpClient = new HttpClient())
        {
            var html = await httpClient.GetStringAsync(url);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var definitions = htmlDoc.DocumentNode.SelectNodes("//h2");
            if (definitions == null)
                throw new Exception("No content found.");

            foreach (var element in definitions)
            {
                var titleNode = element.SelectSingleNode(".//span") ?? element;
                var title = titleNode.InnerText;
                var link = Link + element.GetAttributeValue("href", string.Empty);
                var line = $"{title} - {link}";
                stringBuilder.AppendLine(line).AppendLine();
            }
        }

        return stringBuilder.ToString();
    }
}