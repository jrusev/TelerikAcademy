using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianCycle
{
    class Node
    {
        private char letter;
        
        private bool visited;

        public List<Node> Neighbors;        
        
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

        public Node(char letter)
        {
            this.Letter = letter;
            Neighbors = new List<Node>();
        }
    }
}
