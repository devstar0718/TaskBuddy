﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskBuddy
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            taskBuddyControl1.LoadProject(@"D:\C\Karl\SuferBuddy\PartialSBData");
        }
    }
}
