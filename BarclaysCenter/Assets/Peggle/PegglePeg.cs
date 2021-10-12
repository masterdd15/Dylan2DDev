using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegglePeg : MonoBehaviour
{
    public Color newColor = Color.white;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = newColor;
    }

    IEnumerator PegHit()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = newColor;
        yield return new WaitForSeconds(0.75f);
        //GetComponent<SpriteRenderer>().
    }
}
