using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fixed_version_question_2
{
    internal abstract class Tile
    {


        //Instatiate a field
        //private int typePosition;
        public Position Position;

        //Set Properties that will display the coordinates and each tile as a character
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public abstract char Display { get; }

        //Set a constructor that accepts a parameter and assigns it tot the position class field
        public Tile( Position position)
        {
            //Assign the argument to the field
            //typePosition = positionType;
            this.Position = position;
        }

    }
   
    //Create a new class
    internal class EmptyTile : Tile
    {
        //Set a constructor that will use the argument PositionParameter
        public EmptyTile(Position position) : base(position)
        {

        }
        //Returns the x and y coordinate and a dot
        public override char Display { get { return '.'; } }
    }
    //Create a new class extending Tile class
    internal class WallTile : Tile//Inherit from tile class
    {
        //Initialize a constructor
        public WallTile(Position position) : base(position)//Pass the parameter to the base constructor
        {

        }
        public override char Display { get { return '▋'; } }//Override the display property to showcase the wall character
    }
    

    

}
    

