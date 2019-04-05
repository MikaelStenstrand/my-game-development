using UnityEngine;

[CreateAssetMenu(fileName ="Bool Variable", menuName ="Variable/Bool")]
public class BoolVariable : ScriptableObject, ISerializationCallbackReceiver	{

    public bool InitialValue;

    [System.NonSerialized]
    public bool Value;

    public void OnAfterDeserialize() {
        Value = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
