using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSlot : Slot
{
    public Box.VariableType variableToMatch;
    protected List<Box.VariableType> variables = new List<Box.VariableType>();

    public override void OnBoxDropped(Box box)
    {
        this.box = box;
        slotManager.OnBoxDropped();

        box.gameObject.transform.parent = transform;

        variables.Add(box.variableType);
    }

    public override void OnBoxPickedUp(Box box)
    {
        slotManager.OnBoxPickedUp();
        variables.Remove(box.variableType);
    }

    public bool SlotVariablesCorrect()
    {
        bool hasWrongVariable = false;

        foreach (Box.VariableType variable in variables)
        {
            if(variable != variableToMatch)
            {
                hasWrongVariable = true;
            }

        }

        if(hasWrongVariable)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
