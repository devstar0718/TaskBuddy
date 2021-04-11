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
        public TaskItemControl(string title)
        {
            InitializeComponent();
            label1.Text = title;
        }
    }
}
