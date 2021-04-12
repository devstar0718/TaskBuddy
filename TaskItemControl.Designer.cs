namespace TaskBuddy
{
    partial class TaskItemControl
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelOwner = new System.Windows.Forms.Label();
            this.pictureDefaultImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDefaultImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 24);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Task1";
            // 
            // labelOwner
            // 
            this.labelOwner.AutoSize = true;
            this.labelOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOwner.Location = new System.Drawing.Point(13, 33);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(86, 20);
            this.labelOwner.TabIndex = 0;
            this.labelOwner.Text = "Karl, Alexei";
            // 
            // pictureDefaultImage
            // 
            this.pictureDefaultImage.Image = global::TaskBuddy.Properties.Resources.DefaultLabelImage;
            this.pictureDefaultImage.Location = new System.Drawing.Point(17, 56);
            this.pictureDefaultImage.Name = "pictureDefaultImage";
            this.pictureDefaultImage.Size = new System.Drawing.Size(224, 79);
            this.pictureDefaultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureDefaultImage.TabIndex = 1;
            this.pictureDefaultImage.TabStop = false;
            // 
            // TaskItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureDefaultImage);
            this.Controls.Add(this.labelOwner);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TaskItemControl";
            this.Size = new System.Drawing.Size(257, 150);
            this.DoubleClick += new System.EventHandler(this.TaskItemControl_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDefaultImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureDefaultImage;
        private System.Windows.Forms.Label labelOwner;
    }
}
