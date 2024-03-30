using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 1.5f;
    private GameManager gameManager;
    private bool gameStop;
   
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameStop = gameManager.gamePause;
        Debug.Log(gameStop);
        if (!gameStop)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
        
    }

    
}
