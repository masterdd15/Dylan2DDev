using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerRaycastJump : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    float jumpStrength = 5.0f;

    [SerializeField]
    float movementSpeed = 5.0f;

    float moveX;

    bool isGrounded;
    bool canJump;

    public float raycastDistance = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void PlayerControls()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
        moveX = Input.GetAxis("Horizontal");

        CheckGrounded();

    }

    void Jump()
    {
        if(!isGrounded)
            return;
        Debug.Log("JUMPED");
        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    void CheckGrounded()
    {
        RaycastHit2D groundedRay = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance);

        if(groundedRay.collider != null && groundedRay.collider.GetComponent<JumpObject>())
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.Log(isGrounded);
    }

    private void OnDrawGizmos()
    {
        Color rColor;
        if (isGrounded)
            rColor = Color.green;
        else
            rColor = Color.red;
        Debug.DrawRay(transform.position, Vector2.down * raycastDistance, rColor);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * movementSpeed, rb.velocity.y);
        if (canJump)
        {
            canJump = false;
            Jump();
        }
    }

    private void Update()
    {
        PlayerControls();
    }


}
