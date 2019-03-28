using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceArea : MonoBehaviour	{

    [SerializeField] BoolReference fanState;
    [SerializeField] float forceEffect = 1;
    Rigidbody targetedRigidbody = null;
    CharacterController targetedCharacterController = null;
    Vector3 impact = Vector3.zero;

    private void FixedUpdate() {
        if (fanState.Value) {
            if (targetedRigidbody != null) {
                AddForce(targetedRigidbody);
            }
            if (impact.magnitude > 0.2F && targetedCharacterController != null)
                targetedCharacterController.Move(impact * Time.deltaTime);

            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (targetedRigidbody == null) {
            targetedRigidbody = other.attachedRigidbody;
            targetedCharacterController = other.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other) {
        targetedRigidbody = null;
        targetedCharacterController = null;
    }


    private void AddForce(Rigidbody rigidbody) {
        rigidbody.AddForce(Vector3.forward * Time.deltaTime * forceEffect);
        if (targetedCharacterController != null)
            AddForce(targetedCharacterController);
    }

    private void AddForce(CharacterController characterController) {
        if (characterController != null) {
            Vector3 dir = Vector3.forward;
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y;
            impact += dir.normalized * forceEffect;
        }
    }

}
