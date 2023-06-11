using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfSlotManager : SlotManager
{
    public bool targetIsTrue;


    protected override void Awake()
    {

        foreach (Slot slot in slots)
        {
            slot.SlotInit(this);
        }

        canvas.CanvasInit();
        canvas.IfStatmentStart(targetIsTrue);
        exit.SetActive(false);
    }


    protected override void SlotInput()
    {
        if(slots[0].Box.boxType == Box.BoxType.Function || slots[2].Box.boxType == Box.BoxType.Function)
        {
            //invalid
            return;
        }


        if(slots[1].Box.functionType == Box.FunctionType.largerThan)
        {
            float numOne = slots[0].Box.boxNum;
            float numTwo = slots[2].Box.boxNum;

            if (numOne > numTwo)
            {
                //true
                if(targetIsTrue)
                {
                    canvas.IfStatmentOutput(targetIsTrue, true);
                    canvas.PlayerWin();
                    exit.SetActive(true);
                }
                else
                {
                    canvas.IfStatmentOutput(targetIsTrue, true);
                }
            }
            else
            {
                //false
                if (!targetIsTrue)
                {
                    canvas.IfStatmentOutput(targetIsTrue, false);
                    canvas.PlayerWin();
                    exit.SetActive(true);

                }
                else
                {
                    canvas.IfStatmentOutput(targetIsTrue, false);
                }
            }
        }
        else if(slots[1].Box.functionType == Box.FunctionType.smallerThan)
        {
            float numOne = slots[0].Box.boxNum;
            float numTwo = slots[2].Box.boxNum;

            if (numOne < numTwo)
            {
                //true
                if (targetIsTrue)
                {
                    canvas.IfStatmentOutput(targetIsTrue, true);
                    canvas.PlayerWin();
                    exit.SetActive(true);

                }
                else
                {
                    canvas.IfStatmentOutput(targetIsTrue, true);
                }
            }
            else
            {
                //false
                if (!targetIsTrue)
                {
                    canvas.IfStatmentOutput(targetIsTrue, false);
                    canvas.PlayerWin();
                    exit.SetActive(true);

                }
                else
                {
                    canvas.IfStatmentOutput(targetIsTrue, false);
                }
            }
        }
        else if(slots[1].Box.functionType == Box.FunctionType.equal)
        {
            float numOne = slots[0].Box.boxNum;
            float numTwo = slots[2].Box.boxNum;

            if (numOne == numTwo)
            {
                //true
                if (targetIsTrue)
                {
                    canvas.IfStatmentOutput(targetIsTrue, true);
                    canvas.PlayerWin();
                    exit.SetActive(true);

                }
                else
                {
                    canvas.IfStatmentOutput(targetIsTrue, true);
                }
            }
            else
            {
                //false
                if (!targetIsTrue)
                {
                    canvas.IfStatmentOutput(targetIsTrue, false);
                    canvas.PlayerWin();
                    exit.SetActive(true);

                }
                else
                {
                    canvas.IfStatmentOutput(targetIsTrue, false);
                }
            }
        }
    }
}

