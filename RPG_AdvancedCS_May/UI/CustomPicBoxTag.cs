using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.UI
{
    public class CustomPicBoxTag
    {
        public IRenderable RendObject;
        public IUserInputInterface Controller;

        public CustomPicBoxTag(IRenderable rendObject, IUserInputInterface controller)
        {
            RendObject = rendObject;
            Controller = controller;
        }
    }
}
