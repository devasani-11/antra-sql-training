using System;

namespace OOPS
{
    public class OOPSConcept
    {
        // Abstraction: Abstract class defining a common structure for people
        abstract class Person
        {
            // Encapsulation: Private fields
            private string _name;
            private int _age;

            // Public properties controlling access to private fields
            public string Name
            {
                get { return _name; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _name = value;
                    else
                        throw new ArgumentException("Name cannot be empty.");
                }
            }

            public int Age
            {
                get { return _age; }
                set
                {
                    if (value > 0)
                        _age = value;
                    else
                        throw new ArgumentException("Age must be positive.");
                }
            }

            // Constructor
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            // Polymorphism: Virtual method that can be overridden
            public virtual void GetDetails()
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}");
            }

            // Polymorphism: Abstract method that must be implemented by derived classes
            public abstract double CalculateSalary();
        }

        // Inheritance: Student class inherits from Person
        class Student : Person
        {
            private string _major;
            private double _gpa;

            public string Major
            {
                get { return _major; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _major = value;
                    else
                        throw new ArgumentException("Major cannot be empty.");
                }
            }

            public double GPA
            {
                get { return _gpa; }
                set
                {
                    if (value >= 0.0 && value <= 4.0)
                        _gpa = value;
                    else
                        throw new ArgumentException("GPA must be between 0.0 and 4.0.");
                }
            }

            public Student(string name, int age, string major, double gpa) : base(name, age)
            {
                Major = major;
                GPA = gpa;
            }

            // Overriding GetDetails for Student-specific behavior
            public override void GetDetails()
            {
                Console.WriteLine($"Student: {Name}, Age: {Age}, Major: {Major}, GPA: {GPA}");
            }

            // Overriding abstract method (Polymorphism)
            public override double CalculateSalary()
            {
                return 0;
            }
        }

        // Inheritance: Instructor class inherits from Person
        class Instructor : Person
        {
            private string _department;
            private double _salary;

            public string Department
            {
                get { return _department; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _department = value;
                    else
                        throw new ArgumentException("Department cannot be empty.");
                }
            }

            public double Salary
            {
                get { return _salary; }
                set
                {
                    if (value > 0)
                        _salary = value;
                    else
                        throw new ArgumentException("Salary must be positive.");
                }
            }

            public Instructor(string name, int age, string department, double salary) : base(name, age)
            {
                Department = department;
                Salary = salary;
            }

            // Overriding GetDetails for Instructor-specific behavior
            public override void GetDetails()
            {
                Console.WriteLine($"Instructor: {Name}, Age: {Age}, Department: {Department}, Salary: ${Salary}");
            }

            // Overriding abstract method (Polymorphism)
            public override double CalculateSalary()
            {
                return Salary;
            }
        }

        public static void OOPS()
        {
            try
            {
                // Creating a Student object
                Student student = new Student("Alice", 20, "Computer Science", 3.9);
                student.GetDetails();
                Console.WriteLine($"Calculated Salary: ${student.CalculateSalary()}");

                Console.WriteLine();

                // Creating an Instructor object
                Instructor instructor = new Instructor("Dr. Smith", 45, "Engineering", 75000);
                instructor.GetDetails();
                Console.WriteLine($"Calculated Salary: ${instructor.CalculateSalary()}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
