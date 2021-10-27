using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    public enum Direction { Down, Left, Up, Right}
    public Direction currentDir = Direction.Down;
    //Numeric tracker to help us control gravity
    int tracker;


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
        tracker = 0;
        targetRot = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initializes what our gravity should be
        GravityChanger();
    }

    private void Update()
    {
        //GravityChanger();    
    }

    //When the Left Mouse Button is clicked
    //We move 1 space forward on the list
    public void GravityFoward()
    {
        //We need to increase the tracker by one
        if (tracker != 3) //If were not at the last value, keep increasing
        {
            tracker++;
        }
        else //Loop back to the start
        {
            tracker = 0;
        }

        TrackerToGravity();
        GravityChanger();
        
    }

    //When the Right Mouse Button is clicked
    //We move 1 space back on the list
    public void GravityBackward()
    {
        //We need to increase the tracker by one
        if (tracker != 0) //If were not at the last value, keep increasing
        {
            tracker--;
        }
        else //Loop back to the start
        {
            tracker = 3;
        }

        TrackerToGravity();
        GravityChanger();
    }

    void TrackerToGravity()
    {
        //0 = Down
        //1 = Left
        //2 = Up
        //3 = Right
        switch(tracker)
        {
            case 0:
                currentDir = Direction.Down;
                break;
            case 1:
                currentDir = Direction.Left;
                break;
            case 2:
                currentDir = Direction.Up;
                break;
            case 3:
                currentDir = Direction.Right;
                break;
        }


    }
    


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(rb.mass * dirGravity, ForceMode2D.Force);
        if (transform.rotation != Quaternion.Euler(new Vector3(0, 0, targetRot)))
        {
            ObjectRotate();
        }
    }

    public void GravityChanger()
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
        //Flip the charcter to face the direction of gravity
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetRot));
    }

}
