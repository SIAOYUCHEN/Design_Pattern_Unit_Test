
using ProxyV1;
using ProxyV3;

class Program
{
    static void Main(string[] args)
    {
        ExpenseTrackingCli cli = new ExpenseTrackingCli(new TrialVersionSuperExpenseTrackingSystemProxy());
        cli.Start();
    }
}