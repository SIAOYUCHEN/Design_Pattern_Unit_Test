using ObserverPush;
using ObserverV1;

namespace ObserverPull;

public class StudentJobTitlePieChart : IStudentDataObserver
{
    public void Update(IEnumerable<Student> students)
    {
        try
        {
            PieChart pieChart = new PieChart();
            
            var languages = students.Select(student => student.Language).Distinct().ToList();
            var counts = languages.Select(language => students.Count(student => student.Language == language)).ToList();
            
            // Export the pie chart with the languages and counts.
            pieChart.Export("students.jobtitle.pie.png", languages, counts);
        }
        catch (Exception ex) when (ex is IOException || ex is InvalidOperationException)
        {
            Console.Error.WriteLine(ex.Message);
            throw;
        }
    }
}