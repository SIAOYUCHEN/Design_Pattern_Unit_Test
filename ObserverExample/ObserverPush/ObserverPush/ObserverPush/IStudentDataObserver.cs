using ObserverV1;

namespace ObserverPull;

public interface IStudentDataObserver
{
    void Update(IEnumerable<Student> students);
}