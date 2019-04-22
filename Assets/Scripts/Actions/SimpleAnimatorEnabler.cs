using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimatorEnabler : MonoBehaviour {

    [SerializeField] BoolReference isEnabled;
    [SerializeField] Animator animator = null;

    private bool currentState;

    void Start() {
        if (animator == null)
            animator = gameObject.GetComponent<Animator>();
        currentState = animator.enabled;
    }

    void Update() {
        if (currentState != isEnabled.Value && animator != null) {
            animator.enabled = isEnabled.Value;
            currentState = isEnabled.Value;
        }
    }
}
