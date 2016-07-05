namespace RPG_AdvancedCS_May.Interfaces
{
    using System;

    public interface IUserInputInterface
    {
        event EventHandler OnRightPressed;
        event EventHandler OnLeftPressed;
        event EventHandler OnUpPressed;
        event EventHandler OnDownPressed;

        event EventHandler OnLeftMouseClick;
    }
}
