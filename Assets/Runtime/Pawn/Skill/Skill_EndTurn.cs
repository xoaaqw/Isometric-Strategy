using System.Collections.Generic;
using UnityEngine;

public class Skill_EndTurn : Skill
{
    public override void GetOptions(Vector2Int position, List<Vector2Int> ret)
    {
        base.GetOptions(position, ret);
        ret.Add(position);
    }

    public override void Mock(PawnEntity agent, Vector2Int target, IsometricGridManager igm, EffectUnit ret)
    {
        base.Mock(agent, target, igm, ret);
        ret.timeEffect.current += agent.Property.actionTime;
    }
}