using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal abstract class EnemyTile : CharacterTile
    {
        //Create a constructor to store the trait and abilities of the enemies
        public EnemyTile (Position position, int damagePoints, int enemyATKPower) : base(position, damagePoints, enemyATKPower)
        {
            
        }
        // Abstract method that determines the move and returns the destination tile via out parameter
        public abstract bool GetMove(out Tile destination);
        // Abstract method that identifies the target tiles
        public abstract CharacterTile[] IdentifyTargets();
    }
}
