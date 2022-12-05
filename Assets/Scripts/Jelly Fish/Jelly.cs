using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public AudioSource die;
    public AudioSource point;
    public bool isDead;

    public float velocity = 1f;
    public Rigidbody2D rb2D;

    public GameManager ManagerGame;

    public GameObject DeathScrean;

    private void Start()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")
        {
            ManagerGame.UpdateScore();
            point.Play();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            die.Play();
            isDead = true;
            Time.timeScale = 0;

            DeathScrean.SetActive(true);
        }
    }
}
