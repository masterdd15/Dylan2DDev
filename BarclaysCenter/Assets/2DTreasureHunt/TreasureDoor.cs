using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Has collided");
        if (collision.gameObject.tag == "Player")
        {
            TreasureMove curPlayer = collision.gameObject.GetComponent<TreasureMove>();
            Debug.Log(curPlayer.hasKey);
            if (curPlayer.hasKey)
            {
                Destroy(gameObject);
            }
        }
    }
}
