using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal class GruntTile : EnemyTile
    {
        private Random random = new Random();
        private Level level;
        private Tile _updateVision;
        private EnemyTile[] _enemies; //stores enemy tiles

        public GruntTile(Position position, Level level) : base(position, 10, 1)
        {
            this.level = level;
        }
        public override char Display
        {
            get
            {
                return IsDead ? 'X' : 'δ';
            }
        }
        public override bool GetMove(out Tile destination)
        {
            destination = null;
            List<Tile> emptyTiles = new List<Tile>();

            // Check adjacent tiles (up, right, down, left)
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { -1, 0, 1, 0 };

            //loops through the four directions 
            for (int i = 0; i < 4; i++)
            {
                int newX = Position.XCoordinate + dx[i];
                int newY = Position.YCoordinate + dy[i];

                Tile tile = level.CheckTile(newX, newY);

                //checks if the new tile is an empty tile 
                if (tile is EmptyTile)
                {
                    //adds a valid tile to the empty tile list
                    emptyTiles.Add(tile);
                }
            }
            if (emptyTiles.Count == 0)
            {
                return false; // No empty tiles in vision array
            }

            // Choose a random empty tile from the available tiles
            destination = emptyTiles[random.Next(emptyTiles.Count)];
            return true; //indicates valid move was found 
        }
        public override CharacterTile[] IdentifyTargets()
        {
            //empty list to store detected targets
            List<CharacterTile> targets = new List<CharacterTile>();

            //defines arrays for horizontal and vertical movement
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { -1, 0, 1, 0 };

            //loop that checks adjacent tiles 
            for (int i = 0; i < 4; i++)
            {
                int newX = Position.XCoordinate + dx[i];
                int newY = Position.YCoordinate + dy[i];

                Tile tile = level.CheckTile(newX, newY);

                //loop that checks if the tile adjacent is a herotile 
                if (tile is HeroTile heroTile)
                {
                    //if it is, it adds the herotile to its target list
                    targets.Add(heroTile);
                    break; // Only add the first HeroTile found
                }
            }
            return targets.ToArray();
        }
        public void SetEnemies(EnemyTile[] enemies) //parameters takes array of enemyTile objects
        {
            _enemies = enemies; //it then assigns the input array to the private field
        }

        public void UpdateVision()
        {
            if (_updateVision != null && level != null)
            {
                // calls meethod 
                UpdateVision(level);
            }

            //loop that checks if _enemies is not null 
            if (_enemies != null)
            {
                //iterates through each enemy
                foreach (var enemy in _enemies)
                {
                    //call method on each enemy
                    enemy.UpdateVision(level);  // Update vision for each enemy
                }
            }
        }
    }
}
