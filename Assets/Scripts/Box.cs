using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public enum BoxType { Number, Function, Variable};
    public BoxType boxType;
    public enum FunctionType { plus, minus, multiply, divide,equal, largerThan, smallerThan};
    public FunctionType functionType;
    public enum VariableType { Int, Char};
    public VariableType variableType;
    public int boxNum;
    public bool numCanChange;
    public Sprite newNumSprite;


    private bool onSlot;
    private Slot slot;
    private SpriteRenderer spriteRenderer;

    public List<Sprite> spriteList = new List<Sprite>();
    public Sprite plus, minus, multiply, divide, equal, largerThan, smallerThan;

    public void OnBoxDroppedOnSlot(Slot slot)
    {
        onSlot = true;
        this.slot = slot;
    }

    public void OnBoxPickedUpFromSlot()
    {
        if(onSlot)
        {
            onSlot = false;
            slot.OnBoxPickedUp(this);
        }
    }

    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(boxType == BoxType.Number && !numCanChange)
        {
            switch(boxNum)
            {
                case 0:
                    spriteRenderer.sprite = spriteList[0];
                    break;
                case 1:
                    spriteRenderer.sprite = spriteList[1];
                    break;
                case 2:
                    spriteRenderer.sprite = spriteList[2];
                    break;
                case 3:
                    spriteRenderer.sprite = spriteList[3];
                    break;
                case 4:
                    spriteRenderer.sprite = spriteList[4];
                    break;
                case 5:
                    spriteRenderer.sprite = spriteList[5];
                    break;
                case 6:
                    spriteRenderer.sprite = spriteList[6];
                    break;
                case 7:
                    spriteRenderer.sprite = spriteList[7];
                    break;
                case 8:
                    spriteRenderer.sprite = spriteList[8];
                    break;
                case 9:
                    spriteRenderer.sprite = spriteList[9];
                    break;
            }
        }
        else if(boxType == BoxType.Function && !numCanChange)
        {
            switch(functionType)
            {
                case FunctionType.plus:
                    spriteRenderer.sprite = plus;
                    break;
                case FunctionType.minus:
                    spriteRenderer.sprite = minus;
                    break;
                case FunctionType.multiply:
                    spriteRenderer.sprite = multiply;
                    break;
                case FunctionType.divide:
                    spriteRenderer.sprite = divide;
                    break;
                case FunctionType.equal:
                    spriteRenderer.sprite = equal;
                    break;
                case FunctionType.largerThan:
                    spriteRenderer.sprite = largerThan;
                    break;
                case FunctionType.smallerThan:
                    spriteRenderer.sprite = smallerThan;
                    break;
            }
   
        }
    }

    public void SetBoxNum(int newNum)
    {
        boxNum = newNum;

        if(numCanChange)
        {
            spriteRenderer.sprite = newNumSprite;
            return;
        }

        switch (boxNum)
        {
            case 0:
                spriteRenderer.sprite = spriteList[0];
                break;
            case 1:
                spriteRenderer.sprite = spriteList[1];
                break;
            case 2:
                spriteRenderer.sprite = spriteList[2];
                break;
            case 3:
                spriteRenderer.sprite = spriteList[3];
                break;
            case 4:
                spriteRenderer.sprite = spriteList[4];
                break;
            case 5:
                spriteRenderer.sprite = spriteList[5];
                break;
            case 6:
                spriteRenderer.sprite = spriteList[6];
                break;
            case 7:
                spriteRenderer.sprite = spriteList[8];
                break;
            case 8:
                spriteRenderer.sprite = spriteList[8];
                break;
            case 9:
                spriteRenderer.sprite = spriteList[9];
                break;
        }
    }
}
