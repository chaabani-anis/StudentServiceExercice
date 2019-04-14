using System;

namespace StudentServiceExercice
{
    public abstract class LimitedStudent : Student
    {
        public LimitedStudent(string emailAddress, Guid universityId) : base(emailAddress, universityId)
        {
        }

        public abstract void AddBonusAllowance();

    }
}