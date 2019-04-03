using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBoolVariableChanger : MonoBehaviour	{

    [SerializeField] private BoolReference boolReference;

    public void SwitchState() {
        Debug.Log("SwitchState");
        boolReference.Value = !boolReference.Value;
    }
}
