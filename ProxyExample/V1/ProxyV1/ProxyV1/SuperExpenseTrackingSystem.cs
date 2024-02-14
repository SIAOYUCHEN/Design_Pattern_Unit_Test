using System.Text.Json.Serialization;
using System.Xml;

namespace ProxyV1;

public class SuperExpenseTrackingSystem : IExpenseTrackingSystem
{
    private static readonly string FileName = "expenses.json";
    private readonly List<Expense> _expenses;
    private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
        Converters = new List<JsonConverter> { new StringEnumConverter() },
        DateFormatHandling = DateFormatHandling.IsoDateFormat
    };

    static SuperExpenseTrackingSystem()
    {
        JsonSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ" });
    }

    public SuperExpenseTrackingSystem()
    {
        try
        {
            _expenses = ReadExpensesFromFile();
            Console.WriteLine($"[{_expenses.Count} 筆帳目] ✓");
        }
        catch (IOException e)
        {
            throw new InvalidOperationException(e.Message, e);
        }
    }

    private List<Expense> ReadExpensesFromFile()
    {
        Console.Write("載入資料中⋯⋯");
        var expensesDocument = JsonConvert.DeserializeObject<List<ExpenseDocument>>(
            File.ReadAllText(FileName), JsonSettings) ?? new List<ExpenseDocument>();
        return expensesDocument.Select(ed => ed.Convert()).ToList();
    }

    public List<Expense> GetExpenses() => new List<Expense>(_expenses);

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
        SaveData();
    }

    public void EditExpense(Expense expense)
    {
        var index = _expenses.FindIndex(e => e.Id == expense.Id);
        if (index != -1)
        {
            _expenses[index] = expense;
            SaveData();
        }
    }

    public void ExportCSV(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            writer.WriteLine("id,description,cost,createTime");
            foreach (var expense in _expenses)
            {
                writer.WriteLine($"\"{expense.Id}\",\"{expense.Description}\",\"{expense.Cost}\",\"{expense.CreatedTime:yyyy-MM-dd HH:mm:ss}\"");
            }
        }
    }

    private void SaveData()
    {
        try
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(_expenses, JsonSettings));
        }
        catch (IOException e)
        {
            throw new InvalidOperationException("Can't save data.", e);
        }
    }
}

public class ExpenseDocument
{
    public string Id, Description;
    public decimal Cost;
    public DateTime CreatedTime;

    public Expense Convert() => new Expense(Id, Description, Cost, CreatedTime);
}