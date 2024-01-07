namespace TempleteV3;

public abstract class CutBasedGroupingStrategy : IGroupingStrategy
{
    protected readonly int GroupMinSize;

    protected CutBasedGroupingStrategy(int groupMinSize)
    {
        GroupMinSize = groupMinSize;
    }

    public List<Group> Group(List<Student> students)
    {
        // First cut: by a certain attribute
        List<Group> firstCut = CutGroupByKey(students);

        // Second cut: by minimum group size
        List<Group> secondCut = CutGroupByMinSize(firstCut);

        // Balance group sizes: merge groups with less than the minimum size
        return BalanceGroupSizes(secondCut);
    }

    protected List<Group> CutGroupByKey(List<Student> students)
    {
        var firstCut = new Dictionary<object, Group>();
        foreach (var student in students)
        {
            var key = CutGroupBy(student);
            if (!firstCut.ContainsKey(key))
            {
                firstCut[key] = new Group();
            }
            firstCut[key].AddStudent(student);
        }
        return firstCut.Values.ToList();
    }

    protected abstract object CutGroupBy(Student student);

    protected List<Group> CutGroupByMinSize(List<Group> firstCutGroups)
    {
        var secondCutGroups = new List<Group>();
        foreach (var group in firstCutGroups)
        {
            secondCutGroups.AddRange(group.SplitBySize(GroupMinSize));
        }
        return secondCutGroups;
    }

    protected List<Group> BalanceGroupSizes(List<Group> secondCut)
    {
        var nonFullGroups = secondCut.Where(g => g.Size < GroupMinSize).ToList();
        var fullGroups = secondCut.Where(g => g.Size >= GroupMinSize).ToList();

        foreach (var nonFullGroup in nonFullGroups)
        {
            var fullGroup = fullGroups.FirstOrDefault(fg => MeetMergeCriteria(nonFullGroup, fg));
            if (fullGroup != null)
            {
                Console.WriteLine($"Merge group ({nonFullGroup.Number}) to ({fullGroup.Number}).");
                fullGroup.Merge(nonFullGroup);
                fullGroups = secondCut.Where(g => g.Size >= GroupMinSize).ToList(); // Reevaluate after merging
            }
        }
        return fullGroups;
    }

    protected virtual bool MeetMergeCriteria(Group nonFullGroup, Group fullGroup)
    {
        return true; // Hook: Default unconditional
    }
}