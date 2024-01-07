using System.Text;

namespace ChainV3;

public class CurrencyHandler : MessageHandler
{
    public CurrencyHandler(MessageHandler next) : base(next)
    {
    }

    protected override async Task<bool> Match(IMessage message)
    {
        return string.Equals(message.Content, "currency", StringComparison.OrdinalIgnoreCase);
    }

    protected override async Task DoHandling(IMessage message, IMessageChannel channel)
    {
        string currencyBody = await CrawlCurrencyBodyAsync();
        await channel.SendMessageAsync("▋ CURRENCY ▋");
        await channel.SendMessageAsync(currencyBody);
    }

    private async Task<string> CrawlCurrencyBodyAsync()
    {
        var url = "https://rate.bot.com.tw/xrt?Lang=zh-TW";
        var result = new StringBuilder();
        using (var httpClient = new HttpClient())
        {
            var html = await httpClient.GetStringAsync(url);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var tableNode = htmlDoc.DocumentNode.SelectSingleNode("//table[@id='ie11andabove']/tbody");
            if (tableNode == null)
                throw new Exception("No currency data found.");

            var currencyNodes = tableNode.SelectNodes("tr");
            foreach (var node in currencyNodes)
            {
                var name = node.SelectSingleNode("td[1]/div/div[3]").InnerText;
                var value = node.SelectSingleNode("td[3]").InnerText;
                result.AppendLine($"匯率幣別: {name} 匯率: {value}");
            }
        }
        return result.ToString();
    }
}