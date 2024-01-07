using System.Text;

namespace ChainV1;

public class WaterballBot
{
    private readonly DiscordSocketClient _client;
    private readonly string _token;

    public WaterballBot()
    {
        _client = new DiscordSocketClient();
        _token = GetDiscordToken();
    }

    public async Task ConnectAsync()
    {
        await _client.LoginAsync(TokenType.Bot, _token);
        await _client.StartAsync();

        _client.MessageReceived += HandleMessageAsync;
        await Task.Delay(-1); // Block this task until the program is closed.
    }

    private static string GetDiscordToken()
    {
        var tokenPath = "token.properties"; // 路徑可能需要根據您的專案結構進行調整
        var token = File.ReadAllText(tokenPath);
        return token;
    }

    private async Task HandleMessageAsync(SocketMessage message)
    {
        if (message.Author.IsBot) return; // 忽略其他機器人發的消息

        var channel = message.Channel;
        if (string.Equals(message.Content, "help", StringComparison.OrdinalIgnoreCase))
        {
            await channel.SendMessageAsync("▋ HELP ▋");
            await channel.SendMessageAsync("Commands: dcard, currency");
        }
        else if (string.Equals(message.Content, "dcard", StringComparison.OrdinalIgnoreCase))
        {
            var dcardBody = await CrawlDcardBodyAsync();
            await channel.SendMessageAsync("▋ DCARD ▋");
            await channel.SendMessageAsync(dcardBody);
        }
        else if (string.Equals(message.Content, "currency", StringComparison.OrdinalIgnoreCase))
        {
            var currencyBody = await CrawlCurrencyBodyAsync();
            await channel.SendMessageAsync("▋ CURRENCY ▋");
            await channel.SendMessageAsync(currencyBody);
        }
    }

    private async Task<string> CrawlDcardBodyAsync()
    {
        var url = "https://www.dcard.tw/f/talk";
        using var httpClient = new HttpClient();
        var html = await httpClient.GetStringAsync(url);
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        
        // 這邊的選擇器可能需要根據網頁實際的 HTML 結構進行調整
        var nodes = htmlDoc.DocumentNode.SelectNodes("//h2");
        if (nodes == null) throw new Exception("No content found.");

        var stringBuilder = new StringBuilder();
        foreach (var node in nodes)
        {
            var title = node.InnerText;
            var link = "https://www.dcard.tw" + node.GetAttributeValue("href", string.Empty);
            stringBuilder.AppendLine($"{title} - {link}");
        }

        return stringBuilder.ToString();
    }

    private async Task<string> CrawlCurrencyBodyAsync()
    {
        var url = "https://rate.bot.com.tw/xrt?Lang=zh-TW";
        using var httpClient = new HttpClient();
        var html = await httpClient.GetStringAsync(url);
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        var tableNode = htmlDoc.DocumentNode.SelectSingleNode("//table[@id='ie11andabove']/tbody");
        if (tableNode == null) throw new Exception("No currency data found.");

        var stringBuilder = new StringBuilder();
        var currencyNodes = tableNode.SelectNodes("tr");
        foreach (var node in currencyNodes)
        {
            var name = node.SelectSingleNode("td[1]/div/div[3]").InnerText;
            var value = node.SelectSingleNode("td[3]").InnerText;
            stringBuilder.AppendLine($"匯率幣別: {name} 匯率: {value}");
        }

        return stringBuilder.ToString();
    }
}