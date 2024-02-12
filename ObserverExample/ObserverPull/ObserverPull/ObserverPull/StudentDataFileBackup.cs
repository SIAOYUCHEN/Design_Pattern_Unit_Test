namespace ObserverPull;

public class StudentDataFileBackup : IStudentDataObserver
{
    private readonly StudentDataFile dataFile;

    public StudentDataFileBackup(StudentDataFile dataFile)
    {
        this.dataFile = dataFile;
    }

    public void Update()
    {
        try
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".backup.data";
            string studentData = string.Join(Environment.NewLine, dataFile.GetStudents().Select(student => student.ToString()));
            
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), fileName), studentData);
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine(ex.Message);
            throw;
        }
    }
}