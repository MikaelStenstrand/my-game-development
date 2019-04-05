using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressChecker : MonoBehaviour	{

    [SerializeField] private BoolReference state;
    [SerializeField] private bool requiredState;

    [SerializeField] private GameEvent successEvent = null;
    [SerializeField] private GameEvent failEvent = null;

    private BoxCollider boxCollider;
    private bool onlyOnceSuccessTrigger = false;

    private void Start() {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (state.Value == requiredState) {
                if (successEvent != null && !onlyOnceSuccessTrigger) {
                    successEvent.Raise();
                    onlyOnceSuccessTrigger = true;
                }
            } else {
                if (failEvent != null)
                    failEvent.Raise();
            }
        }
    }


    public void EnablePassing() {
        boxCollider.isTrigger = true;
    }

    public void DisablePassing() {
        boxCollider.isTrigger = false;
    }



}