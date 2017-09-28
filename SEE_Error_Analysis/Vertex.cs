using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEE_Error_Analysis
{
    class Vertex
    {


        string VertexName;
        int VertexNum;
        string GateCode;
        bool LogicValue;
        bool GoldValue;
        int ValidValue;
        string verilogFunction;
        string eqnFunction;
        string backConeVerilog;
        int vertexParity;

        List<int> NumberofBackConeNetlist;
        //int NodePredessor;
        public Vertex(string Vertex_Name, int Vertex_Num, string Gate_Code, string Verilog_code)
        {
            this.VertexName = Vertex_Name;
            this.VertexNum = Vertex_Num;
            GateCode = Gate_Code;
            LogicValue = false;
            ValidValue = 0;
            NumberofBackConeNetlist = new List<int>();
            verilogFunction = Verilog_code;
            backConeVerilog = "";
            vertexParity = -1;

        }


        public int getVertexParity()
        {
            return vertexParity;
        }

        public void setVertexParity(int vertex_Parity)
        {

            vertexParity = vertex_Parity;
        }


        public string getVerilogFunction()
        {
            return verilogFunction;
        }

        public void setVerilogFunction(string Verilog_Function)
        {

            verilogFunction = Verilog_Function;
        }
        public string geteqnFunction()
        {
            return eqnFunction;
        }

        public void seteqnFunction(string eqn_Function)
        {

            eqnFunction = eqn_Function;
        }
        public int GetNumberofBackConeNetlists()
        {
            return this.NumberofBackConeNetlist.Count;

        }
        public void AddNetlistIndexTOBackCone(int Netlist_index)
        {
            if (!this.NumberofBackConeNetlist.Contains(Netlist_index))
                this.NumberofBackConeNetlist.Add(Netlist_index);

        }
        public List<int> GetNumberofBackConeNetlistList()
        {
            return NumberofBackConeNetlist;
        }



        public void SetVertexName(string Vertex_Name)
        {
            this.VertexName = Vertex_Name;
        }
        public string GetVertexName()
        {
            return this.VertexName;
        }
        public void SetVertexNum(int Vertex_Num)
        {
            this.VertexNum = Vertex_Num;
        }
        /*public void SetNodePredessor(int NodePredessor)
        {
            this.NodePredessor = NodePredessor;
        }*/
        public void SetGateCode(string GateCode)
        {
            this.GateCode = GateCode;
        }
        public int GetVertexNum()
        {
            return this.VertexNum;
        }
        public string GetGateCode()
        {
            return this.GateCode;
        }
        public int GetValueStatue()
        {
            return this.ValidValue;
        }
        public bool GetlogicValue()
        {
            return this.LogicValue;
        }
        public bool GetGoldValue()
        {
            return this.GoldValue;
        }
        public string getBackConeVerilog()
        {
            return backConeVerilog;
        }

        public void setBackConeVerilog(string BackConde_Verilog)
        {
            backConeVerilog = BackConde_Verilog;
        }

        public void SetValueStatue(int Valid_Value)
        {
            this.ValidValue = Valid_Value;
        }
        public void SetlogicValue(bool logic_value)
        {
            this.LogicValue = logic_value;

        }
        public void SetGoldValue(bool Gold_value)
        {

            this.GoldValue = Gold_value;
        }

    }
}
