using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(Capacity);
        }

        public int Capacity { get; private set; }

        private List<Student> students;

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else return "Student not found";
        }
        
        public string GetSubjectInfo(string subject)
        {
            List<Student> subjectStudents = students.Where(s => s.Subject == subject).ToList();
            if (subjectStudents.Count == 0) return "No students enrolled for the subject";
            else
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendLine($"Subject: {subject}");
                builder.AppendLine($"Students:");
                foreach (Student student in subjectStudents)
                    builder.AppendLine($"{student.FirstName} {student.LastName}");

                return builder.ToString().TrimEnd();
            }
        }

        public int GetStudentsCount() => students.Count;
        public Student GetStudent(string firstName, string lastName) 
            => students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
