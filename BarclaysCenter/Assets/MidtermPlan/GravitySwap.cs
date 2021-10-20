using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    public enum Direction { None, Right, Left, Up, Down }
    public Direction currentDir = Direction.None;

    private Rigidbody2D rb;

    public float gravity = -10f;
    public Vector2 dirGravity;
    float velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //We are going to be creating our own gravity
        rb.gravityScale = 0;
        currentDir = Direction.Down;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        gravityChanger();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(rb.mass * dirGravity, ForceMode2D.Force);
    }

    void gravityChanger()
    {
        switch(currentDir)
        {
            case Direction.Right:
                dirGravity = new Vector2(-gravity, 0);
                break;
            case Direction.Left:
                dirGravity = new Vector2(gravity, 0);
                break;
            case Direction.Up:
                dirGravity = new Vector2(0, -gravity);
                break;
            case Direction.Down:
                dirGravity = new Vector2(0, gravity);
                break;
         
        }
    }

}
