using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GADE___1B___Part_1.Tile;

namespace GADE___1B___Part_1
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
                return isDead ? 'X' : '▼';
            }
        }
    }
}
