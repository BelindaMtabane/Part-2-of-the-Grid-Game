using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal class Level
    {
        //Initialize fields
        private Tile[,] _tiles;
        private ExitTile _exit;
        private HeroTile _hero;
        private EnemyTile[] _enemyTiles;

        //Initialize properties to expose the fields
        public int Width { get; set; }//2D array of type Tile
        public int Height { get; set; }//stores width
        public Tile[,] Tiles { get { return _tiles; } }//stores height
        public HeroTile HeroTile { get { return _hero; } }//stores hero
        public ExitTile ExitTile { get { return _exit; } }
        public EnemyTile[] enemyTiles { get { return _enemyTiles; } } //exposes the enemyTile array

        private Random random = new Random();
        //constructor  which holds integer paramters for height and width
        public Tile CreateTile(TileType tileType, Position position)
        {
            int enemyIndex = 0;
            switch (tileType)
            {
                case TileType.Empty:
                    _tiles[position.XCoordinate, position.YCoordinate] = new EmptyTile(position);
                    break;
                case TileType.Wall:
                    _tiles[position.XCoordinate, position.YCoordinate] = new WallTile(position);
                    break;
                case TileType.Exit:
                    _tiles[position.XCoordinate, position.YCoordinate] = new ExitTile(position);
                    break;
                case TileType.Hero:
                    _tiles[position.XCoordinate, position.YCoordinate] = new HeroTile(position);
                    break;
                case TileType.Enemy:
                    _enemyTiles[enemyIndex] = new GruntTile(position, this);
                    break;

            }
            return _tiles[position.XCoordinate, position.YCoordinate];
        }
        public Level(int width, int height, HeroTile hero = null, ExitTile exitTile = null, int numEnemies = 4)
        {
            // Set the width and height of the level
            Width = width;
            Height = height;

            // Initialize the 2D tile array with the given dimensions
            _tiles = new Tile[width, height];

            // Store the exit tile (if provided)
            _exit = exitTile;

            // Initialize the tiles in the level
            InitialiseTiles();

            Position randomPosition = GetRandomEmptyPosition();
            // If no hero tile was passed in, create a new hero at a random empty position
            if (hero == null)
            {
                
                hero = (HeroTile)CreateTile(TileType.Hero, randomPosition);
            }
            else
            {
                // Move the hero to a new random empty position
                hero.XCoordinate = randomPosition.XCoordinate;
                hero.YCoordinate = randomPosition.YCoordinate;

                // Place the hero at the updated position in the tiles array
                _tiles[hero.XCoordinate, hero.YCoordinate] = hero;
            }
            Position randomExitTilePosition = GetRandomEmptyPosition();

            _exit = CreateTile(TileType.Exit, randomExitTilePosition) as ExitTile;

            // Assign the hero to the level's hero property
            _hero = hero;

            if (numEnemies > 0)
            {
                //_enemyTiles = new EnemyTile[numEnemies];
                for (int i = 0; i < numEnemies; i++)
                {
                    Position enemyPosition = GetRandomEmptyPosition();
                    _enemyTiles[i] = (EnemyTile)CreateTile(TileType.Enemy, enemyPosition);
                }
            }
            else
            {
                _enemyTiles = new EnemyTile[0];
            }
        }
        //sets all the tiles in the 2D Tile array to EmptyTiles using the CreateTiule method.
        public void InitialiseTiles()
        {
            // loop used to iterates over the x axis of the grid, starting from 0 up to _width - 1.
            for (int y = 0; y < Height; y++)
            {
                //nested loop used to iterates over the y axis of the grid, starting from 0 up to _height - 1.
                for (int x = 0; x < Width; x++)
                {
                    Position position = new Position(x, y);
                    // Create an empty tile at the current position
                    CreateTile(TileType.Empty, x, y);

                    //if statement to check if against wall, if so then will do walltile
                    if (x == Width - 1 || y == Height - 1 || x == 0 || y == 0)
                    {
                        _tiles[x, y] = CreateTile(TileType.Wall, position);

                    }
                    else
                    {
                        _tiles[x, y] = CreateTile(TileType.Empty, position);
                    }
                }
            }
        }
        //enum named TileType
        public enum TileType
        {
            Empty, // single value named Empty
            Wall,   // More types will be added here as we extend the Level class according to assignment brief
            Exit,
            Hero,
            Enemy
        }// single value named Empty
       
        private Tile CreateTile(TileType tileType, int x, int y)
        {
            Position position = new Position(x, y);
            return CreateTile(tileType, position);
        }
        // Method to check if a tile creation was successful
        //provides a string representation of the entire level
        public override string ToString()
        {
            string AcculateVisuals = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    AcculateVisuals = AcculateVisuals + _tiles[x, y].Display;
                }
                AcculateVisuals = AcculateVisuals + "\n"; // Add new line at the end of each row
            }
            return AcculateVisuals;
        }
        public Tile CheckTile(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                return _tiles[x, y];
            }
            return null;
        }
        private Position GetRandomEmptyPosition()
        {
            int xValue = 0;
            int yValue = 0;
            bool openPosition = false;
            Position position = new Position(xValue, yValue);
            //Tile tile = null;

            // Keep looping until we find an empty tile
            while (!openPosition)
            {
                xValue = random.Next(0, Width);
                yValue = random.Next(0, Height);

                // Check if the tile at this position is an empty tile
                if (_tiles[xValue, yValue].Display == '.')
                {
                    position = new Position(xValue, yValue); // Get the Tile at this position
                    openPosition = true; // We've found an empty tile, so exit the loop
                }
            }
            return position; // Return the found empty tile
        }

        public void SwopTiles(Tile tileOne, Tile tileTwo)
        {
            if (tileOne == null || tileTwo == null)
            {
                throw new ArgumentNullException(nameof(tileOne), "Tiles cannot be null.");
            }
            // Capture original coordinates
            var (tileOneX, tileOneY) = (tileOne.XCoordinate, tileOne.YCoordinate);
            var (tileTwoX, tileTwoY) = (tileTwo.XCoordinate, tileTwo.YCoordinate);

            // Perform the tile swap in the array
            _tiles[tileOneX, tileOneY] = tileTwo;
            _tiles[tileTwoX, tileTwoY] = tileOne;

            // Swap the position values of the tiles
            (tileOne.Position, tileTwo.Position) = (tileTwo.Position, tileOne.Position);

            // Update the coordinates of the tiles to reflect their new positions
            tileOne.XCoordinate = tileTwoX;
            tileOne.YCoordinate = tileTwoY;
            tileTwo.XCoordinate = tileOneX;
            tileTwo.YCoordinate = tileOneY;
        }
        public enum Direction
        {
            //Set the directions for the character's movement
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3,
            None = 4
        }
    }
}
