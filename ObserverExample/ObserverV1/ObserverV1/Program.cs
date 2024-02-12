
using ObserverV1;

public class Program
{
    public static void Main(string[] args)
    {
        StudentDataFile studentDataFile = new StudentDataFile("student.data");
        studentDataFile.StartMonitoring();
        
        Console.WriteLine("Monitoring started. Press any key to exit...");
        Console.ReadKey();
        
        studentDataFile.StopMonitoring();
    }
}