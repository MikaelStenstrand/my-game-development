using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour	{

    public HUD hud;
    public DialogManager dialogueManager;
    public GameEvent useEquippedToolEvent;
    [SerializeField] float activeHeadLookControlEffect = 1;
    [SerializeField] float headLookTransitionFade = 0.01f;

    HeadLookController headLookCtrl;
    Interactable currentInteractableFocus;

    private void Start() {
        headLookCtrl = gameObject.GetComponent<HeadLookController>();
    }

    void Update() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        CheckInputActions();

        if(currentInteractableFocus != null && currentInteractableFocus.isActive)   {
            LookAtPosition(currentInteractableFocus.transform.position);

            if (currentInteractableFocus.IsInteractable(gameObject.transform)) {
                hud.OpenMessagePanel("");
            }   else    {
                hud.CloseMessagePanel();
            }
        } else {
            StopLookAtPosition();
        }
    }

    void OnTriggerEnter(Collider other) {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null) {
            SetFocus(interactable);
        }
    }

    void OnTriggerExit(Collider other) {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)   {
            RemoveFocus(interactable);
        }
    }

    void InteractWithFocus() {
        if (currentInteractableFocus != null && currentInteractableFocus.isActive)  {
            if(currentInteractableFocus.IsInteractable(gameObject.transform))    {
                bool wasInteracted = currentInteractableFocus.Interact();
                if (wasInteracted) {
                    RemoveFocus(currentInteractableFocus);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)    {
        if (newFocus == null)
            return;

        if (newFocus != currentInteractableFocus)  {
            if(newFocus.isActive)   {
                if (currentInteractableFocus != null)
                    RemoveFocus(currentInteractableFocus);

                LookAtPosition(newFocus.transform.position);
                currentInteractableFocus = newFocus;
                // call functions on Interactable if needed
            }
        }
    }

    void RemoveFocus(Interactable interactableToBeRemoved)  {
        // call functions on Interactable if needed
        if (currentInteractableFocus == null || interactableToBeRemoved != currentInteractableFocus) {
            return;
        }
        StopLookAtPosition();
        currentInteractableFocus = null;
        hud.CloseMessagePanel();
    }

    void LookAtPosition(Vector3 targetPosition)  {
        headLookCtrl.target = targetPosition;
        if (currentInteractableFocus == null) {
            StartCoroutine("SmoothStartHeadMovement");
        }
    }

    void StopLookAtPosition() {
        headLookCtrl.target = Vector3.zero;
        if (currentInteractableFocus != null) {
            StartCoroutine("SmoothStopHeadMovement");
        }
    }

    IEnumerator SmoothStopHeadMovement() {
        for (float i = activeHeadLookControlEffect; i >= 0; i -= headLookTransitionFade) {
            headLookCtrl.effect = i;
            yield return null;
        }
    }

    IEnumerator SmoothStartHeadMovement() {
        for (float i = 0; i <= activeHeadLookControlEffect; i += headLookTransitionFade) {
            headLookCtrl.effect = i;
            yield return null;
        }
    }

    void CheckInputActions()  {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) {
            if (dialogueManager.IsActiveDialog()) {
                dialogueManager.NextInDialog();
            } else {
                InteractWithFocus();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))  {
            useEquippedToolEvent.Raise();
        }
    }

}
