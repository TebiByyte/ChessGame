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
            List<Vector2> results = new List<Vector2>();
            List<Vector2> candidateMoves = new List<Vector2>();
            candidateMoves.Add(this.peicePosition + new Vector2(1, 0));
            candidateMoves.Add(this.peicePosition + new Vector2(-1, 0));
            candidateMoves.Add(this.peicePosition + new Vector2(1, 1));
            candidateMoves.Add(this.peicePosition + new Vector2(-1, 1));
            candidateMoves.Add(this.peicePosition + new Vector2(1, -1));
            candidateMoves.Add(this.peicePosition + new Vector2(-1, -1));
            candidateMoves.Add(this.peicePosition + new Vector2(0, -1));
            candidateMoves.Add(this.peicePosition + new Vector2(0, 1));

            foreach (Vector2 candidateMove in candidateMoves)
            {
                if (state.canMoveTo(candidateMove, this.peiceColor))
                {
                    results.Add(candidateMove);
                }
            }

            return results;
        }

        public King(COLOR color) : base(color, TYPE.KING)
        {
            this.peiceRotation = 90.0f;
        }
    }
}
