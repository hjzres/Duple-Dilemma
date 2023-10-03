using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public int stars;
    public int level;
    [SerializeField] private GameObject[] filled;
    [SerializeField] private GameObject[] unfilled;

    private void Awake()
    {
        stars = 0;

        foreach(GameObject fill in filled)
        {
            fill.SetActive(false);
        }
    }

    private void Update()
    {
        switch (level)
        {
            case 1:
                stars = StaticData.lvlOneStars;
                break;
            case 2:
                stars = StaticData.lvlTwoStars;
                break;
            case 3:
                stars = StaticData.lvlThreeStars;
                break;
            default:
                stars = 0;
                break;
        }
        

        if(stars >= 1)
        {
            filled[0].SetActive(true);
        }
        if(stars >= 2)
        {
            filled[1].SetActive(true);
        }
        if(stars >= 3)
        {
            filled[2].SetActive(true);
        }

    }
}
