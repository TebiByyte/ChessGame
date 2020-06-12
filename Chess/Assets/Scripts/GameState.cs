using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public ChessPiece[,] boardState;

    public bool squareFilled(int row, int col)
    {
        return boardState[row, col] != null;
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

    public static bool squareIsOnBoard(Vector2 square)
    {
        return square.x >= 0 && square.x < 8 && square.y >= 0 && square.y < 8;
    }
}
