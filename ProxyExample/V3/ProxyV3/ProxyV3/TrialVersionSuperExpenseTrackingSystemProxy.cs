namespace ProxyV3;

public class TrialVersionSuperExpenseTrackingSystemProxy : VirtualSuperExpenseTrackingSystemProxy
{
    public override void ExportCSV(string filename)
    {
        throw new NotSupportedException("CSV exporting is not supported in the trial version.");
    }
}