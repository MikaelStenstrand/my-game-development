using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour	{
    
    public HUD hud;

    Interactable focus;



    void Start() {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Interact();
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

    void Interact() {
        // FindObjectOfType<AudioManager>().Play("Violin");
        bool didInteract = false;
        Debug.Log("interact");
        if (focus != null)  {
            didInteract = focus.Interact();
        }
        if (didInteract)    {
            RemoveFocus();
        }
    }

    void SetFocus(Interactable newFocus)    {
        if (newFocus != focus)  {
            if (focus != null) 
                RemoveFocus();
            
            focus = newFocus;
            hud.OpenMessagePanel("text here");
            // follow focus
            // call functions on Interactable if needed
        }
    }

    void RemoveFocus()  {
        // call functions on Interactable if needed
        focus = null;
        hud.CloseMessagePanel();
        // stop following focus
    }

}
