using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    class Node
    {
        private char letter;
        
        private bool visited;

        public List<KeyValuePair<Node, int>> Neighbors;        
        
        public bool Visited
        {
            get
            {
                return this.visited;
            }
            set
            {
                this.visited = value;
            }
        }

        public char Letter
        {
            get
            {
                return this.letter;
            }
            private set
            {
                this.letter = value;
            }
        }

        public Node(char number)
        {
            this.Letter = number;
            Neighbors = new List<KeyValuePair<Node, int>>();
        }
    }
}
