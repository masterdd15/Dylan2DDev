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

    public float targetRot = 0f;
    float velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //We are going to be creating our own gravity
        rb.gravityScale = 0;
        currentDir = Direction.Down;
        targetRot = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        GravityChanger();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(rb.mass * dirGravity, ForceMode2D.Force);
        ObjectRotate();
    }

    void GravityChanger()
    {
        switch(currentDir)
        {
            case Direction.Right:
                dirGravity = new Vector2(-gravity, 0);
                targetRot = 90;
                break;
            case Direction.Left:
                dirGravity = new Vector2(gravity, 0);
                targetRot = 270;
                break;
            case Direction.Up:
                dirGravity = new Vector2(0, -gravity);
                targetRot = 180;
                break;
            case Direction.Down:
                dirGravity = new Vector2(0, gravity);
                targetRot = 360;
                break;
         
        }
    }

    void ObjectRotate()
    {
        //
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, targetRot), Time.deltaTime);
    }

}
