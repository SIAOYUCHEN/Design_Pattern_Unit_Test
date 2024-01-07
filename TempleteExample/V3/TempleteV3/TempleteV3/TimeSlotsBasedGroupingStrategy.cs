namespace TempleteV3;

public class TimeSlotsBasedGroupingStrategy : CutBasedGroupingStrategy
{
    public TimeSlotsBasedGroupingStrategy() : base(6) // 使用基類構造函數設定最小組大小為 6
    {
    }

    protected override object CutGroupBy(Student student)
    {
        // 根據學生的可用時間段進行分組
        return HashMemberTimeSlots(student);
    }

    private string HashMemberTimeSlots(Student student)
    {
        // 將學生的可用時間段轉換為哈希值
        var s = student.AvailableTimeSlots;
        return $"{ConvertBooleanToNumber(s[0] && s[1] && s[2] && s[3])}" +
               $"{ConvertBooleanToNumber(s[4] && s[5] && s[6] && s[7])}" +
               $"{ConvertBooleanToNumber(s[8] && s[9] && s[10])}" +
               $"{ConvertBooleanToNumber(s[11] && s[12])}";
    }

    private int ConvertBooleanToNumber(bool b)
    {
        // 將布爾值轉換為數字
        return b ? 1 : 0;
    }
}