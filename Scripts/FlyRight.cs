using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRight : MonoBehaviour
{
    private float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
