namespace StudentServiceExercice
{
    public interface IStudentRepository
    {
        bool Exists(string emailAddress);
        void Add(Student student);
    }
}