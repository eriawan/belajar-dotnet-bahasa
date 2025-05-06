namespace DiskusiAwaitableWinforms
{
    partial class FrmAwaitableWinforms
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
            lblRemarkContohAwaitableUIFalse = new Label();
            btnCallAsyncUIAwaitableFalse = new Button();
            lblRemarkContohAwaitableUIFalseLogicUI = new Label();
            btnCallAsyncUIAwaitFalseWithAddUI = new Button();
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI = new Label();
            label1 = new Label();
            btnCallAsyncUIAwaitTrueWithAddUI = new Button();
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            btnCallAsyncUIThenWait = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // lblRemarkContohAwaitableUIFalse
            // 
            lblRemarkContohAwaitableUIFalse.AutoSize = true;
            lblRemarkContohAwaitableUIFalse.Location = new Point(11, 34);
            lblRemarkContohAwaitableUIFalse.Name = "lblRemarkContohAwaitableUIFalse";
            lblRemarkContohAwaitableUIFalse.Size = new Size(369, 20);
            lblRemarkContohAwaitableUIFalse.TabIndex = 0;
            lblRemarkContohAwaitableUIFalse.Text = "Contoh call asynchronous task set awaitable false di UI";
            // 
            // btnCallAsyncUIAwaitableFalse
            // 
            btnCallAsyncUIAwaitableFalse.Location = new Point(11, 72);
            btnCallAsyncUIAwaitableFalse.Margin = new Padding(3, 4, 3, 4);
            btnCallAsyncUIAwaitableFalse.Name = "btnCallAsyncUIAwaitableFalse";
            btnCallAsyncUIAwaitableFalse.Size = new Size(480, 31);
            btnCallAsyncUIAwaitableFalse.TabIndex = 1;
            btnCallAsyncUIAwaitableFalse.Text = "Call async with configureawaitable set to false on UI";
            btnCallAsyncUIAwaitableFalse.UseVisualStyleBackColor = true;
            btnCallAsyncUIAwaitableFalse.Click += btnCallAsyncUIAwaitableFalse_Click;
            // 
            // lblRemarkContohAwaitableUIFalseLogicUI
            // 
            lblRemarkContohAwaitableUIFalseLogicUI.AutoSize = true;
            lblRemarkContohAwaitableUIFalseLogicUI.Location = new Point(11, 38);
            lblRemarkContohAwaitableUIFalseLogicUI.Name = "lblRemarkContohAwaitableUIFalseLogicUI";
            lblRemarkContohAwaitableUIFalseLogicUI.Size = new Size(720, 20);
            lblRemarkContohAwaitableUIFalseLogicUI.TabIndex = 2;
            lblRemarkContohAwaitableUIFalseLogicUI.Text = "Contoh call asynchronous task set awaitable false di UI, tetapi kemudian ada code set property control di UI";
            // 
            // btnCallAsyncUIAwaitFalseWithAddUI
            // 
            btnCallAsyncUIAwaitFalseWithAddUI.Location = new Point(11, 81);
            btnCallAsyncUIAwaitFalseWithAddUI.Margin = new Padding(3, 4, 3, 4);
            btnCallAsyncUIAwaitFalseWithAddUI.Name = "btnCallAsyncUIAwaitFalseWithAddUI";
            btnCallAsyncUIAwaitFalseWithAddUI.Size = new Size(480, 31);
            btnCallAsyncUIAwaitFalseWithAddUI.TabIndex = 3;
            btnCallAsyncUIAwaitFalseWithAddUI.Text = "Call async with configureawait set to false on UI with additional UI logic";
            btnCallAsyncUIAwaitFalseWithAddUI.UseVisualStyleBackColor = true;
            btnCallAsyncUIAwaitFalseWithAddUI.Click += btnCallAsyncUIAwaitFalseWithAddUI_Click;
            // 
            // lblCallAsyncAwaitFalseOnUIWithAdditionalUI
            // 
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.AutoSize = true;
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.Location = new Point(527, 86);
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.Name = "lblCallAsyncAwaitFalseOnUIWithAdditionalUI";
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.Size = new Size(135, 20);
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.TabIndex = 4;
            lblCallAsyncAwaitFalseOnUIWithAdditionalUI.Text = "Status: Not running";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 32);
            label1.Name = "label1";
            label1.Size = new Size(715, 20);
            label1.TabIndex = 5;
            label1.Text = "Contoh call asynchronous task set awaitable true di UI, tetapi kemudian ada code set property control di UI";
            // 
            // btnCallAsyncUIAwaitTrueWithAddUI
            // 
            btnCallAsyncUIAwaitTrueWithAddUI.Location = new Point(11, 70);
            btnCallAsyncUIAwaitTrueWithAddUI.Margin = new Padding(3, 4, 3, 4);
            btnCallAsyncUIAwaitTrueWithAddUI.Name = "btnCallAsyncUIAwaitTrueWithAddUI";
            btnCallAsyncUIAwaitTrueWithAddUI.Size = new Size(480, 31);
            btnCallAsyncUIAwaitTrueWithAddUI.TabIndex = 6;
            btnCallAsyncUIAwaitTrueWithAddUI.Text = "Call async with configureawait set to true on UI with additional UI logic";
            btnCallAsyncUIAwaitTrueWithAddUI.UseVisualStyleBackColor = true;
            btnCallAsyncUIAwaitTrueWithAddUI.Click += btnCallAsyncUIAwaitTrueWithAddUI_Click;
            // 
            // lblCallAsyncAwaitTrueOnUIWithAdditionalUI
            // 
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.AutoSize = true;
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.Location = new Point(527, 75);
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.Name = "lblCallAsyncAwaitTrueOnUIWithAdditionalUI";
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.Size = new Size(135, 20);
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.TabIndex = 7;
            lblCallAsyncAwaitTrueOnUIWithAdditionalUI.Text = "Status: Not running";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblRemarkContohAwaitableUIFalse);
            groupBox1.Controls.Add(btnCallAsyncUIAwaitableFalse);
            groupBox1.Location = new Point(57, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(789, 119);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Contoh ConfigureAwait 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblRemarkContohAwaitableUIFalseLogicUI);
            groupBox2.Controls.Add(btnCallAsyncUIAwaitFalseWithAddUI);
            groupBox2.Controls.Add(lblCallAsyncAwaitFalseOnUIWithAdditionalUI);
            groupBox2.Location = new Point(57, 137);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(789, 125);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Contoh ConfigureAwait 2";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(btnCallAsyncUIAwaitTrueWithAddUI);
            groupBox3.Controls.Add(lblCallAsyncAwaitTrueOnUIWithAdditionalUI);
            groupBox3.Location = new Point(57, 281);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(789, 125);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Contoh ConfigureAwait 3";
            // 
            // btnCallAsyncUIThenWait
            // 
            btnCallAsyncUIThenWait.Location = new Point(68, 445);
            btnCallAsyncUIThenWait.Name = "btnCallAsyncUIThenWait";
            btnCallAsyncUIThenWait.Size = new Size(488, 29);
            btnCallAsyncUIThenWait.TabIndex = 11;
            btnCallAsyncUIThenWait.Text = "Call async with on UI then call wait on task";
            btnCallAsyncUIThenWait.UseVisualStyleBackColor = true;
            btnCallAsyncUIThenWait.Click += btnCallAsyncUIThenWait_Click;
            // 
            // FrmAwaitableWinforms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnCallAsyncUIThenWait);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmAwaitableWinforms";
            Text = "Contoh Configure Awaitable Winforms";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblRemarkContohAwaitableUIFalse;
        private Button btnCallAsyncUIAwaitableFalse;
        private Label lblRemarkContohAwaitableUIFalseLogicUI;
        private Button btnCallAsyncUIAwaitFalseWithAddUI;
        private Label lblCallAsyncAwaitFalseOnUIWithAdditionalUI;
        private Label label1;
        private Button btnCallAsyncUIAwaitTrueWithAddUI;
        private Label lblCallAsyncAwaitTrueOnUIWithAdditionalUI;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnCallAsyncUIThenWait;
    }
}
