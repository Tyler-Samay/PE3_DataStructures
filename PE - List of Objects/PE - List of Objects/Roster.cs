using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___List_of_Objects
{
    class Roster
    {
        //Fields

        private string rName;
        private List<Student> students;

        //Constructor

        public Roster(string rName, List<Student> students)
        {
            this.rName = rName;
            this.students = students;
        }

        //Methods

        //SearchStudent
        public Student SearchByName(string name)
        {
            //loops through list to find student name
            for(int i = 0; i < students.Count; i++)
            {
                if(students[i].Name == name)
                {
                    return students[i];
                }
            }
            //returns null if student was not in the list
            return null;
        }

        //AddStudent void
        public void AddStudent(Student s)
        {
            //checks if student is already in the list and adds them if they aren't in the list
            if (SearchByName(s.Name) == null)
            {
                students.Add(s);
                Console.WriteLine("Added {0} to the {1} roster.\n", s.Name, rName);
            }
            else
            {
                Console.WriteLine("{0} is already in the roster\n", s.Name);
            }           
        }

        //AddStudent user interactive
        public Student AddStudent()
        {
            string inputName;
            string inputMajor;
            int inputYear;

            //Asks for name major and year
            Console.Write("What student are you looking for?\n\t> " );
            inputName = Console.ReadLine();
            Console.Write("What is their major?\n\t> ");
            inputMajor = Console.ReadLine();
            Console.Write("What year are they?\n\t> ");
            inputYear = int.Parse(Console.ReadLine());

            //Create Student using user inputs
            Student s = new Student(inputName, inputMajor, inputYear);

            //tries to add student by calling AddStudent
            AddStudent(s);

            return s;
        }

        //DisplayRoster
        public void DisplayRoster()
        {
            Console.WriteLine("{0} has {1} student/s:\n\t", rName, students.Count());

            //loops through list and prints each players information
            for(int i = 0; i < students.Count(); i++)
            {
                Console.WriteLine(students[i].ToString());
            }
        }






    }
}
