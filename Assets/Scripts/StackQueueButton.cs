using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackQueueButton : MonoBehaviour
{
    //protected QueueStackSlotManager manager;

    public InputMachine Machine;
    public bool isStack;

    //public void ButtonInit(QueueStackSlotManager manager)
    //{
    //    this.manager = manager;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isStack)
        {
            Machine.QueueButton();
        }
        else
        {
            Machine.StackButton();
        }
    }
}
