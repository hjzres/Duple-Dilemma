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
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            t = (int)time;
            timer.text = t.ToString();
        }
        else
        {
            gameManager.gameOver = true;
        }
    }
}
