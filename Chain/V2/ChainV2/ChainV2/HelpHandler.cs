namespace ChainV2;

public class HelpHandler : MessageHandler
{
    public HelpHandler(MessageHandler next) : base(next)
    {
    }

    public override async Task Handle(IMessage message, IMessageChannel channel)
    {
        if (string.Equals(message.Content, "help", StringComparison.OrdinalIgnoreCase))
        {
            await channel.SendMessageAsync("▋ HELP ▋");
            await channel.SendMessageAsync("Commands: dcard, currency");
        }
        else if (Next != null)
        {
            await Next.Handle(message, channel);
        }
    }
}