using Character;
using TMPro;
using UnityEngine;

public class PropertyValueUI : MonoBehaviour
{
    private FindPawnPropertySO so;
    private IPawnReference pawnReference;
    private TextMeshProUGUI tmp;

    public void Refresh()
    {
        PawnEntity pawn = pawnReference.CurrentPawn;
        so.pawn = pawn;
        CharacterProperty property = so.FindProperty();
        if (Mathf.Abs(property.CurrentValue) >= 1)
            tmp.text = property.IntValue.ToString();
        else
            tmp.text = property.CurrentValue.ToString("P0");
    }

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        string propertyName = transform.parent.GetComponent<TextMeshProUGUI>().text;
        so = PawnPropertyUtility.GetProperty(propertyName);
        pawnReference = GetComponentInParent<IPawnReference>();
        pawnReference.OnRefresh += Refresh;
    }
}
