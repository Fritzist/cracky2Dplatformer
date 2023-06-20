using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyEndless : MonoBehaviour
{

    public float speed = 5;
    public float right;
    public float left;
    private Vector3 rotation;
    public int health = 50;
    public GameObject deathEffect;
    public SpriteRenderer sprite;
    public float end;
    
    private EnemyCounterEndless enemyCounterEndless;

    // Start is called before the first frame update
    void Start()
    {
        right = transform.position.x + 3;
        left = transform.position.x - 2; 
        rotation = transform.eulerAngles;
        sprite = GetComponent<SpriteRenderer>();
        
        speed += Random.Range(-5, 15);
        
        enemyCounterEndless = FindObjectOfType<EnemyCounterEndless>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        //flash the enemy when it is hit
        if (health <= 25)
        {
            sprite.color = Color.red;
        }
        else
        {
            sprite.color = Color.white;
        }
        
        if (transform.position.x < end)
        {
            Destroy(gameObject);
            enemyCounterEndless.EnemyDead();
        }

        //make t
        
    }
}