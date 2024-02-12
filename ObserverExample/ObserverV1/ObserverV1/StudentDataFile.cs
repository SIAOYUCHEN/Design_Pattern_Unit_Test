namespace ObserverV1;

public class StudentDataFile
{
    private volatile bool monitoring; // volatile 确保多线程中的可见性
    private readonly string studentDataFileName;
    private HashSet<Student> students = new HashSet<Student>();
    
    private readonly StudentJobTitlePieChart jobTitlePieChart;
    private readonly StudentLanguageBarChart languageBarChart;
    private readonly StudentDataFileBackup dataFileBackup;

    public StudentDataFile(string studentDataFileName)
    {
        this.studentDataFileName = studentDataFileName;
        this.jobTitlePieChart = new StudentJobTitlePieChart(this);
        this.languageBarChart = new StudentLanguageBarChart(this);
        this.dataFileBackup = new StudentDataFileBackup(this);
    }

    public void StartMonitoring()
    {
        monitoring = true;
        Task.Run(() => Monitoring());
    }

    private void Monitoring()
    {
        while (monitoring)
        {
            Thread.Sleep(1000);
            try
            {
                WatchStudentData();
            }
            catch (IOException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }

    private void WatchStudentData()
    {
        HashSet<Student> newStudents = new HashSet<Student>(ReadStudents.FromFile(studentDataFileName));
        if (!this.students.SetEquals(newStudents))
        {
            this.students = newStudents;
            NotifyCharts().Wait();
        }
    }

    private async Task NotifyCharts()
    {
        languageBarChart.RenderBarChart();
        jobTitlePieChart.RenderPieChart();
        dataFileBackup.Backup();
    }

    public IEnumerable<Student> GetStudents()
    {
        return students;
    }

    public void StopMonitoring()
    {
        monitoring = false;
    }
}