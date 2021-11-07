using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpForce : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.UpPlayerForce();
            Destroy(gameObject);
        }
    }
}
