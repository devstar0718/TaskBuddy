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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.taskListControl4 = new TaskBuddy.TaskListControl();
            this.taskListControl3 = new TaskBuddy.TaskListControl();
            this.taskListControl2 = new TaskBuddy.TaskListControl();
            this.taskListControl1 = new TaskBuddy.TaskListControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.taskListControl4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.taskListControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.taskListControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.taskListControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1245, 577);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // taskListControl4
            // 
            this.taskListControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskListControl4.Location = new System.Drawing.Point(938, 8);
            this.taskListControl4.Margin = new System.Windows.Forms.Padding(6);
            this.taskListControl4.Name = "taskListControl4";
            this.taskListControl4.Size = new System.Drawing.Size(299, 561);
            this.taskListControl4.TabIndex = 3;
            // 
            // taskListControl3
            // 
            this.taskListControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskListControl3.Location = new System.Drawing.Point(628, 8);
            this.taskListControl3.Margin = new System.Windows.Forms.Padding(6);
            this.taskListControl3.Name = "taskListControl3";
            this.taskListControl3.Size = new System.Drawing.Size(296, 561);
            this.taskListControl3.TabIndex = 2;
            // 
            // taskListControl2
            // 
            this.taskListControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskListControl2.Location = new System.Drawing.Point(318, 8);
            this.taskListControl2.Margin = new System.Windows.Forms.Padding(6);
            this.taskListControl2.Name = "taskListControl2";
            this.taskListControl2.Size = new System.Drawing.Size(296, 561);
            this.taskListControl2.TabIndex = 1;
            // 
            // taskListControl1
            // 
            this.taskListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskListControl1.Location = new System.Drawing.Point(8, 8);
            this.taskListControl1.Margin = new System.Windows.Forms.Padding(6);
            this.taskListControl1.Name = "taskListControl1";
            this.taskListControl1.Size = new System.Drawing.Size(296, 561);
            this.taskListControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TaskListControl taskListControl4;
        private TaskListControl taskListControl3;
        private TaskListControl taskListControl2;
        private TaskListControl taskListControl1;
    }
}

