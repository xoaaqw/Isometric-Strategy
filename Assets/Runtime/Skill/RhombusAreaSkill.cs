using EditorExtend.GridEditor;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "菱形范围技能", menuName = "技能/菱形范围技能", order = -1)]
public class RhombusAreaSkill : RangedSkill
{
    public int effectRange = 1;

    public override void MockArea(IsometricGridManager igm, Vector3Int position, Vector3Int target, List<Vector3Int> ret)
    {
        ret.Clear();
        List<Vector2Int> primitive = IsometricGridUtility.WithinProjectManhattanDistance(effectRange);
        primitive.Add(Vector2Int.zero);
        for (int i = 0; i < primitive.Count; i++)
        {
            Vector2Int xy = (Vector2Int)target + primitive[i];
            Vector3Int p = igm.AboveGroundPosition(xy);
            if (!LayerCheck(position, p))
                continue;
            if (igm.Contains(xy))
                ret.Add(p);
        }
    }

    protected override void DescribeArea(StringBuilder sb)
    {
        sb.Append("作用范围:");
        sb.Append(effectRange);
        sb.AppendLine();
    }
}
