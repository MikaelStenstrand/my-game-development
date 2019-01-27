using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour	{

    public HUD hud;

    Interactable focus;


    void Update()
    {
        InputActions();

        if(focus != null && focus.isActive)   {
            FollowFocusObject();

            if (focus.IsInteractable(gameObject.transform)) {
                hud.OpenMessagePanel("");
            }   else    {
                hud.CloseMessagePanel();
            }
        }

    }

    void OnTriggerEnter(Collider other) {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)   {
            SetFocus(interactable);
        }
    }

    void OnTriggerExit(Collider other) {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)   {
            RemoveFocus();
        }
    }

    void InteractWithFocus() {
        if (focus != null && focus.isActive)  {
            if(focus.IsInteractable(gameObject.transform))    {
                focus.Interact();
                RemoveFocus();
            }

        }
    }

    void SetFocus(Interactable newFocus)    {
        if (newFocus != focus)  {
            if (focus != null)
                RemoveFocus();

            if(newFocus != null && newFocus.isActive)   {
                focus = newFocus;
                // call functions on Interactable if needed
            }
        }
    }

    void RemoveFocus()  {
        // call functions on Interactable if needed
        focus = null;
        hud.CloseMessagePanel();
    }
    void FollowFocusObject()  {
        // TODO: character to look at the focus object
    }

    void Test() {
    }

    void InputActions()  {
        if (Input.GetKeyDown(KeyCode.E)) {
            InteractWithFocus();
        }
        if (Input.GetKeyDown(KeyCode.T))  {
            Test();
        }
    }

}
