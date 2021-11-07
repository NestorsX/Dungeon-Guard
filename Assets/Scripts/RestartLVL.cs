using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLVL : MonoBehaviour
{
    void FixedUpdate()
    {
        if(Death.isDeathScreenVisible)
            if(Input.anyKeyDown)
            {
                Death.isDeathScreenVisible = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
    }
}
