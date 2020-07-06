using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Move
{
    public int fromRow { get; private set; }
    public int fromCol { get; private set; }
    public int toRow { get; private set; }
    public int toCol { get; private set; }

    public Move(int fromRow, int fromCol, int toRow, int toCol)
    {
        this.fromRow = fromRow;
        this.fromCol = fromCol;
        this.toRow = toRow;
        this.toCol = toCol;
    }
}

public class GameState
{
    public ChessPiece[,] boardState;
    public COLOR turn = COLOR.WHITE;
    public bool inCheck = false;

    public bool squareFilled(Vector2 square)
    {
        int row = (int)square.x;
        int col = (int)square.y;

        return boardState[row, col] != null;
    }

    public List<Move> getAllMoves(COLOR color)
    {
        List<Move> result = new List<Move>();

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (boardState[r, c] != null && boardState[r, c].peiceColor == color)
                {
                    List<Vector2> moves = boardState[r, c].getMoves(this);
                    
                    foreach (Vector2 m in moves)
                    {
                        result.Add(new Move(r, c, (int)m.x, (int)m.y));
                    }
                }
            }
        }

        return result;
    }

    public void movePeice(int rowFrom, int colFrom, int rowTo, int colTo)
    {
        ChessPiece temp = boardState[rowFrom, colFrom];
        boardState[rowFrom, colFrom] = null;

        if (boardState[rowTo, colTo] != null)
        {
            MainGame.Destroy(boardState[rowTo, colTo].peiceModel);
        }

        boardState[rowTo, colTo] = temp;
        temp.lastMove = new Move(rowFrom, colFrom, rowTo, colTo);
    }

    public void enableAll()
    {
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (boardState[r, c] != null)
                {
                    boardState[r, c].peiceModel.SetActive(true);
                }
            }
        }
    }

    public bool canMoveTo(Vector2 to, COLOR color)
    {
        return squareIsOnBoard(to) && (squareFilled(to) && boardState[(int)to.x, (int)to.y].peiceColor != color || !squareFilled(to));
    }

    public static bool squareIsOnBoard(Vector2 square)
    {
        return square.x >= 0 && square.x < 8 && square.y >= 0 && square.y < 8;
    }
}
