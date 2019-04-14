using System;

namespace StudentServiceExercice
{
    public interface IUniversityRepository
    {
        University GetById(Guid universityId);
    }
}