using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [Header("Platforms")]
    [SerializeField] private GameObject winPlatformOne;
    [SerializeField] private GameObject winPlatformTwo;
    private WinPlatform win1, win2;
    [Header("Player Cams")]
    [SerializeField] private GameObject split;
    [SerializeField] private Camera playerOneCam, playerTwoCam;
    //Player
    private Camera realWin1, realWin2;
    private Camera other1, other2;

    [SerializeField] private int amount;
    private bool win1Already, win2Already;
    [Header("Other")]
    public bool win;
    [SerializeField] private GameObject winDisplay;
    private float timer;


    private void Awake()
    {
        win1 = winPlatformOne.GetComponent<WinPlatform>();
        win2 = winPlatformTwo.GetComponent<WinPlatform>();

        amount = 0;

        win1Already = false;
        win2Already = false;
    }

    private void Update()
    { 
        if (win1.win)
        {
            win1Already = true;
        }
        if (win2.win)
        {
            win2Already = true;
        }

        switch (win1.whichPlayer)
        {
            case "Player 1":
                realWin1 = playerOneCam;
                other1 = playerTwoCam;
                break;
            case "Player 2":
                realWin1 = playerTwoCam;
                other1 = playerOneCam;
                break;
            case null:
                realWin1 = null;
                other1 = null;
                break;
        }

        switch (win2.whichPlayer)
        {
            case "Player 1":
                realWin2 = playerOneCam;
                other2 = playerTwoCam;
                break;
            case "Player 2":
                realWin2 = playerTwoCam;
                other2 = playerOneCam;
                break;
            case null:
                realWin2 = null;
                realWin2 = null;
                break;
        }


        if (win1Already)
        {   
            if(!win2Already)
            {
                GameObject.Find(win1.whichPlayer).SetActive(false);
            } 
            else
            {
                var rb1 = GameObject.Find(win1.whichPlayer).GetComponent<Rigidbody>();
                rb1.constraints = RigidbodyConstraints.FreezeAll;
            }

            other1.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            amount++;
            win1Already = false;
        }

        if (win2Already)
        {
            if (!win1Already)
            {
                GameObject.Find(win2.whichPlayer).SetActive(false);
            } 
            else
            {
                var rb2 = GameObject.Find(win2.whichPlayer).GetComponent<Rigidbody>();
                rb2.constraints = RigidbodyConstraints.FreezeAll;
            }

            other2.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            amount++;
            win2Already = false;
        }

        if(amount >= 2)
        {
            Debug.Log("test");
            timer += Time.deltaTime;

            if (timer >= 3)
            {
                win = true;
            }
        }

        if(win1Already && win2Already && win)
        { 
            
            SceneManager.LoadScene(2);
        }
    }
    public void winOutput()
    {
        
    }
}
