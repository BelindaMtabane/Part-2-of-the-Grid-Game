using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Gade_final_Part_1
{
    internal class GameEngine
    {
        //Declare the attributes
        private Level currentLvl;//Stores the user's Current level
        private int lvlNumbers;//Stores the number of levels the game consists of
        private int totalLvls;
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;
        private Tile[,] _tiles; // Assume this is your grid of tiles
        
        private Random random = new Random();
        private GameState gameState = GameState.InProgress;
        //Set a number generator that will return a value between the constants
        private Random randomValue = new Random();

        //Set a constructor to set the number of levels the game has
        public GameEngine(int gameLvls)
        {
            //Assign the gamelevels to a filled
            this.lvlNumbers = gameLvls;
            int height = randomValue.Next(MIN_SIZE, MAX_SIZE);
            int width = randomValue.Next(MIN_SIZE, MAX_SIZE);
            //Create an object for the current level field
            currentLvl = new Level(width, height);
            totalLvls = 1;
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
            return base.ToString();//This is a default function that will supress the reference type warning and if the code returns a null, this is due to the gameover function being used later
        }
        private bool MoveHero(Level.Direction direction)
        {
            var heroTile = currentLvl.HeroTile;
            var heroPosition = heroTile.Position;
            var exitTile = currentLvl.ExitTile;
            var exitPosition = exitTile.Position;

            // Log current hero position and movement direction
            Console.WriteLine("Your Hero position: X = " + heroPosition.XCoordinate + " Y = " + heroPosition.YCoordinate);
            Console.WriteLine("Your Exit position: X = " + exitPosition.XCoordinate + " Y = " + exitPosition.YCoordinate);
            Console.WriteLine($"Placing the hero in the Direction: {direction}");

            // Determine if the hero is adjacent to the exit tile by checking x and y coordinates
            bool isHeroAdjacentToExit = false;

            // Check horizontal proximity
            if (heroPosition.XCoordinate == exitPosition.XCoordinate - 1 &&
                heroPosition.YCoordinate == exitPosition.YCoordinate + 1)
            {
                isHeroAdjacentToExit = true;
            }
            // Check vertical proximity
            if (heroPosition.XCoordinate == exitPosition.XCoordinate + 1 &&
                heroPosition.YCoordinate == exitPosition.YCoordinate - 1)
            {
                isHeroAdjacentToExit = true;
            }
            // If the hero is adjacent to the exit tile, proceed to the next level
            if (isHeroAdjacentToExit)
            {
                // Check if this is the last level
                if (lvlNumbers == totalLvls)
                {
                    Console.WriteLine($"Game complete! Victoryyy");
                    gameState = GameState.Complete; // Update game state to complete
                }
                else
                {
                    Console.WriteLine($"Level complete!");
                    NextLevel(); // Trigger the next level transition
                }
                return true; // Indicate that the hero is near the exit
            }
            // Compute the target position based on direction
            int xOffset = 0, yOffset = 0;

            switch (direction)
            {
                case Level.Direction.Up:
                    yOffset = -1;
                    break;
                case Level.Direction.Down:
                    yOffset = 1;
                    break;
                case Level.Direction.Left:
                    xOffset = -1;
                    break;
                case Level.Direction.Right:
                    xOffset = 1;
                    break;
                default:
                    return false;
            }
            var targetPosition = new Position(heroPosition.XCoordinate + xOffset, heroPosition.YCoordinate + yOffset);
            var targetTile = currentLvl.CheckTile(targetPosition.XCoordinate, targetPosition.YCoordinate);

            if (targetTile is EmptyTile)
            {
                // Swap tiles, update hero position and vision
                currentLvl.SwopTiles(heroTile, targetTile);
                heroTile.Position = targetPosition;
                heroTile.UpdateVision(currentLvl);
                return true;
            }
            //Create this if statement to check if 
            if (targetTile is ExitTile)
            {
                if (lvlNumbers == totalLvls)
                {
                    Console.WriteLine($"Game complete! Victoryyy");
                    gameState = GameState.Complete;
                }
                else
                {
                    Console.WriteLine($"Level complete!");
                    NextLevel();
                }
            }
            return false;
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
            Level temporaryLevel = this.currentLvl;
            lvlNumbers++; // Increase the current level of the character by one
            HeroTile heroTile = currentLvl.HeroTile; // Store the HeroTile from the current level

            int newLvlWidth = randomValue.Next(MIN_SIZE, MAX_SIZE); // Generate the new randomized width
            int newLvlHeight = randomValue.Next(MIN_SIZE, MAX_SIZE); // Generate the new randomized height

            // Display temporary level and hero tile info
            Console.WriteLine($"Temporary Level: {temporaryLevel}, HeroTile: {heroTile.ToString()}");

            // Create a new Level and assign it to currentLvl
            currentLvl = new Level(newLvlWidth, newLvlHeight, heroTile);

            // Log current object state
            Console.WriteLine(this.ToString());
        }

        public void TriggerMovement(Level.Direction direction)
        {
            if (direction != Level.Direction.None)
            {
                if (MoveHero(direction))
                {
                    return; // Successful movement, exit the method
                }
                Console.WriteLine("Movement failed.");
            }
            else
            {
                Console.WriteLine("No movement direction provided.");
            }
        }
    }
}
