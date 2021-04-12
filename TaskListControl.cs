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

namespace TaskBuddy
{
    public partial class TaskListControl : UserControl
    {
        public Control activeControl;
        public static Point previousLocation;
        private List<Control> listItems = new List<Control>();
        public int marginWidth = 10, marginHeight = 10;
        public List<int> listY = new List<int>();
        private string ProjectPath;
        private string CSVFile;
        private DataTable listTaskInfos;
        public string ListName
        {
            get
            {
                return labelName.Text;
            }
            set
            {
                labelName.Text = value;
            }
        }
        public void LoadTasks(string projectPath, string csvFileName)
        {
            ProjectPath = projectPath;
            CSVFile = projectPath + "\\" + csvFileName;
            if (!File.Exists(CSVFile))
                return;
            listItems.Clear();
            listTaskInfos = CSVReader.ReadCSVFile(CSVFile, true);
            foreach(DataRow row in listTaskInfos.Rows)
            {
                string taskPath = ProjectPath + "\\" + row[0].ToString();
                listItems.Add(new TaskItemControl(taskPath));
                if (listItems.Count > 10) // limit the size temperailly
                    break;
            }
            InitializeItems();
            RefreshListLayout();
            GetItemsY();
        }
        public TaskListControl()
        {
            InitializeComponent();
            InitializePanelLayout();
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
            int yActive = activeControl.Location.Y + previousLocation.Y;
            int iActive = listItems.IndexOf(activeControl);
            //if (iActive < 0) return false;
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
            foreach(Control item in listItems)
            {
                panelLayout.Controls.Add(item);
                item.MouseDown += new MouseEventHandler(Task_MouseDown);
                item.MouseMove += new MouseEventHandler(Task_MouseMove);
                item.MouseUp += new MouseEventHandler(Task_MouseUp);
            }
        }

        private void Task_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl != null && activeControl == sender)
            {
                if(Math.Abs(e.X - previousLocation.X) >= 10 || Math.Abs(e.Y - previousLocation.Y) >= 10)
                {
                    activeControl.BringToFront();
                    DoDragDrop(activeControl, DragDropEffects.Move);
                }
            }
        }
        private void Task_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
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
            
        }

        private void TaskListControl_DragDrop(object sender, DragEventArgs e)
        {
            // Console.WriteLine(TaskListName + " - " + "Drag Drop");
            DropActiveTask();
            activeControl = null;
            RefreshListLayout();
        }
        bool CheckDragOver;
        private void TaskListControl_DragEnter(object sender, DragEventArgs e)
        {
            // Console.WriteLine(TaskListName + " - " + "Drag Enter");
            Control source = (Control)e.Data.GetData(typeof(TaskItemControl));
            if (source == null)
            {
                // Console.WriteLine(TaskListName + " - " + "Drag Null");
                return;
            }
            if (source == activeControl)
            {
                // Console.WriteLine(TaskListName + " - " + "Drag in Same List");
                return;
            }
            e.Effect = DragDropEffects.All;
            Point pt = PointToClient(new Point(e.X, e.Y));
            int activeY = pt.Y;
            int i;
            for(i = listItems.Count - 1; i >= 0; i--)
            {
                if(listItems[i].Location.Y + listItems[i].Height / 2 < activeY)
                {
                    listItems.Insert(i + 1, source);
                    break;
                }
            }
            if(i < 0) listItems.Insert(0, source);
            GetItemsY();
            activeControl = source;
            activeControl.MouseDown += Task_MouseDown;
            activeControl.MouseMove += Task_MouseMove;
            activeControl.MouseUp += Task_MouseUp;
            panelLayout.Controls.Add(activeControl);
            activeControl.BringToFront();
            activeControl.Location = new Point(pt.X - previousLocation.X, pt.Y - previousLocation.Y);
            previousLocation = activeControl.PointToClient(new Point(e.X, e.Y));
            CheckDragOver = false;
        }

        private void TaskListControl_DragLeave(object sender, EventArgs e)
        {
            if (!CheckDragOver) return;
            activeControl.MouseDown -= Task_MouseDown;
            activeControl.MouseMove -= Task_MouseMove;
            activeControl.MouseUp -= Task_MouseUp;
            listItems.Remove(activeControl);
            activeControl = null;
            RefreshListLayout();
            GetItemsY();
            // Console.WriteLine(TaskListName + " - " + "Drag Leave");
        }

        private void TaskListControl_DragOver(object sender, DragEventArgs e)
        {
            // Console.WriteLine(TaskListName + " - " + "Drag Over");
            e.Effect = DragDropEffects.All;
            if (activeControl == null)
                return;
            var location = activeControl.Location;
            Point pt = activeControl.PointToClient(new Point(e.X, e.Y));
            location.Offset(pt.X - previousLocation.X, pt.Y - previousLocation.Y);
            activeControl.Location = location;
            bool reOrdered = DropActiveTask();
            if (reOrdered)
            {
                RefreshListLayout();
            }
            CheckDragOver = true;
        }

        private void panelLayout_Resize(object sender, EventArgs e)
        {
            RefreshListLayout();
        }

    }
}
