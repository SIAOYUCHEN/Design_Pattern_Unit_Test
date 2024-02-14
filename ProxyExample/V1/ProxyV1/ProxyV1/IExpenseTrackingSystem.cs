namespace ProxyV1;

public interface IExpenseTrackingSystem
{
    List<Expense> GetExpenses();
    
    void AddExpense(Expense expense);
    
    void EditExpense(Expense expense);
    
    void ExportCsv(string filename);
}