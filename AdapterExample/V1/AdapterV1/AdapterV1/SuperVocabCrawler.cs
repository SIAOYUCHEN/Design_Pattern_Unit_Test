namespace AdapterV1;

public class SuperVocabCrawler
{
    public async Task<SuperWord> Crawl(string spelling)
    {
        string link = "https://www.vocabulary.com/dictionary/" + spelling;
        try
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(link);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var definitionElements = htmlDocument.DocumentNode.SelectNodes("//div[@class='word-definitions']/ol/li[contains(@class, 'sense')]");

            if (definitionElements == null || definitionElements.Count == 0)
            {
                throw new YouSpellItWrongException();
            }

            List<string> definitions = new List<string>();
            foreach (var definitionElement in definitionElements)
            {
                definitions.Add(definitionElement.InnerText.Trim());
            }

            return new SuperWord(spelling, definitions);
        }
        catch (HttpRequestException e)
        {
            throw new RuntimeException($"Failed to fetch data: {e.Message}");
        }
    }
}