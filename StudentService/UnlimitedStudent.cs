using System;

namespace StudentServiceExercice
{
    public class UnlimitedStudent : Student
    {
        public UnlimitedStudent(string emailAddress, Guid universityId) : base(emailAddress, universityId)
        {
            MonthlyEbookAllowance = 0;
        }
    }
}