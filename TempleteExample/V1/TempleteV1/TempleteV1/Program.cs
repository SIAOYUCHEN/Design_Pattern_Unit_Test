// See https://aka.ms/new-console-template for more information

using TempleteV1;

class Program
{
    public static void Main(string[] args)
    {
        LanguageBasedGroupingStrategy groupingStrategy = new LanguageBasedGroupingStrategy();

        List<Student> students = ReadStudents.FromFile("student.data");
        List<Group> groups = groupingStrategy.Group(students);

        PrintGroups(groups);
    }
    
    private static void PrintGroups(List<Group> groups)
    {
        // 打印每個組的詳細信息
        // 假設 Group 類有一個合適的 ToString 方法或其他方式來表示其信息
        foreach (Group group in groups)
        {
            Console.WriteLine(group.ToString());
        }
    }
}