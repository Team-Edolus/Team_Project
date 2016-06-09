using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Controllers
{
    class ControllerUserInput : IUserInputInterface
    {
        public event EventHandler OnRightPressed;
        public event EventHandler OnLeftPressed;
        public event EventHandler OnUpPressed;
        public event EventHandler OnDownPressed;

        public event EventHandler OnSpellOnePressed;

        public ControllerUserInput(Form form)
        {
            form.KeyDown += OnKeyDown;
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
