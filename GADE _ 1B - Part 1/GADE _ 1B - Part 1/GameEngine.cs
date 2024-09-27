using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static GADE___1B___Part_1.Level;
using static GADE___1B___Part_1.Tile;

namespace GADE___1B___Part_1
{
    internal class GameEngine
    {
        //Declare the attributes
        private Level currentLvl;//Stores the user's Current level
        private int lvlNumbers;//Stores the number of levels the game consists of
        private int totalLvls;
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;
        
        private GameState gameState = GameState.InProgress;

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
            if (gameState == GameState.Complete)
            {
                return "Victory Player, You have successfully completed the game, Congradulations!";
            }
            else if (gameState == GameState.InProgress)
            {
                //Using a format to all for the value to be a readable string
                return currentLvl.ToString();
            }

            return base.ToString() ?? "Default string value";//This is a default function that will supress the reference type warning and if the code returns a null, this is due to the gameover function being used later
        }
        private bool MoveHero(Level.Direction direction, CharacterTile characterTile)
        {
             // Assume this represents the hero character

            // Set the direction enum to an integer to use as an index for the vision array
            int directionIndex = (int)direction;

            // Check the target tile in the hero's vision array based on the desired direction
            Tile targetTile = characterTile.charVision[directionIndex];
            
            if (targetTile is EmptyTile)
            {
                if (lvlNumbers == totalLvls)
                {
                    gameState = GameState.Complete;//This function that will end the game
                    return false;//This function will function as the hero finished the game
                }
                else
                {
                    NextLevel();//Set the method if the levels are more within the game
                    return true;//Return the fuunction as true so that the hero moves on to the next level
                }
            }



            // Check if the target tile is an instance of the EmptyTile
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
            //Assign values that will give the progression of the Player
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
    }
}
