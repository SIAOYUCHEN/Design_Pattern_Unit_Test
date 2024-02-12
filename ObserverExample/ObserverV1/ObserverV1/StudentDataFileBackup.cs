using System.Text;

namespace ObserverV1;

public class StudentDataFileBackup
{
    private readonly StudentDataFile dataFile;

    public StudentDataFileBackup(StudentDataFile dataFile)
    {
        this.dataFile = dataFile;
    }

    public void Backup()
    {
        string fileName = DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".backup.data";
        string studentData = string.Join(Environment.NewLine, dataFile.GetStudents().Select(student => student.ToString()));
        
        File.WriteAllText(fileName, studentData, Encoding.UTF8);
    }
}