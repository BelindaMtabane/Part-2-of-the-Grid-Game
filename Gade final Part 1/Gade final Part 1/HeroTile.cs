using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal class HeroTile : CharacterTile
    {
        public HeroTile(Position position) : base(position, 40, 5)
        {
        }
        public override char Display
        {
            get
            {
                return IsDead ? 'X' : '▼';
            }
        }
    }
}
