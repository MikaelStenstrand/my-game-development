using UnityEngine;

public class FlashLightAction : MonoBehaviour {

    [SerializeField] private GameObject flashlight;

    private EquipmentManager equipmentManager;
    private AudioSource audioSource;


    private void Start() {
        equipmentManager = EquipmentManager.instance;
    }


    public void SwitchLightState() {
        if (equipmentManager.isEquiped(gameObject)) {
            bool state = flashlight.activeSelf;
            flashlight.SetActive(!state);
        }
    }
}
