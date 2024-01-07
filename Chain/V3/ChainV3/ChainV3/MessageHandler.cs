namespace ChainV3;

public abstract class MessageHandler
{
    protected MessageHandler Next;

    protected MessageHandler(MessageHandler next)
    {
        Next = next;
    }

    public async Task Handle(IMessage message, IMessageChannel channel)
    {
        if (await Match(message))
        {
            await DoHandling(message, channel);
        }
        else if (Next != null)
        {
            await Next.Handle(message, channel);
        }
    }

    protected abstract Task<bool> Match(IMessage message);
    protected abstract Task DoHandling(IMessage message, IMessageChannel channel);
}