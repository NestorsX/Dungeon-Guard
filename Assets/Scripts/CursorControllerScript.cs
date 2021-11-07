using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorControllerScript : MonoBehaviour
{
    void Start()
    {
        UnityEngine.Cursor.visible = false;
    }
    
    void Update()
    {
        if(PauseMenu.GameIsPaused == true)
        {
            UnityEngine.Cursor.visible = true;
        }
        else
        {
            UnityEngine.Cursor.visible = false;
        }
    }
}
