using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour	{
    
    #region Singelton
    public static GameManager instance; 

    void Awake() {
        if (instance == null)   {
            instance = this;
        } else  {
            Debug.LogWarning("More than one instance of GameManager exists!");
            return;
        }
    }
    #endregion Singelton

    public GameObject playerGO;

    [HideInInspector]
    public Character_Animations playerAnimation;
    [HideInInspector]
    public PlayerController playerController;

    void Start() {
        if (playerGO == null) {
            Debug.Log("No player object");
            return;
        }
        playerAnimation = playerGO.GetComponent<Character_Animations>();
        playerController = playerGO.GetComponent<PlayerController>();
    }
}
