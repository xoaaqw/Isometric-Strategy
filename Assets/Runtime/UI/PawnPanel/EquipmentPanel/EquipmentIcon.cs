using MyTool;
using System;

public class EquipmentIcon : IconUI
{
    private PawnPanel pawnPanel;
    [NonSerialized]
    public EquipmentSlot slot;
    
    public int index;

    protected override void ExtractKeyWords()
    {
        base.ExtractKeyWords();
        if (slot.equipment != null)
            slot.equipment.ExtractKeyWords(keyWordList);
    }

    public void Refresh()
    {
        PawnEntity pawn = pawnPanel.SelectedPawn;
        image.sprite = null;   //TODO:����λͼ��
        if (index < pawn.EquipmentManager.slots.Count)
        {
            canvasGroup.Visible = true;
            slot = pawn.EquipmentManager.slots[index];
            if (slot != null)
            {
                if (slot.equipment != null)
                {
                    info = slot.equipment.name.Bold() + "\n" + slot.equipment.Description;
                    image.sprite = slot.equipment.icon;
                }
                else
                    info = $"��{EquipmentSlot.SlotTypeName(slot.slotType)}��λ";
            }
        }
        else
        {
            canvasGroup.Visible = false;
            info = string.Empty;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        pawnPanel = GetComponentInParent<PawnPanel>();
        pawnPanel.RefreshAll += Refresh;
    }
}
