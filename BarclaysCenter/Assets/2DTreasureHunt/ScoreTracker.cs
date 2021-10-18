using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{

    TextMeshProUGUI tm;
    public int score = 0;

    private void Awake()
    {
        tm = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the player is still collecting coins, update score
        //If they have 6, then they've won
        if (score < 6)
        {
            tm.text = "Score: " + score.ToString() + "/6";
        }
        else
        {
            tm.text = "YOU WIN!!!";
        }
    }
}
