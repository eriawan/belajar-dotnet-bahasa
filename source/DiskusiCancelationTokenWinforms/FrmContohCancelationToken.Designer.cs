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
            gboxCancelationTokenDemo = new GroupBox();
            lblIterationSequence = new Label();
            lblTaskStatus = new Label();
            btnCancelAsync = new Button();
            btnRunAsyncCancelation = new Button();
            lblTaskStatusLabel = new Label();
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
            gboxCancelationTokenDemo.Location = new Point(12, 12);
            gboxCancelationTokenDemo.Name = "gboxCancelationTokenDemo";
            gboxCancelationTokenDemo.Size = new Size(776, 128);
            gboxCancelationTokenDemo.TabIndex = 0;
            gboxCancelationTokenDemo.TabStop = false;
            gboxCancelationTokenDemo.Text = "CancelationToken demo";
            // 
            // lblIterationSequence
            // 
            lblIterationSequence.AutoSize = true;
            lblIterationSequence.Location = new Point(484, 37);
            lblIterationSequence.Name = "lblIterationSequence";
            lblIterationSequence.Size = new Size(132, 15);
            lblIterationSequence.TabIndex = 4;
            lblIterationSequence.Text = "Iteration sequence: N/A";
            // 
            // lblTaskStatus
            // 
            lblTaskStatus.AutoSize = true;
            lblTaskStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskStatus.Location = new Point(588, 74);
            lblTaskStatus.Name = "lblTaskStatus";
            lblTaskStatus.Size = new Size(95, 21);
            lblTaskStatus.TabIndex = 3;
            lblTaskStatus.Text = "Not running";
            // 
            // btnCancelAsync
            // 
            btnCancelAsync.Location = new Point(177, 72);
            btnCancelAsync.Name = "btnCancelAsync";
            btnCancelAsync.Size = new Size(260, 23);
            btnCancelAsync.TabIndex = 2;
            btnCancelAsync.Text = "Cancel async";
            btnCancelAsync.UseVisualStyleBackColor = true;
            btnCancelAsync.Click += btnCancelAsync_Click;
            // 
            // btnRunAsyncCancelation
            // 
            btnRunAsyncCancelation.Location = new Point(177, 35);
            btnRunAsyncCancelation.Name = "btnRunAsyncCancelation";
            btnRunAsyncCancelation.Size = new Size(260, 23);
            btnRunAsyncCancelation.TabIndex = 1;
            btnRunAsyncCancelation.Text = "Run async with CancelationToken support";
            btnRunAsyncCancelation.UseVisualStyleBackColor = true;
            btnRunAsyncCancelation.Click += btnRunAsyncCancelation_Click;
            // 
            // lblTaskStatusLabel
            // 
            lblTaskStatusLabel.AutoSize = true;
            lblTaskStatusLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskStatusLabel.Location = new Point(475, 78);
            lblTaskStatusLabel.Name = "lblTaskStatusLabel";
            lblTaskStatusLabel.Size = new Size(75, 17);
            lblTaskStatusLabel.TabIndex = 0;
            lblTaskStatusLabel.Text = "Task Status:";
            // 
            // FrmContohCancelationToken
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gboxCancelationTokenDemo);
            Name = "FrmContohCancelationToken";
            Text = "Contoh Cancelation Token";
            gboxCancelationTokenDemo.ResumeLayout(false);
            gboxCancelationTokenDemo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gboxCancelationTokenDemo;
        private Label lblTaskStatusLabel;
        private Label lblTaskStatus;
        private Button btnCancelAsync;
        private Button btnRunAsyncCancelation;
        private Label lblIterationSequence;
    }
}
