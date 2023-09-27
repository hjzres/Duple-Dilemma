using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject[] unfilledStars;
    public GameObject[] filledStars;

    public Text text;


    private void Start()
    {
        foreach(GameObject star in filledStars)
        {
            star.SetActive(false);
        }
    }

    private void Update()
    {
        switch (StaticData.level)
        {
            case 1:
                for (int i = 0; i < StaticData.lvlOneStars;i++)
                {
                    filledStars[i].SetActive(true);
                } 
                break;
            case 2:
                for (int i = 0; i < StaticData.lvlTwoStars; i++)
                {
                    filledStars[i].SetActive(true);
                }
                break;
            case 3:
                for (int i = 0; i < StaticData.lvlOneStars; i++)
                {
                    filledStars[i].SetActive(true);
                }
                break;
        }

        text.text = "You have completed " + SceneManager.GetActiveScene().name;
    }
}
