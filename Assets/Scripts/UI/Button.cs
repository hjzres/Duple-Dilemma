using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
        if(scene == StaticData.lvlOne)
        {
            StaticData.level = 1;
        }
        if(scene == StaticData.lvlTwo)
        {
            StaticData.level = 2;
        }
        if (scene == StaticData.lvlThree)
        {
            StaticData.level = 3;
        }
    }
}
