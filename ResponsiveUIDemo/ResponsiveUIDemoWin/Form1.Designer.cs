namespace ResponsiveUIDemoWin
{
    partial class Form1
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
            this.cmdThreadPool = new System.Windows.Forms.Button();
            this.cmdBackgroundWorker = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmdTAPMethod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdThreadPool
            // 
            this.cmdThreadPool.Location = new System.Drawing.Point(12, 56);
            this.cmdThreadPool.Name = "cmdThreadPool";
            this.cmdThreadPool.Size = new System.Drawing.Size(142, 23);
            this.cmdThreadPool.TabIndex = 0;
            this.cmdThreadPool.Text = "Threadpool method";
            this.cmdThreadPool.UseVisualStyleBackColor = true;
            this.cmdThreadPool.Click += new System.EventHandler(this.cmdThreadPool_Click);
            // 
            // cmdBackgroundWorker
            // 
            this.cmdBackgroundWorker.Location = new System.Drawing.Point(160, 56);
            this.cmdBackgroundWorker.Name = "cmdBackgroundWorker";
            this.cmdBackgroundWorker.Size = new System.Drawing.Size(142, 23);
            this.cmdBackgroundWorker.TabIndex = 1;
            this.cmdBackgroundWorker.Text = "Background worker";
            this.cmdBackgroundWorker.UseVisualStyleBackColor = true;
            this.cmdBackgroundWorker.Click += new System.EventHandler(this.cmdBackgroundWorker_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 99);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(438, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // cmdTAPMethod
            // 
            this.cmdTAPMethod.Location = new System.Drawing.Point(308, 56);
            this.cmdTAPMethod.Name = "cmdTAPMethod";
            this.cmdTAPMethod.Size = new System.Drawing.Size(142, 23);
            this.cmdTAPMethod.TabIndex = 1;
            this.cmdTAPMethod.Text = "Progress Reporting Pattern";
            this.cmdTAPMethod.UseVisualStyleBackColor = true;
            this.cmdTAPMethod.Click += new System.EventHandler(this.cmdTAPMethod_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 137);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdTAPMethod);
            this.Controls.Add(this.cmdBackgroundWorker);
            this.Controls.Add(this.cmdThreadPool);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdThreadPool;
        private System.Windows.Forms.Button cmdBackgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cmdTAPMethod;
    }
}

