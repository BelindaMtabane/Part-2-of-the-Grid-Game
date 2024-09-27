using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_PART_1
{
    internal class GameEngine
    {
        //Declare the attributes
        private Level currentLvl;//Stores the user's Current level
        private int lvlNumbers;//Stores the number of levels the game consists of
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;

        //Set a number generator that will return a value between the constants
        private Random randomValue = new Random();

        //Set a constructor to set the number of levels the game has
        public GameEngine(int gameLvls)
        {
            //Assign the gamelevels to a filed
            lvlNumbers = gameLvls;
            int height = randomValue.Next(MIN_SIZE, MAX_SIZE);
            int width = randomValue.Next(MIN_SIZE, MAX_SIZE);
            //Create an object for the current level field 
            currentLvl = new Level(width, height);
        }
        public override string ToString()
        {
            //Using a format to all for the value to be a readble string
            return currentLvl.ToString();
        }
    }
}
