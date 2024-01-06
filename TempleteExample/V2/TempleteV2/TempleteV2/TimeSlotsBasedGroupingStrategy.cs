namespace TempleteV2;

public class TimeSlotsBasedGroupingStrategy : IGroupingStrategy
{
    public static readonly int GroupMinSize = 6;

    public List<Group> Group(List<Student> students)
    {
        List<Group> firstCut = CutGroupByTimeSlots(students);
        
        List<Group> secondCut = CutGroupByMinSize(firstCut);

        return BalanceGroupSizes(secondCut);
    }

    private List<Group> CutGroupByTimeSlots(List<Student> students)
    {
        var firstCut = new Dictionary<string, Group>();
        foreach (var student in students)
        {
            var timeSlotsHash = HashMemberTimeSlots(student);
            if (!firstCut.ContainsKey(timeSlotsHash))
            {
                firstCut[timeSlotsHash] = new Group();
            }
            firstCut[timeSlotsHash].AddStudent(student);
        }
        return new List<Group>(firstCut.Values);
    }

    private List<Group> CutGroupByMinSize(List<Group> firstCutGroups)
    {
        var secondCutGroups = new List<Group>();
        foreach (var group in firstCutGroups)
        {
            secondCutGroups.AddRange(group.SplitBySize(GroupMinSize));
        }
        return secondCutGroups;
    }

    private List<Group> BalanceGroupSizes(List<Group> secondCutGroups)
    {
        var nonFullGroups = secondCutGroups.Where(g => g.Size < GroupMinSize).ToList();
        var fullGroups = secondCutGroups.Where(g => g.Size >= GroupMinSize).ToList();

        foreach (var nonFullGroup in nonFullGroups)
        {
            var fullGroup = fullGroups.FirstOrDefault();
            if (fullGroup != null)
            {
                Console.WriteLine($"Merge group ({nonFullGroup.Number}) to ({fullGroup.Number}).");
                fullGroup.Merge(nonFullGroup);

                fullGroups = secondCutGroups.Where(g => g.Size >= GroupMinSize).ToList();
            }
        }
        return fullGroups;
    }

    private string HashMemberTimeSlots(Student student)
    {
        var s = student.AvailableTimeSlots;
        return $"{ConvertBooleanToNumber(s[0] && s[1] && s[2] && s[3])}" +
               $"{ConvertBooleanToNumber(s[4] && s[5] && s[6] && s[7])}" +
               $"{ConvertBooleanToNumber(s[8] && s[9] && s[10])}" +
               $"{ConvertBooleanToNumber(s[11] && s[12])}";
    }

    private int ConvertBooleanToNumber(bool b)
    {
        return b ? 1 : 0;
    }
}