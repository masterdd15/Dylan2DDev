using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public Rigidbody2D ball;
    Vector2 ballStartPosition;


    // Start is called before the first frame update
    void Start()
    {
        ballStartPosition = ball.transform.localPosition;
    }

    //This will reset the ball back to it's original position

    public void ResetBall()
    {
        ball.velocity = Vector2.zero;
        ball.angularVelocity = 0;


        ball.transform.SetParent(transform, true);
        ball.transform.localPosition = ballStartPosition;
        ball.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
