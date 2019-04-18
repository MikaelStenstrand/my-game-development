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

    [SerializeField] MainMenu mainMenu;

    [HideInInspector]
    public PlayerAnimation playerAnimation;
    [HideInInspector]
    public PlayerController playerController;

    void Start() {
        if (playerGO == null) {
            Debug.Log("No player object");
            return;
        }
        playerAnimation = playerGO.GetComponent<PlayerAnimation>();
        playerController = playerGO.GetComponent<PlayerController>();
    }
    private void Update() {
        CheckInputActions();
    }

    void CheckInputActions() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            mainMenu.ToggleInGameMenu();
        }
    }
}
