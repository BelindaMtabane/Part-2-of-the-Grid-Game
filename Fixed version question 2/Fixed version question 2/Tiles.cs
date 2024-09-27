using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixed_version_question_2
{
    internal abstract class Tile
    {

        // Instantiate a field
        public int TypePosition { get; private set; }

        // Set Properties that will display the coordinates and each tile as a character
        public abstract int X_Coordinate { get; }
        public abstract int Y_Coordinate { get; }
        public abstract char Display { get; }

        // Set a constructor that accepts a parameter and assigns it to the position class field
        protected Tile(int positionType)
        {
            // Assign the argument to the field
            TypePosition = positionType;
        }
    }

    // Create a new class
    internal class EmptyTile : Tile
    {
        private readonly int _xCoordinate;
        private readonly int _yCoordinate;

        // Set a constructor that will use the argument positionParameter
        public EmptyTile(int positionParameter, int xCoordinate, int yCoordinate) : base(positionParameter)
        {
            //initializes the x Coordinate and y Coordinate fields
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }

        //returns the x and y coordinate and a dot
        public override int X_Coordinate => _xCoordinate;
        public override int Y_Coordinate => _yCoordinate;
        public override char Display => '.';

    }
}
