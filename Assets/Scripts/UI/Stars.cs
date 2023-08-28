using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] private GameObject[] filled;
    [SerializeField] private GameObject[] unfilled;

    private void Awake()
    {
        foreach(GameObject fill in filled)
        {
            fill.SetActive(false);
        }
    }
}
