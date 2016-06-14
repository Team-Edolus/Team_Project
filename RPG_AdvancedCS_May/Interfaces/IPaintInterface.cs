using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.Graphics;

namespace RPG_AdvancedCS_May.Interfaces
{
    public interface IPaintInterface
    {
        void AddObject(IRenderable renderableObject);

        void RemoveObject(IRenderable renderableObject);

        void RedrawObject(IRenderable renderableObject);

        void SetBackground(IRenderable renderableObject);
    }
}
