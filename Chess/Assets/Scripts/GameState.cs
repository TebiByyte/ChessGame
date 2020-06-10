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

    public static bool squareIsOnBoard(Vector2 square)
    {
        return square.x >= 0 && square.x < 8 && square.y >= 0 && square.y < 8;
    }
}
