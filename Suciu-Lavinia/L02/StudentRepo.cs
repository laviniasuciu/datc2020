using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L02
{
    public class StudentRepo
    {
        private static List<Student> Student = new List<Student>();

        public static void insert(Student data)
        {
            data.Id = Student.Count;
            Student.Add(data);
        }

        public static Student getById(int id)
        {
            return Student.Find(student => student.Id == id);
        }

        public static List<Student> getAll()
        {
            return Student;
        }

        public static void deleteById(int id)
        {
            Student.RemoveAll(s => s.Id == id);
        }

        public static Student update(int id, Student student)
        {
            int index = Student.FindIndex(s => s.Id == id);
            Student[index].Nume = student.Nume;
            Student[index].Prenume = student.Prenume;
            Student[index].Facultate = student.Facultate;
            Student[index].AnStudiu = student.AnStudiu;
            return Student[index];
        }
}
