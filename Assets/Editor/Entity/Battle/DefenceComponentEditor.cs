using EditorExtend;
using MyTool;
using UnityEditor;

[CustomEditor(typeof(DefenceComponent))]
public class DefenceComponentEditor : AutoEditor
{
    [AutoProperty]
    public SerializedProperty maxHP, hp, damageMultiplier, resistance;
    public SerializedProperty list;

    protected override void OnEnable()
    {
        base.OnEnable();
        list = resistance.FindPropertyRelative(nameof(list));
        SerializedDictionaryHelper.FixEnum<EDamageType>(list);
    }

    protected override void MyOnInspectorGUI()
    {
        maxHP.PropertyField("�������");
        hp.IntField("��ǰ����");
        damageMultiplier.PropertyField("����ϵ��");
        list.PropertyField("����");
    }
}