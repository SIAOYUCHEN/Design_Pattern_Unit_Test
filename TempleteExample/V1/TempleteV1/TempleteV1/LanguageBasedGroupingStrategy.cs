namespace TempleteV1;

public class LanguageBasedGroupingStrategy
{
    public static readonly int GroupMinSize = 6;

    public List<Group> Group(List<Student> students)
    {
        // 第一刀：程式語言專長
        Dictionary<string, Group> firstCut = new Dictionary<string, Group>();
        foreach (Student student in students)
        {
            if (!firstCut.ContainsKey(student.Language))
            {
                firstCut.Add(student.Language, new Group());
            }
            firstCut[student.Language].AddStudent(student);
        }
        List<Group> firstCutGroups = new List<Group>(firstCut.Values);

        // 第二刀：人數 (6人一組)
        List<Group> secondCutGroups = new List<Group>();
        foreach (Group group in firstCutGroups)
        {
            secondCutGroups.AddRange(group.SplitBySize(GroupMinSize));
        }

        // 將不足 6 員的組別併到人滿的組別
        List<Group> nonFullGroups = secondCutGroups.Where(g => g.Size < GroupMinSize).ToList();
        List<Group> fullGroups = secondCutGroups.Where(g => g.Size >= GroupMinSize).ToList();

        foreach (Group nonFullGroup in nonFullGroups)
        {
            foreach (Group fullGroup in fullGroups)
            {
                // 如果兩個組別使用的程式語言一樣，才併組
                if (fullGroup.Get(0).Language.Equals(nonFullGroup.Get(0).Language))
                {
                    Console.WriteLine($"Merge group ({nonFullGroup.Number}) to ({fullGroup.Number}).");
                    fullGroup.Merge(nonFullGroup);
                    break;
                }
            }
        }

        return fullGroups;
    }
}