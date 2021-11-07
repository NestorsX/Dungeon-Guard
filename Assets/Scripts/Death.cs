using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject DeathScreenObj;
    public GameObject DeadedPlayer;

    public static bool isDeathScreenVisible = false; 

    public void PlayerDeath()
    {
        DeadedPlayer.SetActive(true);
        DeadedPlayer.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.SetActive(false);
        Invoke("DeathScreen", 0.8f);
    }
    void DeathScreen()
    {
        isDeathScreenVisible = true;
        DeathScreenObj.SetActive(true);
    }
}