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


        if (win1.win)
        {
            amount++;
            GameObject.Find(win1.whichPlayer).SetActive(false);
            other1.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            win1.win = false;
        }

        if (win2.win)
        {
            amount++;
            GameObject.Find(win2.whichPlayer).SetActive(false);
            other2.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            win2.win = false;
        }

        if(amount == 2)
        {
            win = true;
            winDisplay.SetActive(true);
            yield return new WaitForSeconds(3);
            Invoke("ChangeScene", 10f);
        }
    }

    IEnumerator changer()
    {

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
