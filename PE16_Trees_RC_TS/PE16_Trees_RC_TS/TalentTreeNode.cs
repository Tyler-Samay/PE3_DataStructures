using System;
using System.Collections.Generic;
using System.Text;

namespace PE16_Trees_RC_TS
{
    class TalentTreeNode
    {
        //Fields
        private string ability;
        private bool learned;
        private TalentTreeNode left;
        private TalentTreeNode right;

        //Properties
        //Left Property
        public TalentTreeNode Left
        {
            get { return left; }
            set { left = value; }
        }
        //Right Property
        public TalentTreeNode Right
        {
            get { return right; }
            set { right = value; }
        }

        //Constructor
        public TalentTreeNode(string ability, bool learned)
        {
            this.ability = ability;
            this.learned = learned;
        }

        //Methods
        //ListAllAbilities Method
        public void ListAllAbilities()
        {
            if(this.left != null)
            {
                this.left.ListAllAbilities();
            }
            Console.WriteLine(this.ability);
            if(this.right != null)
            {
                this.right.ListAllAbilities();
            }
        }
        //ListKnownAbilities Method
        public void ListKnownAbilities()
        {
            if (this.learned == true)
            {
                Console.WriteLine("Known Ability: " + this.ability);
            }
            if (this.left != null)
            {
                this.left.ListKnownAbilities();
            }
            if (this.right != null)
            {
                this.right.ListKnownAbilities();
            }
        }
        //ListPossibleAbilities Method
        public void ListPossibleAbilities(TalentTreeNode parent)
        {
            if(this.learned == false)
            {
                Console.WriteLine("Possible Ability: " + this.ability);
            }
            if(this.left != null && this.learned == true)
            {
                this.left.ListPossibleAbilities(parent);
            }
            if(this.right != null && this.learned == true)
            {
                this.right.ListPossibleAbilities(parent);
            }
        }
    }
}
