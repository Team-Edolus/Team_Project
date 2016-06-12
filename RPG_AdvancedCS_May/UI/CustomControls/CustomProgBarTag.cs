using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.UI
{ 
    public class CustomProgBarTag
    {
        public IUnit RendObject;
        public IUserInputInterface Controller;

        public CustomProgBarTag(IUnit rendObject, IUserInputInterface controller)
        {
            RendObject = rendObject;
            Controller = controller;
        }
    }
}
