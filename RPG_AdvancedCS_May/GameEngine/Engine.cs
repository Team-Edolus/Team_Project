using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.Structure;
//using RPG_AdvancedCS_May.Controllers;

namespace RPG_AdvancedCS_May.GameEngine
{
    class Engine
    {
        private IUserInputInterface controller;

        public Engine(IUserInputInterface givenController)
        {
            this.controller = givenController;
            IntialiseCharacter();
        }

        private void IntialiseCharacter()
        {
            //CharacterUnit character = new CharacterUnit(50, 50, 100, 100, 10, 200, 80, 250, 3); //AddSpriteType
        }

        public void Update()
        {

        }
    }
}
