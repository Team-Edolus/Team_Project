using System.Windows.Forms;
using RPG_AdvancedCS_May.Controllers;

namespace RPG_AdvancedCS_May.UI
{
    public class CustomPictureBox : PictureBox
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            int abilityX = this.Location.X + e.X;
            int abilityY = this.Location.Y + e.Y;
            var newArgs = new MouseEventArgs(e.Button, e.Clicks, abilityX, abilityY, e.Delta);
            var mainController = ((this.Tag as CustomPicBoxTag).Controller as ControllerUserInput);
            mainController?.OnMouseClick(this, newArgs);
            //this.Parent?.Invoke(this, OnMouseClick(e));
            //this.Parent.MouseClick += PicBoxMouseClick;
            //this.Parent.MouseClick?.Invoke(this, e);
            //(this.Parent as Form).MouseClick
            //base.OnMouseClick(e);
        }
    }
}
