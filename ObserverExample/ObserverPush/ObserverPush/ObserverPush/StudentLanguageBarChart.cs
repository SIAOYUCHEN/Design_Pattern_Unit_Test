using ObserverPush;
using ObserverV1;

namespace ObserverPull;

public class StudentLanguageBarChart : IStudentDataObserver
{
    public void Update(IEnumerable<Student> students)
    {
        try
        {
            BarChart barChart = new BarChart();
            
            var languages = students.Select(student => student.Language).Distinct().ToList();
            var counts = languages.Select(language => students.Count(student => student.Language == language)).ToList();
            
            barChart.Export("students.language.bar.png", languages, counts);
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine(ex.Message);
            throw;
        }
    }
}