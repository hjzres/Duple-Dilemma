using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timer;
    [SerializeField] private float time;
    private int t;
    [SerializeField] private GameObject gm;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = gm.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (t > 0)
        {
            time -= Time.deltaTime;
            t = (int)time;
            timer.text = t.ToString();
        }
        else
        {

        }
    }
}
