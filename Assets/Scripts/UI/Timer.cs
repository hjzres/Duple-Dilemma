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
    private Win win;
    [SerializeField] private int TimeUntilTwoStars;
    [SerializeField] private int TimeUntilOneStar;
    public int stars;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        win = GetComponent<Win>();
    }

    private void Update()
    {
        if (!Won())
        {
            time -= Time.deltaTime;
            t = (int)time;
            timer.text = t.ToString();
        }
        
        if(t < 0)
        {
            gameManager.gameOver = true;
        }

        if (Won())
        {
            Debug.Log("test");
            
            if (time >= TimeUntilTwoStars)
            {
                stars = 3;
            }
            else if (time >= TimeUntilOneStar)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }
            
            switch (StaticData.level)
            {
                case 1:
                    if(stars > StaticData.lvlOneStars)
                    {
                        StaticData.lvlOneStars = stars;
                    }
                    break;
                case 2:
                    if(stars > StaticData.lvlTwoStars)
                    {
                        StaticData.lvlTwoStars = stars;
                    }
                    break;
                case 3:
                    if(stars > StaticData.lvlThreeStars)
                    {
                        StaticData.lvlTwoStars = stars;
                    }
                    break;
            }
        }
    }

    private bool Won()
    {
        return win.win1Already && win.win2Already;
    }
}
