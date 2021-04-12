using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskBuddy
{
    public partial class TaskDetailDialog : Form
    {
        public TaskDetailDialog()
        {
            InitializeComponent();
        }
        public void SetTask(TaskObject taskObject)
        {
            labelName.Text = taskObject.Name;
            labelStatus.Text = taskObject.Status;
            labelOwner.Text = taskObject.Owner;
            labelAssigned.Text = string.Join(", ", new string[] { taskObject.Assigned1, taskObject.Assigned2, taskObject.Assigned3, taskObject.Assigned4});
            labelCreatedAt.Text = taskObject.Created_At;
            labelWorkingAt.Text = taskObject.Working_At;
            labelTestingAt.Text = taskObject.Testing_At;
            labelCompleteAt.Text = taskObject.Complete_At;
            textDescription.Text = taskObject.Description;
            if (taskObject.DefaultImage != null)
                pictureDefault.Image = taskObject.DefaultImage;
        }
        
        private void TaskDetailDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Hide();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
