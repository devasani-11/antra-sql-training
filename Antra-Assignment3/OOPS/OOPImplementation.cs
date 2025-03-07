using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{

    public class OOP_Implementation
    {
        public interface IPersonService
        {
            int CalculateAge();
            decimal CalculateSalary();
            List<string> GetAddresses();
        }

        public interface IStudentService : IPersonService
        {
            void EnrollInCourse(Course course);
            double CalculateGPA();
        }

        public interface IInstructorService : IPersonService
        {
            decimal CalculateBonus();
        }

        public interface ICourseService
        {
            void AddStudent(Student student);
            void AssignGrade(Student student, char grade);
        }

        public interface IDepartmentService
        {
            void AssignHead(Instructor instructor);
            void AddCourse(Course course);
        }

        public abstract class Person : IPersonService
        {
            private string _name;
            private DateTime _birthDate;
            private decimal _salary;
            private List<string> _addresses = new List<string>();

            public string Name
            {
                get => _name;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _name = value;
                    else
                        throw new ArgumentException("Name cannot be empty.");
                }
            }

            public DateTime BirthDate
            {
                get => _birthDate;
                set
                {
                    if (value > DateTime.Now)
                        throw new ArgumentException("Birth date cannot be in the future.");
                    _birthDate = value;
                }
            }

            public decimal Salary
            {
                get => _salary;
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Salary cannot be negative.");
                    _salary = value;
                }
            }

            public List<string> Addresses => _addresses;

            public void AddAddress(string address) => _addresses.Add(address);

            public int CalculateAge() => DateTime.Now.Year - BirthDate.Year;

            public abstract decimal CalculateSalary();

            public List<string> GetAddresses() => Addresses;
        }

        public class Student : Person, IStudentService
        {
            private List<Course> _enrolledCourses = new List<Course>();
            private Dictionary<Course, char> _grades = new Dictionary<Course, char>();

            public void EnrollInCourse(Course course)
            {
                _enrolledCourses.Add(course);
                course.AddStudent(this);
            }

            public double CalculateGPA()
            {
                if (_grades.Count == 0) return 0.0;

                Dictionary<char, double> gradePoints = new Dictionary<char, double>
            {
                {'A', 4.0}, {'B', 3.0}, {'C', 2.0}, {'D', 1.0}, {'F', 0.0}
            };

                double totalPoints = _grades.Sum(g => gradePoints[g.Value]);
                return totalPoints / _grades.Count;
            }

            public override decimal CalculateSalary() => 0; 
        }

        public class Instructor : Person, IInstructorService
        {
            public string Department { get; set; }
            public DateTime JoinDate { get; set; }

            public override decimal CalculateSalary() => Salary + CalculateBonus();

            public decimal CalculateBonus()
            {
                int experienceYears = DateTime.Now.Year - JoinDate.Year;
                return experienceYears * 1000;
            }
        }

        public class Course : ICourseService
        {
            public string CourseName { get; set; }
            public List<Student> EnrolledStudents { get; private set; } = new List<Student>();
            private Dictionary<Student, char> _studentGrades = new Dictionary<Student, char>();

            public void AddStudent(Student student)
            {
                if (!EnrolledStudents.Contains(student))
                    EnrolledStudents.Add(student);
            }

            public void AssignGrade(Student student, char grade)
            {
                if (EnrolledStudents.Contains(student))
                    _studentGrades[student] = grade;
            }
        }

        public class Department : IDepartmentService
        {
            public string DepartmentName { get; set; }
            public Instructor HeadOfDepartment { get; private set; }
            public List<Course> OfferedCourses { get; private set; } = new List<Course>();
            public decimal Budget { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public void AssignHead(Instructor instructor)
            {
                HeadOfDepartment = instructor;
            }

            public void AddCourse(Course course)
            {
                OfferedCourses.Add(course);
            }
        }

             public static void Implementation()
            {
                try
                {
                    // Creating Instructor
                    Instructor instructor = new Instructor
                    {
                        Name = "Dr. Smith",
                        BirthDate = new DateTime(1980, 5, 15),
                        Salary = 80000,
                        JoinDate = new DateTime(2010, 9, 1),
                        Department = "Computer Science"
                    };
                    instructor.AddAddress("123 Main St, NY");

                    Console.WriteLine($"{instructor.Name}'s Salary: ${instructor.CalculateSalary()}");
                    Console.WriteLine($"{instructor.Name}'s Age: {instructor.CalculateAge()}");
                    Console.WriteLine($"{instructor.Name} Bonus: ${instructor.CalculateBonus()}");

                    // Creating Student
                    Student student = new Student
                    {
                        Name = "Alice",
                        BirthDate = new DateTime(2002, 8, 21)
                    };
                    student.AddAddress("456 College Rd, CA");

                    // Creating Course
                    Course course = new Course { CourseName = "Data Structures" };
                    student.EnrollInCourse(course);
                    course.AssignGrade(student, 'A');

                    Console.WriteLine($"{student.Name}'s GPA: {student.CalculateGPA()}");
                    Console.WriteLine($"{student.Name}'s Age: {student.CalculateAge()}");

                    // Creating Department
                    Department department = new Department
                    {
                        DepartmentName = "Computer Science",
                        Budget = 500000,
                        StartDate = new DateTime(2025, 1, 1),
                        EndDate = new DateTime(2025, 12, 31)
                    };
                    department.AssignHead(instructor);
                    department.AddCourse(course);

                    Console.WriteLine($"Department Head: {department.HeadOfDepartment.Name}");
                    Console.WriteLine($"Budget: ${department.Budget}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

}
