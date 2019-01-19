using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour	{
    
    void Start() {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
    }

    void Interact() {
        FindObjectOfType<AudioManager>().Play("Violin");
        Debug.Log("interact");
    }
}
