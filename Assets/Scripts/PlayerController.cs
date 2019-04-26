using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float ThreePiOverFour = Mathf.PI * 3 / 4;
    private const float PiOverFour = Mathf.PI / 4;
    public Animator animator;
    public Rigidbody2D rb2d;

    [Range(0.001f, 2.0f)]
    public float TranslationIncrement = .07f;

    public Transform playerPos;
    public LayerMask whatIsEnemy;
    public LayerMask whatIsChest;
    public float playerRange;

    // Start is called before the first frame update
    void Start()
    {

    } // End start()

    // Update is called once per frame
    void Update()
    {
        movement();
        if (Input.GetKeyDown(KeyCode.X))
        {
            attack();
            Collider2D[] enemiesToAttack = Physics2D.OverlapCircleAll(playerPos.position, playerRange, whatIsEnemy);
            for (int i = 0; i < enemiesToAttack.Length; i++)
            {
                enemiesToAttack[i].GetComponent<SkeletonController>().destroyEnemy();
            }
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetInteger("AttackState", 0);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Collider2D[] chestsToOpen = Physics2D.OverlapCircleAll(playerPos.position, playerRange, whatIsChest);
            for (int i = 0; i < chestsToOpen.Length; i++)
            {
                chestsToOpen[i].GetComponent<TreasureChestController>().openChest();
            }
        }
    } // End update()

    void movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        if (movement == Vector2.zero)
        {
            if (animator.GetInteger("WalkState") == 1)
            {
                animator.SetInteger("WalkState", 5);
            }
            else if (animator.GetInteger("WalkState") == 2)
            {
                animator.SetInteger("WalkState", 6);
            }
            else if (animator.GetInteger("WalkState") == 3)
            {
                animator.SetInteger("WalkState", 7);
            }
            else if (animator.GetInteger("WalkState") == 4)
            {
                animator.SetInteger("WalkState", 8);
            }
        } // End if
        else
        {
            float angle = Mathf.Atan2(movement.y, movement.x);
            if (angle < ThreePiOverFour && angle > PiOverFour)
            {
                animator.SetInteger("WalkState", 1);
                transform.root.position += Vector3.up * TranslationIncrement;
            }
            else if (angle < PiOverFour && angle > -PiOverFour)
            {
                animator.SetInteger("WalkState", 2);
                transform.root.position += Vector3.right * TranslationIncrement;
            }
            else if (angle < -PiOverFour && angle > -ThreePiOverFour)
            {
                animator.SetInteger("WalkState", 3);
                transform.root.position += Vector3.down * TranslationIncrement;
            }
            else if (angle > ThreePiOverFour || angle < -ThreePiOverFour)
            {
                animator.SetInteger("WalkState", 4);
                transform.root.position += Vector3.left * TranslationIncrement;
            }
        } // End else
    } // End movement

    void attack()
    {
        if (animator.GetInteger("WalkState") == 1 ||
            animator.GetInteger("WalkState") == 5)
        {
            animator.SetInteger("AttackState", 1);
        }
        else if (animator.GetInteger("WalkState") == 2 ||
            animator.GetInteger("WalkState") == 6)
        {
            animator.SetInteger("AttackState", 2);
        }
        else if (animator.GetInteger("WalkState") == 2 ||
            animator.GetInteger("WalkState") == 7)
        {
            animator.SetInteger("AttackState", 3);
        }
        else if (animator.GetInteger("WalkState") == 4 ||
            animator.GetInteger("WalkState") == 8)
        {
            animator.SetInteger("AttackState", 4);
        }
    } // End attack()

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerPos.position, playerRange);
    }
} // End class