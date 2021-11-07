using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool isKeyEntered = false;
    public GameObject KeyCanvas;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            isKeyEntered = true;
            KeyCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
