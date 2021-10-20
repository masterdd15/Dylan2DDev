using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    private Rigidbody2D rb;

    public float gravity = -10f;
    float velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //We are going to be creating our own gravity
        rb.gravityScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(rb.mass * new Vector2(0, -gravity), ForceMode2D.Force);
    }


    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
    }
}
