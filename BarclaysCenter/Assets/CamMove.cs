using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    public GameObject nextCamPosition;
    public GameObject camera;
    
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
        Debug.Log("Detected collision");
        if (collision.tag == "Player") //If our main ball passes through the trigger
        {
            camera.transform.position = nextCamPosition.transform.position;
            Debug.Log("Moved Player");
        }
    }
}
