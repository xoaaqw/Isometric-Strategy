using Character;
using System.Collections.Generic;


public class EquipmentManager : CharacterComponentBase
{
    public List<EquipmentSlot> slots;

    private PlayerManager playerManager;
    private PawnEntity pawn;
    public bool CanChangeEquipment => !pawn.GameManager.inBattle && playerManager.Find(pawn.EntityName) != null;

    public EquipmentSlot this[ESlotType slot]
        => slots.Find(x => x.slotType == slot);

    public void Register(PawnEntity pawn)
    {
        this.pawn = pawn;
        foreach (EquipmentSlot slot in slots)
        {
            if (slot.equipment != null)
                slot.equipment.Register(pawn);
        }
    }

    public void Unregister(PawnEntity pawn)
    {
        this.pawn = pawn;
        foreach (EquipmentSlot slot in slots)
        {
            if (slot.equipment != null)
                slot.equipment.Unregister(pawn);
        }
    }

    public void ApplyAllParameter()
    {
        foreach (EquipmentSlot slot in slots)
        {
            if (slot.equipment != null)
                slot.equipment.ApplyParameter(pawn);
        }
    }

    /// <summary>
    /// 装上装备（返回被卸下的装备）
    /// </summary>
    public Equipment Equip(EquipmentSlot slot, Equipment equipment)
    {
        Equipment ret = null;
        if (slot.equipment != null)
        {
            ret = slot.equipment;
            slot.equipment.Unregister(pawn);
        }
        equipment.Register(pawn);
        slot.equipment = equipment;
        pawn.RefreshProperty();
        return ret;
    }

    /// <summary>
    /// 获取slotType类型的第一个装备槽
    /// </summary>
    public EquipmentSlot GetFirst(ESlotType slotType)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].slotType == slotType)
            {
                return slots[i];
            }
        }
        return null;
    }

    /// <summary>
    /// 获取slotType类型的第一个空余装备槽（若无空余则返回第一个装备槽）
    /// </summary>
    public EquipmentSlot GetFirstEmpty(ESlotType slotType)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].slotType == slotType && slots[i].equipment == null)
            {
                return slots[i];
            }
        }
        return GetFirst(slotType);
    }

    public Equipment Equip(Equipment equipment)
        => Equip(GetFirstEmpty(equipment.slotType), equipment);

    /// <summary>
    /// 卸下装备（返回被卸下的装备）
    /// </summary>
    public Equipment Unequip(EquipmentSlot slot)
    {
        if (slot.equipment != null)
        {
            Equipment ret = slot.equipment;
            slot.equipment.Unregister(pawn);
            slot.equipment = null;
            pawn.RefreshProperty();
            return ret;
        }
        return null;
    }

    public void GetAll(List<Equipment> ret)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].equipment != null)
                ret.Add(slots[i].equipment);
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].equipment != null)
                slots[i].equipment.Unregister(pawn);
            slots[i].equipment = null;
        }
        pawn.RefreshProperty();
    }

    protected override void Awake()
    {
        base.Awake();
        playerManager = PlayerManager.FindInstance();
    }

    public EquipmentManager()
    {
        slots = new()
        {
            new EquipmentSlot(ESlotType.Weapon),
            new EquipmentSlot(ESlotType.Armor),
            new EquipmentSlot(ESlotType.Jewelry),
            new EquipmentSlot(ESlotType.SkillBook),
            new EquipmentSlot(ESlotType.SkillBook),
            new EquipmentSlot(ESlotType.SkillBook),
        };
    }
}
