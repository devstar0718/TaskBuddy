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
    public partial class TaskBuddyControl : UserControl
    {
        private string projectPath;
        private string csvCreated = "Created.csv";
        private string csvWorking = "Working.csv";
        private string csvTesting = "Testing.csv";
        private string csvComplete = "Complete.csv";
        public string ProjectPath
        {
            get
            {
                return projectPath;
            }
            set
            {
                LoadProject(value);
            }
        }
        public TaskBuddyControl()
        {
            InitializeComponent();
        }
        public void LoadProject(string path)
        {
            projectPath = path;
            taskListControl1.LoadTasks(path, csvCreated);
            taskListControl2.LoadTasks(path, csvWorking);
            taskListControl3.LoadTasks(path, csvTesting);
            taskListControl4.LoadTasks(path, csvComplete);
        }
    }
}
