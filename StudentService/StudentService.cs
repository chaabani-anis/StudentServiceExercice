using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServiceExercice
{
	public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IStudentFactory _studentFactory;

        public StudentService(IStudentRepository studentRepository, IUniversityRepository universityRepository, IStudentFactory studentFactory)
        {
            _studentRepository = studentRepository;
            _universityRepository = universityRepository;
            _studentFactory = studentFactory;
        }

        public bool Add(string emailAddress, Guid universityId)
		{
			Console.WriteLine(string.Format("Log: Start add student with email '{0}'", emailAddress));

			if (string.IsNullOrWhiteSpace(emailAddress))
			{
				return false;
			}

			if (_studentRepository.Exists(emailAddress))
			{
				return false;
			}

			var university = _universityRepository.GetById(universityId);

			Student student = null;
            student = _studentFactory.CreateStudent(emailAddress, universityId, university.Package);
            _studentRepository.Add(student);

			Console.WriteLine(string.Format("Log: End add student with email '{0}'", emailAddress));

			return true;
		}

        public IEnumerable<Student> GetStudentsByUniversity()
		{
			//...
			throw new NotImplementedException();
		}

		public IEnumerable<Student> GetStudentsByCurrentlyBorrowedEbooks()
		{
			//...
			throw new NotImplementedException();
		}
	}
}
