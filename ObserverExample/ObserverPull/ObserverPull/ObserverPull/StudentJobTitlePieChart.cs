using ObserverV1;

namespace ObserverPull;

public class StudentJobTitlePieChart : IStudentDataObserver
{
    private readonly StudentDataFile dataFile;

    public StudentJobTitlePieChart(StudentDataFile dataFile)
    {
        this.dataFile = dataFile;
    }

    public void Update()
    {
        try
        {
            PieChart pieChart = new PieChart();
            IEnumerable<Student> students = dataFile.GetStudents();
            List<string> jobTitles = students.Select(student => student.JobTitle).Distinct().ToList();
            List<int> counts = jobTitles.Select(jobTitle => students.Count(student => student.JobTitle == jobTitle)).ToList();
            pieChart.Export("students.jobtitle.pie.png", jobTitles, counts);
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine(ex.Message);
            throw;
        }
    }
}