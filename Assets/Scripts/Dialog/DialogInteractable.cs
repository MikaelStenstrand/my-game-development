using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DialogInteractable : Interactable	{

    [SerializeField] bool autoStart = false;
    private AudioSource audioSource;
    private VIDE_Assign dialog;

    public override bool Interact() {
        if (dialog == null || audioSource == null)  {
            Debug.LogWarning("Cannot start dialog");
            return false;
        }
        
        DialogManager.instance.StartDialog(dialog, audioSource);
        base.WasInteracted();
        return true;
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
        dialog = GetComponent<VIDE_Assign>();

        if (autoStart) {
            Invoke("Interact", 2);
        }
    }
}
