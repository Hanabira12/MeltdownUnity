﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public float velocity;
    public float jump;
    public Rigidbody2D rdb2d;
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;
    public AudioClip walking;
    public AudioClip Jump;
    private AudioSource audio;
    private bool isMoving;
    private bool isGrounded;
    public static bool dead;
    public bool hasKey = false;


    // Start is called before the first frame update
    void Start()
    {
        rdb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && dead)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Scene_0");
        }
    }

    //Player is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Edge")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
        if (collision.gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy(collision.gameObject);
            Debug.Log("Player has the key");
        }
        if (collision.gameObject.tag == "Door" && hasKey == true)
        {
            Debug.Log("Player has opened the door!");
        }
        if (collision.gameObject.tag == "Door" && hasKey == false)
        {
            Debug.Log("You need the key!");
        }
    }

    //Player is not grounded (jumping)
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Ground" && collision.gameObject.tag != "Edge" )
        {
            isGrounded = false;
            Debug.Log(" not Grounded");
        }
    }

    private void FixedUpdate()
    {
        isMoving = false;
        if ( (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded )
        {
            //audio.clip = Jump;
            //audio.Play();
            isMoving = true;
            rdb2d.velocity = new Vector2(rdb2d.velocity.x, jump);
            animator.SetFloat("Speed", jump);
        }
        if ( Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) )
        {
            //audio.clip = walking;
            //audio.Play();
            isMoving = true;
            mySpriteRenderer.flipX = false;
            animator.SetFloat("Speed", velocity);
            rdb2d.velocity = new Vector2(velocity, rdb2d.velocity.y);
        }
        if ( Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //audio.clip = walking;
            //audio.Play();
            isMoving = true;
            mySpriteRenderer.flipX = true;
            animator.SetFloat("Speed", velocity);
            rdb2d.velocity = new Vector2(-velocity, rdb2d.velocity.y);
        }
        if (isMoving == false)
        {
            animator.SetFloat("Speed", 0);
            rdb2d.velocity = new Vector2(0, rdb2d.velocity.y);
        }
    }
}
