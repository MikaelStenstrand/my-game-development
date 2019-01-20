using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour	{
    
    #region Singelton
    public static CameraManager instance;

    void Awake() {
        if(instance == null)
            instance = this;
        else    {
            Debug.LogWarning("More than one instance of CameraManager exists!");
            return;
        }
    }
    #endregion Singelton

    Camera[] allCameras;

    void Start() {
        allCameras = gameObject.GetComponentsInChildren<Camera>();
        DisableAllCameras();
        allCameras[0].enabled = true;
    }

    public void ChangeCamera(Camera camera) {
        if (camera == null)
            return;
        if (camera.enabled)
            return;

        Debug.Log("changing camera to " + camera.name);
        DisableAllCameras();
        camera.enabled = true;
    }
    public void ChangeCamera(string cameraName) {
        if(ValidateCameraName(cameraName))  {
            foreach(Camera camera in allCameras)   {
                if(camera.name == cameraName)  
                    camera.enabled = true;
                else
                    camera.enabled = false;
            }
        }
    }

    bool ValidateCameraName(string cameraName)   {
        foreach(Camera camera in allCameras)    {
            Debug.Log(camera.name);
            if(camera.name == cameraName)
                return true;
        }
        Debug.Log("cannot find camera with name: " + cameraName);
        return false;
    }
    void DisableAllCameras()    {
        foreach(Camera camera in allCameras)    {
            camera.enabled = false;
        }
    }
}
