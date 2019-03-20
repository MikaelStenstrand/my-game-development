using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventTrigger : MonoBehaviour	{

    [SerializeField] private GameEvent gameEvent;

    public void TriggerEvent() {
        gameEvent.Raise();
    }


}
