using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentServiceExercice;

namespace StudentServiceTest
{
    [TestClass]
    public class StudentServiceTest
    {
        [TestMethod]
        public void Should_AddStudent_WhenExist()
        {
            StudentFactory studentFactory = new StudentFactory();
            Student student = studentFactory.CreateStudent("student@student.com", Guid.Empty, Package.Standard);


            var studentRepositoryStub = new Mock<IStudentRepository>();
            var universityRepositoryStub = new Mock<IUniversityRepository>();
            var universityStub = new Mock<University>();

            universityStub.SetupProperty(u => u.Package, Package.Standard);
            studentRepositoryStub.Setup(repo => repo.Exists("student@student.com")).Returns(false);
            studentRepositoryStub.Setup(repo => repo.Add(student));

            universityRepositoryStub.Setup(repo => repo.GetById(Guid.Empty)).Returns(universityStub.Object);

            StudentService studentService = new StudentService(studentRepositoryStub.Object, universityRepositoryStub.Object, studentFactory);

            bool expected = studentService.Add("student@student.com", Guid.Empty);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void Should_AllowanceIs10_IfStandardStudent()
        {
            Student student = new StandardStudent("student@student.com", Guid.Empty);
            Assert.AreEqual(student.MonthlyEbookAllowance, 10);
        }

        [TestMethod]
        public void Should_AllowanceIs20_IfPremiumStudent()
        {
            Student student = new PremiumStudent("student@student.com", Guid.Empty);
            Assert.AreEqual(student.MonthlyEbookAllowance, 20);
        }

        [TestMethod]
        public void Should_AllowanceIs0_IfUnlimitedStudent()
        {
            Student student = new UnlimitedStudent("student@student.com", Guid.Empty);
            Assert.AreEqual(student.MonthlyEbookAllowance, 0);
        }

        [TestMethod]
        public void Should_AllowanceIs15_IfStandardStudent_WhenAddBonus()
        {
            LimitedStudent student = new StandardStudent("student@student.com", Guid.Empty);
            student.AddBonusAllowance();
            Assert.AreEqual(student.MonthlyEbookAllowance, 15);
        }

        [TestMethod]
        public void Should_AllowanceIs30_IfPremiumStudent_WhenAddBonus()
        {
            LimitedStudent student = new PremiumStudent("student@student.com", Guid.Empty);
            student.AddBonusAllowance();
            Assert.AreEqual(student.MonthlyEbookAllowance, 30);
        }
    }
}
