using System;
using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface IStudent : IComparable<IStudent>
    {
        string UserName { get; }

        Dictionary<string, ICourse> EnrolledCourses { get; }

        Dictionary<string, double> MarksByCourseName { get; }

        void EnrollInCourse(ICourse softUniCourse);

        void SetMarksInCourse(string courseName, params int[] scores);
    }
}
