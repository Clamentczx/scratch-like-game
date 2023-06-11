using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputMachine : MonoBehaviour
{
    public List<GameObject> tempSlots = new List<GameObject>();
    public List<Slot> realSlot = new List<Slot>();
    private List<Box> boxes = new List<Box>();
    protected int numOfBox;
    private float boxMoveDuration = .5f;

    public GameObject queueOrStackButton;


    private void Awake()
    {
        queueOrStackButton.SetActive(false);
    }


    public void TransferBox(Box box)
    {
        switch(numOfBox)
        {
            case 0:
                box.transform.DOMove(tempSlots[0].transform.position, boxMoveDuration);
                boxes.Add(box);
                break;
            case 1:
                box.transform.DOMove(tempSlots[1].transform.position, boxMoveDuration);
                boxes.Add(box);
                break;

            case 2:
                box.transform.DOMove(tempSlots[2].transform.position, boxMoveDuration);
                boxes.Add(box);
                queueOrStackButton.SetActive(true);
                break;
        }

        numOfBox++;
    }

    public void QueueButton()
    {
        switch (numOfBox)
        {
            case 1:
                boxes[0].transform.DOMove(realSlot[2].transform.position, boxMoveDuration).OnComplete(()=>DropBox(boxes[0], realSlot[2]));
                realSlot[2].OnBoxDroppedNoTransform(boxes[0]);
                boxes.Remove(boxes[0]);
                break;
            case 2:
                boxes[0].transform.DOMove(realSlot[1].transform.position, boxMoveDuration).OnComplete(() => DropBox(boxes[0], realSlot[1]));
                realSlot[1].OnBoxDroppedNoTransform(boxes[0]);
                boxes.Remove(boxes[0]);
                boxes[0].transform.DOMove(tempSlots[0].transform.position, boxMoveDuration);
                break;

            case 3:
                boxes[0].transform.DOMove(realSlot[0].transform.position, boxMoveDuration).OnComplete(() => DropBox(boxes[0], realSlot[0]));
                realSlot[0].OnBoxDroppedNoTransform(boxes[0]);
                boxes.Remove(boxes[0]);
                boxes[0].transform.DOMove(tempSlots[0].transform.position, boxMoveDuration);
                boxes[1].transform.DOMove(tempSlots[1].transform.position, boxMoveDuration);
                break;
        }

        numOfBox--;
    }

    public void StackButton()
    {
        switch (numOfBox)
        {
            case 1:
                boxes[0].transform.DOMove(realSlot[2].transform.position, boxMoveDuration).OnComplete(() => DropBox(boxes[0], realSlot[2]));
                realSlot[2].OnBoxDroppedNoTransform(boxes[0]);
                boxes.Remove(boxes[0]);
                break;
            case 2:
                boxes[boxes.Count - 1].transform.DOMove(realSlot[1].transform.position, boxMoveDuration).OnComplete(() => DropBox(boxes[boxes.Count - 1], realSlot[1]));
                realSlot[1].OnBoxDroppedNoTransform(boxes[boxes.Count - 1]);
                boxes.Remove(boxes[boxes.Count - 1]);
                break;

            case 3:
                boxes[boxes.Count-1].transform.DOMove(realSlot[0].transform.position, boxMoveDuration).OnComplete(() => DropBox(boxes[boxes.Count - 1], realSlot[0]));
                realSlot[0].OnBoxDroppedNoTransform(boxes[boxes.Count - 1]);
                boxes.Remove(boxes[boxes.Count - 1]);

                break;
        }

        numOfBox--;
    }

    private void DropBox(Box box, Slot slot)
    {
        //slot.OnBoxDropped(box);
    }
}
