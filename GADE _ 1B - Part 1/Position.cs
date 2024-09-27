using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE___1B___Part_1
{
 
    internal class Position : Tile
    {
        private int _xValues;//Carrying the x-coodinates
        private int _yValues;//Carrying the y-coordinates;

        //Create properties that will set and return the fields back to the user
        public int XValues { get { return _xValues; } }
        public int YValues { get { return _yValues; } }

         public Position(int userXValue, int userYValue)
        {
            //Set the arguments to the corresponding fields
            _xValues = userXValue;
            _yValues = userYValue;
            
        }
        //Set the overide methods to all for the child classes to gve information, which is displaying the coordinates
        public override char Display => throw new NotImplementedException();

        public override void X_Coordinate()
        {
            //Display the X-Coordinate
            Console.WriteLine(_xValues);
        }
        public override void Y_Coordinate()
        {
            //Display the Y-Coordinate
            Console.WriteLine(_yValues);
        }

    }
}
