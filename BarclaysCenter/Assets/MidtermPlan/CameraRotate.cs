using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject player;
    GravitySwap playersGrav;

    public float spinSpeed = .3f;


    private void Awake()
    {
        playersGrav = player.GetComponent<GravitySwap>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpinCam();
    }

    void SpinCam()
    {
        //Flip the camera to face the direction of gravity
        transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.Euler(0,0, playersGrav.targetRot),  Time.time * 0.009f);
    }
}
