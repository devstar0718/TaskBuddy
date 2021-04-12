namespace TaskBuddy
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
            this.taskBuddyControl1 = new TaskBuddy.TaskBuddyControl();
            this.SuspendLayout();
            // 
            // taskBuddyControl1
            // 
            this.taskBuddyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskBuddyControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBuddyControl1.Location = new System.Drawing.Point(0, 0);
            this.taskBuddyControl1.Margin = new System.Windows.Forms.Padding(6);
            this.taskBuddyControl1.Name = "taskBuddyControl1";
            this.taskBuddyControl1.ProjectPath = null;
            this.taskBuddyControl1.Size = new System.Drawing.Size(1245, 830);
            this.taskBuddyControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 830);
            this.Controls.Add(this.taskBuddyControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TaskBuddyControl taskBuddyControl1;
    }
}

