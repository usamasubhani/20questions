using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainReader
{
    public class Node
    {
        string data;
        Node left;
        Node right;

        public Node()
        {
            left = null;
            right = null;
        }

        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }

        public Node Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}
