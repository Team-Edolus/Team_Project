using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.Structure;

namespace RPG_AdvancedCS_May.GameEngine
{
    public class Engine
    {
        private IUserInputInterface _controller;
        private IPaintInterface Painter;
        private int _timeInterval;

        private CharacterUnit _player;
        private List<EnemyNPCUnit> _enemies;
        private List<Ability> _abilities; //Timeoutable

        public Engine(IUserInputInterface givenController, IPaintInterface painter, int timeInterval)
        {
            this._controller = givenController;
            this.Painter = painter;
            this._timeInterval = timeInterval;
            SubscribeToController();
            this._enemies = new List<EnemyNPCUnit>();
            this._abilities = new List<Ability>();
            InitialiseEnemies();
            IntialisePlayer();
            SetBackground();
        }

        private void IntialisePlayer()
        {
            this._player = new Warrior(200, 100, 16, 24, 250, 250, 10, 80, 4, SpriteType.Char1);
            Painter.AddObject(_player);
        }
        private void InitialiseEnemies()
        {
            _enemies.Add(new EnemyNPCUnit(200, 200, 39, 24, 1000, 1100, 10, 5, 3, SpriteType.Boar));
            _enemies.Add(new EnemyNPCUnit(300, 300, 39, 24, 450, 450, 10, 5, 3, SpriteType.Boar));
            _enemies.Add(new EnemyNPCUnit(400, 400, 39, 24, 250, 300, 10, 5, 3, SpriteType.Boar));
            _enemies.Add(new EnemyNPCUnit(500, 500, 39, 24, 200, 250, 10, 5, 3, SpriteType.Boar));
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

        private void SubscribeToController()
        {
            _controller.OnUpPressed += (sender, args) =>
                {
                    MovePlayerUp();
                };
            _controller.OnDownPressed += (sender, args) =>
                {
                    MovePlayerDown();
                };
            _controller.OnRightPressed += (sender, args) =>
                {
                    MovePlayerRight();
                };
            _controller.OnLeftPressed += (sender, args) =>
                {
                    MovePlayerLeft();
                };
            _controller.OnLeftMouseClick += (sender, args) =>
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
            if (_player.X < 1263 - _player.SizeX)
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
            #region CodeForRefactoring
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
            #endregion
            //TO DO : Process collision in seperate class CollisionHandler
            this._player.Move();
        }
        private void UsePlayerAbility(int x, int y)
        {
            if (_player is Warrior)
            {
                var meleeAbility = ((Warrior)_player).MeleeAttack(x, y);
                //Ability Logic
                if (meleeAbility == null) return;
                if (meleeAbility is BasicAttack)
                {
                    this._abilities.Add(meleeAbility);
                    this.Painter.AddObject(meleeAbility as IRenderable);
                    this.ProcessAreaAbilityEffect(meleeAbility);
                }
                //else if..  - other melee abilities
            }
            //else if.. - other character classes
        }

        private void ProcessAreaAbilityEffect(Ability ability)
        {
            var hitTargets = this._enemies.Where(e => this.DoIntersect(ability, e)).ToList();
            foreach (var hitEnemy in hitTargets)
            {
                var reaction = hitEnemy.ReactToAbility(ability.AbilityEffect);
                switch (reaction)
                {
                    case ReactionTypeEnum.TakeDamage:
                        {
                            var damage = ability.Power + ability.Caster.AttackPoints - hitEnemy.DefensePoints;
                            hitEnemy.CurrentHP -= damage;
                            break;
                        }
                    case ReactionTypeEnum.TakeHeal:
                        break;
                    case ReactionTypeEnum.TakeBuff:
                        break;
                    case ReactionTypeEnum.TakeDebuff:
                        break;
                    case ReactionTypeEnum.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private bool DoIntersect(IGameObject objA, IGameObject objB)
        {
            int RectAX1 = objA.X;
            int RectAX2 = objA.X + objA.SizeX;
            int RectAY1 = objA.Y;
            int RectAY2 = objA.Y + objA.SizeY;

            int RectBX1 = objB.X;
            int RectBX2 = objB.X + objB.SizeX;
            int RectBY1 = objB.Y;
            int RectBY2 = objB.Y + objB.SizeY;
            if (RectAX1 < RectBX2 &&
                RectAX2 > RectBX1 && 
                RectAY1 < RectBY2 && 
                RectAY2 > RectBY1)
            {
                return true;
            }
            return false;
        }

        public void ProcessProjectileMovement(IMoveable movableObject)
        {
            throw new NotImplementedException();
        }

        public void RemoveDeadUnits()
        {
            var deadUnits = _enemies.Where(e => !e.IsAlive).ToList();
            foreach (var deadUnit in deadUnits)
            {
                this._enemies.Remove(deadUnit);
                this.Painter.RemoveObject(deadUnit);
            }
        }
        

        //----------------------------------------------------------------------------------------\\
        public void Update()
        {
            this.RemoveDeadUnits();
            this.Painter.RedrawObject(_player);
            this._enemies.ForEach(this.Painter.RedrawObject);
            this._abilities.ForEach(a => a.CurrentLifespanInMS += this._timeInterval);
            var timedOutList = this._abilities.Where(a => a.HasTimedOut).ToList();
            foreach (var timedOutObj in timedOutList)
            {
                this._abilities.Remove(timedOutObj);
                this.Painter.RemoveObject(timedOutObj as IRenderable);
            }
        }
    }
}
