using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();     
        }

        public  void AddText(string text)
        {
            tbxLog.Text += Environment.NewLine + DateTime.Now + " " + text;
        }

        public  void Subscription(Game scene)
        {
            scene.LogAction += AddText;
        }
    }
}
