namespace PhoneCallHelper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PhoneCallHelper.Properties.Resources._512_tick;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.CreateLog);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.CloseForm);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(9, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Call Logged";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.CreateLog);
            this.label1.DoubleClick += new System.EventHandler(this.CloseForm);
            // 
            // lblDuration
            // 
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.DimGray;
            this.lblDuration.Location = new System.Drawing.Point(9, 153);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(270, 25);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Duration : ###";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDuration.Click += new System.EventHandler(this.CreateLog);
            this.lblDuration.DoubleClick += new System.EventHandler(this.CloseForm);
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNo.ForeColor = System.Drawing.Color.DimGray;
            this.lblPhoneNo.Location = new System.Drawing.Point(9, 178);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(270, 46);
            this.lblPhoneNo.TabIndex = 3;
            this.lblPhoneNo.Text = "Phone No: ###";
            this.lblPhoneNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPhoneNo.Click += new System.EventHandler(this.CreateLog);
            this.lblPhoneNo.DoubleClick += new System.EventHandler(this.CloseForm);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(9, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Click to Create Job";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Click += new System.EventHandler(this.CreateLog);
            this.label4.DoubleClick += new System.EventHandler(this.CloseForm);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblPhoneNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 231);
            this.panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(175)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(294, 237);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Phone Call Helper";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.CreateLog);
            this.DoubleClick += new System.EventHandler(this.CloseForm);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}

