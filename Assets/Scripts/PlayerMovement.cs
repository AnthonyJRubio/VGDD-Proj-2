using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;


    //TESTING PURPOSES
    [SerializeField]
    [Tooltip("Level is finished")]
    private bool m_Finished = false;

    //END TESTING

    #region Private Variables
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    #endregion

    #region Initialization
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log("Jumping");
            Debug.Log(jumpingPower);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        /*if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    #region Collision Methods
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Got here at least");
        
        Debug.Log("got here");
        if (other.CompareTag("Lever"))
        {
            Debug.Log("Touched a Lever");
            Lever lever = other.GetComponent<Lever>();
            lever.GravChange();
            gameObject.GetComponent<Rigidbody2D>().gravityScale *= lever.GravMult;
            jumpingPower *= lever.GravMult;
            //Transform groundCheck = transform.Find("Ground Check");
            //groundCheck.position *= new Vector2(1, -1);
        }
        else if (other.CompareTag("Finish"))
        {
            m_Finished = true;
            Debug.Log(m_Finished);
        }
        
    }
    #endregion
}
