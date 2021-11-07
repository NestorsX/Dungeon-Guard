using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEntryControl : MonoBehaviour
{
    public GameObject entryScreen;
    public static bool firstEntry = true;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            firstEntry = false;
            entryScreen.SetActive(false);
        }
    }
}
