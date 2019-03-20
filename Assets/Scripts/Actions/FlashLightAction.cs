using UnityEngine;

public class FlashLightAction : MonoBehaviour {

    [SerializeField] private GameObject flashlight;
    [SerializeField] private Sound soundEffect;
    [SerializeField] private float soundVolume = 0.2f;

    private EquipmentManager equipmentManager;
    private AudioSource audioSource;


    private void Start() {
        equipmentManager = EquipmentManager.instance;
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void SwitchLightState() {
        if (equipmentManager.isEquiped(gameObject)) {
            bool state = flashlight.activeSelf;
            flashlight.SetActive(!state);
            this.PlaySwitchLightSound();
        }
    }

    private void PlaySwitchLightSound() {
        audioSource.PlayOneShot(soundEffect.audioClip, soundVolume);
    }
}
