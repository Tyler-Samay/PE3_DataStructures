using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PE___List_of_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables & Objects

            Student temp; 
            List<Student> studentsList = new List<Student>();
            List<Student> freshmanList = new List<Student>();
            Roster allStudents = new Roster("AllStudents", studentsList);
            Roster freshman = new Roster("Freshman", freshmanList);
            int choice;
            string input;
            string newMajor;
            string[] data;

            //file name
            string fileName = "../../allStudents.txt";

            //creates stream reader and writer for the file
            StreamReader reader = new StreamReader(fileName);
            StreamWriter writer = new StreamWriter(fileName);

            //Current line being read
            string line;

            try
            {
                //loop through file while there is something to be read
                while((line = reader.ReadLine()) != null)
                {
                    //adds each piece of information to an array
                    data = line.Split(',');

                    //creates Student object from read information
                    Student obj = new Student(data[0], data[1], int.Parse(data[2]));

                    //adds temp student object to studentsList
                    studentsList.Add(obj);

                    //if the year is one adds to freshmanList
                    if(obj.Year == 1)
                    {
                        freshmanList.Add(obj);
                    }
                }
                reader.Close();

            }
            catch(Exception e)
            {
                Console.WriteLine("File Could not be found");
            }


            //Loop that asks for user input until users quits

            do
            {
                Console.Write("Choose 1 of the following options:\n" +
                "1 - Add a student\n" +
                "2 - Change major for a student\n" +
                "3 - Print the rosters\n" +
                "4 - Quit\n" +
                "> ");
                choice = int.Parse(Console.ReadLine());

                //switch statement based on user input

                switch (choice)
                {
                    //Adds students to list
                    case 1:
                        temp = allStudents.AddStudent();
                        //Adds freshman to freshman list
                        if (temp.Year == 1)
                        {
                            freshmanList.Add(temp);
                        }
                        break;

                    //Search for prompted student and changes their major
                    case 2:
                        Console.Write("Who's major needs to be changed\n" +
                            "> ");
                        input = Console.ReadLine();
                        if (allStudents.SearchByName(input) != null)
                        {
                            Console.Write("What are they changing their major to?\n" +
                                "> ");
                            newMajor = Console.ReadLine();

                            //Searches and gets student object again
                            if (allStudents.SearchByName(input) != null)
                            {
                                //Searches and gets student object again and sets major to input
                                allStudents.SearchByName(input).Major = newMajor;
                            }
                            //.Major = input
                        }
                        else Console.WriteLine("That student does not exist.\n");
                        break;

                    //Print every Roster
                    case 3:
                        allStudents.DisplayRoster();
                        freshman.DisplayRoster();
                        break;

                    //Program ends
                    case 4:                        
                        break;

                    //If any other number is given
                    default:
                        Console.WriteLine("Incorrect input, try again.\n");
                        break;
                }

            }
            while (choice != 4);

        }
    }
}
