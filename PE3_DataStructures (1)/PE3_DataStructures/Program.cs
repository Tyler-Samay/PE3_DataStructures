using System;
using System.Collections.Generic;

// Driver: Jack Carter
// Navigator: Tyler Samay

namespace PE3_DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Scenario 1
            List<string> pets1 = new List<string>();
            pets1.Add("Pax");
            pets1.Add("Aiden");

            // Scenario 2
            Pet[] pets2 = new Pet[5];
            pets2[0] = new Pet();
            pets2[1] = new Pet("Lacy", 7.5);

            // Scenario 3
            List<Pet> pets3 = new List<Pet>();
            pets3.Add(new Pet("Pax", 80));
            pets3.Add(new Pet());


            // Scenario 4
            // create 4x4 2D array
            bool[,] board = new bool[4, 4];

            


            // nested loop thru each row + column
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    // set item at row and col to row % 0 == col %
                    board[row, col] = row % 2 == col % 2;
                }
            }
            /*  testing by writing to console
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
            

            // Scenario 5
            List<int[]> grades = new List<int[]>();
            // instantiate arrays
            int[] g1 = new int[] { 89, 87, 85 };
            int[] g2 = new int[] { 73, 75};
            int[] g3 = new int[] { 88, 90, 92, 94, 99 };
            // add arrays to grades list
            grades.Add(g1);
            grades.Add(g2);
            grades.Add(g3);


            // Scenario 6
            // create list of 4 Pet arrays
            List<Pet>[] familyPets = new List<Pet>[4];

            // add 1 new pet to third family array
            familyPets[2].Add(new Pet("Samson", 11.5));

            // add 2 new pets to fourth family array
            familyPets[3].Add(new Pet("Indy", 75));
            familyPets[3].Add(new Pet("Odin", 93));

            */


            // Scenario 7

            string[,] seats = new string[3, 5];
            seats[0, 0] = "Pax";
            seats[1, 1] = "Lacy";
            seats[1, 3] = "Shiro";
            seats[2, 4] = "Pidge";

            //seats[1, 9] = "Uh oh";
            // 9 is an out of bounds index

            //seats[0] = new string[5];
            // seats is a 2D array, the line only refers to one dimension
        }
    }

    class Pet
    {
        private string name;
        private double weight;

        public Pet()
        {

        }

        public Pet(string name, double weight)
        {
            this.name = name;
            this.weight = weight;
        }
    }
}
