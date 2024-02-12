using ObserverPull;
using ObserverV1;

namespace ObserverPush;

public class StudentDataFile
{
    private bool monitoring;
    private readonly string studentDataFileName;
    private HashSet<Student> students = new HashSet<Student>();
    private readonly List<IStudentDataObserver> observers = new List<IStudentDataObserver>();

    public StudentDataFile(string studentDataFileName)
    {
        this.studentDataFileName = studentDataFileName;
    }

    public void StartMonitoring()
    {
        monitoring = true;
        new Thread(Monitoring).Start();
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

    public void Register(IStudentDataObserver observer)
    {
        observers.Add(observer);
    }

    public void Unregister(IStudentDataObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(students);
        }
    }

    private void WatchStudentData()
    {
        var newStudentsList = ReadStudents.FromFile(studentDataFileName);
        
        var newStudentsSet = new HashSet<Student>(newStudentsList);

        if (!students.SetEquals(newStudentsSet))
        {
            students = newStudentsSet;
            NotifyObservers();
        }
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