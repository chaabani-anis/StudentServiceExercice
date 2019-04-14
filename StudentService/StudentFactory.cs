using System;

namespace StudentServiceExercice
{
    public class StudentFactory : IStudentFactory
    {
        public Student CreateStudent(string emailAddress, Guid universityId, Package universityPackage) 
        {
            switch (universityPackage)
            {
                case Package.Standard:
                    return new StandardStudent(emailAddress, universityId);
                case Package.Premium:
                    return  new PremiumStudent(emailAddress, universityId);
                case Package.Unlimited:
                    return new UnlimitedStudent(emailAddress, universityId);
                default: throw new NotImplementedException();
            }
        }
    }
}