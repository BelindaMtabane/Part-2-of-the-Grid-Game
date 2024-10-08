using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_final_Part_1
{
    internal class HealthPickupTile : PickupTile
    {
        public HealthPickupTile(Position position) : base(position)
        {
            this.Position = position;
        }
        Position Position { get; set; }
        public override char Display
        {
            get
            {
                return '+';
            }
        }
        public override void ApplyEffect(CharacterTile healedTarget)
        {
            healedTarget.HealingTarget(10);
        }
    }
}
