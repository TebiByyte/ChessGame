using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum COLOR { BLACK, WHITE }
public enum TYPE { PAWN, KNIGHT, ROOK, KING, QUEEN, BISHOP }

public abstract class ChessPiece
{
    public COLOR pieceColor { get; private set; }
    public TYPE peiceType { get; private set; }

    public abstract List<Tuple<int, int>> getMoves(GameState state);

    public ChessPiece(COLOR color, TYPE peiceType)
    {
        pieceColor = color;
        this.peiceType = peiceType;
    }
}
