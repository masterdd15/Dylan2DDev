using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Coin : MonoBehaviour
{

    BoxCollider2D bc;
    public GameObject gameScore;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the player collects the coin, update the score
        gameScore.GetComponent<ScoreTracker>().score++;
        //And destroy self
        Destroy(gameObject);
    }
}
