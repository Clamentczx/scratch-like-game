using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSlotManager : SlotManager
{
    public int boxCount;

    protected override void Awake()
    {
        foreach (Slot slot in slots)
        {
            slot.SlotInit(this);
        }

        canvas.CanvasInit();
        canvas.VariableType();
        exit.SetActive(false);
    }

    public override void OnBoxDropped()
    {
        boxOnSlotCount++;

        if (boxOnSlotCount >= boxCount)
        {
            bool correct = true;

            foreach (Slot slot in slots)
            {
                VariableSlot variableSlot = slot as VariableSlot;

                if(!variableSlot.SlotVariablesCorrect())
                {
                    correct = false;
                }

            }

            if(correct)
            {
                print("stage complete");
                canvas.PlayerWin();
                exit.SetActive(true);
            }
            else
            {
                print("wrong");
            }
        }
    }
}
