using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSoundPlayer : MonoBehaviour	{


    [SerializeField] Sound sound;

    [Range(0.0f, 1.0f)]
    [SerializeField] float soundVolume = 0.2f;

    private AudioSource audioSource;

    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound() {
        audioSource.PlayOneShot(sound.audioClip, soundVolume);
    }


}
