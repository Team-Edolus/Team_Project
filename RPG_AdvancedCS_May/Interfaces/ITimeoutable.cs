using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_AdvancedCS_May.Interfaces
{
    public interface ITimeoutable
    {
        int MaxLifespanInMS { get; set; }
        int CurrentLifespanInMS { get; set; }

        bool HasTimedOut { get; set; }
    }
}
