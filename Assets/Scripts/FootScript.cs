using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootScript : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            PlayerController.inGround = true;
    }
}
