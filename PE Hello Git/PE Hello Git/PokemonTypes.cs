using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Hello_Git
{
    class PokemonTypes
    {
        //Fields
        private string attackingType;
        private string defendingType;
        private List<string> weaknesses;

        //Constructor
        public PokemonTypes(string attackingType, string defendingType, List <string> weaknesses)
        {
            this.attackingType = attackingType;
            this.defendingType = defendingType;
            this.weaknesses = weaknesses;
        }

        //Methods

        //finds all type weaknesses and adds them to a list
        public List<string> getWeaknesses(string defendingType)
        {
            switch (defendingType)
            {
                case "NORMAL":
                    weaknesses.Add("FIGHTING");
                    break;

                case "FIGHTING":
                    weaknesses.Add("FLYING");
                    weaknesses.Add("PSYCHIC");
                    weaknesses.Add("FAIRY");
                    break;

                case "FLYING":
                    weaknesses.Add("ROCK");
                    weaknesses.Add("ELECTRIC");
                    weaknesses.Add("ICE");
                    break;

                case "POISON":
                    weaknesses.Add("GROUND");
                    weaknesses.Add("PSYCHIC");
                    break;

                case "GROUND":
                    weaknesses.Add("WATER");
                    weaknesses.Add("GRASS");
                    weaknesses.Add("ICE");
                    break;

                case "ROCK":
                    weaknesses.Add("FIGHTING");
                    weaknesses.Add("GROUND");
                    weaknesses.Add("STEEL");
                    weaknesses.Add("WATER");
                    weaknesses.Add("GRASS");
                    break;

                case "BUG":
                    weaknesses.Add("FLYING");
                    weaknesses.Add("ROCK");
                    weaknesses.Add("FIRE");
                    break;

                case "GHOST":
                    weaknesses.Add("GHOST");
                    weaknesses.Add("DARK");
                    break;

                case "STEEL":
                    weaknesses.Add("FIGHTING");
                    weaknesses.Add("GROUND");
                    weaknesses.Add("FIRE");
                    break;

                case "FIRE":
                    weaknesses.Add("GROUND");
                    weaknesses.Add("ROCK");
                    weaknesses.Add("WATER");
                    break;

                case "WATER":
                    weaknesses.Add("GRASS");
                    weaknesses.Add("ELECTRIC");
                    break;

                case "GRASS":
                    weaknesses.Add("FLYING");
                    weaknesses.Add("POISON");
                    weaknesses.Add("BUG");
                    weaknesses.Add("FIRE");
                    weaknesses.Add("ICE");
                    break;

                case "ELECTRIC":
                    weaknesses.Add("GROUND");
                    break;

                case "PSYCHIC":
                    weaknesses.Add("BUG");
                    weaknesses.Add("GHOST");
                    weaknesses.Add("DARK");
                    break;

                case "ICE":
                    weaknesses.Add("FIGHTING");
                    weaknesses.Add("ROCK");
                    weaknesses.Add("STEEL");
                    weaknesses.Add("FIRE");
                    break;

                case "DRAGON":
                    weaknesses.Add("ICE");
                    weaknesses.Add("DRAGON");
                    weaknesses.Add("FAIRY");
                    break;

                case "DARK":
                    weaknesses.Add("FIGHTING");
                    weaknesses.Add("BUG");
                    weaknesses.Add("FAIRY");
                    break;

                case "FAIRY":
                    weaknesses.Add("POISON");
                    weaknesses.Add("STEEL");
                    break;
            }
            return weaknesses;
        }

        //checks list to see if the defendingtype is weak to the attacking type
        public void isWeak(string attackingType, string defendingType)
        {            
            for (int i = 0; i < weaknesses.Count; i++)
            {
                if(attackingType == weaknesses[i])
                {
                    Console.WriteLine("\n" + defendingType + " is weak to " + attackingType);
                    return;
                }               
            }
            Console.WriteLine("\n" + defendingType + " is not weak to " + attackingType);
        }



    }
}
