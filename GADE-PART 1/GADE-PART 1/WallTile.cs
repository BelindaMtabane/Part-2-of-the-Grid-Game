using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_PART_1
{
    //Create a new class extending Tile class
    internal class WallTile : Tile//Inherit from tile class
    {
        //Initialize a constructor
        public WallTile(Position position) : base(position)//Pass the parameter to the base constructor
        {

        }
        public override char Display => '█';//Override the display property to showcase the wall character
    }
}
