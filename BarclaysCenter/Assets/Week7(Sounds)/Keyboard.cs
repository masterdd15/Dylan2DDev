using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public AudioSource drumLoop;

    public List<KeyboardKey> keyboardKeys = new List<KeyboardKey>();

    void DrumInput()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            drumLoop.Stop();
        }
        if(Input.GetKeyDown(KeyCode.C) && !drumLoop.isPlaying)
        {
            drumLoop.Play();
        }
    }

    private void Update()
    {
        DrumInput();
    }
}
