namespace ProxyV1;

public class ExpenseTrackingCli
{
    private readonly IExpenseTrackingSystem _system;
    public const int ExpensesPageSize = 7;

    public ExpenseTrackingCli(IExpenseTrackingSystem system)
    {
        _system = system;
    }

    public void Start()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("選擇功能：(1) 新增一筆帳目 (2) 編輯一筆帳目 (3) 匯出 CSV：");
                int choice = InputIntegerBetween(1, 3, "請輸入數字 1~3！");
                switch (choice)
                {
                    case 1:
                        AddExpense();
                        break;
                    case 2:
                        EditExpense();
                        break;
                    case 3:
                        ExportCSV();
                        break;
                }
            }
            catch (Exception err)
            {
                Console.Error.WriteLine(err.Message);
            }
        }
    }

    private void AddExpense()
    {
        var expense = InputExpense();
        _system.AddExpense(expense);
        Console.WriteLine($"成功新增一筆帳目 -- {expense.Description} {expense.Cost:F3}");
    }

    // Assume InputExpense, InputIntegerBetween, InputLine, and other input utility methods are implemented here or in a utility class.

    private void EditExpense()
    {
        var expenses = _system.GetExpenses();
        expenses.Reverse();
        int editedExpenseIndex = SelectEditedExpenseIndex(expenses);
        var edited = InputEditedExpense(expenses, editedExpenseIndex);
        _system.EditExpense(edited);
    }

    // Implement SelectEditedExpenseIndex, InputEditedExpense, and other necessary methods for handling expense editing and selection.

    private void PrintExpenses(List<Expense> expenses, int page)
    {
        int start = page * ExpensesPageSize;
        int end = Math.Min(expenses.Count, (page + 1) * ExpensesPageSize);
        for (int i = start; i < end; i++)
        {
            var expense = expenses[i];
            Console.WriteLine($"[{i}] {expense.Description} {expense.Cost:F3} {expense.CreatedTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)}");
        }
    }

    private void ExportCsv()
    {
        Console.WriteLine("請輸出 CSV 檔案名稱：");
        string filename = Console.ReadLine();
        _system.ExportCSV(filename);
    }
}