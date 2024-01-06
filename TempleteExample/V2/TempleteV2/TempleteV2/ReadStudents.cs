namespace TempleteV2;

public class ReadStudents
{
    public static List<Student> FromFile(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        return lines.Select(DataLineToStudent).ToList();
    }
    
    private static Student DataLineToStudent(string line)
    {
        string[] parts = line.Split('[');
        string[] left = parts[0].Trim().Split(' ');
        string name = left[0];
        int experience = int.Parse(left[1].Substring(0, left[1].Length - 1));
        string language = left[2];
        string title = left[3];
        string[] timeSlotsString = parts[1].Trim(new char[] { ' ', ']' }).Split(' ');
        List<int> slots = timeSlotsString.Select(int.Parse).ToList();
        bool[] availableTimeSlots = new bool[13];
        foreach (int slot in slots)
        {
            availableTimeSlots[slot - 9] = true;
        }
        return new Student(name, experience, language, title, availableTimeSlots);
    }
}