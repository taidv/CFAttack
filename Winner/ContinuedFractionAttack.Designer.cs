namespace ContinuedFractionAttack
{
    partial class ContinuedFractionAttack
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
            this.txtE = new System.Windows.Forms.TextBox();
            this.lbE = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnImportJson = new System.Windows.Forms.Button();
            this.openJsonFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbCFA = new System.Windows.Forms.TabControl();
            this.tbCF = new System.Windows.Forms.TabPage();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.tbReport = new System.Windows.Forms.TabPage();
            this.btLoadReport = new System.Windows.Forms.Button();
            this.pnReport = new System.Windows.Forms.Panel();
            this.btCloseReport = new System.Windows.Forms.Button();
            this.lbAverageTime = new System.Windows.Forms.Label();
            this.lbSuccessRate = new System.Windows.Forms.Label();
            this.lbNumFailures = new System.Windows.Forms.Label();
            this.lbNumSuccessfull = new System.Windows.Forms.Label();
            this.lbTotalTime = new System.Windows.Forms.Label();
            this.lbNumKeys = new System.Windows.Forms.Label();
            this.lbKeyLength = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.bgWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tbCFA.SuspendLayout();
            this.tbCF.SuspendLayout();
            this.tbReport.SuspendLayout();
            this.pnReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(34, 71);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(787, 40);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lbN
            // 
            this.lbN.AutoSize = true;
            this.lbN.Location = new System.Drawing.Point(29, 31);
            this.lbN.Name = "lbN";
            this.lbN.Size = new System.Drawing.Size(24, 25);
            this.lbN.TabIndex = 1;
            this.lbN.Text = "n";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(71, 28);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(352, 31);
            this.txtN.TabIndex = 2;
            this.txtN.Text = "8927";
            this.txtN.Enter += new System.EventHandler(this.txtN_Enter);
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(469, 28);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(352, 31);
            this.txtE.TabIndex = 3;
            this.txtE.Text = "2621";
            this.txtE.Enter += new System.EventHandler(this.txtE_Enter);
            // 
            // lbE
            // 
            this.lbE.AutoSize = true;
            this.lbE.Location = new System.Drawing.Point(439, 31);
            this.lbE.Name = "lbE";
            this.lbE.Size = new System.Drawing.Size(24, 25);
            this.lbE.TabIndex = 3;
            this.lbE.Text = "e";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(633, 422);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(188, 37);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Logs";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnImportJson
            // 
            this.btnImportJson.Location = new System.Drawing.Point(34, 117);
            this.btnImportJson.Name = "btnImportJson";
            this.btnImportJson.Size = new System.Drawing.Size(787, 39);
            this.btnImportJson.TabIndex = 8;
            this.btnImportJson.Text = "Import From Json File";
            this.btnImportJson.UseVisualStyleBackColor = true;
            this.btnImportJson.Click += new System.EventHandler(this.btnLoadJson_Click);
            // 
            // openJsonFileDialog
            // 
            this.openJsonFileDialog.FileName = "Open Json File";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(38, 429);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(589, 16);
            this.progressBar1.TabIndex = 9;
            // 
            // tbCFA
            // 
            this.tbCFA.Controls.Add(this.tbCF);
            this.tbCFA.Controls.Add(this.tbReport);
            this.tbCFA.Location = new System.Drawing.Point(12, 12);
            this.tbCFA.Name = "tbCFA";
            this.tbCFA.SelectedIndex = 0;
            this.tbCFA.Size = new System.Drawing.Size(872, 543);
            this.tbCFA.TabIndex = 10;
            // 
            // tbCF
            // 
            this.tbCF.BackColor = System.Drawing.SystemColors.Control;
            this.tbCF.Controls.Add(this.lstResult);
            this.tbCF.Controls.Add(this.btnClearLog);
            this.tbCF.Controls.Add(this.progressBar1);
            this.tbCF.Controls.Add(this.btnProcess);
            this.tbCF.Controls.Add(this.btnImportJson);
            this.tbCF.Controls.Add(this.lbN);
            this.tbCF.Controls.Add(this.txtN);
            this.tbCF.Controls.Add(this.lbE);
            this.tbCF.Controls.Add(this.txtE);
            this.tbCF.Location = new System.Drawing.Point(4, 34);
            this.tbCF.Name = "tbCF";
            this.tbCF.Padding = new System.Windows.Forms.Padding(3);
            this.tbCF.Size = new System.Drawing.Size(864, 505);
            this.tbCF.TabIndex = 0;
            this.tbCF.Text = "Continued Fraction Attack";
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.HorizontalScrollbar = true;
            this.lstResult.ItemHeight = 25;
            this.lstResult.Location = new System.Drawing.Point(38, 162);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(783, 254);
            this.lstResult.TabIndex = 10;
            // 
            // tbReport
            // 
            this.tbReport.BackColor = System.Drawing.SystemColors.Control;
            this.tbReport.Controls.Add(this.btLoadReport);
            this.tbReport.Controls.Add(this.pnReport);
            this.tbReport.Location = new System.Drawing.Point(4, 34);
            this.tbReport.Name = "tbReport";
            this.tbReport.Padding = new System.Windows.Forms.Padding(3);
            this.tbReport.Size = new System.Drawing.Size(864, 505);
            this.tbReport.TabIndex = 1;
            this.tbReport.Text = "Report";
            // 
            // btLoadReport
            // 
            this.btLoadReport.Location = new System.Drawing.Point(109, 14);
            this.btLoadReport.Name = "btLoadReport";
            this.btLoadReport.Size = new System.Drawing.Size(633, 64);
            this.btLoadReport.TabIndex = 1;
            this.btLoadReport.Text = "Load Report....";
            this.btLoadReport.UseVisualStyleBackColor = true;
            this.btLoadReport.Click += new System.EventHandler(this.btLoadReport_Click);
            // 
            // pnReport
            // 
            this.pnReport.Controls.Add(this.btCloseReport);
            this.pnReport.Controls.Add(this.lbAverageTime);
            this.pnReport.Controls.Add(this.lbSuccessRate);
            this.pnReport.Controls.Add(this.lbNumFailures);
            this.pnReport.Controls.Add(this.lbNumSuccessfull);
            this.pnReport.Controls.Add(this.lbTotalTime);
            this.pnReport.Controls.Add(this.lbNumKeys);
            this.pnReport.Controls.Add(this.lbKeyLength);
            this.pnReport.Controls.Add(this.lbTitle);
            this.pnReport.Location = new System.Drawing.Point(22, 34);
            this.pnReport.Name = "pnReport";
            this.pnReport.Size = new System.Drawing.Size(816, 453);
            this.pnReport.TabIndex = 0;
            this.pnReport.Visible = false;
            // 
            // btCloseReport
            // 
            this.btCloseReport.Location = new System.Drawing.Point(689, 372);
            this.btCloseReport.Name = "btCloseReport";
            this.btCloseReport.Size = new System.Drawing.Size(109, 64);
            this.btCloseReport.TabIndex = 2;
            this.btCloseReport.Text = "Close";
            this.btCloseReport.UseVisualStyleBackColor = true;
            this.btCloseReport.Visible = false;
            this.btCloseReport.Click += new System.EventHandler(this.btCloseReport_Click);
            // 
            // lbAverageTime
            // 
            this.lbAverageTime.AutoSize = true;
            this.lbAverageTime.Location = new System.Drawing.Point(82, 337);
            this.lbAverageTime.Name = "lbAverageTime";
            this.lbAverageTime.Size = new System.Drawing.Size(236, 25);
            this.lbAverageTime.TabIndex = 2;
            this.lbAverageTime.Text = "Average time calculate:";
            // 
            // lbSuccessRate
            // 
            this.lbSuccessRate.AutoSize = true;
            this.lbSuccessRate.Location = new System.Drawing.Point(82, 382);
            this.lbSuccessRate.Name = "lbSuccessRate";
            this.lbSuccessRate.Size = new System.Drawing.Size(143, 25);
            this.lbSuccessRate.TabIndex = 2;
            this.lbSuccessRate.Text = "Success rate:";
            // 
            // lbNumFailures
            // 
            this.lbNumFailures.AutoSize = true;
            this.lbNumFailures.Location = new System.Drawing.Point(82, 246);
            this.lbNumFailures.Name = "lbNumFailures";
            this.lbNumFailures.Size = new System.Drawing.Size(187, 25);
            this.lbNumFailures.TabIndex = 2;
            this.lbNumFailures.Text = "Number of failures";
            // 
            // lbNumSuccessfull
            // 
            this.lbNumSuccessfull.AutoSize = true;
            this.lbNumSuccessfull.Location = new System.Drawing.Point(82, 201);
            this.lbNumSuccessfull.Name = "lbNumSuccessfull";
            this.lbNumSuccessfull.Size = new System.Drawing.Size(230, 25);
            this.lbNumSuccessfull.TabIndex = 2;
            this.lbNumSuccessfull.Text = "Number of successfull:";
            // 
            // lbTotalTime
            // 
            this.lbTotalTime.AutoSize = true;
            this.lbTotalTime.Location = new System.Drawing.Point(82, 294);
            this.lbTotalTime.Name = "lbTotalTime";
            this.lbTotalTime.Size = new System.Drawing.Size(210, 25);
            this.lbTotalTime.TabIndex = 2;
            this.lbTotalTime.Text = "Total time calculate: ";
            // 
            // lbNumKeys
            // 
            this.lbNumKeys.AutoSize = true;
            this.lbNumKeys.Location = new System.Drawing.Point(82, 155);
            this.lbNumKeys.Name = "lbNumKeys";
            this.lbNumKeys.Size = new System.Drawing.Size(174, 25);
            this.lbNumKeys.TabIndex = 2;
            this.lbNumKeys.Text = "Number of keys: ";
            // 
            // lbKeyLength
            // 
            this.lbKeyLength.AutoSize = true;
            this.lbKeyLength.Location = new System.Drawing.Point(82, 112);
            this.lbKeyLength.Name = "lbKeyLength";
            this.lbKeyLength.Size = new System.Drawing.Size(126, 25);
            this.lbKeyLength.TabIndex = 2;
            this.lbKeyLength.Text = "Key length: ";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Comic Sans MS", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(150, 6);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(515, 74);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Attack RSA Report";
            // 
            // bgWorker2
            // 
            this.bgWorker2.WorkerReportsProgress = true;
            this.bgWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker2_DoWork);
            this.bgWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker2_RunWorkerCompleted);
            // 
            // ContinuedFractionAttack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 565);
            this.Controls.Add(this.tbCFA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ContinuedFractionAttack";
            this.Text = "Continued Fraction Attack";
            this.tbCFA.ResumeLayout(false);
            this.tbCF.ResumeLayout(false);
            this.tbCF.PerformLayout();
            this.tbReport.ResumeLayout(false);
            this.pnReport.ResumeLayout(false);
            this.pnReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lbN;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.Label lbE;

        public System.Windows.Forms.ListBox LstResult
        {
            get { return lstResult; }
            set { lstResult = value; }
        }
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnImportJson;
        private System.Windows.Forms.OpenFileDialog openJsonFileDialog;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tbCFA;
        private System.Windows.Forms.TabPage tbCF;
        private System.Windows.Forms.TabPage tbReport;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button btLoadReport;
        private System.Windows.Forms.Panel pnReport;
        private System.Windows.Forms.Label lbAverageTime;
        private System.Windows.Forms.Label lbSuccessRate;
        private System.Windows.Forms.Label lbNumFailures;
        private System.Windows.Forms.Label lbNumSuccessfull;
        private System.Windows.Forms.Label lbTotalTime;
        private System.Windows.Forms.Label lbNumKeys;
        private System.Windows.Forms.Label lbKeyLength;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btCloseReport;
        private System.ComponentModel.BackgroundWorker bgWorker2;
    }
}

