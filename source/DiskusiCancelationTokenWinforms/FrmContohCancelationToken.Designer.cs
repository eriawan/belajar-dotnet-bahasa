namespace DiskusiCancelationTokenWinforms
{
    partial class FrmContohCancelationToken
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
            gboxCancelationTokenDemo = new GroupBox();
            lblIterationSequence = new Label();
            lblTaskStatus = new Label();
            btnCancelAsync = new Button();
            btnRunAsyncCancelation = new Button();
            lblTaskStatusLabel = new Label();
            timerJam = new System.Windows.Forms.Timer(components);
            lblJamSekarang = new Label();
            gboxCancelationTokenDemo.SuspendLayout();
            SuspendLayout();
            // 
            // gboxCancelationTokenDemo
            // 
            gboxCancelationTokenDemo.Controls.Add(lblIterationSequence);
            gboxCancelationTokenDemo.Controls.Add(lblTaskStatus);
            gboxCancelationTokenDemo.Controls.Add(btnCancelAsync);
            gboxCancelationTokenDemo.Controls.Add(btnRunAsyncCancelation);
            gboxCancelationTokenDemo.Controls.Add(lblTaskStatusLabel);
            gboxCancelationTokenDemo.Location = new Point(14, 16);
            gboxCancelationTokenDemo.Margin = new Padding(3, 4, 3, 4);
            gboxCancelationTokenDemo.Name = "gboxCancelationTokenDemo";
            gboxCancelationTokenDemo.Padding = new Padding(3, 4, 3, 4);
            gboxCancelationTokenDemo.Size = new Size(887, 171);
            gboxCancelationTokenDemo.TabIndex = 0;
            gboxCancelationTokenDemo.TabStop = false;
            gboxCancelationTokenDemo.Text = "CancelationToken demo";
            // 
            // lblIterationSequence
            // 
            lblIterationSequence.AutoSize = true;
            lblIterationSequence.Location = new Point(553, 49);
            lblIterationSequence.Name = "lblIterationSequence";
            lblIterationSequence.Size = new Size(165, 20);
            lblIterationSequence.TabIndex = 4;
            lblIterationSequence.Text = "Iteration sequence: N/A";
            // 
            // lblTaskStatus
            // 
            lblTaskStatus.AutoSize = true;
            lblTaskStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskStatus.Location = new Point(672, 99);
            lblTaskStatus.Name = "lblTaskStatus";
            lblTaskStatus.Size = new Size(119, 28);
            lblTaskStatus.TabIndex = 3;
            lblTaskStatus.Text = "Not running";
            // 
            // btnCancelAsync
            // 
            btnCancelAsync.Location = new Point(202, 96);
            btnCancelAsync.Margin = new Padding(3, 4, 3, 4);
            btnCancelAsync.Name = "btnCancelAsync";
            btnCancelAsync.Size = new Size(297, 31);
            btnCancelAsync.TabIndex = 2;
            btnCancelAsync.Text = "Cancel async";
            btnCancelAsync.UseVisualStyleBackColor = true;
            btnCancelAsync.Click += btnCancelAsync_Click;
            // 
            // btnRunAsyncCancelation
            // 
            btnRunAsyncCancelation.Location = new Point(202, 47);
            btnRunAsyncCancelation.Margin = new Padding(3, 4, 3, 4);
            btnRunAsyncCancelation.Name = "btnRunAsyncCancelation";
            btnRunAsyncCancelation.Size = new Size(297, 31);
            btnRunAsyncCancelation.TabIndex = 1;
            btnRunAsyncCancelation.Text = "Run async with CancelationToken support";
            btnRunAsyncCancelation.UseVisualStyleBackColor = true;
            btnRunAsyncCancelation.Click += btnRunAsyncCancelation_Click;
            // 
            // lblTaskStatusLabel
            // 
            lblTaskStatusLabel.AutoSize = true;
            lblTaskStatusLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskStatusLabel.Location = new Point(543, 104);
            lblTaskStatusLabel.Name = "lblTaskStatusLabel";
            lblTaskStatusLabel.Size = new Size(96, 23);
            lblTaskStatusLabel.TabIndex = 0;
            lblTaskStatusLabel.Text = "Task Status:";
            // 
            // timerJam
            // 
            timerJam.Interval = 500;
            timerJam.Tick += timerJam_Tick;
            // 
            // lblJamSekarang
            // 
            lblJamSekarang.AutoSize = true;
            lblJamSekarang.Location = new Point(23, 215);
            lblJamSekarang.Name = "lblJamSekarang";
            lblJamSekarang.Size = new Size(89, 20);
            lblJamSekarang.TabIndex = 1;
            lblJamSekarang.Text = "Jam saat ini:";
            // 
            // FrmContohCancelationToken
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(lblJamSekarang);
            Controls.Add(gboxCancelationTokenDemo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmContohCancelationToken";
            Text = "Contoh Cancelation Token";
            Load += FrmContohCancelationToken_Load;
            gboxCancelationTokenDemo.ResumeLayout(false);
            gboxCancelationTokenDemo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gboxCancelationTokenDemo;
        private Label lblTaskStatusLabel;
        private Label lblTaskStatus;
        private Button btnCancelAsync;
        private Button btnRunAsyncCancelation;
        private Label lblIterationSequence;
        private System.Windows.Forms.Timer timerJam;
        private Label lblJamSekarang;
    }
}
