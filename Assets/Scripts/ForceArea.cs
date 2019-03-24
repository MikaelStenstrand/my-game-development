using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceArea : MonoBehaviour	{

    [SerializeField] BoolReference fanState;
    [SerializeField] float forceEffect = 1;
    Rigidbody targetedRigidbody = null;

    private void FixedUpdate() {
        if (fanState.Value && targetedRigidbody != null) {
            AddForce(targetedRigidbody);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("ENTER");
        //if (other.tag == "Player") {
            if (targetedRigidbody == null)
                targetedRigidbody = other.attachedRigidbody;
        //}
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("EXIT");
        //if (other.tag == "Player") {
            targetedRigidbody = null;
        //}    
    }


    private void AddForce(Rigidbody rigidbody) {
        Debug.Log("FORCE");
        rigidbody.AddForce(- Vector3.forward * Time.deltaTime * forceEffect);
    }
}
