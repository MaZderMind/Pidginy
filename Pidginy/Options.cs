using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pidginy
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            this.XmlPath.Text = Properties.Settings.Default.XmlPath;
            this.AvatarPath.Text = Properties.Settings.Default.AvatarPath;
        }

        public void Save()
        {
            Properties.Settings.Default.XmlPath = this.XmlPath.Text;
            Properties.Settings.Default.AvatarPath = this.AvatarPath.Text;
            Properties.Settings.Default.Save();
        }
    }
}
