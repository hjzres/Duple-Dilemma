using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void SceneChange(int scene)
    {
        if(scene == StaticData.lvlOne)
        {
            StaticData.level = 1;
        } 
        if(scene == StaticData.lvlTwo)
        {
            if (StaticData.lvlOneStars >= 2)
            {
                StaticData.level = 2;
            }
            else
            {
                scene = StaticData.titleScreen;
            }
        }
        if (scene == StaticData.lvlThree)
        {
            if (StaticData.lvlTwoStars >= 2)
            {
                StaticData.level = 3;
            }
            else
            {
                scene = StaticData.titleScreen;
            }
        }

        switch (StaticData.level)
        {
            case 1:
                SceneManager.LoadScene(StaticData.lvlOne);
                break;
            case 2:
                SceneManager.LoadScene(StaticData.lvlTwo);
                break;
            case 3:
                SceneManager.LoadScene(StaticData.lvlThree);
                break;
            default:
                SceneManager.LoadScene(scene);
                break;
        }

    }

    public void tryAgain()
    {
        SceneManager.LoadScene(StaticData.level);  
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(StaticData.titleScreen);
    }

    public void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
