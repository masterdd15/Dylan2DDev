using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeggleResetZone : MonoBehaviour
{

    public PeggleBall pb;
    public BallShoot pbs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == pb.gameObject)
        {
            pbs.ResetBall();
        }
    }
}
