namespace FMS_GUI
{
    partial class Rec_Read
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rec_Read));
            this.LBL_read = new System.Windows.Forms.Label();
            this.TB_key = new System.Windows.Forms.TextBox();
            this.BT_key = new System.Windows.Forms.Button();
            this.TB_gr = new System.Windows.Forms.TextBox();
            this.TB_c = new System.Windows.Forms.TextBox();
            this.TB_stun = new System.Windows.Forms.TextBox();
            this.TB_rnr = new System.Windows.Forms.TextBox();
            this.TB_sid = new System.Windows.Forms.TextBox();
            this.LBL_grade = new System.Windows.Forms.Label();
            this.LBL_cn = new System.Windows.Forms.Label();
            this.LBL_name = new System.Windows.Forms.Label();
            this.LBL_cou = new System.Windows.Forms.Label();
            this.LBL_stu = new System.Windows.Forms.Label();
            this.ReedToUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LBL_read
            // 
            this.LBL_read.AutoSize = true;
            this.LBL_read.BackColor = System.Drawing.Color.Transparent;
            this.LBL_read.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_read.Location = new System.Drawing.Point(116, 4);
            this.LBL_read.Name = "LBL_read";
            this.LBL_read.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_read.Size = new System.Drawing.Size(52, 14);
            this.LBL_read.TabIndex = 9;
            this.LBL_read.Text = "הזן מפתח";
            // 
            // TB_key
            // 
            this.TB_key.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_key.Location = new System.Drawing.Point(84, 24);
            this.TB_key.Name = "TB_key";
            this.TB_key.Size = new System.Drawing.Size(113, 20);
            this.TB_key.TabIndex = 7;
            // 
            // BT_key
            // 
            this.BT_key.BackColor = System.Drawing.Color.Transparent;
            this.BT_key.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_key.Font = new System.Drawing.Font("Miriam", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BT_key.Location = new System.Drawing.Point(84, 83);
            this.BT_key.Name = "BT_key";
            this.BT_key.Size = new System.Drawing.Size(104, 26);
            this.BT_key.TabIndex = 6;
            this.BT_key.Text = "קרא רשומה";
            this.BT_key.UseVisualStyleBackColor = false;
            this.BT_key.Click += new System.EventHandler(this.BT_key_Click);
            // 
            // TB_gr
            // 
            this.TB_gr.Enabled = false;
            this.TB_gr.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_gr.Location = new System.Drawing.Point(57, 265);
            this.TB_gr.Name = "TB_gr";
            this.TB_gr.Size = new System.Drawing.Size(100, 21);
            this.TB_gr.TabIndex = 19;
            // 
            // TB_c
            // 
            this.TB_c.Enabled = false;
            this.TB_c.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_c.Location = new System.Drawing.Point(57, 238);
            this.TB_c.Name = "TB_c";
            this.TB_c.Size = new System.Drawing.Size(100, 21);
            this.TB_c.TabIndex = 18;
            // 
            // TB_stun
            // 
            this.TB_stun.Enabled = false;
            this.TB_stun.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_stun.Location = new System.Drawing.Point(57, 211);
            this.TB_stun.Name = "TB_stun";
            this.TB_stun.Size = new System.Drawing.Size(100, 21);
            this.TB_stun.TabIndex = 17;
            // 
            // TB_rnr
            // 
            this.TB_rnr.Enabled = false;
            this.TB_rnr.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_rnr.Location = new System.Drawing.Point(57, 184);
            this.TB_rnr.Name = "TB_rnr";
            this.TB_rnr.Size = new System.Drawing.Size(100, 21);
            this.TB_rnr.TabIndex = 16;
            // 
            // TB_sid
            // 
            this.TB_sid.Enabled = false;
            this.TB_sid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TB_sid.Location = new System.Drawing.Point(57, 157);
            this.TB_sid.Name = "TB_sid";
            this.TB_sid.Size = new System.Drawing.Size(100, 21);
            this.TB_sid.TabIndex = 15;
            this.TB_sid.TextChanged += new System.EventHandler(this.TB_sid_TextChanged);
            // 
            // LBL_grade
            // 
            this.LBL_grade.BackColor = System.Drawing.Color.Transparent;
            this.LBL_grade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_grade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LBL_grade.Location = new System.Drawing.Point(176, 268);
            this.LBL_grade.Name = "LBL_grade";
            this.LBL_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_grade.Size = new System.Drawing.Size(53, 20);
            this.LBL_grade.TabIndex = 14;
            this.LBL_grade.Text = "ציון:";
            // 
            // LBL_cn
            // 
            this.LBL_cn.BackColor = System.Drawing.Color.Transparent;
            this.LBL_cn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_cn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LBL_cn.Location = new System.Drawing.Point(178, 241);
            this.LBL_cn.Name = "LBL_cn";
            this.LBL_cn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_cn.Size = new System.Drawing.Size(51, 20);
            this.LBL_cn.TabIndex = 13;
            this.LBL_cn.Text = "קורס:";
            // 
            // LBL_name
            // 
            this.LBL_name.BackColor = System.Drawing.Color.Transparent;
            this.LBL_name.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LBL_name.Location = new System.Drawing.Point(157, 214);
            this.LBL_name.Name = "LBL_name";
            this.LBL_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_name.Size = new System.Drawing.Size(72, 20);
            this.LBL_name.TabIndex = 12;
            this.LBL_name.Text = "שם סטודנט:";
            // 
            // LBL_cou
            // 
            this.LBL_cou.BackColor = System.Drawing.Color.Transparent;
            this.LBL_cou.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_cou.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LBL_cou.Location = new System.Drawing.Point(157, 187);
            this.LBL_cou.Name = "LBL_cou";
            this.LBL_cou.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_cou.Size = new System.Drawing.Size(72, 20);
            this.LBL_cou.TabIndex = 11;
            this.LBL_cou.Text = "קוד קורס:";
            // 
            // LBL_stu
            // 
            this.LBL_stu.BackColor = System.Drawing.Color.Transparent;
            this.LBL_stu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBL_stu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LBL_stu.Location = new System.Drawing.Point(160, 160);
            this.LBL_stu.Name = "LBL_stu";
            this.LBL_stu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_stu.Size = new System.Drawing.Size(69, 20);
            this.LBL_stu.TabIndex = 10;
            this.LBL_stu.Text = "קוד סטודנט:";
            // 
            // ReedToUpdate
            // 
            this.ReedToUpdate.AutoSize = true;
            this.ReedToUpdate.BackColor = System.Drawing.Color.Transparent;
            this.ReedToUpdate.Location = new System.Drawing.Point(157, 60);
            this.ReedToUpdate.Name = "ReedToUpdate";
            this.ReedToUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ReedToUpdate.Size = new System.Drawing.Size(128, 17);
            this.ReedToUpdate.TabIndex = 20;
            this.ReedToUpdate.Text = "קריאה לצורך עדכון";
            this.ReedToUpdate.UseVisualStyleBackColor = false;
            this.ReedToUpdate.CheckedChanged += new System.EventHandler(this.ReedToUpdate_CheckedChanged);
            // 
            // Rec_Read
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(299, 124);
            this.Controls.Add(this.ReedToUpdate);
            this.Controls.Add(this.TB_gr);
            this.Controls.Add(this.TB_c);
            this.Controls.Add(this.TB_stun);
            this.Controls.Add(this.TB_rnr);
            this.Controls.Add(this.TB_sid);
            this.Controls.Add(this.LBL_grade);
            this.Controls.Add(this.LBL_cn);
            this.Controls.Add(this.LBL_name);
            this.Controls.Add(this.LBL_cou);
            this.Controls.Add(this.LBL_stu);
            this.Controls.Add(this.LBL_read);
            this.Controls.Add(this.TB_key);
            this.Controls.Add(this.BT_key);
            this.Name = "Rec_Read";
            this.Text = "Rec_Read";
            this.Load += new System.EventHandler(this.Rec_Read_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_read;
        private System.Windows.Forms.TextBox TB_key;
        private System.Windows.Forms.Button BT_key;
        private System.Windows.Forms.TextBox TB_gr;
        private System.Windows.Forms.TextBox TB_c;
        private System.Windows.Forms.TextBox TB_stun;
        private System.Windows.Forms.TextBox TB_rnr;
        private System.Windows.Forms.TextBox TB_sid;
        private System.Windows.Forms.Label LBL_grade;
        private System.Windows.Forms.Label LBL_cn;
        private System.Windows.Forms.Label LBL_name;
        private System.Windows.Forms.Label LBL_cou;
        private System.Windows.Forms.Label LBL_stu;
        private System.Windows.Forms.CheckBox ReedToUpdate;
    }
}