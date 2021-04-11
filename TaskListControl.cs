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
    public partial class TaskListControl : UserControl
    {
        private Control activeControl;
        private Point previousLocation;
        private List<Control> listItems = new List<Control>();
        public int marginWidth = 10, marginHeight = 10;
        public List<int> listY = new List<int>();

        public TaskListControl()
        {
            InitializeComponent();
            InitializePanelLayout();
            InitializeItems();
            RefreshListLayout();
            GetItemsY();
        }

        private void RefreshListLayout()
        {
            labelName.Location = new Point(marginWidth, marginHeight);
            int taskWidth = panelLayout.Width - marginWidth * 3;
            int taskY = labelName.Location.Y + labelName.Height;
            foreach(Control item in listItems)
            {
                taskY += marginHeight;
                if(activeControl == null || item != activeControl)
                {
                    item.Location = new Point(marginWidth, taskY);
                    item.Width = taskWidth;
                }
                taskY += item.Height;
            }
        }

        private bool DropActiveTask()
        {
            bool isChanged = false;
            if (activeControl == null || listY.Count != listItems.Count) return isChanged;
            int y = activeControl.Location.Y;
            for(int i = listY.Count - 1; i >= 0; i--)
            {
                if(y >= listY[i])
                {
                    int j = listItems.IndexOf(activeControl);
                    if(i != j)
                    {
                        Control temp = listItems[j];
                        listItems[j] = listItems[i];
                        listItems[i] = temp;

                        isChanged = true;
                    }
                    break;
                }
            }
            return isChanged;
        }

        private void GetItemsY()
        {
            listY.Clear();
            foreach(Control item in listItems)
            {
                listY.Add(item.Location.Y);
            }
        }

        private void InitializeItems()
        {
            listItems.Clear();
            listItems.Add(new TaskItemControl("Task1"));
            listItems.Add(new TaskItemControl("Task2"));
            listItems.Add(new TaskItemControl("Task3"));
            int i = 0;
            foreach(Control item in listItems)
            {
                i++;
                item.Height = 100 * i;
                panelLayout.Controls.Add(item);
                item.MouseDown += new MouseEventHandler(Task_MouseDown);
                item.MouseMove += new MouseEventHandler(Task_MouseMove);
                item.MouseUp += new MouseEventHandler(Task_MouseUp);
            }
        }

        private void InitializePanelLayout()
        {
            panelLayout.HorizontalScroll.Maximum = 0;
            panelLayout.AutoScroll = false;
            panelLayout.VerticalScroll.Visible = false;
            panelLayout.AutoScroll = true;
        }

        void Task_MouseDown(object sender, MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousLocation = e.Location;
            Cursor = Cursors.Hand;
            activeControl.BringToFront();
        }

        void Task_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
                return;
            var location = activeControl.Location;
            location.Offset(e.Location.X - previousLocation.X, e.Location.Y - previousLocation.Y);
            activeControl.Location = location;
            bool reOrdered = DropActiveTask();
            if (reOrdered)
            {
                RefreshListLayout();
            }
        }

        void Task_MouseUp(object sender, MouseEventArgs e)
        {
            DropActiveTask();
            activeControl = null;
            Cursor = Cursors.Default;
            RefreshListLayout();
        }

        private void panelLayout_Resize(object sender, EventArgs e)
        {
            RefreshListLayout();
        }

    }
}
