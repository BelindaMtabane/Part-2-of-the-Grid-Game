using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixed_version_question_2
{
    internal class Level
    {

        //private fields 
        readonly HeroTile _herotile;
        public Tile[,] _tiles; //2D array of type Tile
        public int _width; //stores width 
        public int _height;  //stores height 
        private Random random = new Random();
        private HeroTile _hero; //stores hero 
        private ExitTile _exit;
        public HeroTile HeroTile { get; internal set; }


        //constructor  which holds interger paramters for height and width 
        public Level(int width, int height, HeroTile hero = null, ExitTile exit = null)
        {
            _width = width; //initialises width
            _height = height; //initialises height
            _tiles = new Tile[width, height]; //initialises 2D tile arrayusing the width and height values as the arrays dimensions
            _hero = hero; //passes hero or null 
            _exit = exit;
            InitialiseTiles(); // Call the new method right after initializing the array                            
            
        }

        //sets all the tiles in the 2D Tile array to EmptyTiles using the CreateTile method.
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
                        GetRandomEmptyPosition();
                        _tiles[x, y] = CreateTile(TileType.Exit, position);
                        exitPlaced = true;

                    }
                    else if (!HeroPlaced && _hero != null)
                    {
                        GetRandomEmptyPosition(); 
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
                if (!exitPlaced)
                {
                    Position randomPosition = GetRandomEmptyPosition();
                    if (_exit == null)
                    {
                        _exit = new ExitTile(randomPosition);
                    }
                    else
                    {
                        _exit.Position = randomPosition;
                    }
                    // _tiles[randomPosition.XCoordinate, randomPosition.YCoordinate] = _hero;
                }

            }
            
        }

        //enum named TileType 
        public enum TileType
        {
            Empty,
            Wall,
            Exit, 
            Hero
        }// single value named Empty 

        // More types w

        public Tile CreateTile(TileType tileType, Position position)
        {
            /*
            // if statement used to check if position is value, this brings in the IsValidPosition method
            if (!IsValidPosition(position.xValue, position.yValue))
            {
                return null; // Return null for invalid positions
            }
            */


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
            //StringBuilder levelString = new StringBuilder();

            string AccumulateVisuals = "";

            //
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    AccumulateVisuals = AccumulateVisuals + _tiles[x, y].Display;

                    //+levelString.Append(_tiles[x, y]?.Display ?? '.');
                }
                AccumulateVisuals = AccumulateVisuals + "\n";
                //levelString.Append('\n'); // Add new line at the end of each row
            }

            return AccumulateVisuals;

            //levelString.ToString();
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



