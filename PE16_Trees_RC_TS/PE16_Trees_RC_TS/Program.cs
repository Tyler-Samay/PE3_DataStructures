using System;
using System.Collections.Generic;
using System.Text;

namespace PE16_Trees_RC_TS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create TalentTreeNode Objects
            TalentTreeNode magic = new TalentTreeNode("Magic", true);
            TalentTreeNode fireball = new TalentTreeNode("Fireball", true);
            TalentTreeNode crazyFireball = new TalentTreeNode("Crazy Big Fireball", false);
            TalentTreeNode tinyFireballs = new TalentTreeNode("1000 Tiny Fireballs", true);
            TalentTreeNode magicArrow = new TalentTreeNode("Magic Arrow", false);
            TalentTreeNode iceArrow = new TalentTreeNode("Ice Arrow", false);
            TalentTreeNode boomArrow = new TalentTreeNode("Exploding Arrow", false);
            //Connect Nodes to each other
            magic.Left = fireball;
            magic.Right = magicArrow;
            fireball.Left = crazyFireball;
            fireball.Right = tinyFireballs;
            magicArrow.Left = iceArrow;
            magicArrow.Right = boomArrow;
            //List all abilities
            Console.WriteLine("--Listing all abilities in the game.--");
            magic.ListAllAbilities();
            Console.WriteLine();

            //List all known abilities
            Console.WriteLine("--Listing all my known abilities.--");
            magic.ListKnownAbilities();
            Console.WriteLine();

            //List all possible abilities
            Console.WriteLine("--Listing all abilities I could learn next.--");
            magic.ListPossibleAbilities(magic);
            Console.WriteLine();
        }
    }
}
