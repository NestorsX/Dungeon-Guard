using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    float upLimit;
    [SerializeField]
    float downLimit;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 1.5f + Mathf.Clamp(player.transform.position.y, upLimit, downLimit), -10f);
    }
}