using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField]
    private float jumpForce = 500f;
    [SerializeField]
    private float walkForce = 500f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            List<ContactPoint2D> contacts = new List<ContactPoint2D>();
            rb.GetContacts(contacts);
            if (contacts.Count != 0)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
            }
        }
        /*else if (Input.GetButtonDown("Horizontal"))
        {
            float h = Input.GetAxis("Horizontal");

            rb.velocity = Vector2.zero;
            if (h < 0)
            {
                rb.AddForce(Vector2.left * walkForce);

            }
            else
            {
                rb.AddForce(Vector2.right * walkForce);

            }

        }*/
        /*else if (Input.GetButtonDown("Right"))
        {
        }*/

        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            if (rb.velocity.x > -4 && rb.velocity.x < 4)
            {
                rb.AddForce(Vector2.left * walkForce);
            }

        }
        else if (h > 0)
        {

            if (rb.velocity.x > -4 && rb.velocity.x < 4)
            {
                rb.AddForce(Vector2.right * walkForce);
            }

        }
    }
}
