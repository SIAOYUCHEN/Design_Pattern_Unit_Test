﻿// See https://aka.ms/new-console-template for more information

using TempleteV1;

class Program
{
    public static void Main(string[] args)
    {
        LanguageBasedGroupingStrategy groupingStrategy = new LanguageBasedGroupingStrategy();

        List<Student> students = ReadStudents.FromFile("student.data");
        List<Group> groups = groupingStrategy.Group(students);

        PrintGroups(groups);
    }
    
    private static void PrintGroups(List<Group> groups)
    {
        foreach (Group group in groups)
        {
            Console.WriteLine(group.ToString());
        }
    }
}