using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal class Position
    {
        private int _xCoordinate;//Carrying the x-coodinates
        private int _yCoordinate;//Carrying the y-coordinates;

        public Position(int xValue, int yValue)
        {
            //Set the arguments to the corresponding fields
            _xCoordinate = xValue;
            _yCoordinate = yValue;
        }
        //Create properties that will set and return the fields back to the user
        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }
        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

    }
}
