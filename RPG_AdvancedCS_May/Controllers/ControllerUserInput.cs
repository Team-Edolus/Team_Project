using System;
using System.Windows.Forms;

using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Controllers
{
    class ControllerUserInput : IUserInputInterface
    {
        public event EventHandler OnRightPressed;
        public event EventHandler OnLeftPressed;
        public event EventHandler OnUpPressed;
        public event EventHandler OnDownPressed;

        public event EventHandler OnLeftMouseClick;
        
        public ControllerUserInput(Form form)
        {
            form.KeyDown += OnKeyDown;
            form.MouseClick += OnMouseClick;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("asd");
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("asd");
                this.OnLeftMouseClick?.Invoke(this, new AbilityEventArgs(e.X, e.Y));
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    this.OnUpPressed?.Invoke(this, new EventArgs());
                    break;
                case Keys.S:
                    this.OnDownPressed?.Invoke(this, new EventArgs());
                    break;
                case Keys.D:
                    this.OnRightPressed?.Invoke(this, new EventArgs());
                    break;
                case Keys.A:
                    this.OnLeftPressed?.Invoke(this, new EventArgs());
                    break;
                default:
                    break;
            }
        }
    }
}
