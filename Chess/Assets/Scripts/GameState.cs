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
        boardState[rowTo, colTo] = temp;
    }

    public static bool squareIsOnBoard(Vector2 square)
    {
        return square.x >= 0 && square.x < 8 && square.y >= 0 && square.y < 8;
    }
}
