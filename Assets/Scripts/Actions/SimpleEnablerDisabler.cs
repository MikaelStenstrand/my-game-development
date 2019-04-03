using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnablerDisabler : MonoBehaviour	{

    [SerializeField] BoolReference isEnabled;
    private bool currentState;
    private GameObject gameObjectToEnableDisable;

    private void Start() {
        gameObjectToEnableDisable = gameObject.transform.GetChild(0).gameObject;
        currentState = gameObjectToEnableDisable.activeSelf;
    }

    private void Update() {
        if (currentState != isEnabled.Value) {
            gameObjectToEnableDisable.SetActive(isEnabled.Value);
            currentState = isEnabled.Value;
        }
    }
}
