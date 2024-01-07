namespace ChainV2;

public abstract class MessageHandler
{
    protected MessageHandler Next;

    protected MessageHandler(MessageHandler next)
    {
        Next = next;
    }

    public abstract void Handle(Message message, MessageChannel channel);
}