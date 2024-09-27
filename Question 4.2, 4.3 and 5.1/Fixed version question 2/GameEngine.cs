using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fixed_version_question_2
{
    internal class GameEngine
    {
        //Declare the attributes
        private Level currentLvl;//Stores the user's Current level
        private int lvlNumbers;//Stores the number of levels the game consists of
        private int totalLvls;
        //private readonly int randomValue;//Stores the random value that is within the constants ranges
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;

        //Set a number generator that will return a value between the constants
        private Random randomValue = new Random();

        private GameState gameState = GameState.InProgress;

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
            if (gameState == GameState.Complete)
            {
                return "Victory, You have succefully completed the game, Congratulations";

            }
            else if (gameState == GameState.InProgress)
            {
                return currentLvl.ToString();

            }
            return base.ToString() ?? "Default string value";
            //Using a format to all for the value to be a readble string

        }
        private bool MoveHero(Level.Direction direction, CharacterTile characterTile)
        {
            // Cast the direction enum to an integer to use as an index for the vision array
            int directionIndex = (int)direction;

            //Check the target tile in the hero's vision array based on the desired direction
            Tile targetTile = characterTile.charVision[directionIndex];

            if (targetTile is EmptyTile)
            {
                //swap tiles
                currentLvl.SwopTiles(characterTile, targetTile);

                //update the character tile's position 
                characterTile.Position = targetTile.Position;

                if (lvlNumbers == totalLvls)
                {
                    gameState = GameState.Complete;
                    return false;
                }
                else
                {
                    NextLevel();
                    return true;
                }

            }
            //Check if the target tile is an instance of EmptyTile
            if (targetTile is EmptyTile)
            {
                // Move is successful, return true

                return true;
            }
            else
            {
                // Move failed, return false

                return false;
            }

        }
        public enum GameState
        {
            //Assign values that will give progression of the player
            InProgress,
            Complete,
            GameOver

        }
        public void NextLevel()
        {
            lvlNumbers++;//Increase the current level of the character by one

            HeroTile heroTile = currentLvl.HeroTile;//Temporarily storing the next Level of the game 

            int newLvlWidth = randomValue.Next(MIN_SIZE, MAX_SIZE);//Generate the new randomised width of the new level
            int newLvlHeight = randomValue.Next(MIN_SIZE, MAX_SIZE);//Generate the new randomised height of the new level

            currentLvl = new Level(newLvlWidth, newLvlHeight, heroTile);//Create a new Level, passing in the stored HeroTile
        }
        public void TriggerMovement(Level.Direction direction) 
        {
            // Get the current hero tile from the level
            HeroTile heroTile = currentLvl.HeroTile;

            MoveHero(direction, heroTile);


        }
    }
}













    