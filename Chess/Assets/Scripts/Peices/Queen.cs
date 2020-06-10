using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Peices
{
    class Queen : ChessPiece
    {
        public override List<Vector2> getMoves(GameState state)
        {


            throw new NotImplementedException();
        }

        public Queen(COLOR color) : base(color, TYPE.QUEEN)
        {
        }
    }
}
