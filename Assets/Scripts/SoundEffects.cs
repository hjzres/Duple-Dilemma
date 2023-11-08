using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundEffects : MonoBehaviour
{
    private AudioSource src;
    public bool play = false;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (play)
        {
            src.Play();
            play = false;
        }
    }

    public void putSoundEffect()
    {
        if (!play)
        {
            play = true;
        }
    }
}
