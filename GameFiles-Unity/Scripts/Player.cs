using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float horizontalInput;
    private Animator playerAnim;
    private bool running = false;
    private Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 50f;
    private bool onGround = false;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    //Money of player
    public float money = 500;
    //Player death
    public bool death;
    // Button Event
    



    //Decision POints
    private GameManager gameManager;
    public bool gameStop;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        gameStop = gameManager.gamePause;
        if (!gameStop)
        {
            Movement();
            
        }

        
       
       

    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerAudio.PlayOneShot(jumpSound , 1f);
            if (transform.rotation.eulerAngles.y < 100)
            {
                playerRb.AddForce((new Vector2(0.05f, 2)) * jumpForce);

            }
            if (transform.rotation.eulerAngles.y > 100)
            {
                playerRb.AddForce((new Vector2(-0.05f, 2))* jumpForce);

            }
            
            onGround = false;

            

        }

        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput >= 0.2 )
        {
            running = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
            playerAnim.SetFloat("Speed", 0.4f);

        }
        if (horizontalInput <= -0.2 )
        {
            running = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector2.right * -horizontalInput * speed * Time.deltaTime);
            playerAnim.SetFloat("Speed", 0.4f);

        }

        if ((horizontalInput < 0.2 && horizontalInput > -0.2))
        {

            playerAnim.SetFloat("Speed", 0f);

        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            
            onGround = true;
            

        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            money += 50;
            Destroy(collision.gameObject);
            
        
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            death = true;
            Debug.Log("Randii");
            playerAnim.SetBool("WallSliding", true);
            
        
        }

    }

    
}
