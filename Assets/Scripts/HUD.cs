using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour	{
    
    public GameObject messagePanel;

    void Start() {
        
    }

    void Update()
    {
        
    }

    public void OpenMessagePanel(string text)  {
        messagePanel.SetActive(true);
    }

    public void CloseMessagePanel() {
        messagePanel.SetActive(false);
    }
}
