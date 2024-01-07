// See https://aka.ms/new-console-template for more information

using ChainV2;

class Program
{
    static void Main(string[] args)
    {
        WaterballBot waterballBot = new WaterballBot(new HelpHandler((new CurrencyHandler(null))));
        
        waterballBot.ConnectAsync();
    }
}