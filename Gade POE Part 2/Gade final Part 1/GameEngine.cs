using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Gade_final_Part_1
{
    internal class GameEngine
    {
        //Declare the attributes
        private Level currentLvl;//Stores the user's Current level
        private int lvlNumbers;//Stores the number of levels the game consists of
        private int totalLvls;

        private HeroTile hero;
        private Level level;
        private GruntTile gruntTile;
        private PickupTile pickupTile;
        private CharacterTile characterTile;
        private Tile destination;

        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;
        private Tile[,] _tiles; // Assume this is your grid of tiles
        
        private Random random = new Random();
        private int currentLevelValue = 1;
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
            int numEnemies = currentLevelValue;//Set the new number of levels as the number of enemies
            int numOfHealths = 1;

            //Create an object for the current level field
            currentLvl = new Level(width, height,null, numEnemies, numOfHealths);
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
            else if (gameState == GameState.GameOver)
            {
                return "Snake!?...Snaaaaaake!, Game Over Competitor";
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

            if (targetTile is PickupTile)
            {
                ((PickupTile)targetTile).ApplyEffect(hero);
            }

            if (targetTile is EmptyTile)
            {
                // Swap tiles, update hero position and vision
                currentLvl.SwopTiles(heroTile, targetTile);
                heroTile.Position = targetPosition;
                currentLvl.UpdateVision(currentLvl);
                //gruntTile.GetMove(heroTile);
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
                return false;
            }
            // gruntTile.UpdateVision();//Call the update method?? from the level class instead of the hero update vision method, making sure the enemy visionarrays also get updated when the hero moves
            return targetTile != null;
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

            currentLevelValue++;//Increment the level and the number of enemies
            int newLvlWidth = randomValue.Next(MIN_SIZE, MAX_SIZE); // Generate the new randomized width
            int newLvlHeight = randomValue.Next(MIN_SIZE, MAX_SIZE); // Generate the new randomized height

            // Display temporary level and hero tile info
            Console.WriteLine($"Temporary Level: {temporaryLevel}, HeroTile: {heroTile.ToString()}");
            // Increment the number of enemies with each level
            int numLvlEnemies = currentLevelValue;
            Console.WriteLine($"the number of enemies are: {numLvlEnemies}");
            // Create a new Level and assign it to currentLvl
            currentLvl = new Level(newLvlWidth, newLvlHeight, null, numLvlEnemies);
            // Log current object state
            Console.WriteLine(this.ToString());
        }
        public void TriggerMovement(Level.Direction direction)
        {
            if(currentLvl.HeroTile.IsDead)
            {
                return;
            }
            int counter = 0;
            bool counterSuccess = MoveHero(direction);
            if (counterSuccess)
            {
                Console.WriteLine("Only one successful move was done");
                counter++;
            }
            if (counterSuccess && counter == 2)
            {
                Console.WriteLine("Two successful moves by the enemy was completed");
                EnemiesAttack();
                MoveEnemies();
                counter = 0;
                return; // Successful movement, exit the method
            }
        }
        private void MoveEnemies()
        {
            foreach(GruntTile gruntTile in this.currentLvl.enemyTiles)
            {
                // Check if the character is dead based on its Display character
                if (gruntTile.IsDead)  // Assuming 'X' means dead
                {
                    Console.WriteLine("The enemy is dead.");
                    continue;
                }
                if (gruntTile.GetMove(out Tile destination))
                {
                    Console.WriteLine("The character still consists of moves.");
                    //Level level = gruntTile.Level;//the level class needs a reference in the level class 
                    currentLvl.SwopTiles(gruntTile, destination);
                    gruntTile.Position = destination.Position;
                    //This will show the placement of the enemy on the tile
                    Console.WriteLine($"GruntTile moved to tile at position: {destination.XCoordinate}, {destination.YCoordinate}");
                    currentLvl.UpdateVision(level);
                }
            }
        }
        private bool HeroAttack(Level.Direction direction, CharacterTile characterTile)
        {
            //Retrieve the direction the hero will be located
            int heroX = hero.Position.XCoordinate;
            int heroY = hero.Position.YCoordinate;

            //Assign the directions to the targeted tile position
            int xTarget = heroX;
            int yTarget = heroY;

            //Set the switch method to adjust the location of the target
            switch (direction)
            {
                case Level.Direction.Up:
                    yTarget -= 1;//Moving up in the y-axis
                    break;
                case Level.Direction.Down:
                    yTarget += 1;//Moving down in the y-axis
                    break;
                case Level.Direction.Left:
                    xTarget -= 1;//Moving left in the x-axis
                    break;
                case Level.Direction.Right:
                    xTarget += 1;//Moving right on the x-axis
                    break;
            }
            // Retrieve the target based on the direction provided
            Tile target = level.CheckTile(xTarget, yTarget);

            // Check if the target is valid
            if (target is CharacterTile enemyTile && enemyTile is GruntTile)
            {
                hero.Attack(enemyTile);
                // If target is found, log the message and return true
                Console.WriteLine($"Attacked {target.Display}.");
                return true; // Attack successful
            }
            else
            {
                // If a valid target is not found, proceed with a message
                Console.WriteLine("No target in that direction.");
                return false; // Attack was unsuccessful
            }
        }
        public void TrigggerAttack(Level.Direction direction)
        {
            if(currentLvl.HeroTile.IsDead)
            {
                return;
            }
            HeroTile heroTile = currentLvl.HeroTile;
            bool attackResult = HeroAttack(direction, heroTile);

            if(attackResult == true)
            {
                EnemiesAttack();
                if (heroTile.IsDead)
                {
                    gameState = GameState.GameOver;
                }
            }
        }
        private void EnemiesAttack()
        {
            foreach (var enemy in currentLvl.enemyTiles)
            {
                if (gruntTile.Display != 'X')
                {
                    if (destination == null) // If destination is null, attack
                    {
                        CharacterTile[] targets = enemy.IdentifyTargets();
                        foreach (var target in targets)
                        {
                            enemy.Attack(target); // Attack the hero
                        }
                    }
                }
            }
        }
        public string HeroStats 
        {
            get 
            {
                HeroTile tile = currentLvl.HeroTile;

                return $"Maximum hitpoints are {tile.HitPoints}/{tile.MaxHitPoints}"; 
            } 
        }
    }
}
