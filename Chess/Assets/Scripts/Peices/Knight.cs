using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Peices
{
    public class Knight : ChessPiece
    {
        public override List<Vector2> getMoves(GameState state)
        {
            List<Vector2> results = new List<Vector2>();
            List<Vector2> candidateMoves = new List<Vector2>();
            candidateMoves.Add(this.peicePosition + new Vector2(1, 2));
            candidateMoves.Add(this.peicePosition + new Vector2(1, -2));
            candidateMoves.Add(this.peicePosition + new Vector2(-1, 2));
            candidateMoves.Add(this.peicePosition + new Vector2(-1, -2));

            candidateMoves.Add(this.peicePosition + new Vector2(2, 1));
            candidateMoves.Add(this.peicePosition + new Vector2(2, -1));
            candidateMoves.Add(this.peicePosition + new Vector2(-2, 1));
            candidateMoves.Add(this.peicePosition + new Vector2(-2, -1));

            foreach (Vector2 candidateMove in candidateMoves)
            {
                ChessPiece squareStatus = GameState.squareIsOnBoard(candidateMove) ? state.boardState[(int)candidateMove.x, (int)candidateMove.y] : null;

                if (state.canMoveTo(candidateMove, this.peiceColor))
                {
                    results.Add(candidateMove);
                }
            }

            return results;
            
        }

        public override List<Vector2> getControlledSquares(GameState state)
        {
            return getMoves(state);
        }

        public Knight(COLOR color) : base(color, TYPE.KNIGHT)
        {
        }
    }
}
