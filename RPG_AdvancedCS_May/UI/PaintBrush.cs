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
        private const int ProgrssBarSizeX = 30;
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
            LoadResources();
            this.gameWindow = form;
            this.pictureBoxes = new List<PictureBox>();
            this.progressBars = new List<ProgressBar>();
        }
        //---------
        public void AddObject(IRenderable renderableObject)
        {
            this.CreatepictureBox(renderableObject);
            if (renderableObject is IUnit) //TO DO: Implement separate health bar for the main character
            {
                this.CreateProgressBar(renderableObject as IUnit);
            }
        }
        public void RemoveObject(IRenderable renderableObject)
        {
            PictureBox picBox = GetPictureBoxByObject(renderableObject);
            this.gameWindow.Controls.Remove(picBox);
            this.pictureBoxes.Remove(picBox);
            if (renderableObject is IUnit)
            {
                ProgressBar progressBar = GetProgressbarByObject(renderableObject as IUnit);
                this.progressBars.Remove(progressBar);
            }
        }
        public void RedrawObject(IRenderable renderableObject)
        {
            Point newCoordinates = new Point(renderableObject.X, renderableObject.Y);
            PictureBox picBox = GetPictureBoxByObject(renderableObject);
            picBox.Location = newCoordinates;

            if (renderableObject is IUnit)
            {
                IUnit unit = renderableObject as IUnit;
                ProgressBar progressBar = GetProgressbarByObject(unit);
                this.SetProgressBarLocation(unit, progressBar);
                progressBar.Value = unit.CurrentHP;
            }
        }
        //---------

        private void CreateProgressBar(IUnit unit)
        {
            ProgressBar progressBar = new ProgressBar();
            progressBar.Size = new Size(ProgrssBarSizeX, ProgressBarSizeY);
            this.SetProgressBarLocation(unit, progressBar);
            progressBar.Maximum = unit.MaxHP;
            progressBar.Value = unit.CurrentHP;
            progressBar.Tag = unit;
            progressBars.Add(progressBar);
            this.gameWindow.Controls.Add(progressBar);
        }

        private void CreatepictureBox(IRenderable renderableObject)
        {
            Image spriteImage = GetSpriteImage(renderableObject);
            PictureBox picBox = new PictureBox();
            picBox.BackColor = Color.Transparent;
            picBox.Image = spriteImage;
            picBox.Parent = this.gameWindow;
            picBox.Location = new Point(renderableObject.X, renderableObject.Y);
            picBox.Size = new Size(renderableObject.SizeX, renderableObject.SizeY);
            picBox.Tag = renderableObject;
            this.pictureBoxes.Add(picBox);
            this.gameWindow.Controls.Add(picBox);
        }

        private void SetProgressBarLocation(IUnit unit, ProgressBar progressBar)
        {
            progressBar.Location = new Point(unit.X + ProgressbarOffsetX, unit.Y + ProgressbarOffsetY);
        }

        private Image GetSpriteImage(IRenderable renderableObject)
        {
            Image image;
            switch (renderableObject.SpriteType)
            {
                case SpriteType.Char1:
                    image = this.characterImage;
                    break;
                default:
                    image = new PictureBox().Image; //TO DO: Set To Fully Transparent Image!
                    break;
            }
            return image;
        }
        
        private ProgressBar GetProgressbarByObject(IUnit unit)
        {
            return this.progressBars.First(p => p.Tag == unit);
        }

        private PictureBox GetPictureBoxByObject(IRenderable renderableObject)
        {
            return this.pictureBoxes.First(p => p.Tag == renderableObject);
        }

        public void LoadResources()
        {
            this.characterImage = Image.FromFile(Images.Character1ImagePath);
        }
        
    }
}
