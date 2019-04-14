using System;

namespace StudentServiceExercice
{
    public class StandardStudent : LimitedStudent
    {
        public StandardStudent(string emailAddress, Guid universityId) : base(emailAddress, universityId)
        {
            MonthlyEbookAllowance = Student.ALLOWANCE;
        }

        public override void AddBonusAllowance()
        {
            base.MonthlyEbookAllowance += 5;
        }
    }
}