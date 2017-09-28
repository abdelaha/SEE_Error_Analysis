namespace SEE_Error_Analysis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.output = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_InputTV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.InputText = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(27, 626);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(468, 165);
            this.output.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "Compile the Circuit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Input Verilog Circuit Description";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.listBox4);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.listBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(786, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 751);
            this.panel1.TabIndex = 13;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(510, 47);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(250, 697);
            this.dataGridView2.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(506, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "Active Netlist";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(355, 183);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(394, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "Gold Netlist";
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(398, 46);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(106, 303);
            this.listBox4.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 355);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(485, 389);
            this.dataGridView1.TabIndex = 17;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(243, 46);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(106, 303);
            this.listBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(239, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Netlist";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(131, 46);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(106, 303);
            this.listBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Outputs";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(106, 303);
            this.listBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inputs";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(500, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 48);
            this.button3.TabIndex = 14;
            this.button3.Text = "Simulate the Circuit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_InputTV
            // 
            this.textBox_InputTV.Location = new System.Drawing.Point(593, 139);
            this.textBox_InputTV.Name = "textBox_InputTV";
            this.textBox_InputTV.Size = new System.Drawing.Size(162, 20);
            this.textBox_InputTV.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(593, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Input Test Vector(Decimal)";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(501, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 49);
            this.button4.TabIndex = 17;
            this.button4.Text = "Analysis";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(596, 204);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Harden The Gold Netlist";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(596, 235);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 17);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Very Fast Run";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(596, 258);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 17);
            this.radioButton2.TabIndex = 20;
            this.radioButton2.Text = "Fast Run";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(596, 281);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 21;
            this.radioButton3.Text = "Medium Run";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(496, 402);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(255, 23);
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Visible = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(596, 304);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(71, 17);
            this.radioButton4.TabIndex = 23;
            this.radioButton4.Text = "Slow Run";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(596, 327);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(95, 17);
            this.radioButton5.TabIndex = 24;
            this.radioButton5.Text = "Very Slow Run";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(596, 350);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(64, 17);
            this.radioButton6.TabIndex = 25;
            this.radioButton6.Text = "Full Run";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(22, 45);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(468, 575);
            this.InputText.TabIndex = 26;
            this.InputText.Text = "";
            this.InputText.WordWrap = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(501, 476);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 60);
            this.button6.TabIndex = 27;
            this.button6.Text = "Generate BackCone Verilog";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(501, 543);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(130, 50);
            this.button7.TabIndex = 28;
            this.button7.Text = "Build Eqn";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(501, 599);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(130, 48);
            this.button8.TabIndex = 29;
            this.button8.Text = "Generate Graph Data";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(631, 599);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "CircuitArea";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(634, 626);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 31;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(634, 561);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(146, 17);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "Don\'t Include Gold Netlist";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(587, 738);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(139, 58);
            this.button9.TabIndex = 34;
            this.button9.Text = "Generate Approxmiate Networks";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(587, 669);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(139, 63);
            this.button10.TabIndex = 33;
            this.button10.Text = "unate calculation";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 808);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_InputTV);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_InputTV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox InputText;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

