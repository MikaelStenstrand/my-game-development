using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour	{
    
    [Tooltip("Camera to switch to")]
    public Camera camera;

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
            CameraManager.instance.ChangeCamera(this.camera);
    }
}
