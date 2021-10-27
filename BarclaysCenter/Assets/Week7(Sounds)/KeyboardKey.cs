using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class KeyboardKey : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    public KeyCode keyboardButton;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayKey()
    {
        audioSource.PlayOneShot(audioClip);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        audioSource.pitch = Input.GetKey(KeyCode.LeftShift) ? audioSource.pitch = 2.0f : audioSource.pitch = 1.0f; 

        if (Input.GetKeyDown(keyboardButton))
        {
            PlayKey();
        }
    }
}
