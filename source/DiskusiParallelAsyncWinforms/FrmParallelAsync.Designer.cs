namespace DiskusiParallelAsyncWinforms
{
    partial class FrmParallelAsync
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
            grpParallelFForCallAsync = new GroupBox();
            btnClearParallelForText = new Button();
            txtParalleForCallSync = new TextBox();
            btnParallelForToCallSyncMethod = new Button();
            tmrCurrentTime = new System.Windows.Forms.Timer(components);
            lblCurrentTime = new Label();
            grpTaskWhenAll = new GroupBox();
            txtTaskWhenAll = new TextBox();
            btnAwaitTaskWhenAll = new Button();
            grpParallelForAsync = new GroupBox();
            txtParallelForAsync = new TextBox();
            btnParallelForAsync = new Button();
            grpParallelFForCallAsync.SuspendLayout();
            grpTaskWhenAll.SuspendLayout();
            grpParallelForAsync.SuspendLayout();
            SuspendLayout();
            // 
            // grpParallelFForCallAsync
            // 
            grpParallelFForCallAsync.Controls.Add(btnClearParallelForText);
            grpParallelFForCallAsync.Controls.Add(txtParalleForCallSync);
            grpParallelFForCallAsync.Controls.Add(btnParallelForToCallSyncMethod);
            grpParallelFForCallAsync.Location = new Point(15, 60);
            grpParallelFForCallAsync.Name = "grpParallelFForCallAsync";
            grpParallelFForCallAsync.Size = new Size(747, 123);
            grpParallelFForCallAsync.TabIndex = 0;
            grpParallelFForCallAsync.TabStop = false;
            grpParallelFForCallAsync.Text = "Sample Parallel.For call sync method";
            // 
            // btnClearParallelForText
            // 
            btnClearParallelForText.Location = new Point(549, 42);
            btnClearParallelForText.Name = "btnClearParallelForText";
            btnClearParallelForText.Size = new Size(153, 23);
            btnClearParallelForText.TabIndex = 3;
            btnClearParallelForText.Text = "Clear Parallel.For text";
            btnClearParallelForText.UseVisualStyleBackColor = true;
            btnClearParallelForText.Click += btnClearParallelForText_Click;
            // 
            // txtParalleForCallSync
            // 
            txtParalleForCallSync.Location = new Point(289, 22);
            txtParalleForCallSync.Multiline = true;
            txtParalleForCallSync.Name = "txtParalleForCallSync";
            txtParalleForCallSync.ReadOnly = true;
            txtParalleForCallSync.ScrollBars = ScrollBars.Vertical;
            txtParalleForCallSync.Size = new Size(242, 87);
            txtParalleForCallSync.TabIndex = 2;
            // 
            // btnParallelForToCallSyncMethod
            // 
            btnParallelForToCallSyncMethod.Location = new Point(23, 42);
            btnParallelForToCallSyncMethod.Name = "btnParallelForToCallSyncMethod";
            btnParallelForToCallSyncMethod.Size = new Size(237, 23);
            btnParallelForToCallSyncMethod.TabIndex = 0;
            btnParallelForToCallSyncMethod.Text = "Call sync method within Parallel.For";
            btnParallelForToCallSyncMethod.UseVisualStyleBackColor = true;
            btnParallelForToCallSyncMethod.Click += btnParallelForToCallSyncMethod_Click;
            // 
            // tmrCurrentTime
            // 
            tmrCurrentTime.Tick += tmrCurrentTime_Tick;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentTime.Location = new Point(15, 9);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(101, 21);
            lblCurrentTime.TabIndex = 1;
            lblCurrentTime.Text = "Current time:";
            // 
            // grpTaskWhenAll
            // 
            grpTaskWhenAll.Controls.Add(txtTaskWhenAll);
            grpTaskWhenAll.Controls.Add(btnAwaitTaskWhenAll);
            grpTaskWhenAll.Location = new Point(15, 202);
            grpTaskWhenAll.Name = "grpTaskWhenAll";
            grpTaskWhenAll.Size = new Size(744, 135);
            grpTaskWhenAll.TabIndex = 2;
            grpTaskWhenAll.TabStop = false;
            grpTaskWhenAll.Text = "Sample awaiting Task.WhenAll";
            // 
            // txtTaskWhenAll
            // 
            txtTaskWhenAll.Location = new Point(289, 22);
            txtTaskWhenAll.Multiline = true;
            txtTaskWhenAll.Name = "txtTaskWhenAll";
            txtTaskWhenAll.ReadOnly = true;
            txtTaskWhenAll.ScrollBars = ScrollBars.Vertical;
            txtTaskWhenAll.Size = new Size(242, 93);
            txtTaskWhenAll.TabIndex = 3;
            // 
            // btnAwaitTaskWhenAll
            // 
            btnAwaitTaskWhenAll.Location = new Point(23, 44);
            btnAwaitTaskWhenAll.Name = "btnAwaitTaskWhenAll";
            btnAwaitTaskWhenAll.Size = new Size(237, 23);
            btnAwaitTaskWhenAll.TabIndex = 3;
            btnAwaitTaskWhenAll.Text = "Call and await Task.WhenAll";
            btnAwaitTaskWhenAll.UseVisualStyleBackColor = true;
            btnAwaitTaskWhenAll.Click += btnAwaitTaskWhenAll_Click;
            // 
            // grpParallelForAsync
            // 
            grpParallelForAsync.Controls.Add(txtParallelForAsync);
            grpParallelForAsync.Controls.Add(btnParallelForAsync);
            grpParallelForAsync.Location = new Point(15, 358);
            grpParallelForAsync.Name = "grpParallelForAsync";
            grpParallelForAsync.Size = new Size(744, 135);
            grpParallelForAsync.TabIndex = 4;
            grpParallelForAsync.TabStop = false;
            grpParallelForAsync.Text = "Sample using Parallel.ForAsync";
            // 
            // txtParallelForAsync
            // 
            txtParallelForAsync.Location = new Point(289, 22);
            txtParallelForAsync.Multiline = true;
            txtParallelForAsync.Name = "txtParallelForAsync";
            txtParallelForAsync.ReadOnly = true;
            txtParallelForAsync.ScrollBars = ScrollBars.Vertical;
            txtParallelForAsync.Size = new Size(242, 93);
            txtParallelForAsync.TabIndex = 3;
            // 
            // btnParallelForAsync
            // 
            btnParallelForAsync.Location = new Point(23, 44);
            btnParallelForAsync.Name = "btnParallelForAsync";
            btnParallelForAsync.Size = new Size(237, 23);
            btnParallelForAsync.TabIndex = 3;
            btnParallelForAsync.Text = "Call and await Parallel.ForAsync";
            btnParallelForAsync.UseVisualStyleBackColor = true;
            btnParallelForAsync.Click += btnParallelForAsync_Click;
            // 
            // FrmParallelAsync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 505);
            Controls.Add(grpParallelForAsync);
            Controls.Add(grpTaskWhenAll);
            Controls.Add(lblCurrentTime);
            Controls.Add(grpParallelFForCallAsync);
            Name = "FrmParallelAsync";
            Text = "Contoh Parallel dan Async";
            Load += FrmParallelAsync_Load;
            grpParallelFForCallAsync.ResumeLayout(false);
            grpParallelFForCallAsync.PerformLayout();
            grpTaskWhenAll.ResumeLayout(false);
            grpTaskWhenAll.PerformLayout();
            grpParallelForAsync.ResumeLayout(false);
            grpParallelForAsync.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpParallelFForCallAsync;
        private System.Windows.Forms.Timer tmrCurrentTime;
        private Label lblCurrentTime;
        private TextBox txtParalleForCallSync;
        private Button btnParallelForToCallSyncMethod;
        private GroupBox grpTaskWhenAll;
        private Button btnAwaitTaskWhenAll;
        private TextBox txtTaskWhenAll;
        private GroupBox grpParallelForAsync;
        private TextBox txtParallelForAsync;
        private Button btnParallelForAsync;
        private Button btnClearParallelForText;
    }
}
