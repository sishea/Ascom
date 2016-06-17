namespace AscomIntegrationSimulator
{
    partial class Simulator
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
            this._txtScript = new System.Windows.Forms.TextBox();
            this._btnScript = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtLog = new System.Windows.Forms.TextBox();
            this._btnLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtScript
            // 
            this._txtScript.Location = new System.Drawing.Point(88, 13);
            this._txtScript.Name = "_txtScript";
            this._txtScript.Size = new System.Drawing.Size(374, 20);
            this._txtScript.TabIndex = 0;
            // 
            // _btnScript
            // 
            this._btnScript.Location = new System.Drawing.Point(468, 12);
            this._btnScript.Name = "_btnScript";
            this._btnScript.Size = new System.Drawing.Size(75, 23);
            this._btnScript.TabIndex = 1;
            this._btnScript.Text = "Browse...";
            this._btnScript.UseVisualStyleBackColor = true;
            this._btnScript.Click += new System.EventHandler(this.ScriptClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Test Script";
            // 
            // _txtLog
            // 
            this._txtLog.Location = new System.Drawing.Point(88, 42);
            this._txtLog.Name = "_txtLog";
            this._txtLog.Size = new System.Drawing.Size(374, 20);
            this._txtLog.TabIndex = 0;
            // 
            // _btnLog
            // 
            this._btnLog.Location = new System.Drawing.Point(468, 41);
            this._btnLog.Name = "_btnLog";
            this._btnLog.Size = new System.Drawing.Size(75, 23);
            this._btnLog.TabIndex = 1;
            this._btnLog.Text = "Browse...";
            this._btnLog.UseVisualStyleBackColor = true;
            this._btnLog.Click += new System.EventHandler(this.LogClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Log File";
            // 
            // _btnRun
            // 
            this._btnRun.Location = new System.Drawing.Point(468, 70);
            this._btnRun.Name = "_btnRun";
            this._btnRun.Size = new System.Drawing.Size(75, 23);
            this._btnRun.TabIndex = 1;
            this._btnRun.Text = "Run Script";
            this._btnRun.UseVisualStyleBackColor = true;
            this._btnRun.Click += new System.EventHandler(this.RunClick);
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 103);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnRun);
            this.Controls.Add(this._btnLog);
            this.Controls.Add(this._txtLog);
            this.Controls.Add(this._btnScript);
            this.Controls.Add(this._txtScript);
            this.Name = "Simulator";
            this.Text = "Ascom - Integration Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtScript;
        private System.Windows.Forms.Button _btnScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtLog;
        private System.Windows.Forms.Button _btnLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnRun;
    }
}

