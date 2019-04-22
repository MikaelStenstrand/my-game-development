using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGOEnabler : MonoBehaviour	{

    [SerializeField] BoolReference isEnabled;
    [SerializeField] private GameObject gameObjectToEnableDisable = null;

    [Tooltip("Invert the IsEnabled value")]
    [SerializeField] bool isInverted = false;

    private bool currentState;

    private void Start() {
        currentState = gameObjectToEnableDisable.activeSelf;
    }

    private void Update() {
        bool stateToSet = isInverted ? !isEnabled.Value : isEnabled.Value;
        if (currentState != stateToSet && gameObjectToEnableDisable != null) {
            gameObjectToEnableDisable.SetActive(stateToSet);
            currentState = stateToSet;
        }
    }
}
