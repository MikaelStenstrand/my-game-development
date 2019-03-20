using UnityEngine;

public class FlashLightAction : MonoBehaviour {

    [SerializeField] private GameObject flashLight;
    private EquipmentManager equipmentManager;

    private void Start() {
        equipmentManager = EquipmentManager.instance;
    }


    public void SwitchLightState() {
        if (equipmentManager.isEquiped(gameObject)) {
            bool state = flashLight.activeSelf;
            flashLight.SetActive(!state);
        }
    }
}
