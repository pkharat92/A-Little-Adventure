using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float ThreePiOverFour = Mathf.PI * 3 / 4;
    private const float PiOverFour = Mathf.PI / 4;
    public float speed;
    public Animator animator;
    public Rigidbody2D rb2d;

    [Range(0.001f, 2.0f)]
    public float TranslationIncrement = .035f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        if (movement == Vector2.zero)
        {
            if(animator.GetInteger("WalkState") == 1)
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
        }
        else
        {
            float angle = Mathf.Atan2(movement.y, movement.x);
            if(angle < ThreePiOverFour && angle > PiOverFour )
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
        }

        rb2d.velocity = movement * speed * Time.deltaTime;
    }
}
