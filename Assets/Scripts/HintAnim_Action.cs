using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintAnim_Action : MonoBehaviour
{

    public Animator anim;
    private bool inTrigger = false;
    public int numberOfScene;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("PressF");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("PressF");
            inTrigger = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }
    private void Update()
    {
        if(inTrigger)
        {
            if (Input.GetKey(KeyCode.F) && Key.isKeyEntered == true)
            {
                Key.isKeyEntered = false;
                SceneManager.LoadScene(numberOfScene);
            }
        }
    }
}
