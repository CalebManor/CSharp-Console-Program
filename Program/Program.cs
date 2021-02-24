using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main()
        {
            var students = new List<Student>();

            try
            {
                students.Add(new Student { FirstName = "Bob", LastName = "Smith", HNumber = "H12345678" });
                students.Add(new Student { FirstName = "Pam", LastName = "White", HNumber = "H22345678" });
                students.Add(new Student { FirstName = "Sue", LastName = "Black", HNumber = "H52345678" });
                students.Add(new Student { FirstName = "Lee", LastName = "Green", HNumber = "H82345678" });
            }
            catch(Exception ex)
            {
                Console.WriteLine("Incorrect Input");
                Console.WriteLine(ex.Message);
            }

            List<Student> leftStudents;
            List<Student> rightStudents;
            Student.DivideStudents(students, out leftStudents, out rightStudents);

            // Pam and Lee
            Console.WriteLine("Left:");
            foreach (var s in leftStudents)
            {
                Console.WriteLine(s);
            }

            // Bob and Sue
            Console.WriteLine("\nRight:");
            foreach (var s in rightStudents)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class Student
    {
        private string firstName;
        private string lastName;
        private string hNumber;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("First name can not be blank");
                }
                else
                {
                    firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Last name can not be blank");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public string HNumber
        {
            get
            {
                return hNumber;
            }
            set
            {
                //https://syntaxdb.com/ref/csharp/string-length
                if (value.Length != 9)
                {
                    throw new ArgumentException("H Number must be 9 characters long");
                }

                //https://answers.unity.com/questions/31264/c-check-first-letter-of-string.html
                if (value.Substring(0, 1) != "H")
                {
                    throw new ArgumentException("H Number must begin with H");
                }

                if (value.Length == 9)
                {
                    string digits = value.Substring(1, 8);
                    for (int i = 0; i < digits.Length; i++)
                    {
                        //https://stackoverflow.com/questions/4524957/how-to-check-if-my-string-only-numeric/4524969#:~:text=bool%20IsAllDigits(string%20s)%20%3D,you%20can%20use%20TryParse()%20.
                        char digit = digits[i];
                        if (!char.IsDigit(digit))
                        {
                            throw new ArgumentException("H Number can not have any letters after the initial H");
                        }
                    }
                    hNumber = value;
                }
            }
        }

        public override string ToString()
        {
            string studentInformation = LastName + ", " + FirstName + " - " + HNumber;
            return studentInformation;
        }

        public static void DivideStudents(List<Student> studentList, out List<Student> leftStudents, out List<Student> rightStudents)
        {
            leftStudents = new List<Student>();
            rightStudents = new List<Student>();

            string firstDigit;

            foreach (var student in studentList)
            {
                firstDigit = student.HNumber.Substring(1, 1);

                //https://www.tutorialsteacher.com/articles/convert-string-to-int
                if (int.Parse(firstDigit) % 2 == 0)
                {
                    leftStudents.Add(student);
                }
                else
                {
                    rightStudents.Add(student);
                }
            }
        }
    }
}
