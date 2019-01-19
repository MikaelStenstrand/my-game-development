using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour	{

    public Sound[] sounds;

    void Awake() {
        foreach(Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    void Start() {
        foreach(Sound sound in sounds) {
            if(sound.playOnStart) {
                Play(sound.name);
            }
        }
    }

    public void Play(string name) {
        Sound soundToPlay = Array.Find(sounds, (sound) => sound.name == name);
        if (soundToPlay == null) {
            Debug.LogWarning("AudioManager:Play: trying to play sound that does not exist: " + name);
            return;
        }
        soundToPlay.source.Play();
    }
}
