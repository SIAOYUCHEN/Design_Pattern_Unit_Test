// See https://aka.ms/new-console-template for more information

using ChainV3;

class Program
{
    static void Main(string[] args)
    {
        WaterballBot waterballBot = new WaterballBot(
            new HelpMessageHandler(new DcardHandler(new CurrencyHandler(null))));
        
        waterballBot.ConnectAsync();
    }
}