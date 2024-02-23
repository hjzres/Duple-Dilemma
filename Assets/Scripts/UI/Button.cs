using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioSource))]
public class Button : MonoBehaviour
{
    //private AudioSource audioSource;
    private void Awake() {
        //audioSource = GetComponent<AudioSource>();
    }
    public void SceneChange(int scene)
    {
        //audioSource.Play();
        SceneManager.LoadScene(scene);
    }

    public void loadLevel(int level)
    {
        //audioSource.Play();
        switch (level)
        {
            case 1:
                SceneManager.LoadScene(StaticData.lvlOne);
                StaticData.level = 1;
                break;
            case 2:
                if(StaticData.levelsDone >= 1)
                {
                    SceneManager.LoadScene(StaticData.lvlTwo);
                    StaticData.level = 2;
                }
                break;
            case 3:
                if(StaticData.levelsDone >= 2)
                {
                    SceneManager.LoadScene(StaticData.lvlThree);    
                    StaticData.level = 3;
                }
                break;
        }
    }

    public void tryAgain()
    {
        //audioSource.Play();
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
        //audioSource.Play();
        SceneManager.LoadScene(StaticData.titleScreen);
        Time.timeScale = 1;
    }

    public void resume()
    {
        //audioSource.Play();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }


}
