using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5;
    public float left;
    public float right;
    private Vector3 rotation;
    public int health = 50;
    public GameObject deathEffect;
    public SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {

        rotation = transform.eulerAngles;
        sprite = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < left)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (transform.position.x > right)
        {
            transform.eulerAngles = rotation;
        }
        

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
    }
}
