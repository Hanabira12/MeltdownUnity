using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public float velocity;
    public float jump;
    public float timeRemaining;
    public Rigidbody2D rdb2d;
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;
    public AudioClip walking;
    public AudioClip Jump;
    public Text timeText;
    public GameObject player;
    private AudioSource audio;
    private bool isMoving;
    private bool isGrounded;
    public static bool dead;
    public bool hasKey = false;
    bool timerIsRunning = false;
    public GameObject trapDoor1;
    public GameObject trapDoor2;
    public GameObject timerCanvas;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timerCanvas = GameObject.FindGameObjectWithTag("TimerCanvas");
        rdb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.R) )
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Scene_0");
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0.01)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining <= 10.1)
                {
                    Text text = timeText.GetComponent<Text>();
                    text.color = Color.red;
                }
                else if (timeRemaining <= 30.1)
                {
                    Text text = timeText.GetComponent<Text>();
                    text.color = Color.yellow;
                }
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);
                LoadGameOverAfterTimer();
            }
        }
    }

    private void LateUpdate()
    {
        timeText.transform.position = new Vector3(timerCanvas.transform.position.x + 6, timerCanvas.transform.position.y + 4, transform.position.z);
    }

    //Player is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Trap_Door")//|| collision.gameObject.tag == "Edge")
        {
            isGrounded = true;
            //Debug.Log("Grounded");
            //Debug.Log("Jump: " + collision.gameObject.tag);
        }
        if (collision.gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy(collision.gameObject);
            Debug.Log("Player has the key");
            keyCollected();
        }
        if (collision.gameObject.tag == "Door" && hasKey == true)
        {
            Debug.Log("Player has opened the door!");

            // Hide the "door closed" sprite so the "door open" sprite displays. 
            GameObject.Find("Door 2").transform.localScale = new Vector3(0, 0, 0);
            SceneManager.LoadScene("GoodEnding");
        }
        if (collision.gameObject.tag == "Door" && hasKey == false)
        {
            Debug.Log("You need the key!");
        }

        //Destroy trap doors when grabbing the key.
        if (collision.gameObject.tag == "Key")
        {
            trapDoor1 = GameObject.FindGameObjectWithTag("Trap_Door");
            trapDoor2 = GameObject.FindGameObjectWithTag("Trap_Door2");
            Destroy(trapDoor1);
            Destroy(trapDoor2);

            //Debug.Log("Trap activated");
        }
    }

    // Player has collected the key
    private void keyCollected()
    {
        // Make the X over the exit door disappear
        GameObject.Find("NoKey").transform.localScale = new Vector3(0, 0, 0);

        // Change all the arrows to guide the player the right way
        GameObject.Find("Arrow1").transform.Rotate(0f, -180f, 0f);
        GameObject.Find("Arrow2").transform.Rotate(0f, -180f, 0f);
        GameObject.Find("Arrow4").transform.Rotate(0f, 0f, -45f);
    }

    //Player is not grounded (jumping)
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Trap_Door") //&& collision.gameObject.tag != "Edge" )
        {
            isGrounded = false;
            //Debug.Log(" not Grounded");
            //Debug.Log(collision.gameObject.tag + " exit");
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

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    void LoadGameOverAfterTimer()
    {
        SceneManager.LoadScene("BadEnding");
    }
}
