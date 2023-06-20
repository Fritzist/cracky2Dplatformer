using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel3 : MonoBehaviour
{
    
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpHeight = 10;
    private bool touchGround = false;
    private Animator anim;
    private Vector3 rotation;

    private CoinManager coinmanage;
    public GameObject panel;

    public GameObject deathEffect;

    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        coinmanage = FindObjectOfType<CoinManager>();

    }

    // Update is called once per frame
    void Update()
    {

        float direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }


        if (direction > 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

        }
        else if (direction < 0)
        {
            transform.eulerAngles = new Vector3(rotation.x, rotation.y + 180, rotation.z);
            transform.Translate(Vector2.right * speed * Time.deltaTime * -direction);

        }

        if (touchGround == false)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            touchGround = false;
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        //camera.transform.position = new Vector3(transform.position.x, 0, -10);
        camera.transform.position = new Vector3(transform.position.x, transform.position.y + 1, -10);

        // restart the game with strg + r
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // exit the game with strg + q
        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKey(KeyCode.LeftControl))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            touchGround = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            panel.SetActive(true);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Die");
        }

        if (collision.gameObject.tag == "Flag")
        {
            FindObjectOfType<AudioManager>().Play("LevelFinish");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinmanage.AddCoin();
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }

        if (other.gameObject.tag == "Spike")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            panel.SetActive(true);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Die");

        }

        if (other.gameObject.tag == "Flag")
        {
            FindObjectOfType<AudioManager>().Play("LevelFinish");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
} 
