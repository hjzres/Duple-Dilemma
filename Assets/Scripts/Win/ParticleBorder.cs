using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParticleBorder : MonoBehaviour
{
    public ParticleSystem particles;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            particles.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            particles.Stop();
        }
    }
}
