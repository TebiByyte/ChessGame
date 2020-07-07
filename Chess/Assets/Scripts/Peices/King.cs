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

            
            if (this.lastMove.fromCol == 0 && this.lastMove.fromRow == 0 && this.lastMove.toCol == 0 && this.lastMove.toRow == 0)
            {
                //King side castling
                ChessPiece piece = state.boardState[(int)peicePosition.x, (int)peicePosition.y - 3];

                if (!state.squareFilled(this.peicePosition - new Vector2(0, 1)) &&
                    !state.squareFilled(this.peicePosition - new Vector2(0, 2)) &&
                    state.squareFilled(this.peicePosition - new Vector2(0, 3)) &&
                    piece.lastMove.fromCol == 0 && piece.lastMove.fromRow == 0 && piece.lastMove.toCol == 0 && piece.lastMove.toRow == 0)
                {
                    results.Add(this.peicePosition - new Vector2(0, 2));
                }

                //Queenside castling
                piece = state.boardState[(int)peicePosition.x, (int)peicePosition.y + 4];

                if (!state.squareFilled(this.peicePosition + new Vector2(0, 1)) &&
                    !state.squareFilled(this.peicePosition + new Vector2(0, 2)) &&
                    !state.squareFilled(this.peicePosition + new Vector2(0, 3)) &&
                    state.squareFilled(this.peicePosition + new Vector2(0, 4)) &&
                    piece.lastMove.fromCol == 0 && piece.lastMove.fromRow == 0 && piece.lastMove.toCol == 0 && piece.lastMove.toRow == 0)
                {
                    results.Add(this.peicePosition + new Vector2(0, 2));
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
