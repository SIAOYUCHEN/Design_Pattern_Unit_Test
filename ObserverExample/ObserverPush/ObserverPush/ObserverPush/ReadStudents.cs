namespace ObserverV1;

public class ReadStudents
{
    public static List<Student> FromFile(string fileName)
    {
        return File.ReadAllLines(fileName)
            .Select(DataLineToStudent)
            .ToList();
    }

    // 示例行：Cortez 1y Go 軟體工程師 [9 10 11 12 14 15 16 19]
    private static Student DataLineToStudent(string line)
    {
        string[] s = line.Split('[');
        string[] left = s[0].Trim().Split(' ');
        string name = left[0];
        int experience = int.Parse(left[1].Substring(0, left[1].Length - 1));
        string language = left[2];
        string title = left[3];
        List<int> slots = s[1].Split(new char[] { ' ', ']' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        bool[] availableTimeSlots = new bool[13];
        
        foreach (int slot in slots)
        {
            availableTimeSlots[slot - 9] = true;
        }
        
        return new Student(name, experience, language, title, availableTimeSlots);
    }
}