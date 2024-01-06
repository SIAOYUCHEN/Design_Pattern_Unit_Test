namespace TempleteV2;

public interface IGroupingStrategy
{
    List<Group> Group(List<Student> students);
}