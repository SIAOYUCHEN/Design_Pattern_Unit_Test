namespace ProxyV1;

public class VirtualSuperExpenseTrackingSystemProxy : IExpenseTrackingSystem
{
    private SuperExpenseTrackingSystem _superSystem;

    public List<Expense> GetExpenses()
    {
        LazyInitialization();
        return _superSystem.GetExpenses();
    }

    public void AddExpense(Expense expense)
    {
        LazyInitialization();
        _superSystem.AddExpense(expense);
    }

    public void EditExpense(Expense expense)
    {
        LazyInitialization();
        _superSystem.EditExpense(expense);
    }

    public void ExportCSV(string filename)
    {
        LazyInitialization();
        _superSystem.ExportCSV(filename);
    }

    private void LazyInitialization()
    {
        if (_superSystem == null)
        {
            _superSystem = new SuperExpenseTrackingSystem();
        }
    }
}