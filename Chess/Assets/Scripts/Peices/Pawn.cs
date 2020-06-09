using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Peices
{
    public class Pawn : ChessPiece
    {
        public override List<Tuple<int, int>> getMoves(GameState state)
        {


            throw new NotImplementedException();
        }

        public Pawn(COLOR color) : base(color, TYPE.PAWN)
        {
        }
    }
}
