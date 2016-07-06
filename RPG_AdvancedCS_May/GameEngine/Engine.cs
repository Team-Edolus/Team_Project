using System.Linq;

namespace RPG_AdvancedCS_May.GameEngine
{ 
    using System;

    using Interfaces;
    using Structure;

    public sealed class Engine
    {
        private IUserInputInterface _controller;
        private IPaintInterface _painter;
        private int _timeInterval;
        private RegionEntities regionEntities;

        //private CharacterUnit _player;
        //private List<EnemyNPCUnit> _enemies;
        //private List<Ability> _abilities; //Timeoutable

        public Engine(IUserInputInterface givenController, IPaintInterface painter, int timeInterval)
        {
            this._controller = givenController;
            this._painter = painter;
            this._timeInterval = timeInterval;
            //test
            RegionEntities.IntantiateClass(this._painter);
            this.regionEntities = RegionEntities.GetInstance();
            //endTest
            SubscribeToController();
        }

        private void InitialiseItems()
        {
            var shield = new Shield();
            _painter.AddObject(shield);
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
            this.regionEntities.Player.Direction = new Direction(0, -1);
            if (regionEntities.Player.Y > 0)
            {
                this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerDown()
        {
            this.regionEntities.Player.Direction = new Direction(0, 1);
            if (regionEntities.Player.Y + regionEntities.Player.SizeY < 720)
            {
                this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerRight()
        {
            this.regionEntities.Player.Direction = new Direction(1, 0);
            if (regionEntities.Player.X + regionEntities.Player.SizeX < 1280)
            {
                this.ProcessPlayerMovement();
            }
        }
        private void MovePlayerLeft()
        {
            this.regionEntities.Player.Direction = new Direction(-1, 0);
            if (regionEntities.Player.X > 0)
            {
                this.ProcessPlayerMovement();
            }
        }

        public void ProcessPlayerMovement()
        {
            //TO DO : Process collision in seperate class CollisionHandler
            var buffX = this.regionEntities.Player.X;
            var buffY = this.regionEntities.Player.Y;
            this.regionEntities.Player.Move();
            var colisionDetected = false;
            foreach (var obstacle in this.regionEntities.Obstacles)
            {
                if (DoIntersect(this.regionEntities.Player, obstacle))
                {
                    colisionDetected = true;
                    break;
                }
            }
            if (colisionDetected)
            {
                this.regionEntities.Player.Relocate(buffX, buffY);
            }
            //Check for gateways
            foreach (var gateway in this.regionEntities.Gateways)
            {
                if (this.DoIntersect(this.regionEntities.Player, gateway))
                {
                    gateway.TriggerAction();
                    break;
                }
            }
        }

        private void UsePlayerAbility(int x, int y)
        {
            if (this.regionEntities.Player is Warrior)
            {
                var meleeAbility = ((Warrior)this.regionEntities.Player).MeleeAttack(x, y);
                //Ability Logic
                if (meleeAbility == null) return;
                if (meleeAbility is BasicAttack)
                {
                    this.regionEntities.Abilities.Add(meleeAbility);
                    this._painter.AddObject(meleeAbility as IRenderable);
                    this.ProcessAreaAbilityEffect(meleeAbility);
                }
                //else if..  - other melee abilities
            }
            //else if.. - other character classes
        }

        private void ProcessAreaAbilityEffect(Ability ability)
        {
            var hitTargets = this.regionEntities.Enemies.Where(e => this.DoIntersect(ability, e)).ToList();
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

        private void RemoveDeadUnits()
        {
            var deadUnits = this.regionEntities.Enemies.Where(e => !e.IsAlive).ToList();
            foreach (var deadUnit in deadUnits)
            {
                this.regionEntities.Enemies.Remove(deadUnit);
                this._painter.RemoveObject(deadUnit);
            }
        }
        

        //----------------------------------------------------------------------------------------\\
        public void Update()
        {
            this.RemoveDeadUnits();
            this._painter.RedrawObject(this.regionEntities.Player);
            this.regionEntities.Enemies.ForEach(this._painter.RedrawObject);
            this.regionEntities.Abilities.ForEach(a => a.CurrentLifespanInMS += this._timeInterval);
            var timedOutList = this.regionEntities.Abilities.Where(a => a.HasTimedOut).ToList();
            foreach (var timedOutObj in timedOutList)
            {
                this.regionEntities.Abilities.Remove(timedOutObj);
                this._painter.RemoveObject(timedOutObj as IRenderable);
            }
        }
    }
}
