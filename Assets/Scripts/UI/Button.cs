using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void loadLevel(int level)
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene(StaticData.lvlOne);
                break;
            case 2:
                if(StaticData.levelsDone >= 1)
                {
                    SceneManager.LoadScene(StaticData.lvlTwo);
                }
                break;
            case 3:
                if(StaticData.levelsDone >= 2)
                {
                    SceneManager.LoadScene(StaticData.lvlThree);
                }
                break;
        }
    }

    public void tryAgain()
    {
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
        }
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(StaticData.titleScreen);
        Time.timeScale = 1;
    }

    public void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
