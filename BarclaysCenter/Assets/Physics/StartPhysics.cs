using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhysics : MonoBehaviour
{

    public GameObject mainBall;
    private Rigidbody2D mainRigid;


    private void Awake()
    {
        mainRigid = mainBall.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            mainRigid.WakeUp();
            Destroy(gameObject);
        }
    }
}
