namespace RPG_AdvancedCS_May.GameEngine
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
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
            _controller.On1Pressed += (sender, args) =>
            {
                this.ChangePlayerActiveAbility(args as KeyEventArgs);
            };
            _controller.On2Pressed += (sender, args) =>
            {
                this.ChangePlayerActiveAbility(args as KeyEventArgs);
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

        private void ChangePlayerActiveAbility(KeyEventArgs args)
        {
            var key = string.Empty;
            switch (args.KeyCode)
            {
                case Keys.D1:
                    key = "1";
                    break;
                case Keys.D2:
                    key = "2";
                    break;
                default:
                    break;
            }
            this.regionEntities.Player.SetActiveAbility(key);
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
            foreach (var enemy in this.regionEntities.Enemies)
            {
                if (DoIntersect(this.regionEntities.Player, enemy))
                {
                    colisionDetected = true;
                    break;
                }
            }
            foreach (var friendlyNpcUnit in this.regionEntities.FriendlyNPCs)
            {
                if (DoIntersect(this.regionEntities.Player, friendlyNpcUnit))
                {
                    colisionDetected = true;
                    break;
                }
            }

            foreach (var item in this.regionEntities.Items)
            {
                if (DoIntersect(this.regionEntities.Player, item))
                {
                    //colisionDetected = true;
                    //break;
                    ApplyItemEffext(item,this.regionEntities.Player);
                    item.hasBeenUsed = true;
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

        private void ApplyItemEffext(Item item, CharacterUnit player)
        {
            item.ApplyItemEffects(player);
            this._painter.RedrawObjectWithAShield(player);                      
        }

        private void UsePlayerAbility(int mouseX, int mouseY)
        {
            if (this.regionEntities.Player is Warrior)
            {
                var meleeAbility = ((Warrior)this.regionEntities.Player).MeleeAttack(mouseX, mouseY);
                //Ability Logic
                if (meleeAbility == null) return;
                if (meleeAbility is BasicAttack)
                {
                    this.regionEntities.Abilities.Add(meleeAbility);
                    this._painter.AddObject(meleeAbility as IRenderable);
                    this.ProcessAreaAbilityEffect(meleeAbility);
                }
                else if (meleeAbility is Charge)
                {
                    var mouseRect = new DisposableGameObject(mouseX, mouseY, 1, 1);
                    // Check range restr.
                    if (DoIntersect(meleeAbility, mouseRect))
                    {
                        foreach (var enemyNpcUnit in this.regionEntities.Enemies)
                        {
                            if (DoIntersect(mouseRect, enemyNpcUnit))
                            {
                                this.regionEntities.Player.Relocate(mouseX, mouseY);
                            }
                        }
                    }
                }
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
                            //tuk li e miastoto da napisha dmg det vrushta praseto?
                            var damageBack = hitEnemy.AttackPoints;// znam che moje da se osuvurshenstva tuk!
                            //i  kolko hp mu ostava
                            regionEntities.Player.CurrentHP -= damageBack;
                            break;
                        }
                    case ReactionTypeEnum.TakeShield:
                        var itemToCollect = this.regionEntities.Items.FirstOrDefault();
                        break;
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

        private void RemoveUsedItems()
        {
            var usedItems = this.regionEntities.Items.Where(e => e.hasBeenUsed).ToList();
            foreach (var usedItem in usedItems)
            {
                this.regionEntities.Items.Remove(usedItem);
                this._painter.RemoveObject(usedItem);
            }
        }


        //----------------------------------------------------------------------------------------\\
        public void Update()
        {
            this.RemoveDeadUnits();
            this.RemoveUsedItems();
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
