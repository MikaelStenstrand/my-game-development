﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DialogInteractable : Interactable	{
    
    private AudioSource audioSource;
    private VIDE_Assign dialog;

    public override void Interact() {
        base.Interact();
        if (dialog == null || audioSource == null)  {
            Debug.LogWarning("Cannot start dialog");
            return;
        }
        
        DialogManager.instance.StartDialog(dialog, audioSource);
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
        dialog = GetComponent<VIDE_Assign>();
    }
}
