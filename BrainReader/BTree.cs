using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BrainReader
{
    public class BTree
    {
        Node root;
        public int side; //Last answer
        public int updated = 0;
        public string question;
        
        public BTree()
        {
        }

        public Node Root
        {
            get { return root; }
            set { root = value; }
        }


        public bool IsEmpty()
        {
            return root == null;
        }

        public void WriteToFile(Node temp, StreamWriter filerWriter)
        {
            if(temp==null)
            {
                filerWriter.WriteLine("-1");
                return;
            }
            filerWriter.WriteLine(temp.Data);
            WriteToFile(temp.Left, filerWriter);
            WriteToFile(temp.Right, filerWriter);
        }

        public Node ReadFromFile(Node tempRoot, StreamReader fileReader, string line)
        {
            Node ptr = tempRoot;
            
            line = fileReader.ReadLine();
            if (line == "-1")
                return null;

            else
              {
                Node temp = new Node();
                temp.Data = line;
                ptr = temp;
                ptr.Left = ReadFromFile(temp.Left, fileReader, "");
                ptr.Right = ReadFromFile(temp.Right, fileReader, "");
                return temp;
              }
        }

        

    }
}
