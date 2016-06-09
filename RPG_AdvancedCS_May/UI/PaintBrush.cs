using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.Graphics;

namespace RPG_AdvancedCS_May.UI
{
    class PaintBrush : IPaintInterface
    {
        private const int ProgrssBarSizeX = 60;
        private const int ProgressBarSizeY = 8;
        private const int ProgressbarOffsetX = -3;
        private  const int ProgressbarOffsetY = -10;

        private Image characterImage;

        //test
        private Form gameWindow;
        private List<PictureBox> pictureBoxes;
        private List<ProgressBar> progressBars;

        public PaintBrush(Form form)
        {
            this.gameWindow = form;
            this.pictureBoxes = new List<PictureBox>();
            this.progressBars = new List<ProgressBar>();
        }


        public void AddObject(IRenderable renderableObject)
        {
            this.CreatepictureBox(renderableObject);
            if (renderableObject is IUnit) //TO DO: Implement separate health bar for the main character
            {
                this.CreateProgressBar(renderableObject as IUnit);
            }
        }
        public void RedrawObject(IRenderable renderableObject)
        {

        }

        private void CreateProgressBar(IUnit unit)
        {
            throw new NotImplementedException();
        }

        private void CreatepictureBox(IRenderable renderableObject)
        {
            throw new NotImplementedException();
        }


        public void RemoveObject(IRenderable renderableObject)
        {
            throw new NotImplementedException();
        }
    }
}
