namespace ObserverV1;

public class StudentJobTitlePieChart
{
    private readonly StudentDataFile dataFile;

    public StudentJobTitlePieChart(StudentDataFile dataFile)
    {
        this.dataFile = dataFile;
    }

    public void RenderPieChart()
    {
        IEnumerable<Student> students = dataFile.GetStudents();
        var series = students.Select(student => student.JobTitle).Distinct().ToList();
        var numbers = series.Select(jobTitle => students.Count(student => student.JobTitle == jobTitle)).ToList();

        PieChart pieChart = new PieChart(); // 假定 PieChart 是一个可用的类
        pieChart.Export("students.pie.png", series, numbers);
    }
}