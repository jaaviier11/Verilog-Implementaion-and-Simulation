namespace Simulasi_Eldig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkA = new System.Windows.Forms.CheckBox();
            this.chkLC = new System.Windows.Forms.CheckBox();
            this.chkBT = new System.Windows.Forms.CheckBox();
            this.chkBP = new System.Windows.Forms.CheckBox();
            this.chkHR = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHTR = new System.Windows.Forms.Label();
            this.lblFAN = new System.Windows.Forms.Label();
            this.lblHMD = new System.Windows.Forms.Label();
            this.lblMOT = new System.Windows.Forms.Label();
            this.lblLED = new System.Windows.Forms.Label();
            this.lblBuzzer = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblRiskCount = new System.Windows.Forms.Label();
            this.lblCurrentState = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chkA);
            this.groupBox1.Controls.Add(this.chkLC);
            this.groupBox1.Controls.Add(this.chkBT);
            this.groupBox1.Controls.Add(this.chkBP);
            this.groupBox1.Controls.Add(this.chkHR);
            this.groupBox1.Location = new System.Drawing.Point(24, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Stimulus";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkA
            // 
            this.chkA.AutoSize = true;
            this.chkA.Location = new System.Drawing.Point(48, 160);
            this.chkA.Name = "chkA";
            this.chkA.Size = new System.Drawing.Size(46, 24);
            this.chkA.TabIndex = 4;
            this.chkA.Text = "A";
            this.chkA.UseVisualStyleBackColor = true;
            // 
            // chkLC
            // 
            this.chkLC.AutoSize = true;
            this.chkLC.Location = new System.Drawing.Point(48, 129);
            this.chkLC.Name = "chkLC";
            this.chkLC.Size = new System.Drawing.Size(55, 24);
            this.chkLC.TabIndex = 3;
            this.chkLC.Text = "LC";
            this.chkLC.UseVisualStyleBackColor = true;
            // 
            // chkBT
            // 
            this.chkBT.AutoSize = true;
            this.chkBT.Location = new System.Drawing.Point(48, 98);
            this.chkBT.Name = "chkBT";
            this.chkBT.Size = new System.Drawing.Size(55, 24);
            this.chkBT.TabIndex = 2;
            this.chkBT.Text = "BT";
            this.chkBT.UseVisualStyleBackColor = true;
            // 
            // chkBP
            // 
            this.chkBP.AutoSize = true;
            this.chkBP.Location = new System.Drawing.Point(48, 67);
            this.chkBP.Name = "chkBP";
            this.chkBP.Size = new System.Drawing.Size(56, 24);
            this.chkBP.TabIndex = 1;
            this.chkBP.Text = "BP";
            this.chkBP.UseVisualStyleBackColor = true;
            // 
            // chkHR
            // 
            this.chkHR.AutoSize = true;
            this.chkHR.Location = new System.Drawing.Point(48, 36);
            this.chkHR.Name = "chkHR";
            this.chkHR.Size = new System.Drawing.Size(59, 24);
            this.chkHR.TabIndex = 0;
            this.chkHR.Text = "HR";
            this.chkHR.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblHTR);
            this.groupBox2.Controls.Add(this.lblFAN);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblHMD);
            this.groupBox2.Controls.Add(this.lblMOT);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblLED);
            this.groupBox2.Controls.Add(this.lblBuzzer);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(199, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 246);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Aktutor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 20);
            this.label12.TabIndex = 11;
            this.label12.Text = "HTR";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "FAN";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "HMD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "MOT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "LED";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "BUZZER";
            // 
            // lblHTR
            // 
            this.lblHTR.AutoSize = true;
            this.lblHTR.Location = new System.Drawing.Point(128, 191);
            this.lblHTR.Name = "lblHTR";
            this.lblHTR.Size = new System.Drawing.Size(42, 20);
            this.lblHTR.TabIndex = 5;
            this.lblHTR.Text = "HTR";
            // 
            // lblFAN
            // 
            this.lblFAN.AutoSize = true;
            this.lblFAN.Location = new System.Drawing.Point(128, 159);
            this.lblFAN.Name = "lblFAN";
            this.lblFAN.Size = new System.Drawing.Size(41, 20);
            this.lblFAN.TabIndex = 4;
            this.lblFAN.Text = "FAN";
            // 
            // lblHMD
            // 
            this.lblHMD.AutoSize = true;
            this.lblHMD.Location = new System.Drawing.Point(128, 128);
            this.lblHMD.Name = "lblHMD";
            this.lblHMD.Size = new System.Drawing.Size(46, 20);
            this.lblHMD.TabIndex = 3;
            this.lblHMD.Text = "HMD";
            // 
            // lblMOT
            // 
            this.lblMOT.AutoSize = true;
            this.lblMOT.Location = new System.Drawing.Point(128, 97);
            this.lblMOT.Name = "lblMOT";
            this.lblMOT.Size = new System.Drawing.Size(43, 20);
            this.lblMOT.TabIndex = 2;
            this.lblMOT.Text = "MOT";
            // 
            // lblLED
            // 
            this.lblLED.AutoSize = true;
            this.lblLED.Location = new System.Drawing.Point(128, 66);
            this.lblLED.Name = "lblLED";
            this.lblLED.Size = new System.Drawing.Size(41, 20);
            this.lblLED.TabIndex = 1;
            this.lblLED.Text = "LED";
            // 
            // lblBuzzer
            // 
            this.lblBuzzer.AutoSize = true;
            this.lblBuzzer.Location = new System.Drawing.Point(128, 37);
            this.lblBuzzer.Name = "lblBuzzer";
            this.lblBuzzer.Size = new System.Drawing.Size(42, 20);
            this.lblBuzzer.TabIndex = 0;
            this.lblBuzzer.Text = "BUZ";
            this.lblBuzzer.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lblRiskCount);
            this.groupBox3.Controls.Add(this.lblCurrentState);
            this.groupBox3.Location = new System.Drawing.Point(24, 297);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 115);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "Risk Count";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Current State";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // lblRiskCount
            // 
            this.lblRiskCount.AutoSize = true;
            this.lblRiskCount.Location = new System.Drawing.Point(189, 73);
            this.lblRiskCount.Name = "lblRiskCount";
            this.lblRiskCount.Size = new System.Drawing.Size(87, 20);
            this.lblRiskCount.TabIndex = 1;
            this.lblRiskCount.Text = "Risk Count";
            // 
            // lblCurrentState
            // 
            this.lblCurrentState.AutoSize = true;
            this.lblCurrentState.Location = new System.Drawing.Point(189, 35);
            this.lblCurrentState.Name = "lblCurrentState";
            this.lblCurrentState.Size = new System.Drawing.Size(105, 20);
            this.lblCurrentState.TabIndex = 0;
            this.lblCurrentState.Text = "Current State";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 436);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Software Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkA;
        private System.Windows.Forms.CheckBox chkLC;
        private System.Windows.Forms.CheckBox chkBT;
        private System.Windows.Forms.CheckBox chkBP;
        private System.Windows.Forms.CheckBox chkHR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblBuzzer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblHTR;
        private System.Windows.Forms.Label lblFAN;
        private System.Windows.Forms.Label lblHMD;
        private System.Windows.Forms.Label lblMOT;
        private System.Windows.Forms.Label lblLED;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblRiskCount;
        private System.Windows.Forms.Label lblCurrentState;
        private System.Windows.Forms.Label label16;
    }
}

