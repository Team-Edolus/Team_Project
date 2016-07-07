namespace RPG_AdvancedCS_May.Controllers
{
    using System;
    using System.Windows.Forms;
    using Interfaces;
    using GameEngine;

    public class ControllerUserInput : IUserInputInterface
    {
        public event EventHandler OnRightPressed;
        public event EventHandler OnLeftPressed;
        public event EventHandler OnUpPressed;
        public event EventHandler OnDownPressed;
        public event EventHandler On1Pressed;
        public event EventHandler On2Pressed;

        public event EventHandler OnLeftMouseClick;
        
        public ControllerUserInput(Form form)
        {
            form.KeyDown += OnKeyDown;
            form.MouseClick += OnMouseClick;
        }
        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
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
                case Keys.D1:
                    this.On1Pressed?.Invoke(this, e);
                    break;
                case Keys.D2:
                    this.On2Pressed?.Invoke(this, e);
                    break;
                default:
                    break;
            }
        }
    }
}
