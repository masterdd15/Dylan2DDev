using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMove : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool hasKey = false; //Stores if player is holding key

    //GravityController
    private GravitySwap myGravity;

    [SerializeField]
    float jumpStrength = 5.0f;
    float movementSpeed = 5.0f;
    float moveX;

    [SerializeField]
    bool isGrounded;
    bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myGravity = GetComponent<GravitySwap>();
    }


    void PlayerControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        //Mouse Gravity method
        if(Input.GetMouseButtonDown(0)) //Left Click
        {
            //If we left click, we move the gravity forward 1
            myGravity.GravityFoward();
        }

        if(Input.GetMouseButtonDown(1)) //Right Click
        {
            myGravity.GravityBackward();
        }

        moveX = Input.GetAxis("Horizontal");
    }

    void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        Debug.Log("Jump");

        switch (myGravity.currentDir)
        {
            case GravitySwap.Direction.Left:
                //Shoots off in the Right direction
                rb.AddForce((Vector2.right * jumpStrength), ForceMode2D.Impulse);
                isGrounded = false;
                break;
            case GravitySwap.Direction.Right:
                //Shoots off in the Left direction
                rb.AddForce((Vector2.left * jumpStrength), ForceMode2D.Impulse);
                isGrounded = false;
                break;
            case GravitySwap.Direction.Up:
                //Reversed
                rb.AddForce(-1 * (Vector2.up * jumpStrength), ForceMode2D.Impulse);
                isGrounded = false;
                break;
            case GravitySwap.Direction.Down:
                //Normal
                rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                isGrounded = false;
                break;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            canJump = false;
            Jump();
        }
    }

    private void VelocityUpdate()
    {
        //We first need to save the players current velocity
        Vector2 finalVelocity = rb.velocity;
        
        //We need to decide how to add the movement to the player
        switch(myGravity.currentDir)
        {
            case GravitySwap.Direction.Left:
                //The variables are swapped for the Horizontal movement
                rb.velocity = new Vector2(rb.velocity.x , -(moveX * movementSpeed));
                break;
            case GravitySwap.Direction.Right:
                //Same Horizontal Controls for now (Flip if we flip camera)
                rb.velocity = new Vector2(rb.velocity.x, (moveX * movementSpeed));
                break;
            case GravitySwap.Direction.Up:
                //Same Controls for now (Flip if we flip camera)
                rb.velocity = new Vector2((moveX * movementSpeed), rb.velocity.y);
                break;
            case GravitySwap.Direction.Down:
                //Normal Directional Movement
                rb.velocity = new Vector2(moveX * movementSpeed, rb.velocity.y);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        VelocityUpdate();
        PlayerControls();
    }
}
