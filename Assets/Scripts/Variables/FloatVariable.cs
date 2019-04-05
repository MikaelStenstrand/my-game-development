using UnityEngine;

[CreateAssetMenu(fileName ="FloatVariable", menuName ="Variable/Float")]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver	{

    public float InitialValue;

    [System.NonSerialized]
    public float Value;

    public void OnAfterDeserialize() {
        Value = InitialValue;        
    }

    public void OnBeforeSerialize() { }
}
