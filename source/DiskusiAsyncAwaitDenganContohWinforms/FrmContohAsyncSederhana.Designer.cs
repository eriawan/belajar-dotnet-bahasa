
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
            // FrmContohAsyncSederhana
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
