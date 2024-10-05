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
        private HeroTile hero;
        private CharacterTile updateVision;
        private EnemyTile[] _enemies; //stores enemy tiles

        public GruntTile(Position position) : base(position, 10, 1)
        {

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
            //loops through the four directions 
            destination = null;
            List<Tile> emptyTiles = new List<Tile>();

            // Check adjacent tiles (up, right, down, left)
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { -1, 0, 1, 0 };

            //loops through the four directions 
            for (int i = 0; i < charVision.Length; i++)
            {
                Tile tile = charVision[i];
                int newX = Position.XCoordinate + dx[i];
                int newY = Position.YCoordinate + dy[i];

                //checks if the new tile is an empty tile 
                if (tile is EmptyTile)
                {
                    //adds a valid tile to the empty tile list
                    emptyTiles.Add(tile);
                }
            }
            if (emptyTiles.Count == 0)
            {
                destination = null;
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
                Tile tile = charVision[i];

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
    }
}
