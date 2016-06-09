using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using RPG_AdvancedCS_May.Graphics;

namespace RPG_AdvancedCS_May.Interfaces
{
    interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
