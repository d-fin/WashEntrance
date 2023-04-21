using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WashEntrance_V1
{
    public partial class Form1 : Form
    {
        public static bool Shutdown = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void tmrUpdateForm_Tick(object sender, EventArgs e)
        {
            if (SeaLevelThread.SLInput1Status) { radRollerCall.Checked = true; }
            else { radRollerCall.Checked = false; }

            if (SeaLevelThread.SLInput4Status) { radRollerEye.Checked = true; }
            else { radRollerEye.Checked = false; }

            if (SeaLevelThread.ForkUpBool) { radFork.Checked = true; }
            else { radFork.Checked = false; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Shutdown = true;
            Thread.Sleep(1000);
            Application.Exit();
        }
    }
}
