using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject pickUpPoint;
    public float radius;
    public GameObject sword, swordHolder;
    public bool playerHasSword;
    private BoxCollider2D swordCollider;
    private Animator animator;
    private bool facingRight = true, attacking = false;
    private SpriteRenderer spriteRen;

    Vector2 movement;
    GameObject boxPickedUp;
    bool holdingBox;

    private void Awake()
    {
        swordCollider = sword.GetComponent<BoxCollider2D>();
        swordCollider.enabled = false;
        animator = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(animator != null)
        {
            animator.SetFloat("speed", movement.magnitude);
        }

        if(spriteRen != null)
        {
            if (movement.x > 0 && !facingRight)
            {
                facingRight = true;
                spriteRen.flipX = false;
            }
            else if (movement.x < 0 && facingRight)
            {
                facingRight = false;
                spriteRen.flipX = true;
            }
        }


        if (Input.GetKeyDown("space"))
        {
            if(!holdingBox)
            {
                PickUp(transform.position, radius);
            }
            else
            {
                Drop(transform.position, radius);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerHasSword && !attacking)
        {
            StartCoroutine(SwordAttack());

            IEnumerator SwordAttack()
            {
                swordCollider.enabled = true;
                attacking = true;
                swordHolder.transform.DORotate(new Vector3(0, 0, -30), 0.2f);
                yield return new WaitForSeconds(0.2f);
                swordCollider.enabled = false;
                swordHolder.transform.DORotate(new Vector3(0, 0, 25), 0.2f);
                yield return new WaitForSeconds(0.3f);
                attacking = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void PickUp(Vector3 center, float radius)
    {
        Collider2D [] hitColliders = Physics2D.OverlapCircleAll(center, radius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.CompareTag("Box"))
            {
                //print($"Hit: {hitCollider.gameObject} ");
                boxPickedUp = hitCollider.gameObject;
                holdingBox = true;
                break;
            }
        }

        if(boxPickedUp != null)
        {
            boxPickedUp.GetComponent<Box>().OnBoxPickedUpFromSlot();

            boxPickedUp.transform.parent = pickUpPoint.transform;
            boxPickedUp.transform.localPosition = Vector2.zero;
        }
    }

    private void Drop(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            //print(hitCollider.gameObject);

            if (hitCollider.gameObject.CompareTag("Slot"))
            {
                Slot slot = hitCollider.gameObject.GetComponent<Slot>();
                Box box = boxPickedUp.GetComponent<Box>();


                if (slot.HasBox)
                {
                    Box oldBox = box;

                    boxPickedUp = slot.Box.gameObject;
                    holdingBox = true;

                    if (boxPickedUp != null)
                    {
                        boxPickedUp.GetComponent<Box>().OnBoxPickedUpFromSlot();

                        boxPickedUp.transform.parent = pickUpPoint.transform;
                        boxPickedUp.transform.localPosition = Vector2.zero;
                    }



                    slot.OnBoxDropped(box);
                    box.OnBoxDroppedOnSlot(slot);

                    return;

                }
                else
                {

                    //boxPickedUp.transform.parent = hitCollider.gameObject.transform;
                    //boxPickedUp.transform.localPosition = Vector2.zero;
                    holdingBox = false;

                    slot.OnBoxDropped(box);
                    box.OnBoxDroppedOnSlot(slot);

                    boxPickedUp = null;

                    return;
                }

            }
        }

        boxPickedUp.transform.parent = null;
        boxPickedUp = null;
        holdingBox = false;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnValidate()
    {
        if(playerHasSword)
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }
    }
}
