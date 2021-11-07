using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject gameobj_settings;

    public void Return_to_mainmenu()
    {
        gameobj_settings.SetActive(false);
    }
}
