namespace Banker_sAlgorithmGUI
{
    partial class Form1
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
            txtBoxNumResources = new TextBox();
            txtBoxNumProcesses = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnOK = new Button();
            SuspendLayout();
            // 
            // txtBoxNumResources
            // 
            txtBoxNumResources.Location = new Point(301, 157);
            txtBoxNumResources.Name = "txtBoxNumResources";
            txtBoxNumResources.Size = new Size(150, 27);
            txtBoxNumResources.TabIndex = 0;
            // 
            // txtBoxNumProcesses
            // 
            txtBoxNumProcesses.Location = new Point(301, 276);
            txtBoxNumProcesses.Name = "txtBoxNumProcesses";
            txtBoxNumProcesses.Size = new Size(150, 27);
            txtBoxNumProcesses.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(300, 134);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 2;
            label1.Text = "Number of Resources";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(301, 253);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 3;
            label2.Text = "Number Of Processes";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(325, 362);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOK);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBoxNumProcesses);
            Controls.Add(txtBoxNumResources);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxNumResources;
        private TextBox txtBoxNumProcesses;
        private Label label1;
        private Label label2;
        private Button btnOK;
    }
}