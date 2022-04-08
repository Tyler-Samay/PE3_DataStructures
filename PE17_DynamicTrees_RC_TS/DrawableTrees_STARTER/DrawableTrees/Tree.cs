using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DrawableTrees
{
    /// <summary>
    /// Represents a tree-centric data structure
    /// that can have data dynamically inserted based on the rules of a
    /// binary search tree, and can be drawn as a literal "tree" on the screen
    /// </summary>
    class Tree : DrawableTree
    {
        // Already has an inherited root node field called "root"

        /// <summary>
        /// Creates a tree that can be drawn
        /// </summary>
        /// <param name="sb">The sprite batch used to draw</param>
        /// <param name="treeColor">The color of this tree</param>
        public Tree(Color treeColor)
            : base(treeColor)
        { }

        /// <summary>
        /// Public facing Insert method
        /// </summary>
        /// <param name="data">The data to insert</param>
        public void Insert(int data)
        {
            // TODO: Implement this method!
            if(root == null)
            {
                root = new TreeNode(data);
            }
            else
            {
                Insert(data, root);
            }
        }

        /// <summary>
        /// Private recursive insert method. Data is inserted based on the rules
        /// of a binary search treee
        /// </summary>
        /// <param name="data">The data to insert</param>
        /// <param name="node">The node to attempt to insert into</param>
        private void Insert(int data, TreeNode node)
        {
            // TODO: Implement this method!
            if(data < node.Data)
            {
                if(node.Left == null)
                {
                    node.Left = new TreeNode(data);
                }
                else
                {
                    Insert(data, node.Left);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode(data);
                }
                else
                {
                    Insert(data, node.Right);
                }
            }
        }
    }
}
