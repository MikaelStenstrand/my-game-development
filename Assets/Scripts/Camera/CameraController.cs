using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour	{
    
    [Header("Features")]
    public bool followPlayer;
    
    [Header("References")]
    public Transform playerTransform;

    void Start() {
        
    }

    void Update() {
        if (followPlayer)   {
            followPlayerActions();
        }
    }

    void followPlayerActions()   {
        if (playerTransform != null)
            transform.LookAt(playerTransform);
    }



}
