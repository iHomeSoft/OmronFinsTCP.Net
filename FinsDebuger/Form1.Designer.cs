namespace FinsDebuger
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPlcip = new System.Windows.Forms.TextBox();
            this.btnCon = new System.Windows.Forms.Button();
            this.txtPlcport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.txtPCNode = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtUseTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUseTimeW = new System.Windows.Forms.TextBox();
            this.txtCountW = new System.Windows.Forms.TextBox();
            this.txtValuesW = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtAddressW = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUseTimeB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBitAdd = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnReadF = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtValueF = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPlcip
            // 
            this.txtPlcip.Location = new System.Drawing.Point(81, 21);
            this.txtPlcip.Name = "txtPlcip";
            this.txtPlcip.Size = new System.Drawing.Size(120, 21);
            this.txtPlcip.TabIndex = 0;
            this.txtPlcip.Text = "172.29.29.26";
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(431, 19);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(75, 23);
            this.btnCon.TabIndex = 1;
            this.btnCon.Text = "连接";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // txtPlcport
            // 
            this.txtPlcport.Location = new System.Drawing.Point(290, 21);
            this.txtPlcport.Name = "txtPlcport";
            this.txtPlcport.Size = new System.Drawing.Size(120, 21);
            this.txtPlcport.TabIndex = 2;
            this.txtPlcport.Text = "9600";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "PLC_IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "PLC_PORT:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(87, 72);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(68, 21);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.Text = "1000";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(87, 99);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtValues
            // 
            this.txtValues.Location = new System.Drawing.Point(87, 128);
            this.txtValues.Name = "txtValues";
            this.txtValues.Size = new System.Drawing.Size(475, 21);
            this.txtValues.TabIndex = 7;
            // 
            // txtPCNode
            // 
            this.txtPCNode.Location = new System.Drawing.Point(512, 21);
            this.txtPCNode.Name = "txtPCNode";
            this.txtPCNode.Size = new System.Drawing.Size(50, 21);
            this.txtPCNode.TabIndex = 8;
            this.txtPCNode.Text = "pcNode";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(214, 72);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(68, 21);
            this.txtCount.TabIndex = 9;
            this.txtCount.Text = "2";
            // 
            // txtUseTime
            // 
            this.txtUseTime.Location = new System.Drawing.Point(227, 101);
            this.txtUseTime.Name = "txtUseTime";
            this.txtUseTime.Size = new System.Drawing.Size(132, 21);
            this.txtUseTime.TabIndex = 10;
            this.txtUseTime.Text = "use-time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Offset:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "UseTime:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Datas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "Datas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "UseTime:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "Offset:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "Address:";
            // 
            // txtUseTimeW
            // 
            this.txtUseTimeW.Location = new System.Drawing.Point(430, 205);
            this.txtUseTimeW.Name = "txtUseTimeW";
            this.txtUseTimeW.Size = new System.Drawing.Size(132, 21);
            this.txtUseTimeW.TabIndex = 19;
            this.txtUseTimeW.Text = "use-time";
            // 
            // txtCountW
            // 
            this.txtCountW.Location = new System.Drawing.Point(214, 207);
            this.txtCountW.Name = "txtCountW";
            this.txtCountW.Size = new System.Drawing.Size(68, 21);
            this.txtCountW.TabIndex = 18;
            this.txtCountW.Text = "5";
            // 
            // txtValuesW
            // 
            this.txtValuesW.Location = new System.Drawing.Point(87, 234);
            this.txtValuesW.Name = "txtValuesW";
            this.txtValuesW.Size = new System.Drawing.Size(475, 21);
            this.txtValuesW.TabIndex = 17;
            this.txtValuesW.Text = "1,2,3,4,5";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(290, 205);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 16;
            this.btnWrite.Text = "写入";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtAddressW
            // 
            this.txtAddressW.Location = new System.Drawing.Point(87, 207);
            this.txtAddressW.Name = "txtAddressW";
            this.txtAddressW.Size = new System.Drawing.Size(68, 21);
            this.txtAddressW.TabIndex = 15;
            this.txtAddressW.Text = "300";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(414, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "UseTime:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 292);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "BitAdd:";
            // 
            // txtUseTimeB
            // 
            this.txtUseTimeB.Location = new System.Drawing.Point(473, 289);
            this.txtUseTimeB.Name = "txtUseTimeB";
            this.txtUseTimeB.Size = new System.Drawing.Size(89, 21);
            this.txtUseTimeB.TabIndex = 28;
            this.txtUseTimeB.Text = "use-time";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBitAdd
            // 
            this.txtBitAdd.Location = new System.Drawing.Point(87, 289);
            this.txtBitAdd.Name = "txtBitAdd";
            this.txtBitAdd.Size = new System.Drawing.Size(68, 21);
            this.txtBitAdd.TabIndex = 24;
            this.txtBitAdd.Text = "207.01";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "关";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(332, 287);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 34;
            this.button3.Text = "读";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 35;
            this.label11.Text = "INT16:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 36;
            this.label13.Text = "REAL:";
            // 
            // btnReadF
            // 
            this.btnReadF.Location = new System.Drawing.Point(87, 156);
            this.btnReadF.Name = "btnReadF";
            this.btnReadF.Size = new System.Drawing.Size(75, 23);
            this.btnReadF.TabIndex = 37;
            this.btnReadF.Text = "读取";
            this.btnReadF.UseVisualStyleBackColor = true;
            this.btnReadF.Click += new System.EventHandler(this.btnReadF_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(168, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 39;
            this.label15.Text = "Data:";
            // 
            // txtValueF
            // 
            this.txtValueF.Location = new System.Drawing.Point(227, 158);
            this.txtValueF.Name = "txtValueF";
            this.txtValueF.Size = new System.Drawing.Size(335, 21);
            this.txtValueF.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 340);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtValueF);
            this.Controls.Add(this.btnReadF);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtUseTimeB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBitAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUseTimeW);
            this.Controls.Add(this.txtCountW);
            this.Controls.Add(this.txtValuesW);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtAddressW);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUseTime);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtPCNode);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlcport);
            this.Controls.Add(this.btnCon);
            this.Controls.Add(this.txtPlcip);
            this.Name = "Form1";
            this.Text = "FinsDebuger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlcip;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.TextBox txtPlcport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.TextBox txtPCNode;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtUseTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUseTimeW;
        private System.Windows.Forms.TextBox txtCountW;
        private System.Windows.Forms.TextBox txtValuesW;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtAddressW;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUseTimeB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBitAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnReadF;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtValueF;
    }
}

