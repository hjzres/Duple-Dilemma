using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Awake()
    {
        menu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
            Cursor.lockState = menu.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = menu.activeSelf;
            Time.timeScale = menu.activeSelf ? 0 : 1;
        }
    }
}
