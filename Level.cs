using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Fixed_version_GADE_most_recent.Level;

namespace Fixed_version_GADE_most_recent
{
    internal class Level
    {
        //private fields 
        private Tile[,] _tiles; //2D array of type Tile
        private int _width; //stores width 
        private int _height;  //stores height 


        //constructor  which holds interger paramters for height and width 
        public Level(int width, int height)
        {
            _width = width; //initialises width
            _height = height; //initialises height
            _tiles = new Tile[width, height]; //initialises 2D tile arrayusing the width and height values as the arrays dimensions
            InitialiseTiles(); // Call the new method right after initializing the array                            
        }

        //sets all the tiles in the 2D Tile array to EmptyTiles using the CreateTiule method.
        public void InitialiseTiles()
        {
            // loop used to iterates over the x axis of the grid, starting from 0 up to _width - 1.
            for (int y = 0; y < _width; y++)
            {
                //nested loop used to iterates over the y axis of the grid, starting from 0 up to _height - 1.
                for (int x = 0; x < _height; x++)
                {
                    // Create an empty tile at the current position
                    CreateTile(TileType.Empty, x, y); //error was here. dont know how to fix 
                }
                ToString();
            }
        }

        //enum named TileType 
        public enum TileType
        {
            Empty,
            Wall
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
                // More cases will be added here as we extend the Level class
                default:
                    return null; // Returns null for invalid tile types
            }

            //_tiles[position.xValue, position.yValue] = newTile;

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

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    levelString.Append(_tiles[x, y]?.Display ?? '.');
                }
                levelString.Append('\n'); // Add new line at the end of each row
            }

            return levelString.ToString();
        }

    }
}

