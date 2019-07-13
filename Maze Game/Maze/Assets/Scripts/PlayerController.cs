using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;    
    public float speed;
    public float jumpForce;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;

    private int score;
    private int lives;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetAllText ();
    }

    void Update()
    {
       
        musicSource.clip = musicClipOne;
        musicSource.Play();

        if (score == 8)
            musicSource.clip = musicClipTwo;
            musicSource.Play();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick Ups"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetAllText ();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetAllText ();
        }
        if (score == 4) 
            transform.position = new Vector2 (22.68f, -2.44f);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground") 
        {
            if(Input.GetKey(KeyCode.UpArrow)) 
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void SetAllText()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score >= 8)
            winText.text = "You win!";
        livesText.text = "Lives: " + lives.ToString ();
        if (lives <= 0)
        {
            loseText.text = "You lose!";
            Destroy(this);
        }
    }
}
