namespace TempleteV2;

public abstract class CutBasedGroupingStrategy : IGroupingStrategy
{
    private static readonly int GroupMinSize = 6;

    public List<Group> Group(List<Student> students)
    {
        var firstCut = new Dictionary<object, Group>();
        foreach (var student in students)
        {
            var key = CutBy(student);
            if (!firstCut.ContainsKey(key))
            {
                firstCut[key] = new Group();
            }
            firstCut[key].AddStudent(student);
        }
        var firstCutGroups = new List<Group>(firstCut.Values);
        
        var secondCutGroups = new List<Group>();
        foreach (var group in firstCutGroups)
        {
            secondCutGroups.AddRange(group.SplitBySize(GroupMinSize));
        }
        
        var nonFullGroups = secondCutGroups.Where(g => g.Size < GroupMinSize).ToList();
        var fullGroups = secondCutGroups.Where(g => g.Size >= GroupMinSize).ToList();

        foreach (var nonFullGroup in nonFullGroups)
        {
            var fullGroupToMerge = fullGroups.FirstOrDefault(fg => MeetMergeCriteria(nonFullGroup, fg));
            if (fullGroupToMerge != null)
            {
                Console.WriteLine($"Merge group ({nonFullGroup.Number}) to ({fullGroupToMerge.Number}).");
                fullGroupToMerge.Merge(nonFullGroup);
                fullGroups.Add(fullGroupToMerge);
            }
        }
        
        return fullGroups.Where(g => g.Size >= GroupMinSize).ToList();
    }

    protected virtual bool MeetMergeCriteria(Group nonFullGroup, Group fullGroup)
    {
        return true;
    }

    protected abstract object CutBy(Student student);
}