using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.Structure;
//using RPG_AdvancedCS_May.Controllers;

namespace RPG_AdvancedCS_May.GameEngine
{
    public class Engine
    {
        private IUserInputInterface controller;
        private IPaintInterface Painter;
        private CharacterUnit _player;
        private List<EnemyNPCUnit> _enemies;

        public Engine(IUserInputInterface givenController, IPaintInterface painter)
        {
            this.controller = givenController;
            this.Painter = painter;
            SubscribeToController(controller);
            this._enemies = new List<EnemyNPCUnit>();
            InitialiseEnemies();
            IntialisePlayer();
            SetBackground();
        }


        private void IntialisePlayer()
        {
            this._player = new Warrior(16, 24, 200, 100, 250, 250, 10, 80, 4, SpriteType.Char1);
            Painter.AddObject(_player);
            //Painter.AddObject(new EnemyNPCUnit(39, 24, 200, 200, 50, 50, 10, 5, 3, SpriteType.Boar));
        }
        private void InitialiseEnemies()
        {
            _enemies.Add(new EnemyNPCUnit(39, 24, 200, 200, 50, 50, 10, 5, 3, SpriteType.Boar));
            _enemies.Add(new EnemyNPCUnit(39, 24, 300, 300, 50, 50, 10, 5, 3, SpriteType.Boar));
            //TO DO: add more enemies

            foreach (var enemy in _enemies)
            {
                Painter.AddObject(enemy);
            }
        }
        private void SetBackground()
        {
            Painter.SetBackground(new Background());
        }

        //================================================

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
            controller.OnLeftMouseClick += (sender, args) =>
            {
                var abilityArgs = args as AbilityEventArgs;
                if (abilityArgs != null)
                {
                    UsePlayerAbility(abilityArgs.MouseX, abilityArgs.MouseY);
                }
            };
        }


        //The if statements in the following four methods prevent the player from leaving the screen window
        private void MovePlayerUp()
        {
            this._player.Direction = new Direction(0, -1);
            if (_player.Y > 0)
            {
                this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerDown()
        {
            this._player.Direction = new Direction(0, 1);
            if (_player.Y + _player.SizeY < 680)
            {
                this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerRight()
        {
            this._player.Direction = new Direction(1, 0);
            if (_player.X + _player.Y < 1350)
            //if (_player.X < 1280 - _player.SizeX)
            //if (_player.X < 1266)
            //if(_player.X + _player.SizeX < 1280)
            {
                this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerLeft()
        {
            this._player.Direction = new Direction(-1, 0);
            if (_player.X > 0)
            {
                this.ProcessPlayerMovement();
            }
        }

        public void ProcessPlayerMovement()
        {
            //bool shouldMove = true;
            //foreach (var enemy in _enemies)
            //{
            //    if ((this._player.X - this._player.SizeX + direction.DirX) >= (enemy.X - enemy.SizeX) &&
            //        (this._player.Y + this._player.SizeY + direction.DirY) >= (enemy.Y - enemy.SizeY) &&
            //        (this._player.X - this._player.SizeX + direction.DirX) <= (enemy.X + enemy.SizeX) &&
            //        (this._player.Y - this._player.SizeY + direction.DirY) <= (enemy.Y + enemy.SizeY))
            //    {
            //        if (true) // TO DO : check for going outside of the map
            //        {
            //            shouldMove = false;
            //        }
            //    }
            //}

            //if (shouldMove)
            //{
            //    this._player.Direction = direction;
            //    this._player.Move();
            //}
            this._player.Move();
        }

        private void UsePlayerAbility(int x, int y)
        {
            if (_player is Warrior)
            {
                ((Warrior)_player).MeleeAttack(x, y);
            }
        }

        public void ProcessProjectileMovement(IMoveable movableObject)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------\\
        public void Update()
        {
            this.Painter.RedrawObject(_player);
        }
    }
}
