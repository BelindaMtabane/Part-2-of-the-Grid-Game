using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixed_version_question_2
{
    internal class ExitTile : Tile 
    {
        public ExitTile(Position position) : base(position)
        {
        }

        public override char Display { get { return '▒'; } }
    }   

}

