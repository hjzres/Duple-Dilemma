using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
        if(scene == 3)
        {
            StaticData.level = 1;
        }
        if(scene == 4)
        {
            StaticData.level = 2;
        }
        if(scene == 5)
        {
            StaticData.level = 3;
        }
    }
}
