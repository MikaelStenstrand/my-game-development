using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour	{

    public float interactionRadius = 3f;
    public Transform interactionPoint;

    public int timesOfInteraction = 1;

    [HideInInspector]
    public bool isActive = true;

    public virtual bool Interact()   {
        return false;
    }

    void Start() {
        if (interactionPoint == null)
            interactionPoint = gameObject.transform;
    }


    public bool IsInteractable(Transform playerTransform)    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, interactionPoint.position);
        if (distanceToPlayer <= interactionRadius)
            return true;

        return false;
    }

    public float getDistanceToPlayer(Transform playerTransform) {
        return Vector3.Distance(playerTransform.position, interactionPoint.position);
    }

    public void WasInteracted() {
        timesOfInteraction--;
        if (timesOfInteraction <= 0)
            isActive = false;
    }

    void OnDrawGizmosSelected() {
        if (interactionPoint == null)
            interactionPoint = gameObject.transform;
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }



}
