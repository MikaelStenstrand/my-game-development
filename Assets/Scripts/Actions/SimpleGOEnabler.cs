using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGOEnabler : MonoBehaviour	{

    [SerializeField] BoolReference isEnabled;
    [SerializeField] private GameObject gameObjectToEnableDisable = null;

    private bool currentState;

    private void Start() {
        currentState = gameObjectToEnableDisable.activeSelf;
    }

    private void Update() {
        if (currentState != isEnabled.Value && gameObjectToEnableDisable != null) {
            gameObjectToEnableDisable.SetActive(isEnabled.Value);
            currentState = isEnabled.Value;
        }
    }
}
