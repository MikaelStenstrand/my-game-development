using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour	{
    
    public static GameManager instance; 

    void Awake() {
        if (instance == null)   {
            instance = this;
        } else  {
            Debug.LogWarning("More than one instance of GameManager exists!");
            return;
        }
    }

    // public GameObject hudGO;

    // HUD hud;

    void Start() {
        // hud = hudGO.GetComponent<HUD>();
    }

    void Update()
    {
        
    }


    // public HUD GetHUD() {
        // return hud;
    // }


}
