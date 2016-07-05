﻿namespace RPG_AdvancedCS_May.GameEngine
{
    using System;

    public class AbilityEventArgs : EventArgs
    {
        public int MouseX { get; set; }
        public int MouseY { get; set; }

        public AbilityEventArgs(int mouseX, int mouseY)
        {
            this.MouseX = mouseX;
            this.MouseY = mouseY;
        }
    }
}
