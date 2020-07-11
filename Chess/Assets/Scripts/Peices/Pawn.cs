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

            List<Vector2> candidateMoves = new List<Vector2>();


            float sign = peiceColor == COLOR.WHITE ? -1 : 1;
            Vector2 candidate = this.peicePosition + new Vector2(sign, 0);
            candidateMoves.Add(candidate);

            if (!state.squareFilled(peicePosition + new Vector2(sign, 0)) &&  
               ((this.peicePosition.x == 6 && this.peiceColor == COLOR.WHITE) || (this.peicePosition.x == 1 && this.peiceColor == COLOR.BLACK)))
            {
                candidateMoves.Add(this.peicePosition + new Vector2(2 * sign, 0));
            }

            Vector2 takeLeft = this.peicePosition + new Vector2(sign, -1);
            Vector2 takeRight = this.peicePosition + new Vector2(sign, 1);
            COLOR oppositeColor = this.peiceColor == COLOR.WHITE ? COLOR.BLACK : COLOR.WHITE;
            
            if (GameState.squareIsOnBoard(takeLeft) && state.squareFilled(takeLeft) 
                && state.boardState[(int)takeLeft.x, (int)takeLeft.y].peiceColor == oppositeColor)
            {
                results.Add(takeLeft);
            }

            if (GameState.squareIsOnBoard(takeRight) && state.squareFilled(takeRight)
                && state.boardState[(int)takeRight.x, (int)takeRight.y].peiceColor == oppositeColor)
            {
                results.Add(takeRight);
            }

            Vector2 left = this.peicePosition + new Vector2(0, -1);
            Vector2 right = this.peicePosition + new Vector2(0, 1);

            if (GameState.squareIsOnBoard(left) && state.squareFilled(left))
            {
                ChessPiece toLeft = state.boardState[(int)left.x, (int)left.y];

                if (toLeft.peiceType == TYPE.PAWN && Math.Abs(toLeft.lastMove.fromRow - toLeft.lastMove.toRow) == 2 &&
                    toLeft.lastMove.fromRow == state.lastMove.fromRow && toLeft.lastMove.fromCol == state.lastMove.fromCol)
                {
                    candidateMoves.Add(takeLeft);
                }
            }

            if (GameState.squareIsOnBoard(right) && state.squareFilled(right))
            {
                ChessPiece toRight = state.boardState[(int)right.x, (int)right.y];

                if (toRight.peiceType == TYPE.PAWN && Math.Abs(toRight.lastMove.fromRow - toRight.lastMove.toRow) == 2 &&
                    toRight.lastMove.fromRow == state.lastMove.fromRow && toRight.lastMove.fromCol == state.lastMove.fromCol)
                {
                    candidateMoves.Add(takeRight);
                }
            }

            foreach (Vector2 candidateMove in candidateMoves)
            {
                if (GameState.squareIsOnBoard(candidateMove) && !state.squareFilled(candidateMove))
                {
                    results.Add(candidateMove);
                }
            }

            return results;
        }

        public override List<Vector2> getControlledSquares(GameState state)
        {
            List<Vector2> results = new List<Vector2>();
            List<Vector2> candidateMoves = new List<Vector2>();

            float sign = peiceColor == COLOR.WHITE ? -1 : 1;

            candidateMoves.Add(this.peicePosition + new Vector2(sign, -1));
            candidateMoves.Add(this.peicePosition + new Vector2(sign, 1));

            foreach (Vector2 candidateMove in candidateMoves)
            {
                if (GameState.squareIsOnBoard(candidateMove) && !state.squareFilled(candidateMove))
                {
                    results.Add(candidateMove);
                }
            }

            return results;
        }

        public Pawn(COLOR color) : base(color, TYPE.PAWN)
        {
        }
    }
}
