using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal abstract class PickupTile : Tile
    {
        private int Target;
        public PickupTile(Position position) : base(position) 
        { 
        
        }

        //fixed error abstract classes declared without body
        public abstract void ApplyEffect(CharacterTile healedTarget);

    }

}
