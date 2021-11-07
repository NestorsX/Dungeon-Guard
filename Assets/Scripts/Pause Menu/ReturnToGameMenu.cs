using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToGameMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject gameMenu;
    public GameObject gamecontroller;

    public void Return_To_GameMenu()
    {
        settings.SetActive(false);
        gamecontroller.SetActive(true);
        gameMenu.SetActive(true);
    }
}
