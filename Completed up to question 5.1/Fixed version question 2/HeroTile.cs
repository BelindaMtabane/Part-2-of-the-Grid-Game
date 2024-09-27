using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixed_version_question_2
{
    internal class HeroTile : CharacterTile
    {
        public HeroTile(Position position) : base(position, 40, 5)
        {

        }
        
        public override char Display
        {

            get
            {
                return isDead ? 'X' : '▼';  
            }
          
        }
       
    }
}

    

      

       
