using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    public GameObject playerOne;
    public GameObject playerTwo;

    [Header("Player's properties")]
    public Rigidbody playerOneRigidbody;
    public Rigidbody playerTwoRigidbody;
    public bool playerOneFrozen, playerTwoFrozen;
    public float minimumY;
    public int lives;

    [Header("Position Before Switch")]
    public Vector3 originalPlayerOne;
    public Vector3 originalPlayerTwo;

    [Header("Player Spawn")]
    public Vector3 playerOneSpawn;
    public Vector3 playerTwoSpawn;

    [Header("Game Over")]
    public bool gameOver;
    [SerializeField] int gameOverScene;
    [SerializeField] GameObject[] hearts;

    private void Awake()
    {
        playerOneSpawn = playerOne.transform.position;
        playerTwoSpawn = playerTwo.transform.position;

        playerOneRigidbody = playerOne.GetComponent<Rigidbody>();
        playerTwoRigidbody = playerTwo.GetComponent<Rigidbody>();

        playerOneFrozen = false;
        playerTwoFrozen = false;

        lives = 3;

        gameOver = false;

        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
    }

    public void OtherSide()
    {
        originalPlayerOne = playerOne.transform.position;
        originalPlayerTwo = playerTwo.transform.position;
        playerOne.transform.position = originalPlayerTwo;
        playerTwo.transform.position = originalPlayerOne;
    }

    public void Death()
    {
        playerOne.transform.position = playerOneSpawn;
        playerTwo.transform.position = playerTwoSpawn;
        Freeze(playerOne, false);
        Freeze(playerTwo, false);
        lives--;
    }

    public void Freeze(GameObject player, bool freezing)
    {
        var rb = player.GetComponent<Rigidbody>();
        if (freezing)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        } 
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void Update()
    {
        if(playerOne.transform.position.y <= minimumY || playerTwo.transform.position.y <= minimumY)
        {
            Death();
        }

        if(gameOver)
        {
            SceneManager.LoadScene(gameOverScene);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        switch (lives)
        {
            case 2:
                hearts[0].SetActive(false);
                break;
            case 1:
                hearts[1].SetActive(false);
                break;
            case 0:
                gameOver = true;
                break;
        }
    }
}
