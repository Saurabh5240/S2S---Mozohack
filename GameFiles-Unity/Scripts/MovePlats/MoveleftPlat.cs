using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveleftPlat : MonoBehaviour
{

    public float speed = 6f;
    private Vector2 startPos;
    private bool goLeft = true;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bool pause = player.GetComponent<Player>().gameStop;
        if (!pause)
        {
            if (goLeft)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);

            }

            if (!goLeft)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            }
            if (transform.position.x < startPos.x - 17)
            {
                goLeft = false;

            }
            if (transform.position.x > startPos.x)
            {
                goLeft = true;

            }

        }

        
    }
}
