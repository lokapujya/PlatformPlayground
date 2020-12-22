using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField]
    private float jumpForce = 500f;
    [SerializeField]
    private float walkForce = 500f;
    public int extraJumps = 1;
    public bool isGrounded = false;
    public bool isClimbing = false;
    [SerializeField]
    private float maxClimbVelocity = 1f;
    private float maxWalkVelocity = 2f;
    public int isTouchingLadder = 0;
    private float inputVertical;
    private float inputHorizontal;
    
    private float climbSpeed=1f;
    public Sprite marioKick;
    Sprite marioNormal;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    private bool isKicking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        marioNormal = sr.sprite;

    }
    void Update()
    {
        isGrounded = false;
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        rb.GetContacts(contacts);
        if (contacts.Count != 0)
        {
            isGrounded = true;
        }

        if (isTouchingLadder>0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (isClimbing == false)
                {
                    rb.velocity = new Vector2(0.0f, 0.0f);
                }
                isClimbing = true;
                Debug.Log("Climb");
                rb.gravityScale = 0f;
            }
        }
        else
        {
            isClimbing = false;
            rb.gravityScale = 1.0f;
        }

        if (isClimbing)
        {
            /*if (rb.velocity.y < maxClimbVelocity)
            {
              rb.AddForce(Vector2.up * walkForce);
            }*/
            inputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        float h = Input.GetAxis("Horizontal");

        if (!isClimbing)
        {
            // Horizontal Movement
            if (h < 0)
            {
                if (rb.velocity.x > -maxWalkVelocity && rb.velocity.x < maxWalkVelocity)
                {
                    rb.AddForce(Vector2.left * walkForce);
                }

            }
            else if (h > 0)
            {

                if (rb.velocity.x > -maxWalkVelocity && rb.velocity.x < maxWalkVelocity)
                {
                    rb.AddForce(Vector2.right * walkForce);
                }
            }
            if (rb.velocity.x < 0)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        } else
        {
            // Horizontal Movement (while Climbing)
            inputHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(inputHorizontal * climbSpeed, rb.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            sr.sprite = marioKick;
            this.transform.localScale = new Vector3(0.15f, 0.15f, 1);
            nextAttackTime = Time.time + 1f / attackRate;
            isKicking = true;


        }
        if (Time.time >= nextAttackTime && isKicking == true)
        {
            sr.sprite = marioNormal;
            this.transform.localScale = new Vector3(0.3f, 0.3f, 1);

        } else
        {

        }
    }
}
