using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEE_Error_Analysis
{
    class Edge
    {
        int Head;
        int Tail;
        string Signal_Name;
        double weight;
        bool adj;

        public Edge( )
        {
            this.Tail = 0;
            this.Head = 0;
            Signal_Name = "";
            this.weight = 0;
            this.adj = false;
        }
        public void JoinAdj(int Tail, int Head, string Signal_Name, double weight)
        {
            this.Tail = Tail;
            this.Head = Head;
            this.Signal_Name = Signal_Name;
            this.weight = weight;
            adj = true;
        }
        public void SetWeight(double weight)
        {
            this.weight = weight;
        }
        public bool CheckAdj()
        {
            return adj;
        }
        public string GetSignalName()
        {
            return Signal_Name;
        }

        public double GetWeight()
        {
            return weight;
        }
        public int GetTail()
        {
            return Tail;
        }
        public int GetHead()
        {
            return Head;
        }

    }
}
