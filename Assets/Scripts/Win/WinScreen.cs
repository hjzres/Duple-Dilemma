using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [Header("Stars")]
    public GameObject[] unfilledStars;
    public GameObject[] filledStars;
    [Header("Text")]
    public Text text;
    [Header("Animator")]
    public Animator animator;
    [Header("GameObjects")]
    public GameObject gameManager;


    private void Start()
    {
        animator = GetComponent<Animator>();

        foreach(GameObject star in filledStars)
        {
            star.SetActive(false);
        }
    }

    private void Update()
    {
        text.text = "You have completed " + SceneManager.GetActiveScene().name;
    }

    public IEnumerator fillingStars()
    {
        yield return new WaitForSeconds(1f);
        switch (StaticData.level)
        {
            case 1:
                for (int i = 0; i < StaticData.lvlOneStars; i++)
                {
                    filledStars[i].SetActive(true);
                    yield return new WaitForSeconds(0.6f);
                }
                break;
            case 2:
                for (int i = 0; i < StaticData.lvlTwoStars; i++)
                {
                    filledStars[i].SetActive(true);
                    yield return new WaitForSeconds(0.6f);
                }
                break;
            case 3:
                for (int i = 0; i < StaticData.lvlOneStars; i++)
                {
                    filledStars[i].SetActive(true);
                    yield return new WaitForSeconds(0.6f);
                }
                break;
        }
    }
}
