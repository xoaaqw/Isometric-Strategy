using EditorExtend;
using UnityEditor;

[CustomEditor(typeof(PawnClass))]
public class PawnClassEditor : PawnModifierSOEditor
{
    [AutoProperty]
    public SerializedProperty supportAbility, offenseAbility, bestSupprtDistance, bestOffenseDistance, terrainAbility;

    protected override void MyOnInspectorGUI()
    {
        base.MyOnInspectorGUI();
        supportAbility.FloatField("协助能力");
        offenseAbility.FloatField("威胁能力");
        terrainAbility.FloatField("地形利用能力");
        bestSupprtDistance.IntField("最佳协助距离");
        bestOffenseDistance.IntField("最佳威胁距离");
    }
}