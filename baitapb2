using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }

    public Student(string id, string name, int age, double gpa)
    {
        Id = id;
        Name = name;
        Age = age;
        GPA = gpa;
    }
}

public class StudentDAO
{
    private List<Student> students = new List<Student>();

    public void Add(Student student)
    {
        students.Add(student);
    }

    public void Edit(Student student)
    {
        Student s = getById(student.Id);
        if (s != null)
        {
            s.Name = student.Name;
            s.Age = student.Age;
            s.GPA = student.GPA;
        }
    }

    public void Delete(string id)
    {
        Student s = getById(id);
        if (s != null)
            students.Remove(s);
    }

    public List<Student> getAlls()
    {
        return students;
    }

    public Student getById(string id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> getByName(string name)
    {
        return students.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();
    }
}
