using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleClickCircle : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public Color colorOne = Color.red;
    public Color colorTwo = Color.green;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(int n)
    {
        if (n == 0)
        {
            spriteRenderer.color = colorOne;
        }
        else if(n == 1)
        {
            spriteRenderer.color = colorTwo;
        }

    }
}
