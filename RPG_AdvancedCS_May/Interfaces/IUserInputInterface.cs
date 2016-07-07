namespace RPG_AdvancedCS_May.Interfaces
{
    using System;

    public interface IUserInputInterface
    {
        event EventHandler OnRightPressed;
        event EventHandler OnLeftPressed;
        event EventHandler OnUpPressed;
        event EventHandler OnDownPressed;
        event EventHandler On1Pressed;
        event EventHandler On2Pressed;

        event EventHandler OnLeftMouseClick;
    }
}
