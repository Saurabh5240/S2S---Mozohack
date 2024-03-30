using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public float xOffset = 9f;
    public float yOffset = -3.2f;
    public float zOffset = -15;

    

    private bool gamePop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, zOffset);
    }


}
