using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [Header("Platforms")]
    [SerializeField] private GameObject winPlatformOne;
    [SerializeField] private GameObject winPlatformTwo;
    private WinPlatform WinPlat1, WinPlat2;
    private WinPlatform win1;
    private WinPlatform win2;
    [Header("Player Cams")]
    [SerializeField] private GameObject split;
    [SerializeField] private Camera playerOneCam, playerTwoCam;

    private int amount;


    private void Awake()
    {
        win1 = winPlatformOne.GetComponent<WinPlatform>();
        win2 = winPlatformTwo.GetComponent<WinPlatform>();
        amount = 0;
    }

    private void Update()
    {
        if (win1.win && amount == 0)
        {
            playerOneCam.gameObject.SetActive(false);
            playerTwoCam.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            amount++;
        }
        else if (win2.win && amount == 0)
        {
            playerTwoCam.gameObject.SetActive(false);
            playerOneCam.rect = new Rect(0, 0, 1, 1);
            split.SetActive(false);
            amount++;
        }
        if(amount == 2)
        {

        }
    }
}
