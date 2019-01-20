using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour	{
    
    void Start() {
        
    }

    void Update()
    {
        
    }

    public virtual bool Interact()   {
        Debug.Log("Interactable is interacting, and removing itself");
        Destroy(gameObject);
        return true;
    }

}
