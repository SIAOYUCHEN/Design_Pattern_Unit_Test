namespace ObserverV1;

public class Student
{
    public string Name { get; }
    public int Experience { get; }
    public string Language { get; }
    public string JobTitle { get; }
    public bool[] AvailableTimeSlots { get; }

    public Student(string name, int experience, string language, string jobTitle, bool[] availableTimeSlots)
    {
        Name = name;
        Experience = experience;
        Language = language;
        JobTitle = jobTitle;
        AvailableTimeSlots = availableTimeSlots;
    }

    public override string ToString()
    {
        return $"{Name} {Experience}y {Language} {JobTitle} [{AvailableTimeSlotsToString()}]";
    }

    private string AvailableTimeSlotsToString()
    {
        return Enumerable.Range(0, AvailableTimeSlots.Length)
                         .Where(i => AvailableTimeSlots[i])
                         .Select(i => (i + 9).ToString())
                         .Aggregate((current, next) => $"{current} {next}");
    }

    
    public override bool Equals(object obj)
    {
        return obj is Student student &&
               Experience == student.Experience &&
               Name == student.Name &&
               Language == student.Language &&
               JobTitle == student.JobTitle &&
               AvailableTimeSlots.SequenceEqual(student.AvailableTimeSlots);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + Experience.GetHashCode();
            hash = hash * 23 + Language.GetHashCode();
            hash = hash * 23 + JobTitle.GetHashCode();
            hash = hash * 23 + AvailableTimeSlots.GetHashCode();
            return hash;
        }
    }
}