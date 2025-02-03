namespace StudentGradeManager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public interface IStudent
{
    public string Name { get; set; }
    public int ID { get; set; }
    public Dictionary<string, Grade> Grades { get; }
    public void AddGrade(string course, string credit, string score);
    public void AddGrades(List<(string course, int credit, int score)> grades);
    public void RemoveGrade(string course);
    public void RemoveGrades(List<string> courses);
    public int GetTotalCredit();
    public double GetTotalGradePoint();
    public double GetGPA();
    public string ToString();
}

public class Student : IStudent
{
    // 请仅在此处实现接口，不要在此处以外的地方进行任何修改
    // 请尽可能周全地考虑鲁棒性
    // 提交作业时请删除这 3 行注释
    public string Name { get; set; }
    public int ID { get; set; }
    public Student(string name, string id)
    {
        Name = name;
        ID = int.Parse(id);
    }
    public Dictionary<string, Grade> Grades { get; } = new();
    public void AddGrade(string course, string credit, string score)
    {
        Grades.Add(course, new Grade(int.Parse(credit), int.Parse(score)));
    }
    public void AddGrades(List<(string course, int credit, int score)> grades)
    {
        foreach (var grade in grades)
        {
            Grades.Add(grade.course, new Grade(grade.credit, grade.score));
        }
    }
    public void RemoveGrade(string course)
    {
        Grades.Remove(course);
    }
    public void RemoveGrades(List<string> courses)
    {
        foreach (var course in courses)
        {
            Grades.Remove(course);
        }
    }
    public int GetTotalCredit()
    {
        int totalcredit = 0;
        foreach (var grade in Grades)
        {
            totalcredit += grade.Value.Credit;
        }
        return totalcredit;
    }
    public double GetTotalGradePoint()
    {
        double totalgradepoint = 0;
        foreach (var grade in Grades)
        {
            totalgradepoint += grade.Value.GradePoint * grade.Value.Credit;
        }
        return totalgradepoint;
    }
    public double GetGPA()
    {
        return GetTotalGradePoint() / GetTotalCredit();
    }
    public string ToString()
    {
        var result = $"Name: {Name}";
        result += $"\nID: {ID}";
        result += $"\nGPA: {this.GetGPA()}";
        return result;
    }
}
