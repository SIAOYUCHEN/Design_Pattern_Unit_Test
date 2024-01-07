using System.Text;

namespace ChainV2;

public class DcardHandler : MessageHandler
{
    public DcardHandler(MessageHandler next) : base(next)
    {
    }

    public override async Task Handle(IMessage message, IMessageChannel channel)
    {
        if (string.Equals(message.Content, "dcard", StringComparison.OrdinalIgnoreCase))
        {
            string dcardBody = await CrawlDcardBodyAsync();
            await channel.SendMessageAsync("▋ DCARD ▋");
            await channel.SendMessageAsync(dcardBody);
        }
        else if (Next != null)
        {
            await Next.Handle(message, channel);
        }
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
                stringBuilder.AppendLine(line);
            }
        }

        return stringBuilder.ToString();
    }
}