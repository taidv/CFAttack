namespace LatticAttack
{
    partial class LatticAttack
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.lbN = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.lbE = new System.Windows.Forms.Label();
            this.txtE = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(63, 224);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(787, 40);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lbN
            // 
            this.lbN.AutoSize = true;
            this.lbN.Location = new System.Drawing.Point(58, 190);
            this.lbN.Name = "lbN";
            this.lbN.Size = new System.Drawing.Size(24, 25);
            this.lbN.TabIndex = 6;
            this.lbN.Text = "n";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(100, 187);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(352, 31);
            this.txtN.TabIndex = 7;
            this.txtN.Text = "42004724302405294297751453898364502197";
            // 
            // lbE
            // 
            this.lbE.AutoSize = true;
            this.lbE.Location = new System.Drawing.Point(468, 190);
            this.lbE.Name = "lbE";
            this.lbE.Size = new System.Drawing.Size(24, 25);
            this.lbE.TabIndex = 8;
            this.lbE.Text = "e";
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(498, 187);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(352, 31);
            this.txtE.TabIndex = 9;
            this.txtE.Text = "17924546723775007116522646995236610637";
            // 
            // LatticAttack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 451);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lbN);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.lbE);
            this.Controls.Add(this.txtE);
            this.Name = "LatticAttack";
            this.Text = "Lattic Attack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lbN;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label lbE;
        private System.Windows.Forms.TextBox txtE;
    }
}

