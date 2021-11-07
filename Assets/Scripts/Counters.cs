using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counters : MonoBehaviour
{
    public Text deathCounter;
    public Text killCounter;

    int death;
    int kill;

    void Start()
    {
        Enemy.KillCount = PlayerPrefs.GetInt("currentKills");
        PlayerController.DeathCounter = PlayerPrefs.GetInt("currentDeath");
        if(MainMenuScript.NewGame)
        {
            MainMenuScript.NewGame = false;
            death = 0;
            kill = 0;
            PlayerController.DeathCounter=0;
            Enemy.KillCount=0;
            PlayerPrefs.SetInt("currentKills", kill);
            PlayerPrefs.SetInt("currentDeath", death);
        }
    }
    void Update()
    {
        death = PlayerController.DeathCounter;
        deathCounter.text = ""+death;
        kill = Enemy.KillCount;
        killCounter.text = ""+kill;
        PlayerPrefs.SetInt("currentKills", kill);
        PlayerPrefs.SetInt("currentDeath", death);
    }
}
