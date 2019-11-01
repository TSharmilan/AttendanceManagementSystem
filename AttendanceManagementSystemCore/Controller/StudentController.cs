using AttendanceManagementSystemCore.DAL;
using AttendanceManagementSystemCore.Domain;
using AttendanceManagementSystemCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.Controller
{
    public class StudentController
    {
        public void SaveStudent(string school, string indexNo, string gender, string fName, string lName, int grade, 
            int division, int medium, DateTime dob, string address, string address1, string phoneNo, string email, 
            DateTime enteredDate)
        {
            Student student = new Student();
            StudentDAL studentDAL = new StudentDAL();
            {
                try
                {
                    using (var attendanceContext = new AttendanceContext())
                    {
                        student.School = school;
                        student.IndexNo = indexNo;
                        student.Gender = gender;
                        student.FName = fName;
                        student.LName = lName;
                        student.GradeID = grade;
                        student.DivisionID = division;
                        student.Medium = medium;
                        student.DOB = dob;
                        student.Address = address;
                        student.Address1 = address1;
                        student.PhoneNo = phoneNo;
                        student.Email = email;
                        student.EnteredDate = enteredDate;

                        studentDAL.SaveStudent(student, attendanceContext);
                        attendanceContext.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Student> Studentfromdivisionandgrade(int divisionId, int GradeID)
        {

            try
            {
                using (var attendanceContext = new AttendanceContext())
                {
                    StudentDAL studentDAL = new StudentDAL();
                    return studentDAL.Studentfromdivisionandgrade(divisionId, GradeID, attendanceContext);
                }

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public int GetAllStudents()
        {
            StudentDAL studentDAL = new StudentDAL();
            try
            {
                using (var attendanceContext = new AttendanceContext())
                {
                    return studentDAL.GetAllStudents(attendanceContext);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Student FindByID(string indexNo)
        {
            StudentDAL studentDAL = new StudentDAL();

            using (var attendanceContext = new AttendanceContext())
            {
                return studentDAL.FindByID(indexNo, attendanceContext);
            }
        }

        public List<Student> FethchByIndexNo(string indexNo)
        {

            try
            {
                using (var context = new AttendanceContext())
                {
                    StudentDAL studentDAL = new StudentDAL();
                    return studentDAL.FethchByIndexNo(indexNo, context);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteStudent(int studentID)
        {
            StudentDAL studentDAL = new StudentDAL();
            try
            {
                using (var attendanceContext = new AttendanceContext())
                {
                    studentDAL.DeleteStudent(new Student
                    {
                        StudentID = studentID,
                    }, attendanceContext);
                    attendanceContext.SaveChanges();

                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public List<Student> FindByAll()
        {
            try
            {
                using (var context = new AttendanceContext())
                {
                    StudentDAL studentDAL = new StudentDAL();
                    return studentDAL.FindByAll(context);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
