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
            if (activeControl == null || listY.Count != listItems.Count) return false;
            int yActive = activeControl.Location.Y;
            int iActive = listItems.IndexOf(activeControl);
            if(yActive < listY[iActive]) // dragging up
            {
                for(int i = iActive - 1; i >= 0; i--)
                {
                    if(yActive < listY[i] + listItems[i].Height / 2)
                    {
                        ExchangeTask(iActive, i);
                        return true;
                    }
                }
            }
            else if(yActive > listY[iActive] + listItems[iActive].Height) // dragging down
            {
                for (int i = iActive + 1; i < listItems.Count; i++)
                {
                    if (yActive > listY[i] + listItems[i].Height / 2)
                    {
                        ExchangeTask(iActive, i);
                        return true;
                    }
                }
            }
            return false;
        }

        private void ExchangeTask(int i, int j)
        {
            Control temp = listItems[j];
            listItems[j] = listItems[i];
            listItems[i] = temp;

            GetItemsY();
        }

        private void GetItemsY()
        {
            listY.Clear();
            int y = marginHeight + labelName.Height;
            foreach(Control item in listItems)
            {
                listY.Add(y);
                y += marginHeight + item.Height;
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
                item.Height = 100 + 30 * i;
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
