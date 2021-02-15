using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    class Organisation
    {
        private List<Student> Students { get; set; }

        private string Name { get; set; }

        // new Organisation(“SIA mans uznemums”); 
        public Organisation(string name)
        {
            Name = name;
            Students = new List<Student>(); // avoid NULL REFERENCE error
        }

        public void AddNew(string name, string surname)
        {
            // 'Students' variable is of 'class scope' -> property
            Students.Add(new Student() { 
                Name = name, 
                Surname = surname 
            });

            // new variable 'students' not related to var 'Students'
            // 'students' is of 'method scope'
            var students = new List<Student>();
            students.Add(new Student()
            {
                Name = name,
                Surname = surname
            });
        }
    }
}
