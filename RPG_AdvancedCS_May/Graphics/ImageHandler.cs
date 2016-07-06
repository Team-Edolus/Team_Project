namespace RPG_AdvancedCS_May.Graphics
{
    using System.Drawing;
    using System.Windows.Forms;

    using Interfaces;
    public class ImageHandler
    {
        private Image startRegionBGImage;
        private Image valleyRegionBGImage;
        private Image CharacterImage;
        private Image Boar1Image;
        private Image GiantCrab1Image;
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
            this.valleyRegionBGImage = Image.FromFile(Images.ValleyRegionBGImage);
            this.CharacterImage = Image.FromFile(Images.Character1ImagePath);
            this.Boar1Image = Image.FromFile(Images.BoarImagePath);
            this.GiantCrab1Image = Image.FromFile(Images.GiantCrab1ImagePath);
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
                case SpriteType.ValleyRegionBG:
                    image = this.valleyRegionBGImage;
                    break;
                case SpriteType.Char1:
                    image = this.CharacterImage;
                    break;
                case SpriteType.Boar1:
                    image = this.Boar1Image;
                    break;
                case SpriteType.GiantCrab1:
                    image = this.GiantCrab1Image;
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
