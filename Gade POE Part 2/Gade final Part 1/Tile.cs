using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal abstract class Tile
    {
        // Field to hold the position
        private Position position;

        // Constructor that initializes the position field
        public Tile(Position position)
        {
            this.position = position;
        }

        // Properties to access and modify the coordinates
        public int XCoordinate
        {
            get { return position.XCoordinate; }
            set { position.XCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return position.YCoordinate; }
            set { position.YCoordinate = value; }
        }

        // Abstract property for the tile display character
        public abstract char Display { get; }

        // Property to get and set the position
        public Position Position
        {
            get { return position; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                position = value;
            }
        }
    }
    internal abstract class CharacterTile : Tile
    {
        //Instatiate the fields
        private int _hitPoints;
        private readonly int _hitPointsMax;
        private readonly int _attackPower;

        //Instatiate the Vision Array for the character
        public Tile[] charVision;

        //Declare the constructor for the character
        public CharacterTile(Position position, int hitDamage, int attackLevel) : base(position)
        {
            //Assign the parameter to the fields
            _hitPoints = hitDamage;
            _hitPointsMax = hitDamage;
            _attackPower = attackLevel;
            //Declare the array that will open 4 space to store values
            charVision = new Tile[4];
        }
        public void UpdateVision(Level level)
        {
            //2D Array from the level class to represent the template of the game grid
            var tiles = level.Tiles;

            if (YCoordinate - 1 >= 0)
                charVision[0] = tiles[XCoordinate, YCoordinate - 1]; // Tile above (index 0) of the character

            if (XCoordinate + 1 < level.Width)
                charVision[1] = tiles[XCoordinate + 1, YCoordinate]; // Tile to the right (index 1) of the character

            if (YCoordinate + 1 < level.Height)
                charVision[2] = tiles[XCoordinate, YCoordinate + 1]; // Tile below (index 2) of the character

            if (XCoordinate - 1 >= 0)
                charVision[3] = tiles[XCoordinate - 1, YCoordinate]; // Tile to the left (index 3) of the character
        }
        //Method that the character will take damage
        public int TakeDamage(int charDamage)
        {
            //Calculate the damage the character will endure
            _hitPoints = _hitPoints - charDamage;

            //Create an if statement to check if the hit points of the character is not below 0
            if (_hitPoints < 0)
            {
                _hitPoints = 0;
                //Display a messgae that game is over or the character died
                Console.WriteLine("Game over");
            }
            return _hitPoints;//Return the result to notify the Player
        }
        //Create a method that will to pass the attacker's power along the amount of damage
        public void Attack(CharacterTile target)
        {
            target.TakeDamage(_attackPower);
        }

        public bool IsDead => _hitPoints <= 0;
    }
}
