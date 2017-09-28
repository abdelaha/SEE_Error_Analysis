using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SEE_Error_Analysis
{
    public partial class Form1 : Form
    {

        Graph CircuitGraph = new Graph();
        /*List<string> Circuitnetlist = new List<string>();
        List<string> CircuitInputs = new List<string>();
        List<string> CircuitOutputs = new List<string>();*/


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Input = InputText.Text;
            string Temp, GateName;
            string VertexName, EdgeName;
            int[] output_num = new int[100];
            int substring_startIndex, substring_endIndex;

            //  try
            //  {
            // Read the output and Input List
            // Read Input
            // Example: input i_0_, i_1_, i_2_, i_3_, i_4_, i_5_, i_6_, i_7_, i_8_, i_9_, i_10_, i_11_, i_12_, i_13_;
            this.listBox1.Items.Clear();
            substring_startIndex = Input.IndexOf("input");
            substring_endIndex = Input.IndexOf(";", substring_startIndex);
            Temp = Input.Substring(substring_startIndex + 5, (substring_endIndex - substring_startIndex)).Trim();  //+5 in order to avoid copying "input" word
            Input = Input.Substring(substring_endIndex + 1);

            //
            while (Temp.Length > 0)
            {
                string InputName;   
                if (Temp.Contains(","))
                {
                    InputName = Temp.Substring(0, Temp.IndexOf(",")).Trim();
                    Temp = Temp.Substring(Temp.IndexOf(",") + 1).Trim();

                }
                else // Last input
                {
                    InputName = Temp.Substring(0, Temp.IndexOf(";")).Trim();
                    Temp = "";
                }
                this.listBox1.Items.Add(InputName);
                this.CircuitGraph.AddPrimaryInput(InputName);
            }



            // Read output
            // Example: output o_0_, o_1_, o_2_, o_3_, o_4_, o_5_, o_6_, o_7_ ;
            this.listBox2.Items.Clear();
            substring_startIndex = Input.IndexOf("output");
            substring_endIndex = Input.IndexOf(";", substring_startIndex);
            Temp = Input.Substring(substring_startIndex + 6, (substring_endIndex - substring_startIndex)).Trim();  //+6 in order to avoid copying "output" word
            Input = Input.Substring(substring_endIndex + 1);

            //
            while (Temp.Length > 0)
            {
                string OutputName;
                if (Temp.Contains(","))
                {
                    OutputName = Temp.Substring(0, Temp.IndexOf(",")).Trim();
                    Temp = Temp.Substring(Temp.IndexOf(",") + 1).Trim();

                }
                else // Last output
                {
                    OutputName = Temp.Substring(0, Temp.IndexOf(";")).Trim();
                    Temp = "";
                }
                this.listBox2.Items.Add(OutputName);
            }



            // Read Circuit internal netlist.
            /* Example:  wire    net_155, net_156, net_157, net_158, net_159, net_160, net_161,
                                 net_162, net_163, net_164, net_165, net_166, net_167, net_168,
                                 net_169, net_170, net_171, net_172, net_173, net_174, net_175,
                                 net_176, net_177, net_178, net_179, net_180, net_181, net_182,
                                 net_183, net_184, net_185, net_186, net_187, net_188, net_189,
                                 net_190, net_191, net_192, net_193, net_194, net_195, net_196,
                                 net_197, net_198, net_199, net_200, net_201, net_202, net_203,
                                 net_204, net_205, net_206, net_207, net_209, net_208, net_210,
                                 net_211, net_212, net_213, net_214, net_215, net_216, net_217,
                                 net_218, net_219, net_220, net_221, net_222, net_223, net_224,
                                 net_225, net_226, net_227, net_228, net_229, net_230, net_231,
                                 net_232, net_233, net_234;*/

            this.listBox3.Items.Clear();
            do
            {
                substring_startIndex = Input.IndexOf("wire");
                substring_endIndex = Input.IndexOf(";", substring_startIndex);
                Temp = Input.Substring(substring_startIndex + 4, (substring_endIndex - substring_startIndex)).Trim();  //+5 in order to avoid copying "wire" word
                Input = Input.Substring(substring_endIndex + 1);
                //
                while (Temp.Length > 0)
                {
                    string NetlistName;
                    if (Temp.Contains(","))
                    {
                        NetlistName = Temp.Substring(0, Temp.IndexOf(",")).Trim();
                        Temp = Temp.Substring(Temp.IndexOf(",") + 1).Trim();

                    }
                    else // Last Netlist
                    {
                        NetlistName = Temp.Substring(0, Temp.IndexOf(";")).Trim();
                        Temp = "";
                    }
                    this.listBox3.Items.Add(NetlistName);
                }

            } while (Input.Contains("wire"));




            // Read Circuit structure to create Graph Vertices and arcs
            while (Input.Length > 0 && Input.Trim() != "endmodule")
            {
                // Get the first gate(Line) in the string temp
                Temp = Input.Substring(0, Input.IndexOf(";"));
                Temp = Temp.Trim();
                //Remove this line from the input string
                Input = Input.Substring(Input.IndexOf(";") + 1).Trim();
                // Read the Gate name(Code) of the output Vertex
                GateName = Temp.Substring(0, Temp.IndexOf(" "));   //First word in Temp string

                // Add the vertices of this gate
                int HeadStartIndex, HeadIndex, TailIndex;
                string HeadVertex, HeadName;
                //Get the Head Vertex  syntax label .XX(Output)
                HeadVertex = Temp.Substring(Temp.LastIndexOf("."), (Temp.IndexOf("(", Temp.LastIndexOf(".")) - Temp.LastIndexOf(".")));

                HeadStartIndex = Temp.IndexOf(HeadVertex) + HeadVertex.Length + 1;
                HeadName = Temp.Substring(HeadStartIndex, (Temp.IndexOf(")", HeadStartIndex) - HeadStartIndex)).Trim();
                // Add Output Vertex of this Gate
                //Check if exist before
                HeadIndex = CircuitGraph.findVertexByName(HeadName);
                if (HeadIndex < 0)
                    HeadIndex = CircuitGraph.AddVertex(HeadName, 0, GateName, Temp);
                else //Edit the Gate Name of it
                {
                    CircuitGraph.SetVertexGateCode(HeadIndex, GateName);
                    CircuitGraph.updateVertexVerilogFunction(HeadIndex, Temp);
                }

              
                //Use a loop to create the rest tail vertices of this gate

                bool done = false;
                int VertexStartIndex = Temp.IndexOf(".");
                int BracketIndex = Temp.IndexOf("(", VertexStartIndex);
                while (!done)
                {
                    VertexName = "";
                    VertexName = Temp.Substring(BracketIndex + 1, (Temp.IndexOf(")", BracketIndex) - BracketIndex - 1)).Trim();
                    //Check if exist before
                    TailIndex = CircuitGraph.findVertexByName(VertexName);
                    if (TailIndex < 0)
                        TailIndex = CircuitGraph.AddVertex(VertexName, 0, "", "");
                    EdgeName = Temp.Substring(VertexStartIndex + 1, (BracketIndex - VertexStartIndex - 1)).Trim();
                    CircuitGraph.AddEdge(HeadIndex, TailIndex, EdgeName, 0.0);
                
                    // update the new BracketIndex and VertexStartIndex
                    VertexStartIndex = Temp.IndexOf(".", BracketIndex);
                    BracketIndex = Temp.IndexOf("(", VertexStartIndex);
                    if (BracketIndex + 1 >= HeadStartIndex)
                        done = true;

                }
            }
            //Order the Graph Nodes 
            //Set Input Veritices to be the first and the output ones to be the last

            //set inputs number
            for (int i = 0; i < this.listBox1.Items.Count; i++)
                CircuitGraph.SetVertexNumber(this.listBox1.Items[i].ToString(), i + 1);

            //order the graph

            this.CircuitGraph.OrderVerticesbyNumber(this.listBox1.Items.Count);


            //Calculate the BackCone Netlists List for each Netlist
            this.CircuitGraph.CalculateTheBackConeData();


            /*  }
              catch(ArgumentNullException ex) 
              {
                  MessageBox.Show("CODE01: ERROR IN THE CODE, PLEASE CHECK THE SYNTAX\r\t\n" + ex.Message);

              }
              catch(Exception ax)
              {
                   MessageBox.Show("CODE02: ERROR IN THE CODE, PLEASE CHECK THE SYNTAX\r\t\n"+ ax.Message);
              }*/
            output.Text = "Number of Vertices: \r\t" + CircuitGraph.GetNumberOfNodes().ToString() + "\r\n";
            output.Text += "Number of inputs: \r\t" + this.listBox1.Items.Count.ToString() + "\r\n";
            output.Text += "Number of outpus: \r\t" + this.listBox2.Items.Count.ToString() + "\r\n";
            output.Text += "Number of Netlist: \r\t" + this.listBox3.Items.Count.ToString() + "\r\n";

        }  //********************************* End of Circuit Analysis


        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {


            List<bool> InputValue = new List<bool>();

            int value = int.Parse(this.textBox_InputTV.Text);
            string binary = Convert.ToString(value, 2);

            // set the input value
            for (int i = 1; i <= this.listBox1.Items.Count; i++)
                if (i <= binary.Length)
                {
                    if (binary[binary.Length - i] == '1')
                        this.CircuitGraph.SetVertexLogicValue(true, true, i);
                    else
                        this.CircuitGraph.SetVertexLogicValue(false, false, i);
                    this.listBox1.Items[i - 1] += " " + binary[binary.Length - i].ToString();
                }
                else
                {
                    this.CircuitGraph.SetVertexLogicValue(false, false, i);
                    this.listBox1.Items[i - 1] += " 0";
                }



            //Simulate the Circuit
            for (int i = this.listBox1.Items.Count + 1; i <= this.CircuitGraph.GetNumberOfNodes(); i++)
            {
                //Get Vertex Index
                bool NetlistLogicValue;

                InputValue.Clear();

                int VertexIndex = this.CircuitGraph.findVertexByNum(i);

                //Get EdgeNames, InputVertex Indices, and InputVertices logic Value

                // Get the binary values of Netlists which are connected to the inputs of the current gate (They will be returned ordered as they written in Verilog)
                //Please, make sure that the Digital Library follow the same order.
                InputValue = this.CircuitGraph.FindNetlistInputValue(VertexIndex);
                string AbsoluteGateName = this.CircuitGraph.GetGateName(VertexIndex).Trim();

                AbsoluteGateName = AbsoluteGateName.Substring(0, AbsoluteGateName.LastIndexOf("X"));
                switch (AbsoluteGateName)
                {
                    case "MUX21":
                        NetlistLogicValue = DigitalLibrary.MUX21(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "AND4":
                        NetlistLogicValue = DigitalLibrary.AND4(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;
                    case "AND3":
                        NetlistLogicValue = DigitalLibrary.AND3(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "AND2":
                        NetlistLogicValue = DigitalLibrary.AND2(InputValue[0], InputValue[1]);
                        break;
                    case "NAND4":
                        NetlistLogicValue = DigitalLibrary.NAND4(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;

                    case "NAND2":
                        NetlistLogicValue = DigitalLibrary.NAND2(InputValue[0], InputValue[1]);
                        break;
                    case "NAND3":
                        NetlistLogicValue = DigitalLibrary.NAND3(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "INV":

                        NetlistLogicValue = DigitalLibrary.INV(InputValue[0]);
                        break;
                    case "NOR3":
                        NetlistLogicValue = DigitalLibrary.NOR3(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "NOR4":
                        NetlistLogicValue = DigitalLibrary.NOR4(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;
                    case "NOR2":
                        NetlistLogicValue = DigitalLibrary.NOR2(InputValue[0], InputValue[1]);
                        break;
                    case "OR3":
                        NetlistLogicValue = DigitalLibrary.OR3(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "OR4":
                        NetlistLogicValue = DigitalLibrary.OR4(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;
                    case "OR2":
                    case "ISOLOR":
                        NetlistLogicValue = DigitalLibrary.OR2(InputValue[0], InputValue[1]);
                        break;
                    case "OA222":
                        NetlistLogicValue = DigitalLibrary.OA222(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4], InputValue[5]);
                        break;
                    case "OA22":
                        NetlistLogicValue = DigitalLibrary.OA22(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;
                    case "OA21":
                        NetlistLogicValue = DigitalLibrary.OA21(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "OA221":
                        NetlistLogicValue = DigitalLibrary.OA221(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4]);
                        break;

                    case "OAI21":

                        NetlistLogicValue = DigitalLibrary.OAI21(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "OAI22":
                        NetlistLogicValue = DigitalLibrary.OAI22(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;
                    case "OAI221":
                        NetlistLogicValue = DigitalLibrary.OAI221(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4]);
                        break;
                    case "OAI222":
                        NetlistLogicValue = DigitalLibrary.OAI222(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4], InputValue[5]);
                        break;
                    case "AO21":
                        NetlistLogicValue = DigitalLibrary.AO21(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "AO22":
                        NetlistLogicValue = DigitalLibrary.AO22(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;
                    case "AO221":
                        NetlistLogicValue = DigitalLibrary.AO221(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4]);
                        break;
                    case "AO222":
                        NetlistLogicValue = DigitalLibrary.AO222(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4], InputValue[5]);
                        break;


                    case "AOI21":
                        NetlistLogicValue = DigitalLibrary.AOI21(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "AOI22":
                        NetlistLogicValue = DigitalLibrary.AOI22(InputValue[0], InputValue[1], InputValue[2], InputValue[3]);
                        break;
                    case "AOI221":
                        NetlistLogicValue = DigitalLibrary.AOI221(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4]);
                        break;
                    case "AOI222":
                        NetlistLogicValue = DigitalLibrary.AOI222(InputValue[0], InputValue[1], InputValue[2], InputValue[3], InputValue[4], InputValue[5]);
                        break;

                    case "ISOLAND":
                        NetlistLogicValue = DigitalLibrary.ISOLAND(InputValue[0], InputValue[1]);
                        break;
                    case "XNOR2":
                        NetlistLogicValue = DigitalLibrary.XNOR2(InputValue[0], InputValue[1]);
                        break;
                    case "XNOR3":
                        NetlistLogicValue = DigitalLibrary.XNOR3(InputValue[0], InputValue[1], InputValue[2]);
                        break;
                    case "XOR2":
                        NetlistLogicValue = DigitalLibrary.XOR2(InputValue[0], InputValue[1]);
                        break;
                    default:
                        MessageBox.Show("Invalid Gate name: " + this.CircuitGraph.GetGateName(VertexIndex).Trim());
                        NetlistLogicValue = false;
                        break;

                }
                this.CircuitGraph.SetVertexLogicValue(NetlistLogicValue, NetlistLogicValue, i);


            }

            //output Value
            string output = "";
            for (int i = 0; i < this.listBox2.Items.Count; i++)
            {
                //find output index
                int PortIndex = this.CircuitGraph.findVertexByName(this.listBox2.Items[i].ToString());
                //add its value to the output string
                if (this.CircuitGraph.GetVertexLogicValue(PortIndex))
                {
                    output = "1" + output;
                    this.listBox2.Items[i] += "  1";
                }
                else
                {
                    output = "0" + output;
                    this.listBox2.Items[i] += "  0";
                }

            }
            // display all netlist value
            for (int i = 0; i < this.listBox3.Items.Count; i++)
            {
                //find output index
                int PortIndex = this.CircuitGraph.findVertexByName(this.listBox3.Items[i].ToString());
                //add its value to the output string
                if (this.CircuitGraph.GetVertexLogicValue(PortIndex))
                    this.listBox3.Items[i] += "  1";
                else
                    this.listBox3.Items[i] += "  0";

            }
            MessageBox.Show(output);


        }

        private void button4_Click(object sender, EventArgs e)
        {

            List<bool> InputValue = new List<bool>();
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Columns.Add("NetlistName", "Netlist Name");
            this.dataGridView1.Columns.Add("NetlistA", "propagated Errors to Outputs (Forward Cone Errors)");
            this.dataGridView1.Columns.Add("NetlistB", "propagated Errors to Netlists (BackCone Errors)");
            this.dataGridView1.Columns.Add("NetlistC", "Number of BackCone Netlists (BackCone Area)");
            this.dataGridView1.Columns.Add("NetlistD", "BackCone Netlists");
            this.dataGridView1.Columns.Add("NetlistE", "BackCone HDL");

            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Columns.Clear();
            this.dataGridView2.Columns.Add("Vectors", "Input Vector");
            this.dataGridView2.Columns.Add("NetlistActive", "Number of Active Netlist");

            double TotalOutputErrors = 0;
            double TotalOutputPinsErrors = 0;
            List<int> Netlist_BackConeErrors = new List<int>();

            //----- This variables are used to calculate the number of active netlists for each test vector  (Nihaar Work)
            List<long> ActiveNetlist = new List<long>();


            // To Speed the calculation of running all input cases, we rather use a random value to jump in the input space. the jump step is determined by how fast I want to calculate the required numbers
            Random random = new Random();
            int randomNumber = 1;
            // int MinRand, MaxRand;



            //initilization 
            for (int k = 0; k < this.CircuitGraph.GetNumberOfNodes(); k++)
                Netlist_BackConeErrors.Add(0);
            //Initilize the Active Netlist Vector with Zeros
            for (int TestVector = 0; TestVector < Math.Pow(2, this.listBox1.Items.Count); TestVector++)
                ActiveNetlist.Add(0);

            //Activate the progress bar
            this.progressBar1.Visible = true;
            this.progressBar1.Value = 0;



            //Calculate Min, Max Rand Value
            // this.RunLevelBar.Value


            //Simulate the circuit for all inputs and repeat it for each netlist as a failure node to calculate the propagated errors

            //THis loop Iterate in Netlist in which I will inject errors in it. Moreover, I don't inject errors in the primary inputs
            for (int NetlistIndex = this.listBox1.Items.Count + 1; NetlistIndex <= this.CircuitGraph.GetNumberOfNodes(); NetlistIndex++)
            {
                int Error_Count = 0;
                bool OutputPortError = false;
                string InjectedNetlistName = this.CircuitGraph.GetVertexName(this.CircuitGraph.findVertexByNum(NetlistIndex));
                //  if (this.listBox3.Items[NetlistIndex].ToString() == "net_213")
                //     MessageBox.Show("Debug");

                this.progressBar1.Value = (NetlistIndex - this.listBox1.Items.Count) * 100 / (this.CircuitGraph.GetNumberOfNodes() - this.listBox1.Items.Count);
                this.progressBar1.Update();

                // Iterate in the input Vectors

                for (int TestVector = 0; TestVector < Math.Pow(2, this.listBox1.Items.Count); TestVector += randomNumber)
                {
                    string binary = Convert.ToString(TestVector, 2);



                    //Calculate the jump step
                    if (radioButton1.Checked)
                        randomNumber = random.Next(200, 300);
                    else if (radioButton2.Checked)
                        randomNumber = random.Next(150, 200);
                    else if (radioButton3.Checked)
                        randomNumber = random.Next(50, 100);
                    else if (radioButton4.Checked)
                        randomNumber = random.Next(1, 50);
                    else if (radioButton5.Checked)
                        randomNumber = random.Next(1, 20);
                    else
                        randomNumber = 1;



                    // set the input value
                    for (int i = 1; i <= this.listBox1.Items.Count; i++)
                        if (i <= binary.Length)
                        {
                            if (binary[binary.Length - i] == '1')
                                this.CircuitGraph.SetVertexLogicValue(true, true, i);
                            else
                                this.CircuitGraph.SetVertexLogicValue(false, false, i);

                        }
                        else
                        {
                            this.CircuitGraph.SetVertexLogicValue(false, false, i);

                        }



                    //Simulate the Circuit
                    //Caution: The Netlists are ordered from 1 to their count (Not from Zero).
                    for (int i = this.listBox1.Items.Count + 1; i <= this.CircuitGraph.GetNumberOfNodes(); i++)
                    {

                        //Initialization and definiation
                        bool NetlistLogicValue, LogicValue, GoldValue;

                        InputValue.Clear();
                        GoldValue = false;
                        LogicValue = false;



                        //Get Vertex Index

                        int VertexIndex = this.CircuitGraph.findVertexByNum(i);

                        //Get EdgeNames, InputVertex Indices, and InputVertices logic Value

                        // Get the binary values of Netlists which are connected to the inputs of the current gate (They will be returned ordered as they written in Verilog)
                        //Please, make sure that the Digital Library follow the same order.
                        InputValue = this.CircuitGraph.FindNetlistInputValue(VertexIndex);

                        //Calculate the Netlist Value and the Gold Value
                        for (int k = 0; k < 2; k++)
                        {

                            string AbsoluteGateName = this.CircuitGraph.GetGateName(VertexIndex).Trim();
                           
                           // if (AbsoluteGateName == "")
                             //   continue;

                            AbsoluteGateName = AbsoluteGateName.Substring(0, AbsoluteGateName.LastIndexOf("X"));
                            switch (AbsoluteGateName)
                            {
                                case "MUX21":
                                    NetlistLogicValue = DigitalLibrary.MUX21(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AND4":
                                    NetlistLogicValue = DigitalLibrary.AND4(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AND3":
                                    NetlistLogicValue = DigitalLibrary.AND3(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AND2":
                                    NetlistLogicValue = DigitalLibrary.AND2(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)]);
                                    break;
                                case "NAND4":
                                    NetlistLogicValue = DigitalLibrary.NAND4(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;
                                case "NAND2":
                                    NetlistLogicValue = DigitalLibrary.NAND2(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)]);
                                    break;
                                case "NAND3":
                                    NetlistLogicValue = DigitalLibrary.NAND3(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "INV":
                                    NetlistLogicValue = DigitalLibrary.INV(InputValue[0 + (k * InputValue.Count / 2)]);
                                    break;
                                case "NOR3":
                                    NetlistLogicValue = DigitalLibrary.NOR3(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "NOR4":
                                    NetlistLogicValue = DigitalLibrary.NOR4(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;
                                case "NOR2":
                                    NetlistLogicValue = DigitalLibrary.NOR2(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OR3":
                                    NetlistLogicValue = DigitalLibrary.OR3(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OR4":
                                    NetlistLogicValue = DigitalLibrary.OR4(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;
                                case "ISOLOR":
                                case "OR2":
                                    NetlistLogicValue = DigitalLibrary.OR2(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OA222":
                                    NetlistLogicValue = DigitalLibrary.OA222(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)], InputValue[5 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OA22":
                                    NetlistLogicValue = DigitalLibrary.OA22(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;

                                case "OA21":
                                    NetlistLogicValue = DigitalLibrary.OA21(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;

                                case "OA221":
                                    NetlistLogicValue = DigitalLibrary.OA221(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OAI21":
                                    NetlistLogicValue = DigitalLibrary.OAI21(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OAI22":
                                    NetlistLogicValue = DigitalLibrary.OAI22(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OAI221":
                                    NetlistLogicValue = DigitalLibrary.OAI221(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)]);
                                    break;
                                case "OAI222":
                                    NetlistLogicValue = DigitalLibrary.OAI222(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)], InputValue[5 + (k * InputValue.Count / 2)]);
                                    break;

                                case "AO21":
                                    NetlistLogicValue = DigitalLibrary.AO21(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AO22":
                                    NetlistLogicValue = DigitalLibrary.AO22(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AO221":
                                    NetlistLogicValue = DigitalLibrary.AO221(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AO222":
                                    NetlistLogicValue = DigitalLibrary.AO222(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)], InputValue[5 + (k * InputValue.Count / 2)]);
                                    break;

                                case "AOI21":
                                    NetlistLogicValue = DigitalLibrary.AOI21(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AOI22":
                                    NetlistLogicValue = DigitalLibrary.AOI22(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AOI221":
                                    NetlistLogicValue = DigitalLibrary.AOI221(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)]);
                                    break;
                                case "AOI222":
                                    NetlistLogicValue = DigitalLibrary.AOI222(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)], InputValue[3 + (k * InputValue.Count / 2)], InputValue[4 + (k * InputValue.Count / 2)], InputValue[5 + (k * InputValue.Count / 2)]);
                                    break;




                                case "ISOLAND":
                                    NetlistLogicValue = DigitalLibrary.ISOLAND(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)]);
                                    break;
                                case "XNOR2":
                                    NetlistLogicValue = DigitalLibrary.XNOR2(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)]);
                                    break;
                                case "XNOR3":
                                    NetlistLogicValue = DigitalLibrary.XNOR3(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)], InputValue[2 + (k * InputValue.Count / 2)]);
                                    break;
                                case "XOR2":
                                    NetlistLogicValue = DigitalLibrary.XOR2(InputValue[0 + (k * InputValue.Count / 2)], InputValue[1 + (k * InputValue.Count / 2)]);
                                    break;
                                default:
                                    MessageBox.Show("Invalid Gate name: " + this.CircuitGraph.GetGateName(VertexIndex).Trim());
                                    NetlistLogicValue = false;
                                    break;

                            }
                            if (k == 0)
                                LogicValue = NetlistLogicValue;
                            else
                                GoldValue = NetlistLogicValue;
                        }
                        if (this.checkBox1.Checked & this.listBox4.Items.Contains(this.CircuitGraph.GetVertexName(VertexIndex)))
                        // if (this.checkBox1.Checked & (this.CircuitGraph.GetVertexName(VertexIndex).Trim() == "o_2_"))                    /// for Debugging
                        {
                            this.CircuitGraph.SetVertexLogicValue(GoldValue, GoldValue, i);
                        }
                        else
                            if (this.CircuitGraph.GetVertexName(VertexIndex) == InjectedNetlistName)
                                this.CircuitGraph.SetVertexLogicValue(!LogicValue, GoldValue, i);
                            else
                            {
                                this.CircuitGraph.SetVertexLogicValue(LogicValue, GoldValue, i);
                                //Increment the Back_Cone Error of the simulated  Netlist (VertexIndex)
                                if (LogicValue != GoldValue)
                                    Netlist_BackConeErrors[VertexIndex]++;


                            }







                    }

                    //Check output  to calculate number of errors in this node.
                    OutputPortError = false;
                    for (int i = 0; i < this.listBox2.Items.Count; i++)
                    {
                        //find output index
                        int PortIndex = this.CircuitGraph.findVertexByName(this.listBox2.Items[i].ToString());
                        //compare its value to the Gold output 
                        if (this.CircuitGraph.GetVertexLogicValue(PortIndex) != this.CircuitGraph.GetVertexGoldValue(PortIndex))
                        {

                            OutputPortError = true;
                        }

                    }
                    if (OutputPortError)
                    {
                        TotalOutputErrors++;
                        Error_Count++;


                        // increament the Input Vector Active Netlist.
                        ActiveNetlist[TestVector]++;
                    }


                }  // End of the Test vectors iteration loops 



                //Calculate the total output pin errors for the whole circuit.
                TotalOutputPinsErrors += Error_Count;
                // Add in the Grid the Netlist Name and its number of Errors that successfully mange to propagate to the primary output pins 
                //  if (NetlistIndex < this.listBox3.Items.Count)
                //this.dataGridView1.Rows.Add(this.listBox3.Items[NetlistIndex], Error_Count.ToString(),"");//

                //Get the Name of Netlist in the back cone of the current netlist
                string BackConeNetlistNames = this.CircuitGraph.GetBackConeNetlistListNames(this.CircuitGraph.findVertexByName(InjectedNetlistName));
                string BackCondeHDL = this.CircuitGraph.getBackConeVerilog(this.CircuitGraph.findVertexByName(InjectedNetlistName));

                this.dataGridView1.Rows.Add(InjectedNetlistName, Error_Count.ToString(), "", this.CircuitGraph.GetNumberofBackConeNetlist(this.CircuitGraph.findVertexByName(InjectedNetlistName)).ToString(), BackConeNetlistNames, BackCondeHDL);



            }

            //Fill the DataGrid with the output vector.s
            this.dataGridView1.Rows.Add("TotoalOutputPinsErrors ", TotalOutputPinsErrors.ToString(), "");
            this.dataGridView1.Rows.Add("TotalOutputErrors ", TotalOutputErrors.ToString(), "");


            // Fill the DataGrid with the BackCone Errors Values after finishing the simulation of injecting all possible Netlists( including the Output Gates)
            for (int k = 0; k < this.CircuitGraph.GetNumberOfNodes() - this.listBox1.Items.Count; k++)
            {

                this.dataGridView1["NetlistB", k].Value = Netlist_BackConeErrors[this.CircuitGraph.findVertexByName(this.dataGridView1["NetlistName", k].Value.ToString().Trim())].ToString();
            }

            //Print the Active Netlist Calculation output in the Output prompt.

#if false  
            for (int ActiveNetlist_index = 0; ActiveNetlist_index < Math.Pow(2, this.listBox1.Items.Count); ActiveNetlist_index++)
                this.dataGridView2.Rows.Add(ActiveNetlist_index.ToString(), ActiveNetlist[ActiveNetlist_index].ToString());
                
#endif
            //Deactivate the progress bar
            this.progressBar1.Visible = false;


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int SelectedIndex = this.listBox3.SelectedIndex;
            if (SelectedIndex >= 0)
                if (!this.listBox4.Items.Contains(this.listBox3.Items[SelectedIndex]))
                    this.listBox4.Items.Add(this.listBox3.Items[SelectedIndex]);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int SelectedIndex = this.listBox4.SelectedIndex;

            if (SelectedIndex >= 0)
                this.listBox4.Items.Remove(this.listBox4.Items[SelectedIndex]);
        }

        private void button6_Click(object sender, EventArgs e)
        {


            //Variables Definiation and Inizliation
            int NetlistIndex = 0; //To Reference the Netlist (K) with its index instead of Number
            List<int> TailBackConeList = new List<int>();
            string backconeVerilogCode;
            string verilog_inputs = "";
            string verilog_wires = "";
            string verilog_output = "";
            //IO file streaming
            FileStream My_file;



            //Loop in the Netlists from the Netlist Number (inputs + 1) the first netlist after the primary Input to the Last Netlist (Last Output)
            for (int k = this.listBox1.Items.Count + 1; k <= this.CircuitGraph.GetNumberOfNodes(); k++)
            {  // Main loop




                //Initilization
                //Get the require information about the target netlist
                NetlistIndex = this.CircuitGraph.findVertexByNum(k);
                TailBackConeList = this.CircuitGraph.GetBackConeList(NetlistIndex);

                verilog_inputs = "";
                verilog_wires = "";
                verilog_output = this.CircuitGraph.GetVertexName(NetlistIndex).Trim();

                My_file = File.Create("./Verilog/Cone_" + verilog_output.Trim() + ".v");

                // Calculate the Backcone verilog structure code
                //First, Add the verilog code of this netlist (k)
                backconeVerilogCode = "\r\n\r\t" + this.CircuitGraph.getVerilogFunction(NetlistIndex) + ";";
                //Then, Add the verilog code of each netlist in the backcone of netlist k
                foreach (int BackCondeIndex in TailBackConeList)
                {
                    if (!this.listBox1.Items.Contains(this.CircuitGraph.GetVertexName(BackCondeIndex)))
                    {
                        backconeVerilogCode += "\r\t" + this.CircuitGraph.getVerilogFunction(BackCondeIndex) + ";";
                        if (verilog_wires == "") // The first wire node

                            verilog_wires = this.CircuitGraph.GetVertexName(BackCondeIndex).Trim();
                        else
                            verilog_wires += ", " + this.CircuitGraph.GetVertexName(BackCondeIndex).Trim();
                    }
                    else
                        if (verilog_inputs == "")  // The first input node
                            verilog_inputs = this.CircuitGraph.GetVertexName(BackCondeIndex).Trim();
                        else
                            verilog_inputs += ", " + this.CircuitGraph.GetVertexName(BackCondeIndex).Trim();



                } // end of foreach




                //Finally, add the moduledefinations and endmondule tag
                string Tempdefination = "module Cone_" + verilog_output + " (" + verilog_output + ", " + verilog_inputs + " );";

                Tempdefination += "\r\n\tinput " + verilog_inputs + ";";
                Tempdefination += "\r\n\toutput " + verilog_output + ";";
                if (verilog_wires.Length > 0)
                    Tempdefination += "\r\n\twire " + verilog_wires + ";";


                backconeVerilogCode = Tempdefination + backconeVerilogCode;

                backconeVerilogCode += "\r\nendmodule";

                //Save the code in the Graph structure and verilog file
                this.CircuitGraph.setBackConeVerilog(backconeVerilogCode, NetlistIndex);
                Byte[] info = new UTF8Encoding(true).GetBytes("\r\n// " + verilog_output + "\r\n" + backconeVerilogCode + "\r\n\r\n");
                My_file.Write(info, 0, info.Length);

                My_file.Close();


            } // End of the main loop





        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<string> InputsName = new List<string>();
            for (int i = this.listBox1.Items.Count + 1; i <= this.CircuitGraph.GetNumberOfNodes(); i++)
            {
                //Get Vertex Index


                int VertexIndex = this.CircuitGraph.findVertexByNum(i);

                string netlistLogicEqn = this.CircuitGraph.GetVertexName(VertexIndex) + " = ";

                InputsName.Clear();
                //Get EdgeNames, InputVertex Indices, and InputVertices logic Value

                // Get the binary values of Netlists which are connected to the inputs of the current gate (They will be returned ordered as they written in Verilog)
                //Please, make sure that the Digital Library follow the same order.
                InputsName = this.CircuitGraph.FindNetlistInputsName(VertexIndex);
                string AbsoluteGateName = this.CircuitGraph.GetGateName(VertexIndex).Trim();

                AbsoluteGateName = AbsoluteGateName.Substring(0, AbsoluteGateName.LastIndexOf("X"));
                switch (AbsoluteGateName)
                {
                    case "MUX21":
                        // Z = (A and S') or (B and S)
                        netlistLogicEqn += "(!" + InputsName[2] + " * " + InputsName[0] + ") + (" + InputsName[2] + " * " + InputsName[1] + ");";
                        break;
                    case "AND4":
                        netlistLogicEqn += "(" + InputsName[0] + " * " + InputsName[1] + " * " + InputsName[2] + " * " + InputsName[3] + ");";
                        break;
                    case "AND3":
                        netlistLogicEqn += "(" + InputsName[0] + " * " + InputsName[1] + " * " + InputsName[2] + ");";
                        break;
                    case "AND2":
                        netlistLogicEqn += "(" + InputsName[0] + " * " + InputsName[1] + ");";
                        break;
                    case "NAND4":
                        netlistLogicEqn += "!(" + InputsName[0] + " * " + InputsName[1] + " * " + InputsName[2] + " * " + InputsName[3] + ");";
                        break;
                    case "NAND2":
                        netlistLogicEqn += "!(" + InputsName[0] + " * " + InputsName[1] + ");";
                        break;
                    case "NAND3":
                        netlistLogicEqn += "!(" + InputsName[0] + " * " + InputsName[1] + " * " + InputsName[2] + ");";
                        break;
                    case "INV":
                        netlistLogicEqn += "!" + InputsName[0] + ";";
                        break;
                    case "NOR3":
                        netlistLogicEqn += "!(" + InputsName[0] + " + " + InputsName[1] + " + " + InputsName[2] + ");";
                        break;
                    case "NOR4":
                        netlistLogicEqn += "!(" + InputsName[0] + " + " + InputsName[1] + " + " + InputsName[2] + " + " + InputsName[3] + ");";
                        break;
                    case "NOR2":
                        netlistLogicEqn += "!(" + InputsName[0] + " + " + InputsName[1] + ");";
                        break;
                    case "OR3":
                        netlistLogicEqn += "(" + InputsName[0] + " + " + InputsName[1] + " + " + InputsName[2] + " );";
                        break;
                    case "OR4":
                        netlistLogicEqn += "(" + InputsName[0] + " + " + InputsName[1] + " + " + InputsName[2] + " + " + InputsName[3] + ");";
                        break;
                    case "ISOLOR":
                    case "OR2":

                        netlistLogicEqn += "(" + InputsName[0] + " + " + InputsName[1] + ");";
                        break;
                    case "OA222":
                        //(IN1 | IN2) & (IN3 | IN4) & (IN5 | IN6)
                        netlistLogicEqn += "((" + InputsName[0] + " + " + InputsName[1] + ") * (" + InputsName[2] + " + " + InputsName[3] + ")* (" + InputsName[4] + " + " + InputsName[5] + ") );";
                        break;
                    case "OA22":
                        netlistLogicEqn += "((" + InputsName[0] + " + " + InputsName[1] + ") * (" + InputsName[2] + " + " + InputsName[3] + ") );";
                        break;
                    case "OA21":
                        netlistLogicEqn += "((" + InputsName[0] + " + " + InputsName[1] + ") * " + InputsName[2] + " );";
                        break;
                    case "OA221":
                        netlistLogicEqn += "((" + InputsName[0] + " + " + InputsName[1] + ") * (" + InputsName[2] + " + " + InputsName[3] + ")* " + InputsName[4] + " );";
                        break;
                    case "OAI21":
                        netlistLogicEqn += "!((" + InputsName[0] + " + " + InputsName[1] + ") * (" + InputsName[2] + ") );";
                        break;
                    case "OAI22":
                        netlistLogicEqn += "!((" + InputsName[0] + " + " + InputsName[1] + ") * (" + InputsName[2] + " + " + InputsName[3] + ") );";
                        break;
                    case "OAI221":
                        netlistLogicEqn += "!((" + InputsName[0] + " + " + InputsName[1] + ") * (" + InputsName[2] + " + " + InputsName[3] + ")* " + InputsName[4] + " );";
                        break;
                    case "OAI222":
                        netlistLogicEqn += "!((" + InputsName[0] + " + " + InputsName[1] + ") * (" + InputsName[2] + " + " + InputsName[3] + ")* (" + InputsName[4] + " + " + InputsName[5] + ") );";
                        break;
                    case "AO21":
                        netlistLogicEqn += "((" + InputsName[0] + " * " + InputsName[1] + ") + " + InputsName[2] + "  );";
                        break;
                    case "AO22":
                        netlistLogicEqn += "((" + InputsName[0] + " * " + InputsName[1] + ") + (" + InputsName[2] + " * " + InputsName[3] + ") );";
                        break;
                    case "AO221":
                        netlistLogicEqn += "((" + InputsName[0] + " * " + InputsName[1] + ") + (" + InputsName[2] + " * " + InputsName[3] + ") + " + InputsName[4] + " );";
                        break;
                    case "AO222":
                        netlistLogicEqn += "((" + InputsName[0] + " * " + InputsName[1] + ") + (" + InputsName[2] + " * " + InputsName[3] + ") + (" + InputsName[4] + " * " + InputsName[5] + ") );";
                        break;


                    case "AOI21":
                        netlistLogicEqn += "!((" + InputsName[0] + " * " + InputsName[1] + ") + " + InputsName[2] + "  );";
                        break;
                    case "AOI22":
                        netlistLogicEqn += "!((" + InputsName[0] + " * " + InputsName[1] + ") + (" + InputsName[2] + " * " + InputsName[3] + ") );";
                        break;
                    case "AOI221":
                        netlistLogicEqn += "!((" + InputsName[0] + " * " + InputsName[1] + ") + (" + InputsName[2] + " * " + InputsName[3] + ") + " + InputsName[4] + " );";
                        break;
                    case "AOI222":
                        netlistLogicEqn += "!((" + InputsName[0] + " * " + InputsName[1] + ") + (" + InputsName[2] + " * " + InputsName[3] + ") + (" + InputsName[4] + " * " + InputsName[5] + ") );";
                        break;

                    case "ISOLAND":
                        // (D & (!ISO));
                        netlistLogicEqn += "(" + InputsName[0] + " * !" + InputsName[1] + ");";
                        break;
                    case "XNOR2":
                        netlistLogicEqn += "!((" + InputsName[0] + " * !" + InputsName[1] + ") + (!" + InputsName[0] + " * " + InputsName[1] + "));";
                        break;
                    case "XNOR3":
                        netlistLogicEqn += "( (!" + InputsName[0] + " * !" + InputsName[1] + " * !" + InputsName[2]
                                        + ") + (" + InputsName[0] + " * !" + InputsName[1] + " * " + InputsName[2]
                                        + ") + (!" + InputsName[0] + " * " + InputsName[1] + " * " + InputsName[2]
                                        + ") + (" + InputsName[0] + " * " + InputsName[1] + " * !" + InputsName[2]
                                        + "));";
                        break;
                    case "XOR2":
                        //Y= ( (A and NOT B) or (NOT A and B) ) ;
                        netlistLogicEqn += "((" + InputsName[0] + " * !" + InputsName[1] + ") + (!" + InputsName[0] + " * " + InputsName[1] + "));";
                        break;
                    default:
                        MessageBox.Show("Invalid Gate name: " + this.CircuitGraph.GetGateName(VertexIndex).Trim());
                        netlistLogicEqn = "0;";
                        break;

                }
                this.CircuitGraph.setVertexEqn(netlistLogicEqn, VertexIndex);


            }

            ///  **************** Generate Backcone eqntions *********************** ///////////////////



            //Variables Definiation and Inizliation
            int NetlistIndex = 0; //To Reference the Netlist (K) with its index instead of Number
            List<int> TailBackConeList = new List<int>();
            string backconeEquations;
            string INORDER = "INORDER = ";
            string netlistName = "";
            string OUTORDER = "OUTORDER = ";
            string ABCCommands = "";                // -- For ABC synthesis tool 
            string LogicToolShScript = "";       // -- For Brian Sirwaski (f,h) logic Tool
            //IO file streaming

            FileStream My_file;

            //Create Directories
            if (Directory.Exists("./Equation"))
                Directory.Delete("./Equation", true);
            Directory.CreateDirectory("./Equation");

            if (Directory.Exists("./PLAFiles"))
                Directory.Delete("./PLAFiles", true);
            Directory.CreateDirectory("./PLAFiles");

            //Loop in the Netlists from the Netlist Number (inputs + 1) the first netlist after the primary Input to the Last Netlist (Last Output)
            for (int k = this.listBox1.Items.Count + 1; k <= this.CircuitGraph.GetNumberOfNodes(); k++)
            {  // Main loop




                //Initilization
                //Get the require information about the target netlist
                NetlistIndex = this.CircuitGraph.findVertexByNum(k);
                netlistName = this.CircuitGraph.GetVertexName(NetlistIndex).Trim();
                TailBackConeList = this.CircuitGraph.GetBackConeList(NetlistIndex);
                if (this.checkBox2.Checked)
                {
                    //check if the Golden Cone is a subcone from the Tail Cone; and if yes, remove it. 
                    foreach (string GoldenConeName in this.listBox4.Items)
                    {
                        int GoldenConeIndex = this.CircuitGraph.findVertexByName(GoldenConeName);
                        if (TailBackConeList.Contains(GoldenConeIndex))
                        {
                            //remove the cone by removing all of its netlist
                            List<int> GoldenConeList = new List<int>();
                            GoldenConeList = this.CircuitGraph.GetBackConeList(GoldenConeIndex);

                            //  TailBackConeList.Remove(GoldenConeIndex);

                            foreach (int GoldenConeListIndex in GoldenConeList)
                                TailBackConeList.Remove(GoldenConeListIndex);

                        }

                    }



                }




                INORDER = "INORDER = ";

                OUTORDER = "OUTORDER = " + netlistName;

                My_file = File.Create("./Equation/Cone_" + netlistName + ".eqn");

                // Calculate the Backcone verilog structure code
                //First, Add the verilog code of this netlist (k)
                backconeEquations = "\r\n\r\t" + this.CircuitGraph.getVetrexEqn(NetlistIndex);
                //Then, Add the verilog code of each netlist in the backcone of netlist k
                if (this.checkBox2.Checked)
                    foreach (int BackCondeIndex in TailBackConeList)
                    {
                        if (!this.listBox1.Items.Contains(this.CircuitGraph.GetVertexName(BackCondeIndex)) && !this.listBox4.Items.Contains(this.CircuitGraph.GetVertexName(BackCondeIndex)))
                            backconeEquations += "\r\t" + this.CircuitGraph.getVetrexEqn(BackCondeIndex);
                        else
                            INORDER += this.CircuitGraph.GetVertexName(BackCondeIndex).Trim() + "  ";



                    } // end of foreach


                else

                    foreach (int BackCondeIndex in TailBackConeList)
                    {
                        if (!this.listBox1.Items.Contains(this.CircuitGraph.GetVertexName(BackCondeIndex)))
                            backconeEquations += "\r\t" + this.CircuitGraph.getVetrexEqn(BackCondeIndex);
                        else
                            INORDER += this.CircuitGraph.GetVertexName(BackCondeIndex).Trim() + "  ";



                    } // end of foreach



                //Finally, Create the file with all together inorder, outorder, and equations


                backconeEquations = INORDER + ";\r\n\t" + OUTORDER + ";" + backconeEquations;



                //Save the code in eqn file

                Byte[] info = new UTF8Encoding(true).GetBytes(backconeEquations + "\r\n\r\n");
                My_file.Write(info, 0, info.Length);

                My_file.Close();

                ///Generate the ABC commands for this cone
                ///    read_eqn Cone_x.eqn
                ///    collapse
                ///    write Cone_net_292.pla
                ///    write Cone_net_292.pla  #This redundant command to mitigate unkown bug or strange behavior in ABC (software bugs Masking by redundant ^_^)
                ///    empty          
                ABCCommands += "read_eqn Equation/Cone_" + netlistName + ".eqn\r\n"
                            + "collapse\r\n"
                    //    + "write PLAFiles/Cone_" + netlistName + ".pla\r\n"
                            + "write PLAFiles/Cone_" + netlistName + ".pla\r\n"
                            + "empty\r\n";

                //  Create the shell script file for Brian software 

                /// Example 
                ///     ~/local/src/logicTool/bin/logicTool Cone_#.pla ConeName
                ///     tar -cf syn.ConeName.tar syn.o_0*.pla
                ///     rm -rf syn.ConeName*.pla
                ///     gzip syn.ConeName.tar
                ///

                // LogicToolShScript += "dos2unix  ./PLAFiles/Cone_" + netlistName + ".pla \r\n"                     //To avoid the PLA parsing error in the (logic Tool) Linux program  
                //use Linux ABC to avoid using dos2unix command
                LogicToolShScript += "/home/abdelaha/logicalMaskingTool/bin/logicTool ./PLAFiles/Cone_" + netlistName + ".pla " + netlistName + "| tee MTool." + netlistName + ".log\r\n "
                                    + "tar -cf syn." + netlistName + ".tar syn." + netlistName + "*.pla\r\n"
                                    + "rm -rf syn." + netlistName + "*.pla\r\n"
                                    + "gzip syn." + netlistName + ".tar\r\n\r\n";




            } // End of the main loop

            //Add quit command to ABCCommands
            ABCCommands += "quit\r\n";

            //Uncomment to use ABC in Linux and combine both in Run.sh commands    
            //Save the command in scr file

            /* My_file = File.Create("./ABCCommands.scr");

             Byte[] ABCCommandsByte = new UTF8Encoding(true).GetBytes(ABCCommands);
             My_file.Write(ABCCommandsByte, 0, ABCCommandsByte.Length);

             My_file.Close();*/


            //Combine ABCCommand and LogicToolShScript
            ABCCommands = "#/bin/sh \n SYN_TOOL=/home/abdelaha/ABCworkspace/abc-6144c8/abc \n $SYN_TOOL > ABCeqn2pla.log << EOF\n" + ABCCommands + "EOF\n";
            LogicToolShScript = ABCCommands + LogicToolShScript;
            //Save the Run Scritp in Run.sh file

            My_file = File.Create("./Run.sh");

            Byte[] LogicToolScriptByte = new UTF8Encoding(true).GetBytes(LogicToolShScript);
            My_file.Write(LogicToolScriptByte, 0, LogicToolScriptByte.Length);

            My_file.Close();




            //Execute the Run.sh script from Seawolf server



        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Variables and parameters
            OpenFileDialog browseFiles;
            string[] FileNames;
            string FilePath;
            StreamReader My_file;
            string candidateName;
            double candidateArea;
            double candidateMaskingFactor, candidateMaskingFactor2;
            double candidateSERreduction, candidateSERreduction2;
            double CircuitArea;
            double BackConeErrors, BackConeCellsCount, ForwardConeErrors;
            double AllPossibleErrors;   //in montocarlo this shoulb be the number of injected faults
            StreamWriter Data_file, Data_File_Old;


            //intilizations
            browseFiles = new OpenFileDialog();
            browseFiles.Title = "Browse dat files";
            browseFiles.Multiselect = true;
            FileNames = new string[] { };
            FilePath = "";
            candidateName = "";
            candidateArea = 0.0;
            candidateMaskingFactor = 0.0;
            candidateMaskingFactor2 = 0.0;
            candidateSERreduction = 0.0;
            candidateSERreduction2 = 0.0;
            CircuitArea = double.Parse(this.textBox1.Text.ToString());
            //All possible errors (2^n * number of netlist)
            AllPossibleErrors = (Math.Pow(2, this.listBox1.Items.Count)) * (this.listBox3.Items.Count);
            BackConeCellsCount = 0;
            BackConeErrors = 0;
            ForwardConeErrors = 0;
            Data_file = new StreamWriter("./GraphData.dat", false, Encoding.ASCII);
            Data_File_Old = new StreamWriter("./GraphDataOld.dat", false, Encoding.ASCII);
            //Write the header
            Data_file.WriteLine("candidateName \t candidateArea \t candidateMaskingFactor \t  candidateSERreduction");
            Data_File_Old.WriteLine("candidateName \t candidateArea \t candidateMaskingFactor \t candidateSER");

            //Import Data Files
            if (browseFiles.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {

                FilePath = browseFiles.FileName;
                FileNames = browseFiles.SafeFileNames;

                FilePath = FilePath.Substring(0, FilePath.LastIndexOf("\\") + 1);


            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "File Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



            foreach (string FileName in FileNames)
            {
                //Read Files
                My_file = new StreamReader(FilePath + FileName, Encoding.ASCII, true);
                candidateName = FileName.Substring(0, FileName.IndexOf("."));

                //Get Cone Data


                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row.Cells["NetlistName"].Value.ToString().Equals(candidateName))
                    {
                        //FileName Cone Cells
                        BackConeErrors = int.Parse(row.Cells["NetlistB"].Value.ToString());
                        //Backcone errors
                        BackConeCellsCount = int.Parse(row.Cells["NetlistC"].Value.ToString());
                        //ForwardCone errors 
                        ForwardConeErrors = int.Parse(row.Cells["NetlistA"].Value.ToString());
                        break;
                    }
                }



                //candidateName = netName;
                double coneArea = 0.0;
                while (!My_file.EndOfStream)
                {
                    //Parse Data Files
                    string candidateData = My_file.ReadLine();

                    string[] candiadateDataArray = candidateData.Split(' ');

                    candidateArea = double.Parse(candiadateDataArray[0]);

                    candidateMaskingFactor = double.Parse(candiadateDataArray[1]);

                    if (candiadateDataArray.Length == 3)
                        candidateName = candiadateDataArray[2];
                    else
                    {
                        coneArea = candidateArea;
                        candidateArea *= 2;
                    }


                    //OLD Metrecs
                    Data_File_Old.WriteLine(candidateName + "\t" + (100 * candidateArea / coneArea).ToString() + "\t" + (candidateMaskingFactor * 100).ToString() + "\t" + ((100 * candidateArea / coneArea) + (100 - (candidateMaskingFactor * 100))).ToString());



                    //THis is termparary for clip cadence circuit ONLY:
                    //***************************
                    //############################
                    //&&&&&&&&&&&&&&&&&&&&&&
                    AllPossibleErrors = 13122;
                    //**********************



                    //Calculate the new Metrecis
                    candidateArea = (candidateArea / CircuitArea) * 100;

                    candidateMaskingFactor2 = candidateMaskingFactor * (BackConeErrors / AllPossibleErrors) * ((ForwardConeErrors / (Math.Pow(2, this.listBox1.Items.Count))) * 100);
                    //candidateMaskingFactor = candidateMaskingFactor * (BackConeCellsCount/(double)(this.listBox2.Items.Count + this.listBox3.Items.Count))*100;

                    //candidateSERreduction = 100 - (candidateArea + (100 - candidateMaskingFactor));

                    candidateSERreduction2 = 100 - ((10 / CircuitArea) + (100 - candidateMaskingFactor2));

                    //Save Graph data


                    //Data_file.WriteLine(candidateName + "\t" + candidateArea + "\t" + candidateMaskingFactor + "\t" + candidateMaskingFactor2 + "\t" + candidateSERreduction + "\t" + candidateSERreduction2);////
                    Data_file.WriteLine(candidateName + "\t" + candidateArea + "\t" + candidateMaskingFactor2 + "\t" + candidateSERreduction2);




                }
                My_file.Close();





            }

            Data_file.Close();
            Data_File_Old.Close();



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Initialization 
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Columns.Clear();
            this.dataGridView2.Columns.Add("NetlistName", "Netlist Name");
            this.dataGridView2.Columns.Add("NetlistA", "Netlist Parity");

            //intial all outputs cell to have a parity 0
            foreach (string primaryOutputName in this.listBox2.Items)
                this.CircuitGraph.setVertexParity(0, CircuitGraph.findVertexByName(primaryOutputName));

            //calculate the parity of each node by traversing the network from the primary outputs. 
            for (int i = this.CircuitGraph.GetNumberOfNodes(); i > this.listBox1.Items.Count; i--)
            {
                //Get Output Parity
                int NodeParity = -2;
                int OutputParity = this.CircuitGraph.getVertexParity(this.CircuitGraph.findVertexByNum(i));
                string AbsoluteGateName = this.CircuitGraph.GetGateName(this.CircuitGraph.findVertexByNum(i)).Trim();

                AbsoluteGateName = AbsoluteGateName.Substring(0, AbsoluteGateName.LastIndexOf("X"));


                //Calculate only the input of Valid (unate) nodes
                if (OutputParity >= 0)
                    NodeParity = DigitalLibrary.calculate_Parity(AbsoluteGateName, OutputParity);
                //Get the Gate inputs
                List<int> InputIndices = new List<int>();

                InputIndices = this.CircuitGraph.FindNetlistInputsIndex(this.CircuitGraph.findVertexByNum(i));


                //Assign the parity to the inputs
                foreach (int InputNode in InputIndices)
                {

                    //Check for the current parity to check for biunate nodes)
                    if (this.CircuitGraph.getVertexParity(InputNode) == -1 || this.CircuitGraph.getVertexParity(InputNode) == NodeParity)
                        this.CircuitGraph.setVertexParity(NodeParity, InputNode);
                    else  //if the node has a multiple parity (for example gate with more than one fanout), it will be represented as  binate node. Parity = -2.
                        this.CircuitGraph.setVertexParity(-2, InputNode);

                }
                //Print out the Result in DataGrid View 
                this.dataGridView2.Rows.Add(this.CircuitGraph.GetVertexName(this.CircuitGraph.findVertexByNum(i)), OutputParity);
            }






        }

        private void button9_Click(object sender, EventArgs e)
        {


            //Variables Definiation and Inizliation
            string VerilogCode = "";
            string VerilogZeroApproxCondition = "";
            string VerilogOneApproxCondition = "";
            string verilog_inputs = "";
            string verilog_wires = "";
            string verilog_output = "";
            //IO file streaming
            FileStream My_file1, My_file0;



            //Build Verilog Code for input signals
            verilog_inputs = this.listBox1.Items[0].ToString();  // The first input node
            for (int i = 1; i < this.listBox1.Items.Count; i++)
                verilog_inputs += ", " + this.listBox1.Items[i].ToString();

            //Build Verilog Code for output signals
            verilog_output = this.listBox2.Items[0].ToString(); // The first input node
            for (int i = 1; i < this.listBox2.Items.Count; i++)
                verilog_output += ", " + this.listBox2.Items[i].ToString();

            //Build Verilog Code for wire signals
            verilog_wires = this.listBox3.Items[0].ToString(); // The first input node
            for (int i = 1; i < this.listBox3.Items.Count; i++)
                verilog_wires += ", " + this.listBox3.Items[i].ToString();

            //Build Approximation Conditions
            for (int i = 0; i < this.listBox4.Items.Count; i++)
                if (this.CircuitGraph.getVertexParity(this.CircuitGraph.findVertexByName(this.listBox4.Items[i].ToString())) == 0)
                {
                    VerilogZeroApproxCondition += " assign " + this.listBox4.Items[i].ToString() + " = 0;";
                    VerilogOneApproxCondition += " assign " + this.listBox4.Items[i].ToString() + " = 1;";

                }
                else
                {
                    VerilogZeroApproxCondition += " assign " + this.listBox4.Items[i].ToString() + " = 1;";
                    VerilogOneApproxCondition += " assign " + this.listBox4.Items[i].ToString() + " = 0;";
                }


            //Build Verilog Code for the Circuit Gates
            for (int i = this.listBox1.Items.Count; i < this.CircuitGraph.GetNumberOfNodes(); i++)
                if (!this.listBox4.Items.Contains(this.CircuitGraph.GetVertexName(i)))              //Don't include the gates that has been selected 4 the approximation
                    VerilogCode += "\r\n\r\t" + this.CircuitGraph.getVerilogFunction(i) + ";";







            //Finally, stack all the code parts together in addition to the main moduledefinations and endmondule tags
            string Tempdefination1 = "module Module1_" + " (" + verilog_output + ", " + verilog_inputs + " );";
            string Tempdefination0 = "module Module0_" + " (" + verilog_output + ", " + verilog_inputs + " );";

            Tempdefination1 += "\r\n\tinput " + verilog_inputs + ";";
            Tempdefination1 += "\r\n\toutput " + verilog_output + ";";
            Tempdefination1 += "\r\n\twire " + verilog_wires + ";";

            Tempdefination0 += "\r\n\tinput " + verilog_inputs + ";";
            Tempdefination0 += "\r\n\toutput " + verilog_output + ";";
            Tempdefination0 += "\r\n\twire " + verilog_wires + ";";

            Tempdefination0 = Tempdefination0 + VerilogZeroApproxCondition + VerilogCode + "\r\nendmodule";

            Tempdefination1 = Tempdefination1 + VerilogOneApproxCondition + VerilogCode + "\r\nendmodule";

            //Save both defination in verilog file then syntheisze them
            //Synthesis tool should eliminate the reduandance and the effect of approxmation nodes fixed logic value
            My_file1 = File.Create("./Verilog/Module1_.v");
            My_file0 = File.Create("./Verilog/Module0_.v");


            //get a UTF8Encoding byte formate of the code string
            Byte[] info0 = new UTF8Encoding(true).GetBytes(Tempdefination0);

            Byte[] info1 = new UTF8Encoding(true).GetBytes(Tempdefination1);


            //wirte them 
            My_file0.Write(info0, 0, info0.Length);
            My_file1.Write(info1, 0, info1.Length);
            //close files
            My_file0.Close();
            My_file1.Close();


        }




    }
}
