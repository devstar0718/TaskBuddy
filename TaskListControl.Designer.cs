namespace TaskBuddy
{
    partial class TaskListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLayout = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.panelLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLayout
            // 
            this.panelLayout.Controls.Add(this.labelName);
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(0, 0);
            this.panelLayout.Margin = new System.Windows.Forms.Padding(6);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.Size = new System.Drawing.Size(352, 597);
            this.panelLayout.TabIndex = 2;
            this.panelLayout.Resize += new System.EventHandler(this.panelLayout_Resize);
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(3, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(86, 24);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "To do list";
            // 
            // TaskListControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLayout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TaskListControl";
            this.Size = new System.Drawing.Size(352, 597);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaskListControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TaskListControl_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.TaskListControl_DragOver);
            this.DragLeave += new System.EventHandler(this.TaskListControl_DragLeave);
            this.panelLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLayout;
        private System.Windows.Forms.Label labelName;
    }
}
