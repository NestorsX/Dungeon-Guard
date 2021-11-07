using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f; 
    
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBarScript healthBar;

    bool isFacingRight = true;
    Rigidbody2D rigidbody2D;

    public static bool inGround;
    public bool PlayerIsDead = false;
    bool isBlockingDamage;

    Animator anim;
    public Death dh;
    public GameObject FootCollider;
    public AudioSource healingSound;

    public static int DeathCounter=0;

    float ForceBuffTime = 11f;
    bool isForceBuffed = false;
    public Text ForceTimer;
    public GameObject ForceParticles;
    public GameObject counter;

	private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        if (isBlockingDamage)
        {
            currentHealth -= damage*0.2f;
        }
        else
        {
            currentHealth -= damage;
        }
        healthBar.SetHealth(currentHealth);
        if (currentHealth<=0f)
        {
            maxSpeed = 0f;
            DeathCounter +=1;
            counter.SetActive(false);
            ForceParticles.SetActive(false);
            isForceBuffed = false;
            ForceBuffTime = 11f;
            PlayerAtack.damage = 40f;
            dh.PlayerDeath();
        }
    }
    public void HealPlayer(float hp)
    {
        healingSound.volume = 0.5f;
        healingSound.Play();
        if(currentHealth+hp >= maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += hp;
        healthBar.SetHealth(currentHealth);
    }
    public void UpPlayerForce()
    {
        healingSound.volume = 0.5f;
        healingSound.Play();
        isForceBuffed = true;
        PlayerAtack.damage = 120f;
        counter.SetActive(true);
        ForceParticles.SetActive(true);
    }
	private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if(move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }
    private void Update()
	{
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && inGround==true)
        {
            anim.SetTrigger("jump");
            rigidbody2D.velocity=Vector2.up*17;
            inGround=false;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("block", true);
            isBlockingDamage = true;
        }
        else
        {
            anim.SetBool("block", false);
            isBlockingDamage = false;
        }

        if(isForceBuffed)
        {
            ForceBuffTime -= Time.deltaTime;
            ForceTimer.text = "" + (int)ForceBuffTime;
            if(ForceBuffTime<0)
            {
                counter.SetActive(false);
                ForceParticles.SetActive(false);
                isForceBuffed = false;
                ForceBuffTime = 11f;
                PlayerAtack.damage = 40f;
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    
}