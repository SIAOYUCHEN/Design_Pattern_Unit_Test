namespace ObserverV1;

public class StudentLanguageBarChart
{
    private readonly StudentDataFile dataFile;

    public StudentLanguageBarChart(StudentDataFile dataFile)
    {
        this.dataFile = dataFile;
    }

    public void RenderBarChart()
    {
        BarChart barChart = new BarChart(); // 假定 BarChart 是一个已经实现的类
        IEnumerable<Student> students = dataFile.GetStudents();
        List<string> x = students.Select(student => student.Language).Distinct().ToList();
        List<int> y = x.Select(language => students.Count(student => student.Language == language)).ToList();
        barChart.Export("students.bar.png", x, y);
    }
}