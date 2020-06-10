using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Peices
{
    class King : ChessPiece
    {
        public override List<Vector2> getMoves(GameState state)
        {


            throw new NotImplementedException();
        }

        public King(COLOR color) : base(color, TYPE.KING)
        {
            this.peiceRotation = 90.0f;
        }
    }
}
