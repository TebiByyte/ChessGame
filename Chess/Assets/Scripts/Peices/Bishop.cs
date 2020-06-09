using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Peices
{
    class Bishop : ChessPiece
    {
        public override List<Tuple<int, int>> getMoves(GameState state)
        {


            throw new NotImplementedException();
        }

        public Bishop(COLOR color) : base(color, TYPE.BISHOP)
        {
            this.peiceRotation = 90.0f;
        }
    }
}
