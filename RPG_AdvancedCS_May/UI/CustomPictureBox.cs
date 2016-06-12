using System.Drawing;
using System.Windows.Forms;
using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Controllers;

namespace RPG_AdvancedCS_May.UI
{
    public class CustomPictureBox : PictureBox
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            var mainController = ((this.Tag as CustomPicBoxTag).Controller as ControllerUserInput);
            mainController?.OnMouseClick(this, e);



            //base.BackgroundImage = this.Image;
            //this.Parent.BackgroundImage = this.Image;
            //base.Parent.BackgroundImage = this.Image;
            //this.Parent?.Invoke(this, OnMouseClick(e));
            //this.Parent.MouseClick += PicBoxMouseClick;
            //this.Parent.MouseClick?.Invoke(this, e);
            //(this.Parent as Form).MouseClick
            //base.OnMouseClick(e);
        }
    }
}
