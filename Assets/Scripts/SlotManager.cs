using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    protected int boxOnSlotCount=0;
    private float combinedNum, total;
    public float targetNumber;
    public List<float> combinedNumbers = new List<float>();
    public List<Box.FunctionType> functionTypeList = new List<Box.FunctionType>();
    public NewCanvas canvas;
    public GameObject exit;
        
    protected virtual void Awake()
    {
        foreach(Slot slot in slots)
        {
            slot.SlotInit(this);
        }

        canvas.CanvasInit();
        canvas.SetNumber(targetNumber, 0);
        exit.SetActive(false);
    }

    public virtual void OnBoxDropped()
    {
        print("box dropped");

        boxOnSlotCount++;

        if(boxOnSlotCount >= slots.Count)
        {
            SlotInput();
        }
    }


    public virtual void OnBoxPickedUp()
    {
        boxOnSlotCount--;
    }

    protected virtual void SlotInput()
    {
        int numCounter = 0;
        combinedNum = 0;
        total = 0;
        combinedNumbers.Clear();
        functionTypeList.Clear();
        print("slot input");

        if(slots[slots.Count -2].Box.boxType == Box.BoxType.Function || slots[0].Box.boxType == Box.BoxType.Function)
        {
            canvas.InvalidInput(targetNumber);
            return;
        }

        for (int i =0; i < slots.Count; i++)
        {
            //print(slots[i].Box.boxType);

            if(slots[i].Box.boxType == Box.BoxType.Number)
            {
                numCounter++;
            }
            else
            {
                if(slots[i].Box.functionType != Box.FunctionType.equal)
                {
                    functionTypeList.Add(slots[i].Box.functionType);
                }

                if (numCounter > 1)
                {
                    int loop = i;

                    for (int y = numCounter; y > 0; y--)
                    {
                        combinedNum += slots[loop - numCounter].Box.boxNum * Mathf.Pow(10, y - 1);
                        loop++;
                    }


                }
                else
                {
                    if(i - (numCounter + 1) < 0)
                    {
                        combinedNum += slots[0].Box.boxNum;
                    }
                    else
                    {
                        combinedNum += slots[i - (numCounter + 1)].Box.boxNum;
                    }
                }

                combinedNumbers.Add(combinedNum);

                numCounter =0;
                combinedNum = 0;
            }
        }


        bool firstTime = true;
        for(int z = 0; z < functionTypeList.Count; z++)
        {
            if(firstTime)
            {
                firstTime = false;

                float numOne = combinedNumbers[z];
                float numTwo = combinedNumbers[z+1];

                total = MathsFunction(numOne, numTwo, functionTypeList[z]);
            }
            else
            {
                float numOne = total;
                float numTwo = combinedNumbers[z + 1];

                total = MathsFunction(numOne, numTwo, functionTypeList[z]);
            }
        }

        canvas.SetNumber(targetNumber, total);

        if (targetNumber == total)
        {
            canvas.PlayerWin();
            exit.SetActive(true);
        }

    }

    protected float MathsFunction(float numOne, float numTwo, Box.FunctionType functionType)
    {
        float returnFloat;

        switch (functionType)
        {
            case Box.FunctionType.plus:
                returnFloat = numOne + numTwo;
                return returnFloat;

            case Box.FunctionType.minus:
                returnFloat = numOne - numTwo;
                return returnFloat;

            default:
                Debug.LogWarning("Function Type Invalid");
                return 0;
        }
    }
}
