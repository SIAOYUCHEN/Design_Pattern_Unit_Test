
using ObserverPull;
using ObserverPush;

class Program
{
    static void Main(string[] args)
    {
        StudentDataFile studentDataFile = new StudentDataFile("student.data");
        StudentLanguageBarChart barChart = new StudentLanguageBarChart();
        StudentJobTitlePieChart pieChart = new StudentJobTitlePieChart();
        StudentDataFileBackup dataFileBackup = new StudentDataFileBackup();

        studentDataFile.Register(barChart);
        studentDataFile.Register(pieChart);
        studentDataFile.Register(dataFileBackup);

        studentDataFile.StartMonitoring();

        Console.WriteLine("Monitoring started. Press any key to exit...");

        Console.ReadKey();

        studentDataFile.StopMonitoring();

        Console.WriteLine("Monitoring stopped. Exiting application.");
    }
}