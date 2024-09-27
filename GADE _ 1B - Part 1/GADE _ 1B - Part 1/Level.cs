using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE___1B___Part_1
{
    internal class Level
    {
        //Initialize properties
        //public HeroTile heroTile { get; private set; }
        public int _width { get; set; }//2D array of type Tile
        public int _height {  get; set; }//stores width
        public Tile[,] _tiles {  get; set; }//stores height
        public HeroTile HeroTile { get; internal set; }

        private Random random = new Random();
        private HeroTile _hero; //stores hero 
        //constructor  which holds interger paramters for height and width
        public Level(int width, int height, HeroTile hero = null)
        {
            _width = width; //initialises width
            _height = height; //initialises height
            _tiles = new Tile[width, height]; //initialises 2D tile arrayusing the width and height values as the arrays dimensions
            _hero = hero; //passes hero or null 
            InitialiseTiles(); // Call the new method right after initializing the array    
            //heroTile = new HeroTile();//Initializing a Hero object
        }

        //sets all the tiles in the 2D Tile array to EmptyTiles using the CreateTiule method.
        public void InitialiseTiles()
        {
            bool exitPlaced = false;
            bool HeroPlaced = false;
            // loop used to iterates over the x axis of the grid, starting from 0 up to _width - 1.
            for (int y = 0; y < _height; y++)
            {
                //nested loop used to iterates over the y axis of the grid, starting from 0 up to _height - 1.
                for (int x = 0; x < _width; x++)
                {
                    Position position = new Position(x, y);
                    // Create an empty tile at the current position
                    CreateTile(TileType.Empty, x, y); //error was here. dont know how to fix

                    //if statement to check if against wall, if so then will do walltile 

                    if (x == _width - 1 || y == _height - 1 || x == 0 || y == 0)
                    {
                        _tiles[x, y] = CreateTile(TileType.Wall, position);

                    }
                    else if (!exitPlaced)
                    {

                        _tiles[x, y] = CreateTile(TileType.Exit, position);
                        exitPlaced = true;

                    }
                    else if (!HeroPlaced && _hero != null)
                    {
                        _tiles[x, y] = _hero;
                        _hero.Position = position;  // This should now work
                        CreateTile(TileType.Hero, position);
                        HeroPlaced = true;
                    }

                    else
                    {
                        _tiles[x, y] = CreateTile(TileType.Empty, position);
                    }
                    //Position position = new Position(x, y);
                }
                //ToString();
                // If hero wasn't placed (because it was null), place it randomly
                if (!HeroPlaced)
                {
                    Position randomPosition = GetRandomEmptyPosition();
                    if (_hero == null)
                    {
                        _hero = new HeroTile(randomPosition);
                    }
                    else
                    {
                        _hero.Position = randomPosition;
                    }
                    // _tiles[randomPosition.XCoordinate, randomPosition.YCoordinate] = _hero;
                }

            }
        }

        //enum named TileType
        public enum TileType
        {
            Empty, // single value named Empty
            Wall,   // More types will be added here as we extend the Level class according to assignment brief
            Exit,
            Hero
        }// single value named Empty 
        public Tile CreateTile(TileType tileType, Position position)
        {
            Tile newTile;

            switch (tileType)
            {

                case TileType.Empty:
                    newTile = new EmptyTile(position);
                    break;
                case TileType.Wall:
                    newTile = new WallTile(position);
                    break;
                case TileType.Exit:
                    newTile = new ExitTile(position);
                    break;
                case TileType Hero:
                    newTile = new HeroTile(position);
                    break;

            }

            _tiles[position.XCoordinate, position.YCoordinate] = newTile;

            return newTile;
        }
        private Tile CreateTile(TileType tileType, int x, int y)
        {
            Position position = new Position(x, y);
            return CreateTile(tileType, position);
        }
        // Method to check if a tile creation was successful
        //provides a string representation of the entire level
        public override string ToString()
        {
            StringBuilder levelString = new StringBuilder();
            string AcculateVisuals = "";
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    AcculateVisuals = AcculateVisuals + _tiles[x, y].Display;
                }
                AcculateVisuals = AcculateVisuals + "\n"; // Add new line at the end of each row
            }
            return AcculateVisuals;
        }
        private Position GetRandomEmptyPosition()
        {
            List<Position> emptyPositions = new List<Position>();

            // Find all empty positions
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_tiles[x, y] is EmptyTile)
                    {
                        return new Position(x, y);
                        // emptyPositions.Add(new Position(x, y));
                    }
                }
            }
            return null;
            // Select a random empty position
            //int randomIndex = random.Next(emptyPositions.Count);
            //return emptyPositions[randomIndex];
        }
        public void SwopTiles(Tile tileOne, Tile tileTwo)
        {
            //Set properties to swap the actual tiles by updating the tile references in the _tiles array
            _tiles[tileOne.XCoordinate, tileOne.YCoordinate] = tileOne;
            _tiles[tileTwo.XCoordinate, tileTwo.YCoordinate] = tileTwo;

            //Updating function that will swap the positions of the two tiles using the Position property
            Position tempPosition = tileOne.Position;
            tileOne.Position = tileTwo.Position;
            tileTwo.Position = tempPosition;
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
