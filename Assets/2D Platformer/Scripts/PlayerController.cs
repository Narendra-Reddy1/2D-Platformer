using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;

        public float moveSpeed;
        public float jumpForce;
        public int noOfJumps = 2;
        public float knockBackTime;
        public float knockBackForce;
        public float bounceForce;
        public float groundCheckRadius = 0.2f;

        private float knockBackCounter;
        private float direction;
        private int noOfJumpsLeft;
        private bool isGrounded;
        private bool canJump;


        public Transform groundCheck;
        public LayerMask whatIsGrounded;
        private Animator anim;
        private Rigidbody2D rb;
        private SpriteRenderer sr;


        private void Awake()
        {
            instance = this;

        }
        void Start()
        {

            UI_Controller.instance.FadeFromBlack();
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            noOfJumpsLeft = noOfJumps;
        }


        void Update()
        {
            if (!PauseMenu.instance.isPaused)
            {
                if (!(UI_Controller.instance.fadeScreen.color.a > 0))
                {
                    if (knockBackCounter <= 0)
                    {
                        PlayerInput();
                        PlayerFlip();
                        GroundCheck();
                        PlayerJump();

                    }
                    else
                    {
                        knockBackCounter -= Time.deltaTime;
                        if (!sr.flipX)
                        {
                            rb.velocity = new Vector2(-knockBackForce, rb.velocity.y);
                        }
                        else
                        {
                            rb.velocity = new Vector2(knockBackForce, rb.velocity.y);
                        }

                    }
                }



                //---------------Animations---------------------


                /* if (!isGrounded && rb.velocity.x != 0)
                {
                    anim.SetBool("isAirborne", true);
                }
                else
                {
                    anim.SetBool("isAirborne", false);
                }*/

                if (!isGrounded && rb.velocity.y <= 0)
                {
                    anim.SetBool("isLanding", true);
                }
                else
                {
                    anim.SetBool("isLanding", false);
                }
            }

            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        }

        private void PlayerInput()
        {
            direction = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }

        private void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGrounded);
        }
        private void PlayerFlip()
        {
            if (direction > 0)
            {
                sr.flipX = false;
            }
            else if (direction < 0)
            {
                sr.flipX = true;
            }
        }


        private void PlayerJump()
        {
            if (isGrounded && rb.velocity.y <= 0)
            {
                noOfJumpsLeft = noOfJumps;
            }
            if (noOfJumpsLeft <= 0)
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (canJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    AudioManager.instance.playSFX(10);
                    noOfJumpsLeft--;
                }
            }

        }

        public void KnockBack()
        {
            knockBackCounter = knockBackTime;
            rb.velocity = new Vector2(0f, knockBackForce);

            anim.SetTrigger("playerHurt");
        }

        public void Bounce() => rb.velocity = new Vector2(rb.velocity.x, bounceForce);

        private void OnDrawGizmos() => Gizmos.DrawWireSphere(groundCheck.position, .2f);
    }
}