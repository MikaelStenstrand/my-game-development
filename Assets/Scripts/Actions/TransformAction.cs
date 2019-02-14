using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAction : ActionLogic	{

    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    [Tooltip("Make changes in relation to the target transform.")]
    bool relatedChanges;

    [SerializeField]
    float transitionSpeed = 1.0f;

    [SerializeField]
    Vector3 newPosition;
    [SerializeField]
    Vector3 newRotation;
    [SerializeField]
    Vector3 newScale;


    public override void DoAction() {
        Debug.Log("Do Transform action");

        Vector3 positionChange = (relatedChanges) ? targetTransform.localPosition + newPosition : newPosition;
        Vector3 rotationChange = (relatedChanges) ? targetTransform.localEulerAngles + newRotation : newRotation;
        Vector3 scaleChange = (relatedChanges) ? targetTransform.localScale + newScale : newScale;
        StartCoroutine(SmoothTransform(targetTransform, positionChange, rotationChange, scaleChange, 1 / transitionSpeed));
    }

    public override void FailedToDoAction() {
        Debug.Log("failed to do transform action");
    }


    IEnumerator SmoothTransform(Transform target, Vector3 position, Vector3 rotation, Vector3 scale, float time) {
        float elapsedTime = 0f;
        Vector3 startingPosition = target.localPosition;
        Vector3 startingRotation = target.localEulerAngles;
        Vector3 startingScale = target.localScale;

        while (elapsedTime < time) {
            target.localPosition = Vector3.Lerp(startingPosition, position, (elapsedTime / time));
            target.localEulerAngles = Vector3.Lerp(startingRotation, rotation, (elapsedTime / time));
            target.localScale = Vector3.Lerp(startingScale, scale, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
           yield return new WaitForSeconds(.05f);
        }
    }


}
