namespace TempleteV3;

public class Group
{
    private static int count = 0;
    public int Number { get; private set; }
    private List<Student> students;

    public Group() : this(new List<Student>())
    {
    }

    public Group(List<Student> students)
    {
        Number = ++count;
        this.students = new List<Student>(students);
    }

    public Student Get(int index)
    {
        return students[index];
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public List<Group> SplitBySize(int groupSize)
    {
        List<Group> groups = new List<Group>();
        for (int i = 0; i < students.Count; i += groupSize)
        {
            groups.Add(new Group(students.GetRange(i, Math.Min(groupSize, students.Count - i))));
        }
        return groups;
    }

    public void Merge(Group group)
    {
        students.AddRange(group.students);
    }

    public List<Student> Students => students;

    public int Size => students.Count;
    
    public override string ToString()
    {
        var studentDescriptions = students.Select(student => student.ToString()).ToList();
        string studentsString = string.Join(", ", studentDescriptions);
        return $"Group Number: {Number}, Students: {studentsString}";
    }
}