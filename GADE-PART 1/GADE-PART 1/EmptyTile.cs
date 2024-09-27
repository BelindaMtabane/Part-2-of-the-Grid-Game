using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_PART_1
{
    //Create a new class
    internal class EmptyTile : Tile
    {
        //Set a constructor that will use the argument PositionParameter
        public EmptyTile(Position position) : base(position)
        {

        }
        //Returns the x and y coordinate and a dot
        public override char Display => '.';
    }
}
