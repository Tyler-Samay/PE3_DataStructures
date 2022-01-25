using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Hello_Git
{
    class Program
    {
        static void Main(string[] args)
        {
            string moveType;
            string foeType;
            List<string> weaknesses = new List<string>();

            Console.WriteLine("Pokemon Type Advantage Checker: Check to see what Pokemon types are advantageous" +
                " against one another.\n");

            //Pick a move type
            Console.Write("Please enter what type move you will be attacking with.\n" +
                "\t> ");
            moveType = Console.ReadLine().ToUpper();

            //Pick a pokemon type
            Console.Write("\nPlease enter what type pokemon will be attacked with the previous selected type.\n" +
                "\t> ");
            foeType = Console.ReadLine().ToUpper();

            //Create object using player inputs
            PokemonTypes weakness = new PokemonTypes(moveType, foeType, weaknesses);

            //finds weaknesses
            weakness.getWeaknesses(foeType);

            //checks if the movetype is effective against the foetype
            weakness.isWeak(moveType, foeType);
            
        }
    }
}
