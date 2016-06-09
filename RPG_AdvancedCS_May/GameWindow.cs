using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Controllers;
using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.UI;

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
            IUserInputInterface controller = new ControllerUserInput(this);
            IPaintInterface painter = new PaintBrush(this);
            Engine engine = new Engine(controller, painter);
            Timer timer = new Timer();
            timer.Interval = 30;
            timer.Tick += (s, args) =>
            {
                engine.Update();
            };
            timer.Start();
        }
    }
}
