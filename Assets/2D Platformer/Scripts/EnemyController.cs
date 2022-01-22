using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class EnemyController : MonoBehaviour
    {
        /* public float moveTime, waitTime;*/
        private float moveTimeCount, waitTimeCount;
        private bool isMovingRight;
        [SerializeField] private float moveSpeed;

        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private Animator anim;
        [SerializeField] private Transform leftPoint, rightPoint;




        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponentInChildren<SpriteRenderer>();
            anim = GetComponent<Animator>();
            leftPoint.parent = null;
            rightPoint.parent = null;

            isMovingRight = true;
            moveTimeCount = 2;
            waitTimeCount = 1;

        }



        void Update()
        {
            if (moveTimeCount > 0)
            {
                moveTimeCount -= Time.deltaTime;
                if (isMovingRight)
                {
                    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                    sr.flipX = true;
                    if (transform.position.x > rightPoint.position.x)
                    {
                        isMovingRight = false;
                    }

                }
                else
                {
                    rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                    sr.flipX = false;
                    if (transform.position.x < leftPoint.position.x)
                    {
                        isMovingRight = true;
                    }
                }
                if (moveTimeCount <= 0)
                {
                    waitTimeCount = Random.Range(0.5f, 1.25f);
                }
                anim.SetBool("isMoving", true);

            }
            else if (waitTimeCount > 0)
            {
                waitTimeCount -= Time.deltaTime;
                rb.velocity = new Vector2(0f, rb.velocity.y);
                if (waitTimeCount <= 0)
                {
                    moveTimeCount = Random.Range(1f, 2.75f);
                }
                anim.SetBool("isMoving", false);
            }
        }
    }
}