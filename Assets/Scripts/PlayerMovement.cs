using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;


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
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // don't care
        /// RECOMMENDATION FOR THIS PROJECT
        /// 1. Stick to side to side shooter, cut out ability to shoot upwards due to time constraint
        /// 2. Cut down to 2 levels due to Issues (noted below)
        /// 
        /// ISSUES:
        /// 1. Collision detection between Next_Game_Bar (meant to end the game using LevelManager.cs) and Player  AND Lever and Player is currently
        /// not working. I have not worked on the Death_Bar but the game does not seem to detect the collision beteen Player and objects. Highest priority.
        /// 2. Needing to import all animations from Lab4 from Kyle to game and attach to player. Would recommend scrapping grappling hook idea
        /// since animation and code will take up too much time. Instead, could make the player activate by using player body, but Death_Bar would need to work.
        /// 3. Death_Bar needs to be set up, no code to detect when hit and take away health. The least needed is to reset player to original position when
        /// Death_Bar is hit.
        /// 4. UI is set up but Color changing from green to red is needed, as well as function to decrease health on player. If necessary for time, removal can
        /// be done. Lowest priority.
        ///
    }

    //ISSUE: Not detecting other collider even with trigger on
    #region Collision Methods
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got here at least");
        /**
        Debug.Log("got here");
        if (other.CompareTag("Lever"))
        {
            Debug.Log("Touched a Lever");
            //other.GetComponent<Lever>().GravChange();
        }else if (other.CompareTag("Finish"))
        {
            m_Finished = true;
            Debug.Log(m_Finished);
        }
        **/
    }
    #endregion
}
