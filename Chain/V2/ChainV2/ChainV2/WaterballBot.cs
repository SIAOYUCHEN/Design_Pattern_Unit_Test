namespace ChainV2;

public class WaterballBot
{
    private readonly DiscordSocketClient _client;
    private readonly MessageHandler _handler;

    public WaterballBot(MessageHandler handler)
    {
        _client = new DiscordSocketClient();
        _handler = handler;
    }

    public async Task ConnectAsync()
    {
        var token = GetDiscordToken();
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        _client.MessageReceived += MessageReceivedAsync;
        await Task.Delay(-1); // Keep the program alive
    }

    private static string GetDiscordToken()
    {
        var tokenPath = "token.properties"; // Adjust the path as needed
        var token = File.ReadAllText(tokenPath);
        return token;
    }

    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if (!(message is SocketUserMessage userMessage)) return;
        if (message.Author.IsBot) return;

        var channel = message.Channel;
        await _handler.Handle(userMessage, channel);
    }
}