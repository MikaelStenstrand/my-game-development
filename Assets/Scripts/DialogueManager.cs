using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour  {

    public Character_Animations playerAnimation;

    public GameObject containerNPC;
    public GameObject containerPlayer;

    public Text textNPC;
    public Text[] textChoises;

    // Start is called before the first frame update
    void Start() {
        containerNPC.SetActive(false);
        containerPlayer.SetActive(false);
    }


    public void SetPlayerChoice(int choice) {
        VD.nodeData.commentIndex = choice;
        if(Input.GetMouseButtonUp(0))
            VD.Next();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Return))   {
            if(!VD.isActive)    {
                BeginDialouge();
            } else  {
                VD.Next();
            }
        }
    }

    void BeginDialouge()    {
        playerAnimation.isMovementEnabled = false;

        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += EndDialogue;
        VD.BeginDialogue(GetComponent<VIDE_Assign>());
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
