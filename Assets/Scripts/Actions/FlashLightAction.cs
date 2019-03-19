using UnityEngine;

public class FlashLightAction : MonoBehaviour {

    [SerializeField] private GameObject flashLight;

    public void SwitchLightState() {
        bool state = flashLight.activeSelf;
        flashLight.SetActive(!state);
    }
}
