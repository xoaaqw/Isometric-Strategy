using EditorExtend.GridEditor;
using System.Collections.Generic;
using UnityEngine;

public class IsometricGridManager : IsometricGridManagerBase
{
    private readonly Dictionary<Vector2Int, GridPawn> pawnDict = new();
    public Dictionary<Vector2Int,GridPawn> PawnDict => pawnDict;

    public static IsometricGridManager FindInstance()
    {
        return GameObject.Find("Grid").GetComponent<IsometricGridManager>();
    }

    public override void Clear()
    {
        base.Clear();
        pawnDict.Clear();
    }

    public override void AddObject(GridObject gridObject)
    {
        base.AddObject(gridObject);
        if (gridObject is GridPawn pawn)
        {
            pawnDict.Add((Vector2Int)gridObject.CellPosition, pawn);
        }
    }

    public override GridObject RemoveObject(Vector3Int cellPosition)
    {
        GridObject gridObject = base.RemoveObject(cellPosition);
        if(gridObject is GridPawn)
        {
            pawnDict.Remove((Vector2Int)cellPosition);
        }
        return gridObject;
    }
}