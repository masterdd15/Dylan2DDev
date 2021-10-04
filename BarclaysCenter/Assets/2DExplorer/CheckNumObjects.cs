using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckNumObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var objs = FindObjectsOfType<GameObject>();
        Debug.Log($"game objects: {objs.Length}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
