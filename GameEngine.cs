using System;
using System.Collections.Generic;


namespace Fixed_version_GADE_most_recent
{
    internal class GameEngine
    {
        //Declare the attributes
        private Level currentLvl;//Stores the user's Current level
        private int lvlNumbers;//Stores the number of levels the game consists of
                               //private readonly int randomValue;//Stores the random value that is within the constants ranges
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
