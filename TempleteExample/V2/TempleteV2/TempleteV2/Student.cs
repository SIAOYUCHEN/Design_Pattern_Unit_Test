namespace TempleteV2;

public class Student
{
    public string Name { get; private set; }
    public int Experience { get; private set; }
    public string Language { get; private set; }
    public string JobTitle { get; private set; }
    public bool[] AvailableTimeSlots { get; private set; }

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
        return string.Join(" ", AvailableTimeSlots
            .Select((slot, index) => new { slot, index })
            .Where(x => x.slot)
            .Select(x => (x.index + 9).ToString()));
    }
}