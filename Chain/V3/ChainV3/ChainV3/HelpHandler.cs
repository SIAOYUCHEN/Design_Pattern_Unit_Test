namespace ChainV3;

public class HelpMessageHandler : MessageHandler
{
    public HelpMessageHandler(MessageHandler next) : base(next)
    {
    }

    protected override async Task<bool> Match(IMessage message)
    {
        return string.Equals(message.Content, "help", StringComparison.OrdinalIgnoreCase);
    }

    protected override async Task DoHandling(IMessage message, IMessageChannel channel)
    {
        await channel.SendMessageAsync("▋ HELP ▋");
        await channel.SendMessageAsync("Commands: dcard, currency");
    }
}