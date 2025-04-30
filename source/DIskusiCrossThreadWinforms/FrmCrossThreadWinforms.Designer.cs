namespace DIskusiCrossThreadWinforms
{
    partial class FrmCrossThreadWinforms
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timerCheckForBlocking = new System.Windows.Forms.Timer(components);
            btnRunAsyncMethodAsync = new Button();
            lblCurrentTime = new Label();
            btnRunAsyncMethodCrossThread = new Button();
            lblReproCrossThread = new Label();
            btnCreateNewThread = new Button();
            lblUnsafeCrossThread = new Label();
            btnRunAsyncInParallel = new Button();
            SuspendLayout();
            // 
            // timerCheckForBlocking
            // 
            timerCheckForBlocking.Enabled = true;
            timerCheckForBlocking.Tick += timerCheckForBlocking_Tick;
            // 
            // btnRunAsyncMethodAsync
            // 
            btnRunAsyncMethodAsync.Location = new Point(467, 168);
            btnRunAsyncMethodAsync.Margin = new Padding(3, 4, 3, 4);
            btnRunAsyncMethodAsync.Name = "btnRunAsyncMethodAsync";
            btnRunAsyncMethodAsync.Size = new Size(232, 31);
            btnRunAsyncMethodAsync.TabIndex = 0;
            btnRunAsyncMethodAsync.Text = "Run async method asynchronously";
            btnRunAsyncMethodAsync.UseVisualStyleBackColor = true;
            btnRunAsyncMethodAsync.Click += btnRunAsyncMethodAsync_Click;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(93, 160);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(94, 20);
            lblCurrentTime.TabIndex = 1;
            lblCurrentTime.Text = "Current time:";
            lblCurrentTime.Click += label1_Click;
            // 
            // btnRunAsyncMethodCrossThread
            // 
            btnRunAsyncMethodCrossThread.Location = new Point(471, 221);
            btnRunAsyncMethodCrossThread.Margin = new Padding(3, 4, 3, 4);
            btnRunAsyncMethodCrossThread.Name = "btnRunAsyncMethodCrossThread";
            btnRunAsyncMethodCrossThread.Size = new Size(289, 31);
            btnRunAsyncMethodCrossThread.TabIndex = 2;
            btnRunAsyncMethodCrossThread.Text = "Run async method with possible cross thread";
            btnRunAsyncMethodCrossThread.UseVisualStyleBackColor = true;
            btnRunAsyncMethodCrossThread.Click += btnRunAsyncMethodCrossThread_Click;
            // 
            // lblReproCrossThread
            // 
            lblReproCrossThread.AutoSize = true;
            lblReproCrossThread.Location = new Point(89, 221);
            lblReproCrossThread.Name = "lblReproCrossThread";
            lblReproCrossThread.Size = new Size(279, 20);
            lblReproCrossThread.TabIndex = 3;
            lblReproCrossThread.Text = "Sample label cross thread. Time elapsed:";
            // 
            // btnCreateNewThread
            // 
            btnCreateNewThread.Location = new Point(467, 276);
            btnCreateNewThread.Margin = new Padding(3, 4, 3, 4);
            btnCreateNewThread.Name = "btnCreateNewThread";
            btnCreateNewThread.Size = new Size(293, 31);
            btnCreateNewThread.TabIndex = 4;
            btnCreateNewThread.Text = "Create new thread within button click handler";
            btnCreateNewThread.UseVisualStyleBackColor = true;
            btnCreateNewThread.Click += btnCreateNewThread_Click;
            // 
            // lblUnsafeCrossThread
            // 
            lblUnsafeCrossThread.AutoSize = true;
            lblUnsafeCrossThread.Location = new Point(88, 279);
            lblUnsafeCrossThread.Name = "lblUnsafeCrossThread";
            lblUnsafeCrossThread.Size = new Size(209, 20);
            lblUnsafeCrossThread.TabIndex = 5;
            lblUnsafeCrossThread.Text = "Sample unsafe label container";
            // 
            // btnRunAsyncInParallel
            // 
            btnRunAsyncInParallel.Location = new Point(315, 362);
            btnRunAsyncInParallel.Name = "btnRunAsyncInParallel";
            btnRunAsyncInParallel.Size = new Size(225, 29);
            btnRunAsyncInParallel.TabIndex = 6;
            btnRunAsyncInParallel.Text = "Run async in parallel";
            btnRunAsyncInParallel.UseVisualStyleBackColor = true;
            btnRunAsyncInParallel.Click += btnRunAsyncInParallel_Click;
            // 
            // FrmCrossThreadWinforms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnRunAsyncInParallel);
            Controls.Add(lblUnsafeCrossThread);
            Controls.Add(btnCreateNewThread);
            Controls.Add(lblReproCrossThread);
            Controls.Add(btnRunAsyncMethodCrossThread);
            Controls.Add(lblCurrentTime);
            Controls.Add(btnRunAsyncMethodAsync);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCrossThreadWinforms";
            Text = "Contoh reproduce cross thread di Winforms";
            Load += FrmCrossThreadWinforms_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timerCheckForBlocking;
        private Button btnRunAsyncMethodAsync;
        private Label lblCurrentTime;
        private Button btnRunAsyncMethodCrossThread;
        private Label lblReproCrossThread;
        private Button btnCreateNewThread;
        private Label lblUnsafeCrossThread;
        private Button btnRunAsyncInParallel;
    }
}
