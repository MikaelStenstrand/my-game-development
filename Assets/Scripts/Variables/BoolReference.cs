using System.Collections;
using UnityEngine;

[System.Serializable]
public class BoolReference	{

    public bool useConstant = true;
    public bool constantValue;
    public BoolVariable variable;

    public bool Value {
        get {
            return useConstant ? constantValue : variable.Value;
        }
        set {
            if (useConstant)
                constantValue = value;
            else
                variable.Value = value;
        }
    }
}
