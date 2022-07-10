using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    bool isMoving = false;
    //public AudioSource audio;
    public Transform wallGrabPoint;
    public bool canGrab, isGrabbing;
    private float gravityStore;
    //public float wallJumpTime = .2f;
    //public float wallJumpCounter;
    public KeyCode m1;

    public Rigidbody2D rb;
    public Transform GroundCheakPoint;
    public float GroundCheakRadius;
    public LayerMask WhatIsGround;

    private bool IsGrounded;
    public Transform KeyFollowPoint; //key
    public Key followingKey;
    private Animator anim;

    public bool doubleJump;

    public int pich;
    //[SerializeField] private AudioSource SoundJump;
     void Start()
    {
        
        anim = GetComponent<Animator>();
        gravityStore = rb.gravityScale;
        //audio.pitch = pich;
    }
    // Update is called once per frame
    void Update()
    {
        //if (wallJumpCounter <= 0)
        //{
        IsGrounded = Physics2D.OverlapCircle(GroundCheakPoint.position, GroundCheakRadius, WhatIsGround); /*Verifica se um Collider está dentro de uma área circular, se estiver 
                                                                                                            está na superficie*/
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        if (Input.GetKey(left))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);


            }
            else if (Input.GetKey(right))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKeyDown(jump)) // && IsGrounded
            {
                     if (IsGrounded)
                     {
                        rb.velocity = Vector2.zero;
                        FindObjectOfType<Audio_Manager>().Play("PlayerManJump");
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        doubleJump = true;
                     }

           else if (!IsGrounded && doubleJump)
                    {
                        FindObjectOfType<Audio_Manager>().Play("PlayerManJump");
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        doubleJump = false;
                     }
            //SoundJump.Play();
        }

            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (rb.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }


        //     canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, .2f, WhatIsGround);
        //     isGrabbing = false;
        //     if (canGrab && !IsGrounded)
        //     {
        //         if ((transform.localScale.x == 1f && Input.GetAxisRaw("Horizontal") > 0) || (transform.localScale.x == -1f && Input.GetAxisRaw("Horizontal") < 0))
        //         {
        //             isGrabbing = true;
        //         }
        //     }
        //     if (isGrabbing)
        //     {
        //         rb.gravityScale = 0f;
        //         rb.velocity = Vector3.zero;
        //         if (Input.GetKeyDown(jump))
        //         {
        //             wallJumpCounter = wallJumpTime;
        //             rb.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * moveSpeed, jumpForce);
        //             rb.gravityScale = gravityStore;
        //             isGrabbing = false;
        //         }
        //     }
        //     else
        //     {
        //         rb.gravityScale = gravityStore;
        //     }

        // }
        // else
        // {
        //     wallJumpCounter -= Time.deltaTime;
        // }


        //if (rb.velocity.sqrMagnitude != 0)
        //{
        //    isMoving = true;
        //}
        //else
        //{
        //    isMoving = false;
        //}

        //if (isMoving == true)
        //{
        //    if (!audio.isPlaying)
        //    {
        //        audio.Play();
        //    }

        //}
        //else
        //{
        //    audio.Stop();
        //}

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", IsGrounded);


        // anim.SetBool("IsGrabbing", isGrabbing);
    }


}
