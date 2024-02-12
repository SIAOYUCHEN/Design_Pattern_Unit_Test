
using ObserverPull;

class Program
{
    static void Main(string[] args)
    {
        StudentDataFile studentDataFile = new StudentDataFile("student.data");
        StudentLanguageBarChart barChart = new StudentLanguageBarChart(studentDataFile);
        StudentJobTitlePieChart pieChart = new StudentJobTitlePieChart(studentDataFile);
        StudentDataFileBackup dataFileBackup = new StudentDataFileBackup(studentDataFile);

        studentDataFile.Register(barChart);
        studentDataFile.Register(pieChart);
        studentDataFile.Register(dataFileBackup);

        studentDataFile.StartMonitoring();

        Console.WriteLine("Monitoring started. Press any key to stop...");
        Console.ReadKey();

        studentDataFile.StopMonitoring();
        Console.WriteLine("Monitoring stopped.");
    }
}