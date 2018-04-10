using System.Collections.Generic;
using BashSoft.Contracts;
using BashSoft.Exceptions;

public class SoftUniCourse : ICourse
{
    private string name;
    private Dictionary<string, IStudent> studentsByName;

    public const int NumberOfTasksOnExam = 5;
    public const int MaxScoreOnExamTask = 100;

    public SoftUniCourse(string name)
    {
        this.Name = name;
        this.studentsByName = new Dictionary<string, IStudent>();
    }

    public string Name
    {
        get
        {
            return this.name;

        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidStringException();
            }

            this.name = value;
        }
    }

    public IReadOnlyDictionary<string, IStudent> StudentsByName
    {
        get { return this.studentsByName; }
    }

    public void EnrollStudent(IStudent softUniStudent)
    {
        if (this.StudentsByName.ContainsKey(softUniStudent.UserName))
        {
            throw new DuplicateEntryInStructureException(softUniStudent.UserName, this.Name);

        }
        this.studentsByName.Add(softUniStudent.UserName, softUniStudent);
    }

    public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);

    public override string ToString()
    {
        return this.Name;
    }
}

