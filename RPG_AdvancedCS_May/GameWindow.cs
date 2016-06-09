using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_AdvancedCS_May
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine engine = new Engine();
            Timer timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += (s, args) =>
            {
                engine.Update();
            };
            timer.Start();
        }
    }
}
