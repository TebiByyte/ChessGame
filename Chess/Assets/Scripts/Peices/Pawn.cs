using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Peices
{
    public class Pawn : ChessPiece
    {
        public override List<Vector2> getMoves(GameState state)
        {
            List<Vector2> results = new List<Vector2>();

            //Placeholder
            Vector2 candidate = this.peicePosition + new Vector2(-1, 0);

            if (GameState.squareIsOnBoard(candidate) && !state.squareFilled((int)candidate.x, (int)candidate.y))
            {
                results.Add(candidate);
            }

            return results;
        }

        public Pawn(COLOR color) : base(color, TYPE.PAWN)
        {
        }
    }
}
