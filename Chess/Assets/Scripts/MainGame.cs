using Assets.Scripts.Peices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public GameObject KnightPrefab;
    public GameObject PawnPrefab;
    public GameObject BishopPrefab;
    public GameObject RookPrefab;
    public GameObject KingPrefab;
    public GameObject QueenPrefab;
    public Material WhiteMat;
    public Material BlackMat;

    GameState state;

    //0 = no peice
    //1 = pawn
    //2 = rook
    //3 = knight
    //4 = bishop
    //5 = king
    //6 = queen

    //TODO make pieces different colors
    int[,] initialState = new int[,]
    {
        {2, 3, 4, 6, 5, 4, 3, 2 },
        {1, 1, 1, 1, 1, 1, 1, 1 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {1, 1, 1, 1, 1, 1, 1, 1 },
        {2, 3, 4, 6, 5, 4, 3, 2 }
    };


    void InitializeBoard()
    {
        state = new GameState();
        state.boardState = new ChessPiece[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                COLOR color = COLOR.WHITE;

                switch(initialState[i, j])
                {
                    case (1):
                        state.boardState[i, j] = new Pawn(color);
                        break;
                    case (2):
                        state.boardState[i, j] = new Rook(color);
                        break;
                    case (3):
                        state.boardState[i, j] = new Knight(color);
                        break;
                    case (4):
                        state.boardState[i, j] = new Bishop(color);
                        break;
                    case (5):
                        state.boardState[i, j] = new King(color);
                        break;
                    case (6):
                        state.boardState[i, j] = new Queen(color);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    GameObject createPeice(TYPE type, COLOR color)
    {
        GameObject prefab = null;

        switch (type)
        {
            case (TYPE.PAWN):
                prefab = Instantiate(PawnPrefab, Vector3.zero, Quaternion.identity);
                prefab.name = "Pawn";
                break;
            case (TYPE.ROOK):
                prefab = Instantiate(RookPrefab, Vector3.zero, Quaternion.identity);
                prefab.name = "Rook";
                break;
            case (TYPE.QUEEN):
                prefab = Instantiate(QueenPrefab, Vector3.zero, Quaternion.identity);
                prefab.name = "Queen";
                break;
            case (TYPE.KNIGHT):
                prefab = Instantiate(KnightPrefab, Vector3.zero, Quaternion.identity);
                prefab.name = "Knight";
                break;
            case (TYPE.BISHOP):
                prefab = Instantiate(BishopPrefab, Vector3.zero, Quaternion.identity);
                prefab.name = "Bishop";
                break;
            case (TYPE.KING):
                prefab = Instantiate(KingPrefab, Vector3.zero, Quaternion.identity);
                prefab.name = "King";
                break;
            default:
                break;
        }

        prefab.GetComponent<Renderer>().material = color == COLOR.BLACK ? BlackMat : WhiteMat;

        return prefab;
    }

    void DrawBoard()
    {
        for (int r = 0; r < 8; r++)
        {
            for(int c = 0; c < 8; c++)
            {
                ChessPiece peice = state.boardState[r, c];
                if (peice != null)
                {
                    GameObject peiceModel = createPeice(peice.peiceType, peice.pieceColor);
                    //Move the peice to the correct location
                    peiceModel.transform.Translate(new Vector3(2 * (c - 4) + 1, 0, 2 * (r - 4) + 1));
                    peiceModel.transform.Rotate(-90, 0, 0);
                    peiceModel.transform.localScale = new Vector3(200, 200, 200);
                }
                

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeBoard();
        DrawBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
