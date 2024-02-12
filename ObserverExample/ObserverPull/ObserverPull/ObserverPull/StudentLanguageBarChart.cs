using ObserverV1;

namespace ObserverPull;

public class StudentLanguageBarChart : IStudentDataObserver
{
    private readonly StudentDataFile dataFile;

    public StudentLanguageBarChart(StudentDataFile dataFile)
    {
        this.dataFile = dataFile;
    }

    public void Update()
    {
        try
        {
            BarChart barChart = new BarChart();
            IEnumerable<Student> students = dataFile.GetStudents();
            List<string> x = students.Select(student => student.Language).Distinct().ToList();
            List<int> y = x.Select(language => students.Count(student => student.Language == language)).ToList();
            barChart.Export("students.bar.png", x, y);
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine(ex.Message);
            throw;
        }
    }
}