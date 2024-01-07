namespace TempleteV3;

public class LanguageBasedGroupingStrategy : CutBasedGroupingStrategy
{
    public LanguageBasedGroupingStrategy() : base(6) // 使用基類構造函數設定最小組大小為 6
    {
    }

    protected override object CutGroupBy(Student student)
    {
        // 根據學生的程式語言專長進行分組
        return student.Language;
    }

    protected override bool MeetMergeCriteria(Group nonFullGroup, Group fullGroup)
    {
        // 只有當兩個組中的第一位學生的程式語言專長相同時，才合併這兩個組
        return nonFullGroup.Get(0).Language == fullGroup.Get(0).Language;
    }
}