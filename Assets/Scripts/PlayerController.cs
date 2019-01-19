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
            hud.OpenMessagePanel("text here");
            SetFocus(interactable);
        }
    }


    void OnTriggerExit(Collider other) {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)   {
            hud.CloseMessagePanel();
        }        
    }

    void Interact() {
        // FindObjectOfType<AudioManager>().Play("Violin");
        Debug.Log("interact");
        if (focus != null)  {
            focus.Interact();
        }
    }

    void SetFocus(Interactable newFocus)    {
        if (newFocus != focus)  {
            if (focus != null) 
                RemoveFocus();
            
            focus = newFocus;
            // follow focus
            // call functions on Interactable if needed
        }
    }

    void RemoveFocus()  {
        // call functions on Interactable if needed
        focus = null;
        // stop following focus
    }

}
