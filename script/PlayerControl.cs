using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleApp
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        private Animator anim;
        private bool isLadder;
        private bool isClimbing;
        private bool isJumping;
        private bool isFalling;
        private float playerGravity;


        public float speed;
        public float jumpforce;
        public float climbspeed;
        public LayerMask ground;
        public LayerMask platform;
        public LayerMask moveplatform;
        public Collider2D coll;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            playerGravity = rb.gravityScale;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Movement();
            Switchanim();
            Climb();
            CheckLadder();
            CheckAirStatus();
        }
        private void Update()
        {
            if (Input.GetButtonDown("Jump") && (coll.IsTouchingLayers(ground)||coll.IsTouchingLayers(moveplatform)))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }
        void Movement()
        {
            float horizontalmove = Input.GetAxis("Horizontal");
            float facedircetion = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedircetion));

            if (facedircetion != 0)
            {
                transform.localScale = new Vector3(facedircetion, 1, 1);
            }
        }
        void Switchanim()
        {
            anim.SetBool("idle", true);
            if (anim.GetBool("jumping"))
            {
                if (rb.velocity.y < 0)
                {
                    anim.SetBool("jumping", false);
                    anim.SetBool("falling", true);
                }
            }
            else if (coll.IsTouchingLayers(ground))
            {
                anim.SetBool("falling", false);
                anim.SetBool("idle", true);
            }
        }
        void CheckLadder()
        {
            isLadder = coll.IsTouchingLayers(LayerMask.GetMask("Ladder"));
        }
        void Climb()
        {
            if (isLadder)
            {
                float move = Input.GetAxis("Vertical");
                if (move > 0.5f || move < -0.5f)
                {
                    anim.SetBool("climbing", true);
                    rb.gravityScale = 0.0f;
                    rb.velocity = new Vector2(rb.velocity.x, move * climbspeed);
                }
                else
                {
                    if (isJumping || isFalling)
                    {
                        anim.SetBool("climbing", false);
                    }
                    else
                    {
                        anim.SetBool("climbing", false);
                        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                    }
                }
            }
            else
            {
                anim.SetBool("climbing", false);
                rb.gravityScale = playerGravity;
            }
        }
        void CheckAirStatus()
        {
            isJumping = anim.GetBool("jumping");
            isFalling = anim.GetBool("falling");
            isClimbing = anim.GetBool("climbing");
        }
    }
}
