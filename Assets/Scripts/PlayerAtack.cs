using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private float timeBtwAtack;
    public float startTimeBtwAtack;
    
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public static float damage = 40f;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(timeBtwAtack <=0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().EnemyTakeDamage(damage);
                }
                timeBtwAtack = startTimeBtwAtack;
            }
        }
        else
        {
            timeBtwAtack -=Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
