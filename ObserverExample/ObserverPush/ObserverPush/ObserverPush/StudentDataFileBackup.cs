using System.Text;
using ObserverV1;

namespace ObserverPull;

public class StudentDataFileBackup : IStudentDataObserver
{
    public void Update(IEnumerable<Student> students)
    {
        string fileName = DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".backup.data";
        string studentData = String.Join(Environment.NewLine, students.Select(student => student.ToString()));

        try
        {
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), fileName), studentData, Encoding.UTF8);
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine(ex.Message);
            throw;
        }
    }
}