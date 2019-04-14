using System;

namespace StudentServiceExercice
{
    public interface IStudentFactory
    {
        Student CreateStudent(string emailAddress, Guid universityId, Package universityPackage);
    }
}