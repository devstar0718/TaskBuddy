using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace TaskBuddy
{
    public partial class TaskItemControl : UserControl
    {
        private TaskDetailDialog DetailDialog;
        private TaskObject taskObject = null;
        public string TaskPath {
            get
            {
                if(taskObject != null)
                {
                    return taskObject.Path;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                LoadTask(value);
            }
        }
        public TaskItemControl(string folderPath)
        {
            InitializeComponent();
            RedirectControlMouseEventsToForms();
            DetailDialog = new TaskDetailDialog();
            TaskPath = folderPath;
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
        public void LoadTask(string path)
        {
            bool result = LoadTaskObject(path);
            if (result == false)
                return;
            labelName.Text = taskObject.Name;
            labelOwner.Text = taskObject.Owner;
            pictureDefaultImage.Image = taskObject.DefaultImage;
            DetailDialog.SetTask(taskObject);
        }
        private bool LoadTaskObject(string path)
        {
            string properties = path + "\\Properties";
            if (!File.Exists(properties)) return false;
            try
            {
                string[] TempPartProperties = new string[20];
                TempPartProperties = DeSerializeArray(properties);
                taskObject = new TaskObject();
                taskObject.Name = TempPartProperties[0];
                taskObject.Status = TempPartProperties[17];
                taskObject.Owner = TempPartProperties[2];
                taskObject.Assigned1 = TempPartProperties[3];
                taskObject.Assigned2 = TempPartProperties[4];
                taskObject.Assigned3 = TempPartProperties[5];
                taskObject.Assigned4 = TempPartProperties[6];
                taskObject.Created_At = TempPartProperties[11];
                taskObject.Working_At = TempPartProperties[12];
                taskObject.Testing_At = TempPartProperties[13];
                taskObject.Complete_At = TempPartProperties[14];
                taskObject.Description = TempPartProperties[1];
                taskObject.Path = path;
                string defaultPath = path + "\\DefaultLabelImage.jpg";
                if (File.Exists(defaultPath))
                    taskObject.DefaultImage = Image.FromFile(defaultPath);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static string[] DeSerializeArray(string fname)
        {
            // Deserialize the SOAP message back into a string array.
            FileStream fstream = new FileStream(fname, FileMode.Open, FileAccess.Read);
            SoapFormatter soapFormat = new SoapFormatter();
            string[] ArrayToReturn = new string[1];

            try
            {
                ArrayToReturn = (string[])soapFormat.Deserialize(fstream);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Soap reader error" + ex.ToString());
            }
            finally
            {
                fstream.Close();
            }
            return ArrayToReturn;
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
