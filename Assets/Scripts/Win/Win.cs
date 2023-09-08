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

    private int amount;
    [Header("Other")]
    public bool win;
    [SerializeField] private GameObject winDisplay;


    private void Awake()
    {
        win1 = winPlatformOne.GetComponent<WinPlatform>();
        win2 = winPlatformTwo.GetComponent<WinPlatform>();
        amount = 0;
    }

    private void Update()
    {
        if(win1.whichPlayer == "Player 1")
        {
            realWin1 = playerOneCam;
            other1 = playerTwoCam;
        }
        else if(win1.whichPlayer == "Player 2")
        {
            realWin1 = playerTwoCam;
            other1 = playerOneCam;
        }
        else
        {
            realWin1 = null;
            other1 = null;
        }

        if(win2.whichPlayer == "Player 1")
        {
            realWin2 = playerOneCam;
            other2 = playerTwoCam;
        } 
        else if(win1.whichPlayer == "Player 2")
        {
            realWin2 = playerTwoCam;
            other2 = playerOneCam;
        }
        else
        {
            realWin2 = null;
            other2 = null;
        }

        if (win1.win && amount <= 1)
        {
            GameObject.Find(win1.whichPlayer).SetActive(false);
            other1.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            amount++;
        }
        else if (win2.win && amount <= 1)
        {
            GameObject.Find(win2.whichPlayer).SetActive(false);
            other2.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            amount++;
        }
        if(amount == 2)
        {
            win = true;
            winDisplay.SetActive(true);
            Invoke("ChangeScene", 3);
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
