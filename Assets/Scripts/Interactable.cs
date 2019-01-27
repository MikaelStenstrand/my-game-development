using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour	{

    public float interactionRadius = 3f;
    public Transform interactionPoint;

    public bool supportMultipleInteractions = false;

    [HideInInspector]
    public bool isActive = true;

    public virtual void Interact()   {
        SetInactive();
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

    public void SetInactive()  {
        if (!supportMultipleInteractions)
            isActive = false;
    }

    void OnDrawGizmosSelected() {
        if (interactionPoint == null)
            interactionPoint = gameObject.transform;
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }



}
