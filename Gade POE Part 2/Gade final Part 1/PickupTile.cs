using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal abstract class PickupTile : Tile
    {
        public PickupTile(Position position) : base(position)
        {
            this.Position = position;
        }
        Position Position { get; set; }
        public override char Display
        {
            get
            {
                return 'δ';
            }
        }
        //fixed error abstract classes declared without body
        public abstract void ApplyEffect(CharacterTile healedTarget);

    }
}
