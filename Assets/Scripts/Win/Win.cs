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
    public bool win1Already, win2Already;

    [Header("Other")]
    public bool win;
    private float timer;

    [Header("Win Screen")]
    public GameObject winScreen;
    private WinScreen ws;
    private Animator animator;
    private GameManager gameManager;


    private void Awake()
    {
        win1 = winPlatformOne.GetComponent<WinPlatform>();
        win2 = winPlatformTwo.GetComponent<WinPlatform>();

        animator = winScreen.GetComponent<Animator>();
        ws = winScreen.GetComponent<WinScreen>();
        gameManager = GetComponent<GameManager>();

        win1Already = false;
        win2Already = false;

        winScreen.SetActive(false);
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

        if (win1Already && realWin1 != null && other1 != null && GameObject.Find(win1.whichPlayer) != null)
        {
            gameManager.Freeze(GameObject.Find(win1.whichPlayer), true);

            realWin1.rect = Rect.zero;
            other1.rect = new Rect(0, 0, 1, 1);

            split.SetActive(false);
        }

        if (win2Already && realWin2 != null && other2 != null && GameObject.Find(win2.whichPlayer) != null)
        {
            gameManager.Freeze(GameObject.Find(win2.whichPlayer), true);

            realWin2.rect = Rect.zero;
            other2.rect = new Rect(0, 0, 1, 1);

            split.SetActive(false);
        }


        if (win1Already && win2Already)
        {
            timer += Time.deltaTime;

            if (animator) {
                winScreen.SetActive(true);
                animator.Play("WinScreenAnimation");
                StartCoroutine(ws.fillingStars());
            }

            if (timer >= 5)
            {
                win = true;
            }
        }

        if (win)
        {
            SceneManager.LoadScene(2);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
