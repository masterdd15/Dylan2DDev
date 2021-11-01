using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipSprite(float moveSpeed)
    {
        Vector3 charecterScale = transform.localScale;
        if (moveSpeed < 0)
        {
            charecterScale.x = -1.6f;
        }
        if (moveSpeed > 0)
        {
            charecterScale.x = 1.6f;
        }
        transform.localScale = charecterScale;
    }
}
