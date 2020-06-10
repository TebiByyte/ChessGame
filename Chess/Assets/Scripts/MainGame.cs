using Assets.Scripts.Peices;
using System;
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
    public Material SelectedMaterial;

    GameState state;
    public Camera camera;
    private ChessPiece selectedPeice;

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
        { 2, 3, 4, 5, 6, 4, 3, 2 },
        { 1, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 1, 1, 1, 1 },
        { 2, 3, 4, 5, 6, 4, 3, 2 }
    };// Bottom rows are white peices

    //TODO rewrite to include black and white peices in initial board layout. 


    void InitializeBoard()
    {
        state = new GameState();
        state.boardState = new ChessPiece[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                COLOR color = i <= 4 ? COLOR.BLACK : COLOR.WHITE;//fix this

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
        MeshCollider collider = prefab.AddComponent<MeshCollider>();

        collider.sharedMesh = prefab.GetComponent<MeshFilter>().sharedMesh;

        return prefab;
    }

    Vector3 getPosition(Vector2 boardPosition)
    {
        return new Vector3(2 * (boardPosition.y - 4) + 1, 0, 2 * (boardPosition.x - 4) + 1);
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
                    GameObject peiceModel = createPeice(peice.peiceType, peice.peiceColor);
                    //Move the peice to the correct location
                    peiceModel.transform.Translate(getPosition(new Vector2(r, c)));
                    peiceModel.transform.Rotate(-90, peice.peiceRotation + (peice.peiceColor == COLOR.BLACK ? 180 : 0), 0);
                    peiceModel.transform.localScale = new Vector3(200, 200, 200);
                    peice.peiceModel = peiceModel;
                    peiceModel.name = r + " " + c;
                    peice.peicePosition = new Vector2(r, c);
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string[] coords = hit.transform.name.Split(' ');
                int row = Int32.Parse(coords[0]);
                int col = Int32.Parse(coords[1]);

                selectedPeice = state.boardState[row, col];

                List<Vector2> peiceMoves = selectedPeice.getMoves(state);
                List<GameObject> peicePlaceHolders = new List<GameObject>();

                foreach (Vector2 peiceChoice in peiceMoves)
                {
                    GameObject peice = createPeice(selectedPeice.peiceType, selectedPeice.peiceColor);
                    peicePlaceHolders.Add(peice);

                    peice.transform.position = getPosition(peiceChoice);
                    peice.transform.Rotate(-90, selectedPeice.peiceRotation + (selectedPeice.peiceColor == COLOR.BLACK ? 180 : 0), 0);
                    peice.transform.localScale = new Vector3(200, 200, 200);
                    peice.GetComponent<Renderer>().material = SelectedMaterial;
                }
            }
        }
    }
}
