using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixed_version_question_2
{
    internal class Level
    {
        // Enum declaration
        public enum TileType
        {
            Empty
        }

        private EmptyTile[,] tiles;
        private int width;
        private int height;

        // Constructor
        public Level(int width, int height)
        {
            this.width = width;
            this.height = height;
            tiles = new EmptyTile[width, height];

            // Initialize tiles method called inside levels constructor
            initialiseTiles();
        }

        // Properties to expose width and height
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        // Get a tile at a specific position
        public EmptyTile GetTile(int x, int y)
        {
            if (IsValidPosition(x, y))
            {
                return tiles[x, y];
            }
            throw new ArgumentOutOfRangeException("Position out of bounds");
        }

        // Set a tile at a specific position
        public void SetTile(int x, int y, EmptyTile tile)
        {
            if (IsValidPosition(x, y))
            {
                tiles[x, y] = tile;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Position out of bounds");
            }
        }

        // Loops through the entire 2D array and sets each tile to an EmptyTile using the CreateTile method.
        private void initialiseTiles()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    CreateTile(TileType.Empty, x, y); // Create and place an EmptyTile
                }
            }
        }

        // Private method to create a tile based on TileType and position
        private EmptyTile CreateTile(TileType tileType, Position position)
        {
            EmptyTile tile;
            switch (tileType)
            {
                case TileType.Empty:
                    tile = new EmptyTile(positionParameter, position.XValues, position.YValues);// Uses the constructor correctly
                    break;
                // Future tile types will be handled here
                default:
                    throw new ArgumentException("Unsupported TileType");
            }

            // Place tile in the array
            tiles[position.XValues, position.YValues] = tile;

            return tile;
        }

        // Overloaded CreateTile method for convenience
        private EmptyTile CreateTile(TileType tileType, int x, int y)
        {
            Position position = new Position(x, y);
            return CreateTile(tileType, position);
        }

        // Helper function to check if position is valid
        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        // Override ToString method to represent the level visually
        public override string ToString()
        {
            StringBuilder levelRepresentation = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    levelRepresentation.Append(tiles[x, y].Display); // Accesses the DisplayCharacter property
                }
                levelRepresentation.Append("\n"); // using /n a New line after each row is added to te string everytime row ends
            }

            return levelRepresentation.ToString();
        }
    }
    


    // Position class to hold tile coordinates
    /*public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

    }*/



