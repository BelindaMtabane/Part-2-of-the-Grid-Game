using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal class WallTile : Tile//Inherit from tile class
    {
        //Initialize a constructor
        public WallTile(Position position) : base(position)//Pass the parameter to the base constructor
        {

        }
        public override char Display => '█';//Override the display property to showcase the wall character
    }

}
