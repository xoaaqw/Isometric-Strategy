using Character;
using UnityEngine;

public class OffenceComponent : CharacterComponentBase
{
    public CharacterProperty strength;
    public CharacterProperty dexterity;
    public CharacterProperty intelligence;
    public CharacterProperty mind;

    /// <summary>
    /// ���㹥����������
    /// </summary>
    public int MockAttackPower(SkillPower skillPower)
    {
        int attack = Mathf.RoundToInt(skillPower.strMultiplier * strength.CurrentValue
            + skillPower.dexMultiplier * dexterity.CurrentValue
            + skillPower.intMultiplier * intelligence.CurrentValue
            + skillPower.mndMultiplier * mind.CurrentValue);
        return attack * skillPower.power;
    }

    public void RefreshProperty()
    {
        strength.Refresh();
        dexterity.Refresh();
        intelligence.Refresh();
        mind.Refresh();
    }
}
