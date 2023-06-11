using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    protected SlotManager slotManager;
    protected Box box;
    public Box Box { get { return box; } }

    protected bool hasBox = false;
    public bool HasBox { get { return hasBox; } }


    public void SlotInit(SlotManager manager)
    {
        slotManager = manager;
    }

    public virtual void OnBoxDropped(Box box)
    {
        hasBox = true;
        this.box = box;
        slotManager.OnBoxDropped();

        box.gameObject.transform.parent = transform;
        box.gameObject.transform.localPosition = Vector2.zero;

        //if (hasBox)
        //{
        //    //already has box so swap box
        //}
        //else
        //{
        //    hasBox = true;
        //    this.box = box;
        //    slotManager.OnBoxDropped();

        //    box.gameObject.transform.parent = transform;
        //    box.gameObject.transform.localPosition = Vector2.zero;
        //}
    }

    public virtual void OnBoxDroppedNoTransform(Box box)
    {
        hasBox = true;
        this.box = box;
        slotManager.OnBoxDropped();



        //if (hasBox)
        //{
        //    //already has box so swap box
        //}
        //else
        //{
        //    hasBox = true;
        //    this.box = box;
        //    slotManager.OnBoxDropped();

        //    box.gameObject.transform.parent = transform;
        //    box.gameObject.transform.localPosition = Vector2.zero;
        //}
    }

    public virtual void OnBoxPickedUp(Box box)
    {
        hasBox = false;
        slotManager.OnBoxPickedUp();
    }
}
