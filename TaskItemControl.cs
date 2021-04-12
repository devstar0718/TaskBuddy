using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskBuddy
{
    public partial class TaskItemControl : UserControl
    {
        private TaskDetailDialog DetailDialog;
        public TaskItemControl(string title)
        {
            InitializeComponent();
            labelName.Text = title;
            RedirectControlMouseEventsToForms();
            DetailDialog = new TaskDetailDialog();
        }
        void RedirectControlMouseEventsToForms()
        {
            foreach(Control control in Controls)
            {
                control.MouseDown += RedirectMouseDown;
                control.MouseMove += RedirectMouseMove;
                control.MouseUp += RedirectMouseUp;
                control.DoubleClick += RedirectDoubleClick;
            }
        }

        private void RedirectDoubleClick(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            OnDoubleClick(e);
        }

        private void RedirectMouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
            Point formPoint = PointToClient(screenPoint);
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
                formPoint.X, formPoint.Y, e.Delta);
            OnMouseDown(args);
        }
        private void RedirectMouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
            Point formPoint = PointToClient(screenPoint);
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
                formPoint.X, formPoint.Y, e.Delta);
            OnMouseMove(args);
        }
        private void RedirectMouseUp(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
            Point formPoint = PointToClient(screenPoint);
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
                formPoint.X, formPoint.Y, e.Delta);
            OnMouseUp(args);
        }

        private void TaskItemControl_DoubleClick(object sender, EventArgs e)
        {
            DetailDialog.Show();
            DetailDialog.Focus();
        }
    }
}
