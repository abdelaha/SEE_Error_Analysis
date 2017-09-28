using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEE_Error_Analysis
{
    class Graph
    {
        //int MaxNodes;

        List<Edge> Edges;
        List<Vertex> Vertices;
        List<string> PrimaryInput;



        public Graph()
        {
            // this.MaxNodes = MaxNodes;
            Edges = new List<Edge>();
            Vertices = new List<Vertex>();
            PrimaryInput = new List<string>();

        }


        public int AddVertex(string Vertex_Name, int Vertex_Num, string Gate_Code, string Verilog_code)
        {
            int VertexIndex;
            Vertex NewOne = new Vertex(Vertex_Name, Vertex_Num, Gate_Code, Verilog_code);
            Vertices.Add(NewOne);
            VertexIndex = Vertices.Count - 1;
            return VertexIndex;
        }
        public void AddEdge(int HeadIndex, int TailIndex, string Signal_Name, Double Weight)
        {
            Edge NewEdge = new Edge();
            NewEdge.JoinAdj(TailIndex, HeadIndex, Signal_Name, Weight);
            Edges.Add(NewEdge);
        }
        public void AddPrimaryInput(string primary_input)
        {

            this.PrimaryInput.Add(primary_input);
        }
        public Vertex GetVertex(int VertexIndex)
        {
            return Vertices[VertexIndex];
        }
        public int findVertexByName(string VertexName)
        {
            int VertexIndex = -1;
            for (int i = 0; i < Vertices.Count(); i++)
            {
                if (Vertices[i].GetVertexName() == VertexName)
                    VertexIndex = i;
            }

            return VertexIndex;

        }
        public int findVertexByNum(int VertexNum)
        {
            int VertexIndex = -1;
            for (int i = 0; i < Vertices.Count(); i++)
            {
                if (Vertices[i].GetVertexNum() == VertexNum)
                    VertexIndex = i;
            }

            return VertexIndex;

        }
        public Edge GetEdge(int EdgeIndex)
        {
            return Edges[EdgeIndex];
        }
        public int GetNumberOfNodes()
        {
            return Vertices.Count;
        }
        public void updateVertexVerilogFunction(int VertexIndex, string Verilog_Code)
        {
            this.Vertices[VertexIndex].setVerilogFunction(Verilog_Code);


        }
        public void SetVertexGateCode(int VertexIndex, string Gate_Code)
        {
            this.Vertices[VertexIndex].SetGateCode(Gate_Code);
        }
        public void SetVertexNumber(string VertexName, int Thenumber)
        {
            int VertixIndex = findVertexByName(VertexName);
            this.Vertices[VertixIndex].SetVertexNum(Thenumber);


        }
        public string GetVertexName(int Vertex_Index)
        {

            return this.Vertices[Vertex_Index].GetVertexName();


        }
        public string GetGateName(int Vertex_Index)
        {

            return this.Vertices[Vertex_Index].GetGateCode();


        }
        public void SetVertexLogicValue(bool LogicValue, bool GoldValue, int Vertex_Num)
        {
            int Vertexindex = findVertexByNum(Vertex_Num);
            this.Vertices[Vertexindex].SetlogicValue(LogicValue);
            this.Vertices[Vertexindex].SetGoldValue(GoldValue);



        }
        public bool GetVertexLogicValue(int Vertex_Index)
        {

            return this.Vertices[Vertex_Index].GetlogicValue();



        }
        public bool GetVertexGoldValue(int Vertex_Index)
        {

            return this.Vertices[Vertex_Index].GetGoldValue();



        }
        public string getVerilogFunction(int Vertex_Index)
        {


            return this.Vertices[Vertex_Index].getVerilogFunction();
        }
        /* public List<Edge> FindNetlistInputEdges(int VertexIndex)
         {
             List<Edge> EdgesInput = new List<Edge>();

             for (int j = 0; j < this.Edges.Count; j++)
                 if (this.Edges[j].GetHead() == VertexIndex)
                     EdgesInput.Add(this.Edges[j]);


             return EdgesInput;
         }*/


        public List<bool> FindNetlistInputValue(int VertexIndex)
        {
            List<bool> InputValues = new List<bool>();
            List<bool> InputGoldValues = new List<bool>();

            for (int j = 0; j < this.Edges.Count; j++)
                if (this.Edges[j].GetHead() == VertexIndex)
                {
                    InputValues.Add(this.Vertices[this.Edges[j].GetTail()].GetlogicValue());
                    InputGoldValues.Add(this.Vertices[this.Edges[j].GetTail()].GetGoldValue());
                }

            //Combine to one list to return


            for (int i = 0; i < InputGoldValues.Count; i++)
                InputValues.Add(InputGoldValues[i]);

            return InputValues;
        }

        public List<string> FindNetlistInputsName(int VertexIndex)
        {
            List<string> InputsName = new List<string>();


            for (int j = 0; j < this.Edges.Count; j++)
                if (this.Edges[j].GetHead() == VertexIndex)
                {
                    InputsName.Add(this.Vertices[this.Edges[j].GetTail()].GetVertexName());

                }



            return InputsName;
        }
        public List<int> FindNetlistInputsIndex(int Vertex_Index)
        {

            List<int> InputsVertices = new List<int>();

            for (int j = 0; j < this.Edges.Count; j++)
                if (this.Edges[j].GetHead() == Vertex_Index)
                {
                    InputsVertices.Add(this.Edges[j].GetTail());

                }

            return InputsVertices;


        }

        public void OrderVerticesbyNumber(int seed)
        {
            int NewSeed = seed;
            bool done = true;
            while (done)
            {
                done = false;
                NewSeed = seed + 1;
                for (int i = 0; i < this.Vertices.Count; i++)
                {
                    bool ValidVertex = true;
                    if (this.Vertices[i].GetVertexNum() == 0)
                    {
                        for (int j = 0; j < this.Edges.Count; j++)
                            if (this.Edges[j].GetHead() == i)
                                if (this.Vertices[this.Edges[j].GetTail()].GetVertexNum() == 0 || this.Vertices[this.Edges[j].GetTail()].GetVertexNum() > seed)
                                    ValidVertex = false;

                        if (ValidVertex)
                        {
                            this.Vertices[i].SetVertexNum(NewSeed);
                            NewSeed++;
                            ValidVertex = false;
                            done = true;

                        }

                    }


                }
                seed = NewSeed - 1;
            }


        }

        public string getVetrexEqn(int Netlist_Index)
        {
            return this.Vertices[Netlist_Index].geteqnFunction();

        }

        public void setVertexEqn(string Vertex_eqn, int Netlist_Index)
        {
            this.Vertices[Netlist_Index].seteqnFunction(Vertex_eqn);

        }

        public int getVertexParity(int Netlist_Index)
        {
            return this.Vertices[Netlist_Index].getVertexParity();
        }

        public void setVertexParity(int vertex_Parity, int Netlist_Index)
        {

            this.Vertices[Netlist_Index].setVertexParity(vertex_Parity);
        }

        public string getBackConeVerilog(int Netlist_Index)
        {
            return this.Vertices[Netlist_Index].getBackConeVerilog();

        }

        public void setBackConeVerilog(string Back_Cone_Verilog, int Netlist_Index)
        {
            this.Vertices[Netlist_Index].setBackConeVerilog(Back_Cone_Verilog);

        }


        public int GetNumberofBackConeNetlist(int Netlist_Index)
        {

            int BackconeNetlist = 1;  // To include the gate of the target netlist.
            List<int> BackConeNetlistIndices;

            BackConeNetlistIndices = this.Vertices[Netlist_Index].GetNumberofBackConeNetlistList();

            for (int i = 0; i < BackConeNetlistIndices.Count; i++)
                if (!PrimaryInput.Contains(this.Vertices[BackConeNetlistIndices[i]].GetVertexName().ToString()))
                    BackconeNetlist++;

            return BackconeNetlist;

        }
        public string GetBackConeNetlistListNames(int Netlist_Index)
        {
            string BackconeNetlist = "";
            List<int> BackConeNetlistIndices;

            BackConeNetlistIndices = this.Vertices[Netlist_Index].GetNumberofBackConeNetlistList();

            for (int i = 0; i < BackConeNetlistIndices.Count; i++)
                BackconeNetlist += "\r\t " + this.Vertices[BackConeNetlistIndices[i]].GetVertexName();

            return BackconeNetlist;
        }
        public List<int> GetBackConeList(int Netlist_Index)
        {


            return this.Vertices[Netlist_Index].GetNumberofBackConeNetlistList();




        }


        public void CalculateTheBackConeData()
        {

            //Variables Definiation and Inizliation
            int NetlistIndex = 0; //To Reference the Netlist (K) with its index instead of Number
            List<int> TailBackConeList = new List<int>();

            //Loop in the Netlists from the Netlist Number (1) the first Input to the Last Netlist (Last Output)
            for (int k = 1; k <= Vertices.Count; k++)
            {
                NetlistIndex = findVertexByNum(k);
                //Loop in the Netlist with Number K Tails
                //Search for the First Edge in which the Netlist(k) is the Head.  if there is no such an Edge just move to the next Netlist(k) 
                //This will happen in the Primary inputs.
                for (int j = 0; j < this.Edges.Count; j++)
                    if (this.Edges[j].GetHead() == NetlistIndex)
                    {

                        //Add the Tail Netlists to the Netlist(k) BackCone List.
                        this.Vertices[NetlistIndex].AddNetlistIndexTOBackCone(this.Edges[j].GetTail());
                        // Add the Tail Netlist code to the Verilog Code

                        //Add the Netlist members in the BackCone List of each tail Netlist to Netlist(k) List.
                        TailBackConeList = this.Vertices[this.Edges[j].GetTail()].GetNumberofBackConeNetlistList();
                        if (TailBackConeList.Count > 0)
                            for (int i = 0; i < TailBackConeList.Count; i++)
                                this.Vertices[NetlistIndex].AddNetlistIndexTOBackCone(TailBackConeList[i]);

                        //Clear it to be ready for the next tail
                        //TailBackConeList.Clear();
                    }






            }










        }//End of BackConeNetlistLists calclation Function

    }
}
