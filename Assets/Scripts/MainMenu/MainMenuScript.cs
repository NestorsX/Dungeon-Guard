using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject gameobj_settings;
    public GameObject gameobj_about;
    int sceneID;

    int killsCount;
    int deathCount;
    public Text statickill;
    public Text staticdeath;

    int prefkillsCount;
    int prefdeathCount;

    public GameObject cup;
    public GameObject lid;

    public GameObject entryScreen;

    public static bool NewGame;
    void Start()
    {      
        statickill.text = PlayerPrefs.GetInt("statickills").ToString();
        staticdeath.text = PlayerPrefs.GetInt("staticdeath").ToString();

        killsCount = PlayerPrefs.GetInt("currentKills");
        deathCount = PlayerPrefs.GetInt("currentDeath");

        UnityEngine.Cursor.visible = true;

        int.TryParse(statickill.text, out prefkillsCount);
        int.TryParse(staticdeath.text, out prefdeathCount);

        if(FirstEntryControl.firstEntry == false)
            entryScreen.SetActive(false);
            
        if(EndGame.endOfGame)
        {
            if((prefkillsCount < killsCount && prefdeathCount >= deathCount) || (prefkillsCount <= killsCount && prefdeathCount > deathCount) || (prefkillsCount < killsCount && prefdeathCount <= deathCount) || (prefkillsCount == killsCount && prefdeathCount <= deathCount))
            {
                statickill.text = killsCount.ToString();
                staticdeath.text = deathCount.ToString();
                PlayerPrefs.SetInt("statickills", killsCount);
                PlayerPrefs.SetInt("staticdeath", deathCount);

            }
            EndGame.endOfGame = false;
        }
    }
    public void Play()
    {
        UnityEngine.Cursor.visible = false;
        NewGame = true;
        SceneManager.LoadScene(5);
    }
    public void Continue()
    {
        int sceneID = PlayerPrefs.GetInt("currentLVL");
        print(sceneID);
        if(sceneID != 0)
        {
            UnityEngine.Cursor.visible = false;
            SceneManager.LoadScene(sceneID);
        }
    }
    public void Settings()
    {
        gameobj_settings.SetActive(true);
    }
    public void About()
    {
        gameobj_about.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void CupEnabled()
    {
        cup.SetActive(false);
        lid.SetActive(true);
    }
    public void CupDisabled()
    {
        cup.SetActive(true);
        lid.SetActive(false);
    }
}
