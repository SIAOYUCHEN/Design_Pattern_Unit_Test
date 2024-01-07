// See https://aka.ms/new-console-template for more information

using ChainV1;

class Program
{
    static void Main(string[] args)
    {
        WaterballBot waterballBot = new WaterballBot();
        
        waterballBot.ConnectAsync();
    }
}