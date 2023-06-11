using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sword : MonoBehaviour
{
    public int swordNumber;
    public List<Sprite> spriteList = new List<Sprite>();
    private SpriteRenderer spriteRenderer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Box box))
        {
            if(box.numCanChange)
            {
                box.SetBoxNum(swordNumber);
            }
        }
    }

    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (swordNumber)
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
