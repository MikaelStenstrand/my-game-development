using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenValveCharacterAction : MonoBehaviour	{

    [SerializeField] Sound hitSound;

    [Range(0.0f, 1.0f)]
    [SerializeField] float soundVolume = 0.2f;

    [SerializeField] BoolReference steamState;

    private Animator animator;
    private AudioSource audioSource;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void TriggerOpenValveAnimation() {
        animator.SetTrigger("OpenValve");
    }
    public void PlayOpenValveSound() {
        audioSource.PlayOneShot(hitSound.audioClip, soundVolume);
        steamState.Value = !steamState.Value;
    }

}
