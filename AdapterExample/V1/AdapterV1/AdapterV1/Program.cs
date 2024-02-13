
using AdapterV1;

class Program
{
    static void Main(string[] args)
    {
        VocabLookupCLI cli = new VocabLookupCLI(new VocabCrawlerAdapter());
        cli.Start();
    }
}