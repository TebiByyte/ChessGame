using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum COLOR { BLACK, WHITE }
public enum TYPE { PAWN, KNIGHT, ROOK, KING, QUEEN, BISHOP }

public abstract class ChessPiece
{
    public COLOR peiceColor { get; private set; }
    public TYPE peiceType { get; private set; }
    public GameObject peiceModel { get; set; }
    public float peiceRotation { get; protected set; }
    public Vector2 peicePosition { get; set; }
    public Move lastMove;

    public abstract List<Vector2> getMoves(GameState state);

    protected bool isInRange(int r, int c)
    {
        bool result = false;

        if (r <= 0 && r < 8 && c <= 0 && c < 8)
        {
            result = true;
        }

        return result;
    }

    public ChessPiece(COLOR color, TYPE peiceType)
    {
        peiceColor = color;
        this.peiceType = peiceType;
    }
}
