using System;

namespace StudentServiceExercice
{
    public class PremiumStudent : LimitedStudent
    {
        public PremiumStudent(string emailAddress, Guid universityId) : base(emailAddress, universityId)
        {
            MonthlyEbookAllowance = Student.ALLOWANCE * 2;
        }

        public override void AddBonusAllowance()
        {
            base.MonthlyEbookAllowance += 10;
        }
    }
}