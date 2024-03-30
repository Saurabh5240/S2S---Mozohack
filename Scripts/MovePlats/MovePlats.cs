using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlats : MonoBehaviour
{
    public float speed = 6f;
    private Vector2 startPos;
    private bool goRight = true;

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
            if (goRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            }

            if (!goRight)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);

            }
            if (transform.position.x < startPos.x)
            {
                goRight = true;

            }
            if (transform.position.x > startPos.x + 18)
            {
                goRight = false;

            }

        }

       
    }
}
