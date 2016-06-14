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
    public class Engine
    {
        private IUserInputInterface controller;
        private IPaintInterface Painter;
        private CharacterUnit Player;
        private List<EnemyNPCUnit> enemies = new List<EnemyNPCUnit>();

        public Engine(IUserInputInterface givenController, IPaintInterface painter)
        {
            this.controller = givenController;
            this.Painter = painter;
            SubscribeToController(controller);
            IntialisePlayer();
            this.enemies = InitialiseEnemies();

        }

        private void IntialisePlayer()
        {
            this.Player = new Warrior(16, 24, 200, 100, 250, 250, 10, 80, 4, SpriteType.Char1);
            Painter.AddObject(Player);
        }

        private List<EnemyNPCUnit> InitialiseEnemies()
        {
            List<EnemyNPCUnit> enemies = new List<EnemyNPCUnit>();

            enemies.Add(new EnemyNPCUnit(39, 24, 200, 200, 50, 50, 10, 5, 3, SpriteType.Boar));
            enemies.Add(new EnemyNPCUnit(39, 24, 300, 300, 50, 50, 10, 5, 3, SpriteType.Boar));
            //TO DO: add more enemies


            foreach (var enemy in enemies)
            {
                Painter.AddObject(enemy);
            }

            return enemies;
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
            controller.OnLeftMouseClick += (sender, args) =>
            {
                var abilityArgs = args as AbilityEventArgs;
                if (abilityArgs != null)
                {
                    UsePlayerAbility(abilityArgs.MouseX, abilityArgs.MouseY);
                }
            };
        }

        
        private void MovePlayerUp()
        {
            this.ProcessPlayerMovement(new Direction(0, -1));
        }
        private void MovePlayerDown()
        {
            this.ProcessPlayerMovement(new Direction(0, 1));
        }
        private void MovePlayerRight()
        {
            this.ProcessPlayerMovement(new Direction(1, 0));
        }
        private void MovePlayerLeft()
        {
            this.ProcessPlayerMovement(new Direction(-1, 0));
        }

        public void ProcessPlayerMovement(Direction direction)
        {
            bool shouldMove = true;
            foreach (var enemy in enemies)
            {
                if ((this.Player.X - this.Player.SizeX + direction.DirX) >= (enemy.X - enemy.SizeX) &&
                    (this.Player.Y + this.Player.SizeY + direction.DirY) >= (enemy.Y - enemy.SizeY) &&
                    (this.Player.X - this.Player.SizeX + direction.DirX) <= (enemy.X + enemy.SizeX) &&
                    (this.Player.Y - this.Player.SizeY + direction.DirY) <= (enemy.Y + enemy.SizeY))
                {
                    if (true) // TO DO : check for going outside of the map
                    {
                        shouldMove = false;
                    }
                }
            }

            if (shouldMove)
            {
                this.Player.Direction = direction;
                this.Player.Move();
            }
        }

        private void UsePlayerAbility(int x, int y)
        {
            if (Player is Warrior)
            {
                ((Warrior)Player).MeleeAttack(x, y);
            }
        }

        public void ProcessProjectileMovement(IMoveable movableObject)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------\\
        public void Update()
        {
            this.Painter.RedrawObject(Player);
        }
    }
}
