using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1.0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveObject()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.left * Time.deltaTime) * speed);
            transform.localScale = new Vector2(-1f, 1f);
            animator.SetFloat("Speed", 1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
            transform.localScale = new Vector2(1f, 1f);
            animator.SetFloat("Speed", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", 0f);
        MoveObject();
    }
}
