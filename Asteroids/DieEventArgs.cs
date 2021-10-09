using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class DieEventArgs : EventArgs
    {
        public int LastDamage { get; set; }

        public DieEventArgs(int lastDamage)
        {
            LastDamage = lastDamage;
        }
    }
}
