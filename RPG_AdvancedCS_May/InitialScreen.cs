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
    public partial class InitialScreen : Form
    {
        public InitialScreen()
        {
            InitializeComponent();
        }

        private void InitialScreen_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Play_Click(object sender, EventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.FormClosed += new FormClosedEventHandler(gameWindow_FormClosed);
            Hide();
            gameWindow.Show();
        }

        void gameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
