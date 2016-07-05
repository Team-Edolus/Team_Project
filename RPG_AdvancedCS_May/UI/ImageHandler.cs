namespace RPG_AdvancedCS_May.UI
{
    using System.Drawing;
    using System.Windows.Forms;

    using Interfaces;
    using Graphics;
    public class ImageHandler
    {
        private Image startRegionBGImage;
        private Image CharacterImage;
        private Image BoarImage;
        private Image BackgroundImage;
        private Image SwordImage;
        private Image AxeImage;
        private Image PineappleImage;
        private Image ShieldImage;

        public ImageHandler()
        {
            LoadResources();
        }

        private void LoadResources()
        {
            this.startRegionBGImage = Image.FromFile(Images.StartRegionBGImage);
            this.CharacterImage = Image.FromFile(Images.Character1ImagePath);
            this.BoarImage = Image.FromFile(Images.BoarImagePath);
            this.BackgroundImage = Image.FromFile(Images.BackGroundImagePath);
            this.SwordImage = Image.FromFile(Images.SwordImagePath);
            this.AxeImage = Image.FromFile(Images.AxeDefaultImagePath);
            this.PineappleImage = Image.FromFile(Images.PineappleImage);
            this.ShieldImage = Image.FromFile(Images.ShieldImage);
        }

        public Image GetSpriteImage(IRenderable renderableObject)
        {
            Image image;
            switch (renderableObject.SpriteType)
            {
                case SpriteType.StartRegionBG:
                    image = this.startRegionBGImage;
                    break;
                case SpriteType.Char1:
                    image = this.CharacterImage;
                    break;
                case SpriteType.Boar:
                    image = this.BoarImage;
                    break;
                case SpriteType.Background:
                    image = this.BackgroundImage;
                    break;
                case SpriteType.Sword:
                    image = this.SwordImage;
                    break;
                case SpriteType.Axe:
                    image = this.AxeImage;
                    break;
                case SpriteType.Pineapple:
                    image = this.PineappleImage;
                    break;
                case SpriteType.Shield:
                    image = this.ShieldImage;
                    break;
                default:
                    image = new PictureBox().Image;
                    break;
            }
            return image;
        }
    }
}
