
namespace PetShop
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Percent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Myprocess = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pet Shop Managerment System";
            // 
            // Percent
            // 
            this.Percent.AutoSize = true;
            this.Percent.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percent.Location = new System.Drawing.Point(281, 98);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(42, 23);
            this.Percent.TabIndex = 4;
            this.Percent.Text = "%%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(194, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loading";
            // 
            // Myprocess
            // 
            this.Myprocess.AllowAnimations = false;
            this.Myprocess.Animation = 0;
            this.Myprocess.AnimationSpeed = 220;
            this.Myprocess.AnimationStep = 10;
            this.Myprocess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.Myprocess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Myprocess.BackgroundImage")));
            this.Myprocess.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.Myprocess.BorderRadius = 7;
            this.Myprocess.BorderThickness = 1;
            this.Myprocess.Location = new System.Drawing.Point(197, 230);
            this.Myprocess.Maximum = 100;
            this.Myprocess.MaximumValue = 100;
            this.Myprocess.Minimum = 0;
            this.Myprocess.MinimumValue = 0;
            this.Myprocess.Name = "Myprocess";
            this.Myprocess.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.Myprocess.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.Myprocess.ProgressColorLeft = System.Drawing.Color.DodgerBlue;
            this.Myprocess.ProgressColorRight = System.Drawing.Color.DodgerBlue;
            this.Myprocess.Size = new System.Drawing.Size(285, 20);
            this.Myprocess.TabIndex = 2;
            this.Myprocess.Value = 50;
            this.Myprocess.ValueByTransition = 50;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::PetShop.Properties.Resources.cat_purr_icon;
            this.guna2PictureBox1.Location = new System.Drawing.Point(26, 113);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(135, 127);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.ClientSize = new System.Drawing.Size(515, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Percent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Myprocess);
            this.Controls.Add(this.guna2PictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Bunifu.UI.WinForms.BunifuProgressBar Myprocess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Percent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

