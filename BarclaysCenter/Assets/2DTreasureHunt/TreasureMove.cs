using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMove : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool hasKey = false; //Stores if player is holding key

    //GravityController
    private GravitySwap myGravity;

    //Animator
    public Animator playerAnimator;
    public CharacterFlip playerSpriteHolder;
    private float currentControlMove = 0;

    //Audio
    AudioSource playerAudio;

    
    //We need to see if the gravity has changed since the last update
    bool gravityChangeCheck = false;

    //Stores the final velocity before gravity is switched
    public Vector2 finalVelocity;

    [SerializeField]
    float jumpStrength = 5.0f;
    float movementSpeed = 5.0f;
    float moveX;

    [SerializeField]
    bool isGrounded;
    bool canJump;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
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
            //Play sound
            playerAudio.Play();
            //Save the final velocity
            finalVelocity = rb.velocity;
            //If we left click, we move the gravity forward 1
            myGravity.GravityFoward();
            //We need to know that the gravity has shifted
            gravityChangeCheck = true;

        }

        if(Input.GetMouseButtonDown(1)) //Right Click
        {
            //Play sound
            playerAudio.Play();
            //Save the final velocity
            finalVelocity = rb.velocity;
            //If we right click, we move the gravity backward 1
            myGravity.GravityBackward();
            //We need to know that the gravity has shifted
            gravityChangeCheck = true;
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
            //We will stop using the previous gravity force once the player lands
            gravityChangeCheck = false;
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

        //If the player is in the air, we need to keep the momentum when they change gravity
        if (gravityChangeCheck)
        {
            switch (myGravity.currentDir)
            {
                case GravitySwap.Direction.Left:
                    //The variables are swapped for the Horizontal movement
                    rb.velocity = new Vector2(rb.velocity.x, -(moveX * movementSpeed) + finalVelocity.y);
                    currentControlMove = -rb.velocity.y;
                    //Keep the initial Velocity 
                    break;
                case GravitySwap.Direction.Right:
                    //Same Horizontal Controls for now (Flip if we flip camera)
                    rb.velocity = new Vector2(rb.velocity.x, (moveX * movementSpeed) + finalVelocity.y);
                    currentControlMove = rb.velocity.y;
                    break;
                case GravitySwap.Direction.Up:
                    //Same Controls for now (Flip if we flip camera)
                    rb.velocity = new Vector2(-(moveX * movementSpeed) + finalVelocity.x, rb.velocity.y);
                    currentControlMove = -rb.velocity.x;
                    break;
                case GravitySwap.Direction.Down:
                    //Normal Directional Movement
                    rb.velocity = new Vector2((moveX * movementSpeed) + finalVelocity.x, rb.velocity.y);
                    currentControlMove = rb.velocity.x;
                    break;
            }

        }
        else
        {
            //We need to decide how to add the movement to the player
            switch (myGravity.currentDir)
            {
                case GravitySwap.Direction.Left:
                    //The variables are swapped for the Horizontal movement
                    rb.velocity = new Vector2(rb.velocity.x, -(moveX * movementSpeed));
                    currentControlMove = -rb.velocity.y;
                    //Keep the initial Velocity 
                    break;
                case GravitySwap.Direction.Right:
                    //Same Horizontal Controls for now (Flip if we flip camera)
                    rb.velocity = new Vector2(rb.velocity.x, (moveX * movementSpeed));
                    currentControlMove = rb.velocity.y;
                    break;
                case GravitySwap.Direction.Up:
                    //Same Controls for now (Flip if we flip camera)
                    rb.velocity = new Vector2(-(moveX * movementSpeed), rb.velocity.y);
                    currentControlMove = -rb.velocity.x;
                    break;
                case GravitySwap.Direction.Down:
                    //Normal Directional Movement
                    rb.velocity = new Vector2((moveX * movementSpeed), rb.velocity.y);
                    currentControlMove = rb.velocity.x;
                    break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        VelocityUpdate();
        PlayerControls();

        //Update animator speed
        if (isGrounded) //If we are grounded, then we can walk
        {
            playerAnimator.SetFloat("Speed", Mathf.Abs(moveX));
        }
        else
        {

        }

        //Flip character depending on sideways velocity
        playerSpriteHolder.FlipSprite(currentControlMove);

    }
}
