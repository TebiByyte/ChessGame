using Assets.Scripts.Peices;
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
    public Move lastMove;
    public ChessPiece[,] boardState;
    public COLOR turn = COLOR.WHITE;

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

        if (boardState[rowTo, colTo] != null && boardState[rowTo, colTo].peiceModel != null)
        {
            MainGame.Destroy(boardState[rowTo, colTo].peiceModel);
        }

        boardState[rowTo, colTo] = temp;
        temp.lastMove = new Move(rowFrom, colFrom, rowTo, colTo);
        lastMove = temp.lastMove;
    }

    public bool inCheck(COLOR color)
    {
        bool result = false;
        King king = getKing(color);
        if (king != null)
        {
            Vector2 kingPosition = king.peicePosition;

            List<Vector2> moves = getControlledSquares(color == COLOR.WHITE ? COLOR.BLACK : COLOR.WHITE);

            foreach (Vector2 move in moves)
            {
                if (move == kingPosition)
                {
                    result = true;
                    break;
                }
            }
        }

        return result;
    }

    public bool isCheckmate(COLOR color)
    {
        //I need to go through every peice and check to see if they have any moves that remove the check. 
        bool result = true;

        if (inCheck(color))
        {
            //List<Move> oppositeMoves = getAllMoves(color == COLOR.WHITE ? COLOR.BLACK : COLOR.WHITE);
            List<Move> moves = getAllMoves(color);

            foreach (Move move in moves)
            {
                GameState testState = copyBoardState();
                testState.movePeice(move.fromRow, move.fromCol, move.toRow, move.toCol);
                testState.boardState[move.toRow, move.toCol].peicePosition = new Vector2(move.toRow, move.toCol);

                if (!testState.inCheck(color))
                {
                    result = false;
                    break;
                }
            }

        } else
        {
            result = false;
        }

        return result;
    }

    public List<Vector2> getControlledSquares(COLOR color)
    {
        List<Vector2> result = new List<Vector2>();

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (boardState[r, c] != null && boardState[r, c].peiceColor == color)
                {
                    List<Vector2> squares = boardState[r, c].getControlledSquares(this);

                    foreach (Vector2 s in squares)
                    {
                        result.Add(s);
                    }
                }
            }
        }

        return result;
    }

    public King getKing(COLOR color)
    {
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                ChessPiece piece = boardState[r, c];
                if (piece != null && piece.peiceColor == color && piece.peiceType == TYPE.KING)
                {
                    return (King)piece;
                }
            }
        }

        return null;
    }

    public void removePiece(Vector2 position)
    {
        MainGame.Destroy(boardState[(int)position.x, (int)position.y].peiceModel);
        boardState[(int)position.x, (int)position.y] = null;
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

    public GameState copyBoardState()
    {
        GameState result = new GameState();
        result.lastMove = this.lastMove;
        result.turn = this.turn;
        result.boardState = new ChessPiece[8, 8];

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (this.boardState[r, c] != null)
                {
                    COLOR color = this.boardState[r, c].peiceColor;
                    ChessPiece toAdd = null;

                    switch (this.boardState[r, c].peiceType)
                    {
                        case (TYPE.PAWN):
                            toAdd = new Pawn(color);
                            break;
                        case (TYPE.BISHOP):
                            toAdd = new Bishop(color);
                            break;
                        case (TYPE.KNIGHT):
                            toAdd = new Knight(color);
                            break;
                        case (TYPE.ROOK):
                            toAdd = new Rook(color);
                            break;
                        case (TYPE.KING):
                            toAdd = new King(color);
                            break;
                        case (TYPE.QUEEN):
                            toAdd = new Queen(color);
                            break;
                    }

                    toAdd.peicePosition = new Vector2(r, c);
                    toAdd.lastMove = this.boardState[r, c].lastMove;
                    result.boardState[r, c] = toAdd;
                }
            }
        }

        return result;
    }
}
