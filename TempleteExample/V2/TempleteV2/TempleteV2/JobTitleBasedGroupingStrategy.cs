namespace TempleteV2;

public class JobTitleBasedGroupingStrategy : CutBasedGroupingStrategy
{
    protected override object CutBy(Student student)
    {
        return student.JobTitle;
    }

    protected override bool MeetMergeCriteria(Group nonFullGroup, Group fullGroup)
    {
        return nonFullGroup.Get(0).JobTitle == fullGroup.Get(0).JobTitle;
    }
}
