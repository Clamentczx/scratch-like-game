using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMachineSlot : Slot
{
    public InputMachine inputMachine;


    public override void OnBoxDropped(Box box)
    {
        box.gameObject.transform.parent = transform;
        box.gameObject.transform.localPosition = Vector2.zero;
        inputMachine.TransferBox(box);
    }
}
