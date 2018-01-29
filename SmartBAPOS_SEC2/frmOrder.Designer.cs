namespace SmartBAPOS_Sec2
{
    partial class frmOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtProName = new System.Windows.Forms.TextBox();
            this.txtOrdID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpOrdDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.txtDisc = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUsID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lsvShow = new System.Windows.Forms.ListView();
            this.txtProPrice = new System.Windows.Forms.TextBox();
            this.txtProID = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCpName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCpID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCpContact = new System.Windows.Forms.Label();
            this.lblCpAddress = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.crvRep = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(573, 19);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(144, 20);
            this.txtNum.TabIndex = 11;
            this.txtNum.Text = "txtNum";
            this.txtNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNum_KeyDown);
            // 
            // txtProName
            // 
            this.txtProName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProName.Location = new System.Drawing.Point(162, 19);
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(253, 20);
            this.txtProName.TabIndex = 9;
            this.txtProName.Text = "txtProName\r";
            // 
            // txtOrdID
            // 
            this.txtOrdID.BackColor = System.Drawing.SystemColors.Info;
            this.txtOrdID.Location = new System.Drawing.Point(355, 26);
            this.txtOrdID.Name = "txtOrdID";
            this.txtOrdID.Size = new System.Drawing.Size(144, 20);
            this.txtOrdID.TabIndex = 8;
            this.txtOrdID.Text = "txtOrdID\r";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "เลขที่ใบสั่งซื้อ";
            // 
            // dtpOrdDate
            // 
            this.dtpOrdDate.Location = new System.Drawing.Point(75, 26);
            this.dtpOrdDate.Name = "dtpOrdDate";
            this.dtpOrdDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrdDate.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.txtNet);
            this.panel1.Controls.Add(this.txtDisc);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(703, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 83);
            this.panel1.TabIndex = 17;
            // 
            // txtNet
            // 
            this.txtNet.Location = new System.Drawing.Point(75, 53);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(100, 20);
            this.txtNet.TabIndex = 17;
            this.txtNet.Text = "txtNet";
            this.txtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDisc
            // 
            this.txtDisc.Location = new System.Drawing.Point(75, 32);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(100, 20);
            this.txtDisc.TabIndex = 16;
            this.txtDisc.Text = "txtDisc";
            this.txtDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc.Click += new System.EventHandler(this.txtDisc_Click);
            this.txtDisc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDisc_KeyDown);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(75, 10);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.Text = "txtTotal\r";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "สุทธิ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "ส่วนลด\r";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ราคารวม";
            // 
            // lblUsID
            // 
            this.lblUsID.Location = new System.Drawing.Point(75, 52);
            this.lblUsID.Name = "lblUsID";
            this.lblUsID.Size = new System.Drawing.Size(424, 20);
            this.lblUsID.TabIndex = 8;
            this.lblUsID.Text = "lblUsID\r";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "ผู้สั่งซื้อ\r";
            // 
            // lsvShow
            // 
            this.lsvShow.Location = new System.Drawing.Point(12, 175);
            this.lsvShow.Name = "lsvShow";
            this.lsvShow.Size = new System.Drawing.Size(951, 230);
            this.lsvShow.TabIndex = 12;
            this.lsvShow.UseCompatibleStateImageBehavior = false;
            this.lsvShow.SelectedIndexChanged += new System.EventHandler(this.lsvShow_SelectedIndexChanged);
            this.lsvShow.DoubleClick += new System.EventHandler(this.lsvShow_DoubleClick);
            // 
            // txtProPrice
            // 
            this.txtProPrice.Location = new System.Drawing.Point(421, 19);
            this.txtProPrice.Name = "txtProPrice";
            this.txtProPrice.Size = new System.Drawing.Size(144, 20);
            this.txtProPrice.TabIndex = 10;
            this.txtProPrice.Text = "txtProPrice\r";
            this.txtProPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProPrice_KeyDown);
            // 
            // txtProID
            // 
            this.txtProID.BackColor = System.Drawing.SystemColors.Info;
            this.txtProID.Location = new System.Drawing.Point(12, 19);
            this.txtProID.Name = "txtProID";
            this.txtProID.Size = new System.Drawing.Size(144, 20);
            this.txtProID.TabIndex = 8;
            this.txtProID.Text = "txtProID";
            this.txtProID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProID_KeyDown);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblTime.Location = new System.Drawing.Point(30, 81);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(469, 20);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "lblTime";
            this.lblTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "วันที่สั่งซื้อ";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.txtSum);
            this.groupBox3.Controls.Add(this.txtNum);
            this.groupBox3.Controls.Add(this.txtProPrice);
            this.groupBox3.Controls.Add(this.txtProName);
            this.groupBox3.Controls.Add(this.txtProID);
            this.groupBox3.Location = new System.Drawing.Point(12, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(951, 46);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = resources.GetString("groupBox3.Text");
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(898, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 27);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point(726, 19);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(166, 20);
            this.txtSum.TabIndex = 12;
            this.txtSum.Text = "txtSum\r";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.lblUsID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtOrdID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpOrdDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(454, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 110);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ขอมูลทั่วไป\r";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ผู้ติดต่อ\r";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ที่อยู่";
            // 
            // txtCpName
            // 
            this.txtCpName.BackColor = System.Drawing.SystemColors.Info;
            this.txtCpName.Location = new System.Drawing.Point(236, 26);
            this.txtCpName.Name = "txtCpName";
            this.txtCpName.Size = new System.Drawing.Size(165, 20);
            this.txtCpName.TabIndex = 3;
            this.txtCpName.Text = "txtCpName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "รหัสผู้จำหน่าย";
            // 
            // txtCpID
            // 
            this.txtCpID.Location = new System.Drawing.Point(86, 26);
            this.txtCpID.Name = "txtCpID";
            this.txtCpID.Size = new System.Drawing.Size(144, 20);
            this.txtCpID.TabIndex = 0;
            this.txtCpID.Text = "txtCpID";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.lblCpContact);
            this.groupBox1.Controls.Add(this.lblCpAddress);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCpName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCpID);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 110);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รหัสผู้จำาหน่าย";
            // 
            // lblCpContact
            // 
            this.lblCpContact.BackColor = System.Drawing.Color.AliceBlue;
            this.lblCpContact.Location = new System.Drawing.Point(86, 81);
            this.lblCpContact.Name = "lblCpContact";
            this.lblCpContact.Size = new System.Drawing.Size(315, 20);
            this.lblCpContact.TabIndex = 9;
            this.lblCpContact.Text = "lblCpContact";
            // 
            // lblCpAddress
            // 
            this.lblCpAddress.BackColor = System.Drawing.Color.AliceBlue;
            this.lblCpAddress.Location = new System.Drawing.Point(86, 55);
            this.lblCpAddress.Name = "lblCpAddress";
            this.lblCpAddress.Size = new System.Drawing.Size(315, 20);
            this.lblCpAddress.TabIndex = 8;
            this.lblCpAddress.Text = "lblCpAddress";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(403, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 30);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(528, 421);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(126, 63);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "F10 เลิกงาน";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.Location = new System.Drawing.Point(396, 421);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 63);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "F7 ต่อไป\r";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(257, 421);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(126, 63);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "F6 พิมพ์";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(116, 421);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 63);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "F5 บัญทึก";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // crvRep
            // 
            this.crvRep.ActiveViewIndex = -1;
            this.crvRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRep.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRep.Location = new System.Drawing.Point(44, 211);
            this.crvRep.Name = "crvRep";
            this.crvRep.Size = new System.Drawing.Size(215, 150);
            this.crvRep.TabIndex = 18;
            this.crvRep.Load += new System.EventHandler(this.crvRep_Load);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(975, 501);
            this.Controls.Add(this.crvRep);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lsvShow);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrder";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtProName;
        private System.Windows.Forms.TextBox txtOrdID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpOrdDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNet;
        private System.Windows.Forms.TextBox txtDisc;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox lblUsID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lsvShow;
        private System.Windows.Forms.TextBox txtProPrice;
        private System.Windows.Forms.TextBox txtProID;
        private System.Windows.Forms.TextBox lblTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCpName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCpID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRep;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCpContact;
        private System.Windows.Forms.Label lblCpAddress;
    }
}