namespace TempleteV2;

public class LanguageBasedGroupingStrategy : IGroupingStrategy
{
    public static readonly int GroupMinSize = 6;

    public List<Group> Group(List<Student> students)
    {
        // 先用「Language」將成員分組
        List<Group> firstCut = CutGroupByLanguage(students);

        // 再到各組中以最低成員數 6 員分組
        List<Group> secondCut = CutGroupByMinSize(firstCut);

        // 平衡各組大小：將不足 6 員的組別併到組
        return BalanceGroupSizes(secondCut);
    }

    private List<Group> CutGroupByLanguage(List<Student> students)
    {
        Dictionary<string, Group> firstCut = new Dictionary<string, Group>();
        foreach (var student in students)
        {
            if (!firstCut.ContainsKey(student.Language))
            {
                firstCut.Add(student.Language, new Group());
            }
            firstCut[student.Language].AddStudent(student);
        }
        return firstCut.Values.ToList();
    }

    private List<Group> CutGroupByMinSize(List<Group> firstCutGroups)
    {
        List<Group> secondCutGroups = new List<Group>();
        foreach (var group in firstCutGroups)
        {
            secondCutGroups.AddRange(group.SplitBySize(GroupMinSize));
        }
        return secondCutGroups;
    }

    private List<Group> BalanceGroupSizes(List<Group> secondCut)
    {
        List<Group> nonFullGroups = secondCut.Where(g => g.Size < GroupMinSize).ToList();
        List<Group> fullGroups = secondCut.Where(g => g.Size >= GroupMinSize).ToList();

        foreach (var nonFullGroup in nonFullGroups)
        {
            var fullGroupToMerge = fullGroups.FirstOrDefault(fullGroup => MeetMergeCriteria(nonFullGroup, fullGroup));
            if (fullGroupToMerge != null)
            {
                Console.WriteLine($"Merge group ({nonFullGroup.Number}) to ({fullGroupToMerge.Number}).");
                fullGroupToMerge.Merge(nonFullGroup);
                fullGroups.Add(fullGroupToMerge); // Re-add the merged group in case it can accept more members.
            }
        }
        return fullGroups.Where(g => g.Size >= GroupMinSize).ToList(); // Return only the groups that are full.
    }

    private bool MeetMergeCriteria(Group nonFullGroup, Group fullGroup)
    {
        return fullGroup.Students.FirstOrDefault()?.Language == nonFullGroup.Students.FirstOrDefault()?.Language;
    }
}