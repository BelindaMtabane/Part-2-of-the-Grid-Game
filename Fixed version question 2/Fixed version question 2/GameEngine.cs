using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixed_version_question_2
{
    internal class GameEngine
    {
        //Declare the attributes
        private List<int> currentLvl;//Stores the user's Current level
        private int lvlNumbers;//Stores the number of levels the game consists of
        private Random randomValue;//Stores the random value that is within the constants ranges
        public const int MIN_SIZE = 10;
        public const int MAX_SIZE = 20;

        //Set a constructor to set the number of levels the game has
        public GameEngine(int gameLvls)
        {
            //Assign the gamelevels to a filed
            lvlNumbers = gameLvls;
            //Create an object for the current level field 
            currentLvl = new List<int>();
        }
        //
        public int GenerateValues()
        {
            randomValue = new Random();
            return randomValue.Next(MIN_SIZE, MAX_SIZE);
        }
        public override string ToString()
        {
            return string.Join(", ", currentLvl);
        }
    }
}
