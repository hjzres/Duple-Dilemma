using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundEffects : MonoBehaviour
{
    private AudioSource src;
    public bool isPushed;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPushed)
        {
            src.Play();
        }
        else
        {
            src.Stop();
        }
    }
}
