using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask enemies;
    public float attackRange;
    public int damage;    
    private Animator anim;
    

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("IsAttacking", true);
            FindObjectOfType<AudioManager>().Play("swordAttack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
            }
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    
    // flash the enemy red when hit
    public void FlashRed()
    {
        StartCoroutine(FlashRedCoroutine());
    }
    
    private IEnumerator FlashRedCoroutine()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    

}
