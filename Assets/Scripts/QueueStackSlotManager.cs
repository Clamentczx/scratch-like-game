using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueStackSlotManager : SlotManager
{
    List<float> numbersInSlot = new List<float>();
    public StackQueueButton stackButton, queueButton;
    protected bool isStack;

    public List<Box.FunctionType> functionList = new List<Box.FunctionType>();



    protected override void Awake()
    {
        base.Awake();

        //stackButton.ButtonInit(this);
        //queueButton.ButtonInit(this);
    }

    protected override void SlotInput()
    {
        print("input");

        if(boxOnSlotCount == slots.Count)
        {
            numbersInSlot.Clear();

            for (int i = 0; i < slots.Count; i++)
            {
                numbersInSlot.Add(slots[i].Box.boxNum);
            }

            if (isStack)
            {
                //stack so reverse
                numbersInSlot.Reverse();
            }

            float total = 0;
            bool firstTime = true;
            for (int z = 0; z < functionList.Count; z++)
            {
                if (firstTime)
                {
                    firstTime = false;

                    float numOne = numbersInSlot[z];
                    float numTwo = numbersInSlot[z + 1];

                    total = MathsFunction(numOne, numTwo, functionList[z]);
                }
                else
                {
                    float numOne = total;
                    float numTwo = numbersInSlot[z + 1];

                    //print($"num one: {numOne}, num two: {numTwo}, function {functionList[z]}");

                    total = MathsFunction(numOne, numTwo, functionList[z]);
                }
            }

            canvas.SetNumber(targetNumber, total);

            if (targetNumber == total)
            {
                canvas.PlayerWin();
                exit.SetActive(true);
            }
        }
    }

    public void ButtonPressed(bool isStack)
    {
        print("pressed");

        this.isStack = isStack;
        SlotInput();
    }

    public override void OnBoxDropped()
    {
        boxOnSlotCount++;

        if (boxOnSlotCount >= slots.Count)
        {
            SlotInput();
        }
    }
}
