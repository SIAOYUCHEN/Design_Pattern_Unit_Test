
using ProxyV1;

class Program
{
    static void Main(string[] args)
    {
        ExpenseTrackingCli cli = new ExpenseTrackingCli(new VirtualSuperExpenseTrackingSystemProxy());
        cli.Start();
    }
}