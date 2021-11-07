using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int positionOfPatrol;
    public Transform point;

    bool movingRight;

    Transform player;
    public Rigidbody2D rbEnemy;
    public float stoppingDistance;

    bool idle = false;
    bool angry = false;
    bool goback = false;

    private Animator anim;

    public float health = 100f;
    
    Material matBlink;
    Material matDefault;
    SpriteRenderer spriteRend;
    UnityEngine.Object explosion;

    public AudioSource takinDamageSound;

    public static int KillCount = 0;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        explosion = Resources.Load("Explosion");
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            idle = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            idle = false;
            goback = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goback = true;
            angry = false;
        }

        if (idle == true)
        {
            Idle();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goback == true)
        {
            GoBack();
        }
    }

    void Idle()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, 1.5f * speed * Time.deltaTime);
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
    public void EnemyTakeDamage(float damage)
    {
        Invoke("SetMat", 0.3f);
        if(health-damage>0)
        {
            health-=damage;
            Invoke("ResetMaterial", 0.4f);
        }
        else
        {
            Invoke("KillEnemy", 0.2f);
        }
    }
    void ResetMaterial()
    {
        spriteRend.material = matDefault;    
    }
    void SetMat()
    {
        takinDamageSound.volume = 0.08f;
        takinDamageSound.pitch = Random.Range(0.9f, 1.1f);
        takinDamageSound.Play();
        spriteRend.material = matBlink;
    }
    void KillEnemy()
    {
        KillCount+=1;
        takinDamageSound.volume = 0.08f;
        takinDamageSound.pitch = Random.Range(0.9f, 1.1f);
        takinDamageSound.Play();
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(gameObject, 0.1f);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            anim.SetTrigger("Attack");
            player.TakeDamage(10f);
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.TakeDamage(0.5f);
        }
    }
}