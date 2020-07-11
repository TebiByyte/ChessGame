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

    public abstract List<Vector2> getControlledSquares(GameState state);

    public ChessPiece(COLOR color, TYPE peiceType)
    {
        peiceColor = color;
        this.peiceType = peiceType;
    }
}
