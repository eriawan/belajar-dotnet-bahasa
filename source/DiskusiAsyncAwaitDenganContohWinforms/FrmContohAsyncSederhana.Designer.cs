
namespace DiskusiAsyncAwaitDenganContohWinforms
{
    partial class FrmContohAsyncSederhana
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
            lblSyncProcess = new Label();
            lblAsyncProcess = new Label();
            btnRunSyncProc = new Button();
            btnRunAsync = new Button();
            timerBlockingTest = new System.Windows.Forms.Timer(components);
            lblCurrentTime = new Label();
            btnRunAsyncSynchronously = new Button();
            lblRunAsyncCrossThreadUI = new Label();
            btnRunAsyncInCrossThread = new Button();
            lblRunAsyncProcess = new Label();
            SuspendLayout();
            // 
            // lblSyncProcess
            // 
            lblSyncProcess.AutoSize = true;
            lblSyncProcess.Location = new Point(104, 76);
            lblSyncProcess.Name = "lblSyncProcess";
            lblSyncProcess.Size = new Size(165, 15);
            lblSyncProcess.TabIndex = 0;
            lblSyncProcess.Text = "Simulasi synchronous process";
            // 
            // lblAsyncProcess
            // 
            lblAsyncProcess.AutoSize = true;
            lblAsyncProcess.Location = new Point(104, 217);
            lblAsyncProcess.Name = "lblAsyncProcess";
            lblAsyncProcess.Size = new Size(171, 15);
            lblAsyncProcess.TabIndex = 1;
            lblAsyncProcess.Text = "Simulasi asynchronous process";
            // 
            // btnRunSyncProc
            // 
            btnRunSyncProc.Location = new Point(342, 75);
            btnRunSyncProc.Name = "btnRunSyncProc";
            btnRunSyncProc.Size = new Size(229, 23);
            btnRunSyncProc.TabIndex = 2;
            btnRunSyncProc.Text = "Run synchronous process";
            btnRunSyncProc.UseVisualStyleBackColor = true;
            btnRunSyncProc.Click += btnRunSyncProc_Click;
            // 
            // btnRunAsync
            // 
            btnRunAsync.Location = new Point(342, 217);
            btnRunAsync.Name = "btnRunAsync";
            btnRunAsync.Size = new Size(229, 23);
            btnRunAsync.TabIndex = 3;
            btnRunAsync.Text = "Run asynchronous process";
            btnRunAsync.UseVisualStyleBackColor = true;
            btnRunAsync.Click += btnRunAsync_Click;
            // 
            // timerBlockingTest
            // 
            timerBlockingTest.Tick += timerBlockingTest_Tick;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentTime.Location = new Point(115, 139);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(140, 30);
            lblCurrentTime.TabIndex = 4;
            lblCurrentTime.Text = "Current time: ";
            // 
            // btnRunAsyncSynchronously
            // 
            btnRunAsyncSynchronously.Location = new Point(342, 262);
            btnRunAsyncSynchronously.Name = "btnRunAsyncSynchronously";
            btnRunAsyncSynchronously.Size = new Size(229, 23);
            btnRunAsyncSynchronously.TabIndex = 5;
            btnRunAsyncSynchronously.Text = "Run async process synchronously";
            btnRunAsyncSynchronously.UseVisualStyleBackColor = true;
            btnRunAsyncSynchronously.Click += btnRunAsyncSynchronously_Click;
            // 
            // lblRunAsyncCrossThreadUI
            // 
            lblRunAsyncCrossThreadUI.AutoSize = true;
            lblRunAsyncCrossThreadUI.Location = new Point(342, 345);
            lblRunAsyncCrossThreadUI.Name = "lblRunAsyncCrossThreadUI";
            lblRunAsyncCrossThreadUI.Size = new Size(150, 15);
            lblRunAsyncCrossThreadUI.TabIndex = 6;
            lblRunAsyncCrossThreadUI.Text = "lblRunAsyncCrossThreadUI";
            // 
            // btnRunAsyncInCrossThread
            // 
            btnRunAsyncInCrossThread.Location = new Point(342, 319);
            btnRunAsyncInCrossThread.Name = "btnRunAsyncInCrossThread";
            btnRunAsyncInCrossThread.Size = new Size(229, 23);
            btnRunAsyncInCrossThread.TabIndex = 7;
            btnRunAsyncInCrossThread.Text = "Run async process in crossing UI thread";
            btnRunAsyncInCrossThread.UseVisualStyleBackColor = true;
            btnRunAsyncInCrossThread.Click += btnRunAsyncInCrossThread_Click;
            // 
            // lblRunAsyncProcess
            // 
            lblRunAsyncProcess.AutoSize = true;
            lblRunAsyncProcess.Location = new Point(591, 221);
            lblRunAsyncProcess.Name = "lblRunAsyncProcess";
            lblRunAsyncProcess.Size = new Size(113, 15);
            lblRunAsyncProcess.TabIndex = 8;
            lblRunAsyncProcess.Text = "lblRunAsyncProcess";
            // 
            // FrmContohAsyncSederhana
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblRunAsyncProcess);
            Controls.Add(btnRunAsyncInCrossThread);
            Controls.Add(lblRunAsyncCrossThreadUI);
            Controls.Add(btnRunAsyncSynchronously);
            Controls.Add(lblCurrentTime);
            Controls.Add(btnRunAsync);
            Controls.Add(btnRunSyncProc);
            Controls.Add(lblAsyncProcess);
            Controls.Add(lblSyncProcess);
            DoubleBuffered = true;
            Name = "FrmContohAsyncSederhana";
            Text = "Form Contoh Async";
            Load += FrmContohAsyncSederhana_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSyncProcess;
        private Label lblAsyncProcess;
        private Button btnRunSyncProc;
        private Button btnRunAsync;
        private System.Windows.Forms.Timer timerBlockingTest;
        private Label lblCurrentTime;
        private Button btnRunAsyncSynchronously;
        private Label lblRunAsyncCrossThreadUI;
        private Button btnRunAsyncInCrossThread;
        private Label lblRunAsyncProcess;
    }
}
