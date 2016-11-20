namespace FMS_GUI
{
    partial class rec_write
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rec_write));
            this.LBL_stu = new System.Windows.Forms.Label();
            this.BT_write = new System.Windows.Forms.Button();
            this.LBL_G = new System.Windows.Forms.Label();
            this.LBL_c = new System.Windows.Forms.Label();
            this.LBL_LN = new System.Windows.Forms.Label();
            this.LBL_FN = new System.Windows.Forms.Label();
            this.LBL_RNR = new System.Windows.Forms.Label();
            this.LBL_SID = new System.Windows.Forms.Label();
            this.TB_G = new System.Windows.Forms.TextBox();
            this.TB_C = new System.Windows.Forms.TextBox();
            this.TB_LN = new System.Windows.Forms.TextBox();
            this.TB_FN = new System.Windows.Forms.TextBox();
            this.TB_RegNR = new System.Windows.Forms.TextBox();
            this.TB_StudID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBL_stu
            // 
            this.LBL_stu.AutoSize = true;
            this.LBL_stu.BackColor = System.Drawing.Color.Transparent;
            this.LBL_stu.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_stu.Location = new System.Drawing.Point(68, 9);
            this.LBL_stu.Name = "LBL_stu";
            this.LBL_stu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_stu.Size = new System.Drawing.Size(83, 16);
            this.LBL_stu.TabIndex = 27;
            this.LBL_stu.Text = "פרטי סטודנט:";
            this.LBL_stu.Click += new System.EventHandler(this.LBL_stu_Click);
            // 
            // BT_write
            // 
            this.BT_write.Font = new System.Drawing.Font("Miriam", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BT_write.Location = new System.Drawing.Point(68, 256);
            this.BT_write.Name = "BT_write";
            this.BT_write.Size = new System.Drawing.Size(97, 23);
            this.BT_write.TabIndex = 26;
            this.BT_write.Text = "כתיבה לקובץ";
            this.BT_write.UseVisualStyleBackColor = true;
            this.BT_write.Click += new System.EventHandler(this.BT_write_Click);
            // 
            // LBL_G
            // 
            this.LBL_G.AutoSize = true;
            this.LBL_G.BackColor = System.Drawing.Color.Transparent;
            this.LBL_G.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_G.Location = new System.Drawing.Point(136, 222);
            this.LBL_G.Name = "LBL_G";
            this.LBL_G.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_G.Size = new System.Drawing.Size(25, 15);
            this.LBL_G.TabIndex = 25;
            this.LBL_G.Text = "ציון:";
            this.LBL_G.Click += new System.EventHandler(this.LBL_G_Click);
            // 
            // LBL_c
            // 
            this.LBL_c.AutoSize = true;
            this.LBL_c.BackColor = System.Drawing.Color.Transparent;
            this.LBL_c.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_c.Location = new System.Drawing.Point(136, 187);
            this.LBL_c.Name = "LBL_c";
            this.LBL_c.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_c.Size = new System.Drawing.Size(33, 15);
            this.LBL_c.TabIndex = 24;
            this.LBL_c.Text = "קורס:";
            this.LBL_c.Click += new System.EventHandler(this.LBL_c_Click);
            // 
            // LBL_LN
            // 
            this.LBL_LN.AutoSize = true;
            this.LBL_LN.BackColor = System.Drawing.Color.Transparent;
            this.LBL_LN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_LN.Location = new System.Drawing.Point(136, 152);
            this.LBL_LN.Name = "LBL_LN";
            this.LBL_LN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_LN.Size = new System.Drawing.Size(64, 15);
            this.LBL_LN.TabIndex = 23;
            this.LBL_LN.Text = "שם משפחה:";
            this.LBL_LN.Click += new System.EventHandler(this.LBL_LN_Click);
            // 
            // LBL_FN
            // 
            this.LBL_FN.AutoSize = true;
            this.LBL_FN.BackColor = System.Drawing.Color.Transparent;
            this.LBL_FN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_FN.Location = new System.Drawing.Point(136, 117);
            this.LBL_FN.Name = "LBL_FN";
            this.LBL_FN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_FN.Size = new System.Drawing.Size(51, 15);
            this.LBL_FN.TabIndex = 22;
            this.LBL_FN.Text = "שם פרטי:";
            this.LBL_FN.Click += new System.EventHandler(this.LBL_FN_Click);
            // 
            // LBL_RNR
            // 
            this.LBL_RNR.AutoSize = true;
            this.LBL_RNR.BackColor = System.Drawing.Color.Transparent;
            this.LBL_RNR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_RNR.Location = new System.Drawing.Point(136, 82);
            this.LBL_RNR.Name = "LBL_RNR";
            this.LBL_RNR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_RNR.Size = new System.Drawing.Size(52, 15);
            this.LBL_RNR.TabIndex = 21;
            this.LBL_RNR.Text = "קוד קורס:";
            this.LBL_RNR.Click += new System.EventHandler(this.LBL_RNR_Click);
            // 
            // LBL_SID
            // 
            this.LBL_SID.AutoSize = true;
            this.LBL_SID.BackColor = System.Drawing.Color.Transparent;
            this.LBL_SID.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_SID.Location = new System.Drawing.Point(136, 47);
            this.LBL_SID.Name = "LBL_SID";
            this.LBL_SID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_SID.Size = new System.Drawing.Size(63, 15);
            this.LBL_SID.TabIndex = 20;
            this.LBL_SID.Text = "קוד סטודנט:";
            this.LBL_SID.Click += new System.EventHandler(this.LBL_SID_Click);
            // 
            // TB_G
            // 
            this.TB_G.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_G.Location = new System.Drawing.Point(13, 211);
            this.TB_G.Name = "TB_G";
            this.TB_G.Size = new System.Drawing.Size(100, 21);
            this.TB_G.TabIndex = 19;
            // 
            // TB_C
            // 
            this.TB_C.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_C.Location = new System.Drawing.Point(13, 177);
            this.TB_C.Name = "TB_C";
            this.TB_C.Size = new System.Drawing.Size(100, 21);
            this.TB_C.TabIndex = 18;
            // 
            // TB_LN
            // 
            this.TB_LN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_LN.Location = new System.Drawing.Point(13, 143);
            this.TB_LN.Name = "TB_LN";
            this.TB_LN.Size = new System.Drawing.Size(100, 21);
            this.TB_LN.TabIndex = 17;
            // 
            // TB_FN
            // 
            this.TB_FN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_FN.Location = new System.Drawing.Point(13, 109);
            this.TB_FN.Name = "TB_FN";
            this.TB_FN.Size = new System.Drawing.Size(100, 21);
            this.TB_FN.TabIndex = 16;
            // 
            // TB_RegNR
            // 
            this.TB_RegNR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_RegNR.Location = new System.Drawing.Point(13, 75);
            this.TB_RegNR.Name = "TB_RegNR";
            this.TB_RegNR.Size = new System.Drawing.Size(100, 21);
            this.TB_RegNR.TabIndex = 15;
            // 
            // TB_StudID
            // 
            this.TB_StudID.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_StudID.Location = new System.Drawing.Point(13, 41);
            this.TB_StudID.Name = "TB_StudID";
            this.TB_StudID.Size = new System.Drawing.Size(100, 21);
            this.TB_StudID.TabIndex = 14;
            // 
            // rec_write
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(224, 289);
            this.Controls.Add(this.LBL_stu);
            this.Controls.Add(this.BT_write);
            this.Controls.Add(this.LBL_G);
            this.Controls.Add(this.LBL_c);
            this.Controls.Add(this.LBL_LN);
            this.Controls.Add(this.LBL_FN);
            this.Controls.Add(this.LBL_RNR);
            this.Controls.Add(this.LBL_SID);
            this.Controls.Add(this.TB_G);
            this.Controls.Add(this.TB_C);
            this.Controls.Add(this.TB_LN);
            this.Controls.Add(this.TB_FN);
            this.Controls.Add(this.TB_RegNR);
            this.Controls.Add(this.TB_StudID);
            this.Name = "rec_write";
            this.Text = "rec_write";
            this.Load += new System.EventHandler(this.rec_write_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_stu;
        private System.Windows.Forms.Button BT_write;
        private System.Windows.Forms.Label LBL_G;
        private System.Windows.Forms.Label LBL_c;
        private System.Windows.Forms.Label LBL_LN;
        private System.Windows.Forms.Label LBL_FN;
        private System.Windows.Forms.Label LBL_RNR;
        private System.Windows.Forms.Label LBL_SID;
        private System.Windows.Forms.TextBox TB_G;
        private System.Windows.Forms.TextBox TB_C;
        private System.Windows.Forms.TextBox TB_LN;
        private System.Windows.Forms.TextBox TB_FN;
        private System.Windows.Forms.TextBox TB_RegNR;
        private System.Windows.Forms.TextBox TB_StudID;
    }
}