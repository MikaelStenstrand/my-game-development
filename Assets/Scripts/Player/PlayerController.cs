using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour	{

    public HUD hud;
    public DialogManager dialogueManager;
    Interactable currentInteractableFocus;

    void Update() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        CheckInputActions();

        if(currentInteractableFocus != null && currentInteractableFocus.isActive)   {
            FollowFocusObject();

            if (currentInteractableFocus.IsInteractable(gameObject.transform)) {
                hud.OpenMessagePanel("");
            }   else    {
                hud.CloseMessagePanel();
            }
        }

    }

    void OnTriggerEnter(Collider other) {
        Interactable interactable = other.GetComponent<Interactable>();
        SetFocus(interactable);
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
        currentInteractableFocus = null;
        hud.CloseMessagePanel();
    }
    void FollowFocusObject()  {
        // TODO: character to look at the focus object
    }

    void Test() {
    }

    void CheckInputActions()  {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) {
            if (dialogueManager.IsActiveDialog()) {
                dialogueManager.NextInDialog();
            } else {
                InteractWithFocus();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))  {
            Test();
        }
    }

}
