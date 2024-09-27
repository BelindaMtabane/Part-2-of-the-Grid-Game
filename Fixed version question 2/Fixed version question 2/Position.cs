using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixed_version_question_2
{
    internal class Position : Tile
    {
        private int _xValues;//Carrying the x-coodinates
        private int _yValues;//Carrying the y-coordinates;
        private static int parameterPosition;

        //Create properties that will set and return the fields back to the user
        public int XValues { get; set; }
        public int YValues { get; set; }

        public Position(int userXValue, int userYValue) : base(userXValue + userYValue)
        {
            //Set the arguments to the corresponding fields
            _xValues = userXValue;
            _yValues = userYValue;

        }
        //Set the overide methods to all for the child classes to gve information, which is displaying the coordinates
        public override char Display => '.';

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
