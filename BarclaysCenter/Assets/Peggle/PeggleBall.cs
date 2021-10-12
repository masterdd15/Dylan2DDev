using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeggleBall : MonoBehaviour
{

    Rigidbody2D rb;
    public float force = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

    }

    void MouseControls()
    {
        if(Input.GetMouseButton(0))
        {
            rb.simulated = true;
            transform.parent = null;
            rb.AddForce(transform.right * force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseControls();
    }
}
