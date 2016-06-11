using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.Structure;
//using RPG_AdvancedCS_May.Controllers;

namespace RPG_AdvancedCS_May.GameEngine
{
    class Engine
    {
        private IUserInputInterface controller;
        private IPaintInterface Painter;
        private CharacterUnit Player;

        public Engine(IUserInputInterface givenController, IPaintInterface painter)
        {
            this.controller = givenController;
            this.Painter = painter;
            IntialisePlayer();
            SubscribeToController(controller);
        }
        
        private void IntialisePlayer()
        {
            this.Player = new CharacterUnit(16, 24, 100, 100, 250, 250, 10, 80, 4, SpriteType.Char1);
            Painter.AddObject(Player);
            Painter.AddObject(new EnemyNPCUnit(39, 24, 200, 200, 50, 50, 10, 5, 3, SpriteType.Boar));
            Painter.AddObject(new Background());
        }

        private void SubscribeToController(IUserInputInterface userInputInterface)
        {
            controller.OnUpPressed += (sender, args) =>
                {
                    MovePlayerUp();
                };
            controller.OnDownPressed += (sender, args) =>
                {
                    MovePlayerDown();
                };
            controller.OnRightPressed += (sender, args) =>
                {
                    MovePlayerRight();
                };
            controller.OnLeftPressed += (sender, args) =>
                {
                    MovePlayerLeft();
                };
        }
        //The if statements in the following four methods prevent the player from leaving the screen window
        private void MovePlayerUp()
        {
            this.Player.Direction = new Direction(0, -1);
            if (!(Player.Y == 0))
            {
                this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerDown()
        {
            this.Player.Direction = new Direction(0, 1);
            if (!(Player.Y >= 681 - Player.SizeY))
            {
            this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerRight()
        {
            this.Player.Direction = new Direction(1, 0);
            if (!(Player.X >= 1264 - Player.SizeX))
            {
            this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerLeft()
        {
            this.Player.Direction = new Direction(-1, 0);
            if (!(Player.X == 0))
            {
                this.ProcessPlayerMovement();
            }
        }

        public void ProcessPlayerMovement()
        {
            //TO DO: Implement checks and collision detection
            
            this.Player.Move();
            
        }
        public void Update()
        {
            this.Painter.RedrawObject(Player);
        }
    }
}
