
namespace Player
{
    partial class playlistSaveAs
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.SaveBtn);
            this.flowLayoutPanel1.Controls.Add(this.NameBox);
            this.flowLayoutPanel1.Controls.Add(this.CancelBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(351, 75);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 15, 5, 0);
            this.label1.MinimumSize = new System.Drawing.Size(255, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the name of new playlist:";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBtn.Location = new System.Drawing.Point(270, 5);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.SaveBtn.MinimumSize = new System.Drawing.Size(0, 32);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 32);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameBox.Location = new System.Drawing.Point(5, 42);
            this.NameBox.Margin = new System.Windows.Forms.Padding(5);
            this.NameBox.MinimumSize = new System.Drawing.Size(255, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(255, 26);
            this.NameBox.TabIndex = 1;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelBtn.Location = new System.Drawing.Point(270, 37);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.CancelBtn.MinimumSize = new System.Drawing.Size(0, 32);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 32);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // playlistSaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(351, 75);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "playlistSaveAs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save playlist As...";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button CancelBtn;
    }
}