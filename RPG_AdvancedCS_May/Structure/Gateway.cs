namespace RPG_AdvancedCS_May.Structure
{
    using System;
    public class Gateway : Environment //TO DO
    {
        //Desc: Used to load new regions
        //Collision-free
        private readonly Action loadingAction;
        private readonly Action<int, int> playerPositionAction;
        private readonly int newPlayerX;
        private readonly int newPlayerY;

        public Gateway(int x, int y, int sizeX, int sizeY, Action loadingAction, 
            int nX, int nY, Action<int, int> playerPositionAction) 
            : base(x, y, sizeX, sizeY)
        {
            this.loadingAction = loadingAction;
            this.newPlayerX = nX;
            this.newPlayerY = nY;
            this.playerPositionAction = playerPositionAction;
        }

        public void TriggerAction()
        {
            playerPositionAction.Invoke(newPlayerX, newPlayerY);
            loadingAction.Invoke();
        }
    }
}
