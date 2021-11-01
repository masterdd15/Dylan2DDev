using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    AudioSource keySound;

    private void Awake()
    {
        keySound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Has collided");
        if (collision.tag == "Player")
        {
            Debug.Log("Collect Key");
            collision.GetComponent<TreasureMove>().hasKey = true;
            transform.SetParent(collision.transform, true);
            GetComponent<Collider2D>().enabled = false;
            keySound.Play();
        }
    }
}
