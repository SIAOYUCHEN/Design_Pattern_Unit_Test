namespace TempleteV3;

public class JobTitleBasedGroupingStrategy : CutBasedGroupingStrategy
{
    public JobTitleBasedGroupingStrategy(int groupMinSize) : base(groupMinSize)
    {
    }

    protected override object CutGroupBy(Student student)
    {
        // 根据学生的职称进行分组
        return student.JobTitle;
    }

    protected override bool MeetMergeCriteria(Group nonFullGroup, Group fullGroup)
    {
        // 只有当两个组的第一个学生的职称相同时，才会合并这两个组
        return nonFullGroup.Get(0).JobTitle == fullGroup.Get(0).JobTitle;
    }
}