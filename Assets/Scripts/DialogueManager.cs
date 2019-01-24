using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DialogueManager : MonoBehaviour  {

    public Character_Animations playerAnimation;
    public GameObject containerNPC;
    public GameObject containerPlayer;
    public Text textNPC;
    public Text[] textChoises;

    private AudioSource audioSource;
    private VIDE_Assign dialog;

    #region Singelton
    public static DialogueManager instance;

    void Awake() {
        if (instance == null)   {
            instance = this;
        } else  {
            Debug.LogWarning("More than one instance of GameManager exists!");
            return;
        }
    }
    #endregion Singelton

    void Start() {
        containerNPC.SetActive(false);
        containerPlayer.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Return))   {
            if(!VD.isActive)    {
                BeginDialouge();
            } else  {
                VD.Next();
            }
        }
    }


    public void StartDialog(VIDE_Assign dialog, AudioSource audioSource) {
        this.dialog = dialog;
        this.audioSource = audioSource;
        BeginDialouge();
    }
    public void setAudioSource(AudioSource audioSource) {
        this.audioSource = audioSource;
    }
    public void SetPlayerChoice(int choice) {
        VD.nodeData.commentIndex = choice;
        if(Input.GetMouseButtonUp(0))
            VD.Next();
    }

    void BeginDialouge()    {
        playerAnimation.isMovementEnabled = false;  // TODO: stop character first

        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += EndDialogue;
        VD.BeginDialogue(dialog);
        //VD.BeginDialogue(GetComponent<VIDE_Assign>());
    }

    void UpdateUI(VD.NodeData data) {
        containerNPC.SetActive(false);
        containerPlayer.SetActive(false);

        if (data.isPlayer)  {
            containerPlayer.SetActive(true);
            for (int i = 0; i < textChoises.Length; i++)    {
                if (i < data.comments.Length)   {
                    textChoises[i].transform.parent.gameObject.SetActive(true);
                    textChoises[i].text = data.comments[i];
                } else  {
                    textChoises[i].transform.parent.gameObject.SetActive(false);
                }
            }
            textChoises[0].transform.parent.GetComponent<Button>().Select();
        } else  {
            containerNPC.SetActive(true);
            textNPC.text = data.comments[data.commentIndex];
            if (data.audios[data.commentIndex] != null) {
                if (audioSource != null)    {
                    audioSource.clip = data.audios[data.commentIndex];
                    audioSource.Play();
                }
            }
        }
    }

    void EndDialogue(VD.NodeData data)  {
        playerAnimation.isMovementEnabled = true;
        containerNPC.SetActive(false);
        containerPlayer.SetActive(false);

        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= EndDialogue;
        VD.EndDialogue();
    }

    void OnDisable()    {
        if (containerNPC != null)
            EndDialogue(null);
    }
}
