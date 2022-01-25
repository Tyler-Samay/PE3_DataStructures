using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___List_of_Objects
{
    class Student
    {
        //Fields

        private string name;
        private string major;
        private int year;

        //Constructor

        public Student(string name, string major, int year)
        {
            this.name = name;
            this.major = major;
            this.year = year;
        }


        //Properties

        //Name
        public string Name
        {
            get { return name; }
        }

        //Major
        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        //Year
        public int Year
        {
            get { return year; }
        }

        //Methods

        public override string ToString()
        {
            //returns a string of info about the student
            string info = (name + "-" + year + "-" + major);
            return info;
        }


    }
}
