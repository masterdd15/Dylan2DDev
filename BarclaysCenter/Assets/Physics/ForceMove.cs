using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMove : MonoBehaviour
{

    public Rigidbody2D rb;
    bool moveLeft = false;

    void MoveControls()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveControls();
    }

    private void FixedUpdate()
    {
        if (moveLeft)
        {
            rb.AddForce(Vector2.left);
        }
    }
}
